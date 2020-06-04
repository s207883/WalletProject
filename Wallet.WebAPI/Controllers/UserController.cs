using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wallet.BLL;
using Wallet.Core.Constants;
using Wallet.Core.Enums;
using Wallet.Core.Extentions;
using Wallet.Core.ViewModels;

namespace Wallet.WebAPI.Controllers
{
	public class UserController : ControllerBase
	{
		private readonly RepoManager _repoManager;

		public UserController(RepoManager repoManager)
		{
			_repoManager = repoManager ?? throw new ArgumentNullException(nameof(repoManager));
		}

		/// <summary>
		/// Получить пользователя по идентификатору.
		/// </summary>
		/// <param name="userId">Идентификатор.</param>
		/// <returns>Модель пользователя.</returns>
		[HttpGet(ApiRoutes.UserRoutes.GetUserById)]
		public async Task<ActionResult<UserViewModel>> GetUserById (int userId)
		{
			if (userId <=0)
			{
				return BadRequest();
			}
			
			var model = await _repoManager.UserRepository.GetUserByIdAsync(userId);
			if (model.Result == UserRepoActionsResult.Success)
			{
				return Ok(model.UserViewModel);
			}

			if (model.Result == UserRepoActionsResult.IdentityNotFound)
			{
				return NotFound(model.Result.GetDescription());
			}
			else
			{
				return BadRequest(model.Result.GetDescription());
			}
		}
	}
}
