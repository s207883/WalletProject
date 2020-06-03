using System.Collections.Generic;

namespace Wallet.DAL.Models
{
	/// <summary>
	/// Кошелек пользователя.
	/// </summary>
	public class UserWallet
	{
		/// <summary>
		/// Идентификатор кошелька.
		/// </summary>
		public int UserWalletId { get; set; }

		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public int UserId { get; set; }

		#region Навигационные свойства
		public User User { get; set; }
		public IEnumerable<BankAccount> BankAccounts { get; set; }
		#endregion
	}
}
