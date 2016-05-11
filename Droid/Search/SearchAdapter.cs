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
		private SearchAdapterListener Listener { get; set; }

		public SearchAdapter(Context context, List<SongModel> songs, SearchAdapterListener listener):base(context, 0) {
			this.Songs = songs;
			this.Listener = listener;
		}

		public override int Count{
			get { return this.Songs.Count; }
		}
			
		public override View GetView(int position, View convertView, ViewGroup parent) {
			LayoutInflater inflater = (LayoutInflater) this.Context.GetSystemService (Context.LayoutInflaterService);
			var view = convertView ?? inflater.Inflate (
				Resource.Layout.item_search, parent, false);

			var nameText = view.FindViewById<TextView> (Resource.Id.txtName);
			var addButton = view.FindViewById<Button> (Resource.Id.btnAddToMyList);
			var addedImage = view.FindViewById<ImageView> (Resource.Id.imgAdded);

			SongModel song = Songs [position];
			nameText.Text = song.Song.Name;
			addedImage.Visibility = ViewStates.Gone;
			if (song.IsAdded) {
				addedImage.Visibility = ViewStates.Visible;
			}

			addButton.Click += (object sender, EventArgs e) => {
				Listener.OnAddPressed(song);
			};

			return view;
		}
	}

	public interface SearchAdapterListener {
		void OnAddPressed(SongModel song);
	}
}

