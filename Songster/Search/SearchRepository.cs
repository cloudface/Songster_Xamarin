using System;
using System.Collections.Generic;

namespace Songster
{
	public delegate void OnSearchSuccessful(List<SongDto> songs);

	public delegate void OnAddSuccessful(SongDto addedSong);

	public interface SearchRepository
	{
		void SearchForSongs(String searchString, OnSearchSuccessful onSuccess);

		void AddSongToMyList(SongDto song, OnAddSuccessful onSuccess);
	}
}

