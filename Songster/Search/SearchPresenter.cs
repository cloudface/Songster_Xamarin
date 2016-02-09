using System;
using System.Collections.Generic;

namespace Songster
{
	public class SearchPresenter
	{
		private SearchView SearchView { get; set; }
		private SearchViewModel ViewModel { get; set; }
		private SearchDataRepository SearchDataRepository { get; set; }

		public SearchPresenter (SearchView searchView, SearchViewModel viewModel, SearchDataRepository searchDataRepository)
		{
			this.SearchView = searchView;
			this.SearchDataRepository = searchDataRepository;
			this.ViewModel = viewModel;
		}

		public void Search (string text)
		{
			this.SearchDataRepository.SearchForSongs(text, delegate(List<SongDto> songs){
				this.ViewModel.updateResults(songs);
				this.SearchView.DisplayResults();
			});
		}

		public void AddSongToMyList(SongModel song){
			SongDto selectedSong = ViewModel.SelectSong (song);
			this.SearchDataRepository.AddSongToMyList (selectedSong, delegate(SongDto addedSong){
				this.SearchView.DisplayResults();
			});
		}

	}
}

