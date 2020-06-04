using System.ComponentModel;

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
		[Description("Успех")]
		Success,

		/// <summary>
		/// Кошелек не найден.
		/// </summary>
		[Description("Кошелек не найден")]
		WalletNotFound,

		/// <summary>
		/// Неправильный идентификатор.
		/// </summary>
		[Description("Неправильный идентификатор")]
		WrongIdentity,

		/// <summary>
		/// Пользователь не найден.
		/// </summary>
		[Description("Пользователь не найден")]
		UserNotFound,
	}
}
