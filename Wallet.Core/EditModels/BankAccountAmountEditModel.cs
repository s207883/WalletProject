using System;
using System.ComponentModel.DataAnnotations;

namespace Wallet.Core.EditModels
{
	/// <summary>
	/// Модель изменения состояния счета.
	/// </summary>
	public class BankAccountAmountEditModel
	{
		/// <summary>
		/// Идентификатор счета.
		/// </summary>
		[Range(1, int.MaxValue, ErrorMessage = "Id must be positive number.")]
		public int AcctountId { get; set; }

		/// <summary>
		/// Сумма.
		/// </summary>
		[Range(0.1, 1000000, ErrorMessage ="Amount is out of range")]
		public float Amount { get; set; }
	}
}
