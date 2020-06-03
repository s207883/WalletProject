using System.Collections.Generic;

namespace Wallet.DAL.Models
{
	/// <summary>
	/// Модель пользователя.
	/// </summary>
	public class User
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Имя пользователя.
		/// </summary>
		public string UserName { get; set; }

		#region Навигационные свойства
		public IEnumerable<UserWallet> UserWallets { get; set; }
		#endregion
	}
}
