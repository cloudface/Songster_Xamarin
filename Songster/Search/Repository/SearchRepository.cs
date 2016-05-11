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

		void PurchaseSong (SongDto song, SearchRepositoryListener listener);
	}

	public interface SearchRepositoryListener{
	
		void OnCheckoutSuccess(CheckoutDto checkoutDto, SongDto songDto);

		void OnAuthorizationSuccess(AuthorizationDto authorizationDto, SongDto songDto);

		void OnLoginSuccess(UserDto userDto, SongDto songDto);

		void OnPurchaseSuccess(SongDto song);	
	}
}

