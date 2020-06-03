using System.Collections.Generic;

namespace Wallet.Core.ViewModels
{
	/// <summary>
	/// Модель представления кошелька пользователя.
	/// </summary>
	public class UserWalletViewModel
	{
		/// <summary>
		/// Идентификатор кошелька.
		/// </summary>
		public int UserWalletId { get; set; }

		/// <summary>
		/// Счета кошелька.
		/// </summary>
		public IEnumerable<BankAccountViewModel> BankAccounts { get; set; }
	}
}
