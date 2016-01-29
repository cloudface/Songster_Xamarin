using System;
using System.Collections.Generic;

namespace Songster
{
	public class SearchDataRepository : SearchRepository
	{
		public SearchDataRepository ()
		{
		}

		#region SearchRepository implementation

		public void searchForSongs (string searchString, OnSearchSuccessful onSuccess)
		{
			List<SongDto> songs = new List<SongDto> ();
			songs.Add (new SongDto ());
			songs.Add (new SongDto ());
			songs.Add (new SongDto ());
			songs.Add (new SongDto ());
			songs.Add (new SongDto ());
			songs.Add (new SongDto ());
			songs.Add (new SongDto ());
			songs.Add (new SongDto ());
			songs.Add (new SongDto ());
			songs.Add (new SongDto ());
			onSuccess (songs);
		}

		#endregion
	}
}

