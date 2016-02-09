using System;
using System.Collections.Generic;

namespace Songster
{
	public class SearchViewModel
	{
		public List<SongModel> SearchResults { get; private set; }

		public SearchViewModel ()
		{
			SearchResults = new List<SongModel> ();
		}

		public void updateResults (List<SongDto> songs)
		{
			SearchResults.Clear ();
			foreach(SongDto songDto in songs){
				SearchResults.Add(new SongModel(songDto));
			}
		}

		public SongDto SelectSong (SongModel song)
		{
			//TODO: Mark song as selected
			song.IsAdded = true;
			return song.Song;
		}
	}

	public class SongModel{
		public SongDto Song { get; private set; }
		public bool IsAdded { get; set; }

		public SongModel (SongDto songDto)
		{
			Song = songDto;
		}
	}
}

 