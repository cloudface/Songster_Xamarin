using System;

namespace Songster
{
	public interface UseCase
	{
		void PurchaseSong(SongDto song);
	}

	public interface UseCaseListener
	{
	}
}

