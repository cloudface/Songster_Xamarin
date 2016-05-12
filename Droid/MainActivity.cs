
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;

//CI Build 3
namespace Songster.Droid
{	
	[Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]			
	public class MainActivity : FragmentActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.activity_main);

			ViewPager viewPager = FindViewById<ViewPager> (Resource.Id.viewPager);
			viewPager.Adapter = new MainViewPagerAdapter (SupportFragmentManager);

			fafafa
		}
	}
}

