namespace Wallet.Core.ViewModels
{
	/// <summary>
	/// Модель представления валюты.
	/// </summary>
	public class CurrencyViewModel
	{
		/// <summary>
		/// Идентификатор валюты.
		/// </summary>
		public int CurrencyId { get; set; }

		/// <summary>
		/// Название валюты.
		/// </summary>
		public string CurrencyName { get; set; }
	}
}
