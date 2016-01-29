using System;
using System.Collections.Generic;

namespace Songster
{
	public delegate void OnSearchSuccessful(List<SongDto> songs);

	public interface SearchRepository
	{
		void searchForSongs(String searchString, OnSearchSuccessful onSuccess);
	}
}

