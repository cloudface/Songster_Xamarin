// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

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

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView ResultsTable { get; set; }

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
			if (ResultsTable != null) {
				ResultsTable.Dispose ();
				ResultsTable = null;
			}
		}
	}
}
