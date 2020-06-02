using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.DAL.Models
{
	/// <summary>
	/// Модель валюты.
	/// </summary>
	public class Currency
	{
		/// <summary>
		/// Идентификатор валюты.
		/// </summary>
		public int CurrencyId { get; set; }

		/// <summary>
		/// Название валюты.
		/// </summary>
		public string CurrencyName { get; set; }

		#region Навигационные свойства
		public IEnumerable<BankAccount> BankAccounts { get; set; }
		#endregion
	}
}
