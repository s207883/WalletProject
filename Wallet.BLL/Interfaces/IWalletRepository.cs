using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wallet.Core.Enums;
using Wallet.Core.ViewModels;

namespace Wallet.BLL.Interfaces
{
	/// <summary>
	/// Интерфейс репозитория пользователя.
	/// </summary>
	public interface IWalletRepository
	{
		/// <summary>
		/// Получить кошелек по идентификатору кошелька.
		/// </summary>
		/// <param name="walletId">Идентификатор кошелька.</param>
		/// <returns>Результат операции и модель.</returns>
		Task<(WalletRepoActionResult result, UserWalletViewModel UserWalletViewModel)> GetUserWalletByWalletIdAsync(int walletId);

		/// <summary>
		/// Получить кошельки пользователя по идентификатору.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя</param>
		/// <returns>Результат операции и список моделей.</returns>
		Task<(WalletRepoActionResult result, IEnumerable<UserWalletViewModel> userWallets)> GetUserWalletByUserIdAsync(int userId);
	}
}
