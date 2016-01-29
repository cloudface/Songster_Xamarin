// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Songster.iOS
{
	[Register ("SearchViewController")]
	partial class SearchViewController
	{
		[Outlet]
		UIKit.UIButton BtnSearch { get; set; }

		[Outlet]
		UIKit.UITextField FieldSearch { get; set; }

		[Outlet]
		UIKit.UITableView resultsTableView { get; set; }

		[Action ("BtnSearch_TouchUpInside:")]
		partial void BtnSearch_TouchUpInside (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (BtnSearch != null) {
				BtnSearch.Dispose ();
				BtnSearch = null;
			}

			if (FieldSearch != null) {
				FieldSearch.Dispose ();
				FieldSearch = null;
			}

			if (resultsTableView != null) {
				resultsTableView.Dispose ();
				resultsTableView = null;
			}
		}
	}
}
