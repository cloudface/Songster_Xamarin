require 'fileutils'
require 'rubygems'
require 'rexml/document'

# Some utility functions
def set(key, value)
  if false == value
    value = 'FALSE'
  elsif true == value
    value = 'TRUE'
  end
  ENV[key.to_s.upcase] = value
end

def fetch(key)
  val = ENV[key.to_s.upcase]
  if 'FALSE' == val
    val = false
  elsif 'TRUE' == val
    val = true
  end
  val
end

# Resolves dependencies using nuget. Requires a the location of the packages.config file.
def resolveDependencies(packagesConfig)
	puts "Resolving dependencies using #{packagesConfig}"
  file = File.new(packagesConfig)
        doc = REXML::Document.new(file)
        doc.elements.each("packages/package") do |elm|
                package=elm.attributes["id"]
                version=elm.attributes["version"]

                packagePath="#{LIB_PATH}/#{package}"
                versionInfo="#{packagePath}/version.info"
                currentVersion=IO.read(versionInfo) if File.exists?(versionInfo)
                packageExists = File.directory?(packagePath)
                
                if(!(version or packageExists) or currentVersion!= version) then
                        feedsArg = FEEDS.map{ |x| "-Source " + x }.join (' ')
                        versionArg = "-Version #{version}" if version
                        sh "nuget install #{package} #{versionArg} -o \"#{LIB_PATH}\" #{feedsArg} -ExcludeVersion" do |ok,results|
                                File.open(versionInfo,'w'){|f| f.write(version)} if ok
                        end
                end
        end
end

if File.exists? ('rake_env')
  load 'rake_env'
else
  puts "Using environment variables."
end

# Hardcoding these paths here - adjust them as necessary. These shouldn't change much (if at all)
@mono = '/usr/bin/mono'
@mdtool = '/Applications/Xamarin\\ Studio.app/Contents/MacOS/mdtool build'
@xbuild = '/usr/bin/xbuild'
@test_cloud = "#{@mono} ./packages/Xamarin.UITest.0.5.0/tools/test-cloud.exe"
@xamarin_component = "#{@mono}  ./xamarin-component.exe"

@test_assembly_dir = "./Tasky.UITest/bin/Debug/"
@apk = './Tasky.Droid/bin/Release/com.xamarin.samples.taskydroid-Signed.apk'
@ipa = 'iOS/bin/iPhone/Release/Songster.iOS.app'
@dsym = './Tasky.iOS/bin/iPhone/Debug/TaskyiOS.app.dSYM'

# These values will come from either the file rake_env or environment variables
@testcloud_api_key = fetch(:testcloud_api_key)
@android_device_id = fetch(:android_device_id)
@ios_device_id = fetch(:ios_device_id)

# The directory where the nuget packages will get downloaded into
LIB_PATH = File.expand_path("packages")

#The nuget feeds
FEEDS = [
        #Your internal repo can go here
        "http://go.microsoft.com/fwlink/?LinkID=206669"
]

task :default => [:clean, :dependencies, :build]

desc "Cleans the project"
task :clean do
  directories_to_delete = [
      "./iOS/bin",
      "./iOS/obj",
      "./Droid/bin",
      "./Droid/obj"
  ]

  directories_to_delete.each { |x|
    rm_rf x
  }
end

task :dependencies do

	#resolveDependencies("iOS/packages.config")
	#resolveDependencies("Droid/packages.config")
	sh "nuget restore Songster.sln"
end

desc "Compiles the Android and iOS projects."
task :build => [:build_android, :build_ios] do

end

task :build_android => [:clean] do
	puts "Build Android"
  system("#{@xbuild} /verbosity:diagnostic /t:SignAndroidPackage /p:Configuration=Release Droid/Songster.Droid.csproj")
end

task :build_ios => [:clean] do
  puts "Build the IPA:"
  system("#{@mdtool} \"--configuration:Release|iPhone\" Songster.sln")

  puts "Build the iPhoneSimulator:"
  system("#{@mdtool} build \"--configuration:Debug|iPhoneSimulator\" Songster.sln")

	#Fail if the IPA was not generated
	puts "Checking for generated IPA file"
	raise "Missing the IPA #{@ipa}." unless File.exists?(@ipa)
	puts "SUCCESS: IPA file exists!"
end