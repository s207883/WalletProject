using System;
using System.ComponentModel.DataAnnotations;

namespace Wallet.Core.EditModels
{
	/// <summary>
	/// Модель конвертации валюты.
	/// </summary>
	public sealed class CurrencyConvertEditModel
	{
		/// <summary>
		/// Из какой валюты перевести.
		/// </summary>
		[Required(ErrorMessage = "Empty origin currency")]
		[StringLength(3)]
		public string OriginCurrency { get; set; }

		/// <summary>
		/// В какую валюту перевести.
		/// </summary>
		[Required(ErrorMessage = "Empty destination currency")]
		[StringLength(3)]
		public string DestinationCurrency { get; set; }

		/// <summary>
		/// Количество.
		/// </summary>
		[Range(0, 9000000,ErrorMessage = "Too big value")]
		public float Amount { get; set; }
	}
}
