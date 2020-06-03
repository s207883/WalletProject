using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Core.Enums
{
	/// <summary>
	/// Результат работы репозитория кошелька.
	/// </summary>
	public enum WalletRepoActionResult
	{
		/// <summary>
		/// Успех.
		/// </summary>
		Success,

		/// <summary>
		/// Кошелек не найден.
		/// </summary>
		WalletNotFound,

		/// <summary>
		/// Неправильный идентификатор.
		/// </summary>
		WrongIdentity,

		/// <summary>
		/// Пользователь не найден.
		/// </summary>
		UserNotFound,
	}
}
