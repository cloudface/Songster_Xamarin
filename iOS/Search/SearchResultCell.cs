using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace Songster.iOS
{
	public class SearchResultCell : UITableViewCell
	{
		UILabel titleLabel;
		UIButton addButton;
		UIImageView addedImage;

		private SongModel Song { get; set; }

		public SearchResultCellListener Listener { get; set; }

		public SearchResultCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			ContentView.BackgroundColor = UIColor.FromRGB (218, 255, 127);
			titleLabel = new UILabel () {
				Font = UIFont.FromName("Cochin-BoldItalic", 22f),
				TextColor = UIColor.FromRGB (127, 51, 0),
				BackgroundColor = UIColor.Clear
			};
			addButton = new UIButton ();
			addButton.SetTitle ("Add", UIControlState.Normal);
			addButton.SetTitleColor(UIColor.FromRGB(0, 0, 255), UIControlState.Normal);
			addButton.TouchUpInside += (object sender, EventArgs e) => {
				if(Listener != null){
					Listener.OnAddPressed(Song);
				}
			};
			addedImage = new UIImageView (UIImage.FromBundle ("ic_check_circle"));
			ContentView.AddSubviews(new UIView[] {titleLabel, addButton, addedImage});
		}

		public void UpdateCell (SongModel song)
		{
			Song = song;
			titleLabel.Text = Song.Song.Name;
			if (song.IsAdded) {
				addedImage.Alpha = 1;
			} else {
				addedImage.Alpha = 0;
			}
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			titleLabel.Frame = new CGRect (5, 4, ContentView.Bounds.Width - 63, 25);
			addButton.Frame = new CGRect (100, 4, 80, 25);
			addedImage.Frame = new CGRect (180, 4, 25, 25);
		}
	}

	public interface SearchResultCellListener {
		void OnAddPressed(SongModel song);
	}
}

