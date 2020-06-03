namespace Wallet.DAL.Models
{
	/// <summary>
	/// Модель счета пользователя.
	/// </summary>
	public class BankAccount
	{
		/// <summary>
		/// Идентификатор счета.
		/// </summary>
		public int BankAccountId { get; set; }

		/// <summary>
		/// Идентификатор кошелька.
		/// </summary>
		public int UserWalletId { get; set; }

		/// <summary>
		/// Идентификатор валюты.
		/// </summary>
		public int CurrencyId { get; set; }

		/// <summary>
		/// Сумма на счету.
		/// </summary>
		public long Amount { get; set; }

		#region Навигационные свойства
		public UserWallet UserWallet { get; set; }
		public Currency Currency { get; set; }
		#endregion
	}
}
