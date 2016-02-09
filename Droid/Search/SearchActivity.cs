
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
using Android.Util;

namespace Songster.Droid
{
	[Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]			
	public class SearchActivity : Activity, SearchView
	{
		private const String Tag = "SearchActivity";

		private SearchViewModel ViewModel { get; set; }
		private SearchPresenter Presenter { get; set; }
		private SearchAdapter Adapter { get; set; }

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.activity_search);

			ViewModel = new SearchViewModel ();
			Presenter = new SearchPresenter (this, ViewModel, new SearchDataRepository ());

			Button searchButton = FindViewById<Button> (Resource.Id.btnSearch);
			EditText searchField = FindViewById<EditText> (Resource.Id.editSearch);
			ListView resultList = FindViewById<ListView> (Resource.Id.resultList);

			searchButton.Click += (object sender, EventArgs e) => {
				Presenter.Search(searchField.Text);
			};
			this.Adapter = new SearchAdapter (this, ViewModel.SearchResults);
			resultList.Adapter = this.Adapter;
		}

		#region SearchView implementation

		public void DisplayResults ()
		{
			this.Adapter.NotifyDataSetChanged ();
		}

		#endregion
	}
}

