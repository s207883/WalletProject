using System.Collections.Generic;

namespace Wallet.Core.ViewModels
{
	/// <summary>
	/// Модель представления пользователя.
	/// </summary>
	public class UserViewModel
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Имя пользователя.
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// Счета пользователя.
		/// </summary>
		public IEnumerable<BankAccountViewModel> BankAccounts { get; set; }
	}
}
