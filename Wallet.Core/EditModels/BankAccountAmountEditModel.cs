using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wallet.Core.Enums;

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
		[Range(1, int.MaxValue, ErrorMessage = "Amount is out of range")]
		public int AcctountId { get; set; }

		/// <summary>
		/// Сумма.
		/// </summary>
		[Range(0.1, 1000000, ErrorMessage ="Amount is out of range")]
		public float Amount { get; set; }
	}
}
