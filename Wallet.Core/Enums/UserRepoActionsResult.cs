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
		Success,

		/// <summary>
		/// Не обнаружен пользователь.
		/// </summary>
		IdentityNotFound,

		/// <summary>
		/// Нерпвильный идентификатор.
		/// </summary>
		WrongIdentity,
	}
}
