using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wallet.BLL;
using Wallet.Core.Constants;
using Wallet.Core.EditModels;
using Wallet.Core.Enums;
using Wallet.Core.ViewModels;

namespace Wallet.WebAPI.Controllers
{
	public class BankAccountController : ControllerBase
	{
		private readonly RepoManager _repoManager;

		public BankAccountController(RepoManager repoManager)
		{
			_repoManager = repoManager ?? throw new ArgumentNullException(nameof(repoManager));
		}

		/// <summary>
		/// Увеличить количество денег на счете.
		/// </summary>
		/// <param name="amountEditModel">Модель изменения счета.</param>
		/// <returns>Новое состояние счета.</returns>
		[HttpPost(ApiRoutes.BankAccountRoutes.IncreaseAccountAmount)]
		public async Task<ActionResult<BankAccountViewModel>> IncreaceAccountAmount(BankAccountAmountEditModel amountEditModel)
		{
			if (ModelState.IsValid)
			{
				var (Result, newAccountState) = await _repoManager.BankAccountRepository.IncreaseAmount(amountEditModel.AcctountId, amountEditModel.Amount);
				return MakeRequestByRepoResult(Result, newAccountState);
			}
			else
			{
				return BadRequest(amountEditModel);
			}
		}

		/// <summary>
		/// Уменьшить количество денег на счете.
		/// </summary>
		/// <param name="amountEditModel">Модель изменения счета .</param>
		/// <returns>Новое состояние счета .</returns>
		[HttpPost(ApiRoutes.BankAccountRoutes.DecreaseAccountAcount)]
		public ActionResult<BankAccountViewModel> DecreaceAccountAmount(BankAccountAmountEditModel amountEditModel)
		{
			if (ModelState.IsValid)
			{
				var (Result, newAccountState) = _repoManager.BankAccountRepository.DescreaseAmount(amountEditModel.AcctountId, amountEditModel.Amount).Result;
				return MakeRequestByRepoResult(Result, newAccountState);
			}
			else
			{
				return BadRequest(amountEditModel);
			}
		}
		
		/// <summary>
		/// Сгенерировать ответ по полученным данным из непозитория.
		/// </summary>
		/// <param name="Result">Результат работы репозитория.</param>
		/// <param name="newAccountState">Новое состояние счета.</param>
		/// <returns>ActionResult</returns>
		private ActionResult<BankAccountViewModel> MakeRequestByRepoResult(BankRepoActionResults Result, BankAccountViewModel newAccountState)
		{
			switch (Result)
			{
				case BankRepoActionResults.Success:
					return Ok(newAccountState);
				case BankRepoActionResults.AccountNotFound:
				case BankRepoActionResults.CurrencyNotFound:
				case BankRepoActionResults.WalletNotFound:
					return NotFound();
				case BankRepoActionResults.NotEnouthMoney:
				case BankRepoActionResults.WrongAmount:
					return BadRequest("Received wrong amount or not enouth money.");
				case BankRepoActionResults.OutterServiceFailure:
					return Problem("Outer service sent no response or response was invalid.");
				default:
					return BadRequest();
			}
		}
	}
}
