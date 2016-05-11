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

		public void SearchForSongs (string searchString, OnSearchSuccessful onSuccess)
		{
			List<SongDto> songs = new List<SongDto> ();
			songs.Add (new SongDto ("Foggy"));
			songs.Add (new SongDto ("Karen"));
			songs.Add (new SongDto ("Matt"));
			songs.Add (new SongDto ("Fisk"));
			songs.Add (new SongDto ("Nobu"));
			songs.Add (new SongDto ("Stick"));
			songs.Add (new SongDto ("Owlsley"));
			songs.Add (new SongDto ("Union Allied"));
			songs.Add (new SongDto ("Madam Gao"));
			onSuccess (songs);
		}
			
		public void AddSongToMyList (SongDto song, OnAddSuccessful onSuccess)
		{
			System.Diagnostics.Debug.WriteLine ("Adding song: " + song.Name);
			onSuccess (song);
		}

		public void PurchaseSong (SongDto song, SearchRepositoryListener listener)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

