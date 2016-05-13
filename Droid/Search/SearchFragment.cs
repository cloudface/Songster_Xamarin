
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android.Support.V4.App;

namespace Songster.Droid
{	
	public class SearchFragment : Fragment, SearchView, SearchAdapterListener
	{
		private SearchViewModel ViewModel { get; set; }
		private SearchPresenter Presenter { get; set; }
		private SearchAdapter Adapter { get; set; }

		public static SearchFragment Instance { 
			get {
				SearchFragment fragment = new SearchFragment ();
				Bundle args = new Bundle ();
				//TODO: Pass arguments into Bundle
				fragment.Arguments = args;
				return fragment;
			}
		}

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			ViewModel = new SearchViewModel ();
			Presenter = new SearchPresenter (this, ViewModel, new SearchDataRepository ());
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState){
			View view = inflater.Inflate (Resource.Layout.fragment_search, container, false);
			Button searchButton = view.FindViewById<Button> (Resource.Id.btnSearch);
			EditText searchField = view.FindViewById<EditText> (Resource.Id.editSearch);
			ListView resultList = view.FindViewById<ListView> (Resource.Id.resultList);

			searchButton.Click += (object sender, EventArgs e) => {
				Presenter.Search(searchField.Text);
			};
			this.Adapter = new SearchAdapter (Activity, ViewModel.SearchResults, this);
			resultList.Adapter = this.Adapter;

			resultList.farfoostus ();

			return view;
		}

		#region SearchView implementation

		public void DisplayResults ()
		{
			this.Adapter.NotifyDataSetChanged ();
		}

		#endregion

		#region SearchAdapterListener implementation

		public void OnAddPressed (SongModel song)
		{
			Presenter.AddSongToMyList (song);
		}

		#endregion
	}
}

