using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Core.ViewModels
{
	/// <summary>
	/// Модель представления счета.
	/// </summary>
	public class BankAccountViewModel
	{
		/// <summary>
		/// Название валюты.
		/// </summary>
		public string CurrencyName { get; set; }

		/// <summary>
		/// Количество.
		/// </summary>
		public long Amount { get; set; }
	}
}
