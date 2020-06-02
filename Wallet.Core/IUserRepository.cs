using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wallet.Core.Enums;
using Wallet.Core.ViewModels;

namespace Wallet.BLL.Interfaces
{
	/// <summary>
	/// Интерфейс репозиторию пользователя.
	/// </summary>
	public interface IUserRepository
	{
		/// <summary>
		/// Получить пользователя по идентификатору.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <returns>Результат запроса и модель.</returns>
		Task<(RepoActionsResult Result, UserViewModel UserViewModel)> GetUserByIdAsync(int userId);

	}
}
