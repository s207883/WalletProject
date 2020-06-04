using System.ComponentModel;

namespace Wallet.Core.Enums
{
	/// <summary>
	/// Результат работы репозитория пользователя.
	/// </summary>
	public enum UserRepoActionsResult
	{
		/// <summary>
		/// Успех.
		/// </summary>
		[Description("Успех")]
		Success,

		/// <summary>
		/// Не обнаружен пользователь.
		/// </summary>
		[Description("Не обнаружен пользователь")]
		IdentityNotFound,

		/// <summary>
		/// Неправильный идентификатор.
		/// </summary>
		[Description("Неправильный идентификатор")]
		WrongIdentity,
	}
}
