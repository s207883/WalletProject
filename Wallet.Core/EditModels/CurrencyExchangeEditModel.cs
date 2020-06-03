using System.ComponentModel.DataAnnotations;

namespace Wallet.Core.EditModels
{
	/// <summary>
	/// Модель обмена валюты.
	/// </summary>
	public class CurrencyExchangeEditModel
	{
		/// <summary>
		/// Идентификатор кошелька.
		/// </summary>
		[Range(1, int.MaxValue, ErrorMessage = "Id must be positive number.")]
		public int WalletId { get; set; }

		/// <summary>
		/// Валюта, которую меняем.
		/// </summary>
		[Range(1, int.MaxValue, ErrorMessage = "Id must be positive number.")]
		public int OriginCurrencyId { get; set; }

		/// <summary>
		/// Валюта, на которую меняем.
		/// </summary>
		[Range(1, int.MaxValue, ErrorMessage = "Id must be positive number.")]
		public int DestinationCurrencyId { get; set; }

		/// <summary>
		/// Количество.
		/// </summary>
		[Range(0.1, 100000, ErrorMessage = "Amount is out of range.")]
		public float Amount { get; set; }
	}
}
