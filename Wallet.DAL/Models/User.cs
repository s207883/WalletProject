using System;
using System.Collections.Generic;
using System.Text;

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
		public int UserName { get; set; }

		#region Навигационные свойства
		public UserWallet UserWallet { get; set; }
		#endregion
	}
}
