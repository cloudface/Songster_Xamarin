using System;
using UIKit;
using Foundation;

namespace Songster.iOS
{
	public class SearchTableDataSource : UITableViewDataSource, SearchResultCellListener {
		private SearchViewModel ViewModel { get; set; }
		private SearchTableDataSourceListener Listener { get; set; }

		public SearchTableDataSource (SearchViewModel viewModel, SearchTableDataSourceListener listener)
		{
			ViewModel = viewModel;
			Listener = listener;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			NSString cellIdentifier = new NSString("searchResultCell");
			var cell = tableView.DequeueReusableCell (cellIdentifier) as SearchResultCell;
			if (cell == null) {
				cell = new SearchResultCell (cellIdentifier);
			}

			SongModel song = ViewModel.SearchResults [indexPath.Row];
			cell.Listener = this;
			cell.UpdateCell (song);

			return cell;
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return ViewModel.SearchResults.Count;	
		}

		#region SearchResultCellListener implementation

		public void OnAddPressed (SongModel song)
		{
			Listener.OnAddPressed (song);
		}


		public void OnBuyPressed (SongModel song)
		{
			Listener.OnBuyPressed (song);
		}
		#endregion
	}

	public interface SearchTableDataSourceListener {
		void OnAddPressed(SongModel song);

		void OnBuyPressed (SongModel song);
	}
}

