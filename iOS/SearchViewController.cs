﻿// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace Songster.iOS
{
	public partial class SearchViewController : UIViewController, SearchView
	{
		private SearchViewModel ViewModel { get; set; }
		private SearchPresenter Presenter { get; set; }

		public SearchViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			ViewModel = new SearchViewModel ();
			Presenter = new SearchPresenter (this, ViewModel, new SearchDataRepository ());

			this.resultsTableView.DataSource = new SearchTableDataSource(this.ViewModel);
		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}

		partial void BtnSearch_TouchUpInside (UIButton sender)
		{
			this.Presenter.search(this.FieldSearch.Text);
		}

		#region SearchView implementation

		public void displayResults ()
		{
			this.resultsTableView.ReloadData ();
		}

		#endregion

		public class SearchTableDataSource : UITableViewDataSource {
			private SearchViewModel ViewModel { get; set; }

			public SearchTableDataSource (SearchViewModel viewModel)
			{
				ViewModel = viewModel;
			}
			
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell ("searchResultCell");
				if (cell == null) {
					cell = new UITableViewCell (UITableViewCellStyle.Default, "searchResultCell");
				}

				cell.TextLabel.Text = "Foggy";

				return cell;
			}

			public override nint RowsInSection (UITableView tableView, nint section)
			{
				return ViewModel.SearchResults.Count;	
			}
		}
	}
}