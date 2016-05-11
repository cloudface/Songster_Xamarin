using System;

namespace Songster
{
	public class SearchUseCase : UseCase, SearchRepositoryListener
	{
		SearchRepository repository;
		UseCaseListener listener;

		public SearchUseCase (SearchRepository repository, UseCaseListener listener)
		{
			this.repository = repository;
			this.listener = listener;
		}

		#region UseCase implementation

		public void PurchaseSong (SongDto song)
		{
			this.repository.PurchaseSong (song, this);
		}

		#endregion

		#region SearchRepositoryListener implementation

		public void OnCheckoutSuccess (CheckoutDto checkoutDto, SongDto songDto)
		{
			throw new NotImplementedException ();
		}

		public void OnAuthorizationSuccess (AuthorizationDto authorizationDto, SongDto songDto)
		{
			throw new NotImplementedException ();
		}

		public void OnLoginSuccess (UserDto userDto, SongDto songDto)
		{
			throw new NotImplementedException ();
		}

		public void OnPurchaseSuccess (SongDto song)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

