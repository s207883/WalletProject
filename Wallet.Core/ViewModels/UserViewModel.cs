using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Core.ViewModels
{
	/// <summary>
	/// Модель представления пользователя.
	/// </summary>
	public class UserViewModel
	{
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
