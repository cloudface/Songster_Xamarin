using System;
using Android.Widget;
using System.Collections.Generic;
using Android.Views;
using Android.Content;

namespace Songster.Droid
{
	public class SearchAdapter : ArrayAdapter<SongModel>
	{
		private List<SongModel> Songs { get; set;}

		public SearchAdapter(Context context, List<SongModel> songs):base(context, 0) {
			this.Songs = songs;
		}

		public override int Count{
			get { return this.Songs.Count; }
		}
			
		public override View GetView(int position, View convertView, ViewGroup parent) {
			LayoutInflater inflater = (LayoutInflater) this.Context.GetSystemService (Context.LayoutInflaterService);
			var view = convertView ?? inflater.Inflate (
				Resource.Layout.item_search, parent, false);

			/*var contactName = view.FindViewById<TextView> (Resource.Id.ContactName);
			var contactImage = view.FindViewById<ImageView> (Resource.Id.ContactImage);*/

			return view;
		}
	}
}

