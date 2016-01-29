using System;
using System.Collections.Generic;

namespace Songster
{
	public class SearchViewModel
	{
		public List<SongDto> SearchResults { get; private set; }

		public SearchViewModel ()
		{
			SearchResults = new List<SongDto> ();
		}

		public void updateResults (List<SongDto> songs)
		{
			SearchResults.Clear ();
			SearchResults.AddRange (songs);
		}
	}
}

 