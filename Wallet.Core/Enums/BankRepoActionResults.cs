using System.ComponentModel;

namespace Wallet.Core.Enums
{
	/// <summary>
	/// Результат работы репозитория счетов.
	/// </summary>
	public enum BankRepoActionResults
	{
		/// <summary>
		/// Успех.
		/// </summary>
		[Description("Успех")]
		Success,

		/// <summary>
		/// Не найден счет.
		/// </summary>
		[Description("Не найден счет")]
		AccountNotFound,

		/// <summary>
		/// Не найдена валюта.
		/// </summary>
		[Description("Не найдена валюта")]
		CurrencyNotFound,

		/// <summary>
		/// Недостаточно денег.
		/// </summary>
		[Description("Недостаточно денег")]
		NotEnouthMoney,

		/// <summary>
		/// Неправильное количество.
		/// </summary>
		[Description("Неправильное количество")]
		WrongAmount,

		/// <summary>
		/// Кошелек не найден.
		/// </summary>
		[Description("Кошелек не найден")]
		WalletNotFound,

		/// <summary>
		/// Ошибка внешнего сервиса.
		/// </summary>
		[Description("Ошибка внешнего сервиса")]
		OutterServiceFailure,
	}
}
