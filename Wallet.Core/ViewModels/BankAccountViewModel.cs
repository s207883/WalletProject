namespace Wallet.Core.ViewModels
{
	/// <summary>
	/// Модель представления счета.
	/// </summary>
	public class BankAccountViewModel
	{
		/// <summary>
		/// Идентификатор счета.
		/// </summary>
		public int BankAccountId { get; set; }

		/// <summary>
		/// Название валюты.
		/// </summary>
		public CurrencyViewModel Currency { get; set; }

		/// <summary>
		/// Количество.
		/// </summary>
		public float Amount { get; set; }
	}
}
