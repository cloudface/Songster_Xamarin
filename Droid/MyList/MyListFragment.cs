
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;

namespace Songster.Droid
{
	public class MyListFragment : Fragment
	{
		public static MyListFragment Instance { 
			get {
				MyListFragment fragment = new MyListFragment ();
				Bundle args = new Bundle ();
				//TODO: Pass arguments into Bundle
				fragment.Arguments = args;
				return fragment;
			}
		}

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate (Resource.Layout.fragment_mylist, container, false);

			return view;
		}
	}
}

