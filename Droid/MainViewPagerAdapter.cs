using System;
using Android.Support.V4.App;

namespace Songster.Droid
{
	public class MainViewPagerAdapter : FragmentStatePagerAdapter
	{
		public MainViewPagerAdapter (FragmentManager fm) : base(fm)
		{
		}

		#region implemented abstract members of PagerAdapter

		public override int Count {
			get {
				return 2;
			}
		}

		#endregion

		#region implemented abstract members of FragmentStatePagerAdapter

		public override Fragment GetItem (int position)
		{
			if (position == 0) {
				return SearchFragment.Instance;
			} else {
				return MyListFragment.Instance;
			}
		}

		#endregion
	}
}

