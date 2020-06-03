using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wallet.BLL;
using Wallet.Core.Enums;
using Wallet.Core.ViewModels;

namespace Wallet.WebAPI.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
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
		[HttpGet]
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
				return NotFound();
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
