namespace Wallet.Core.Enums
{
	/// <summary>
	/// Результат работы репозитория.
	/// </summary>
	public enum RepoActionsResult
	{
		/// <summary>
		/// Ошибка.
		/// </summary>
		Fail,

		/// <summary>
		/// Успех.
		/// </summary>
		Success,

		/// <summary>
		/// Не обнаружена запись в бд.
		/// </summary>
		IdentityNotFound,
	}
}
