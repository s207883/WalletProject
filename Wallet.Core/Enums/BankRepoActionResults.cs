using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Core.Enums
{
	/// <summary>
	/// Результат работы репозитория счетов.
	/// </summary>
	public enum BankRepoActionResults
	{
		/// <summary>
		/// Успех
		/// </summary>
		Success,

		/// <summary>
		/// Не найден счет.
		/// </summary>
		AccountNotFound,

		/// <summary>
		/// Не найдена валюта.
		/// </summary>
		CurrencyNotFound,

		/// <summary>
		/// Недостаточно денег.
		/// </summary>
		NotEnouthMoney,
		
		/// <summary>
		/// Неправильное количество.
		/// </summary>
		WrongAmount,

		/// <summary>
		/// Кошелек не найден.
		/// </summary>
		WalletNotFound,

		/// <summary>
		/// Ошибка внешнего сервиса.
		/// </summary>
		OutterServiceFailure,
	}
}
