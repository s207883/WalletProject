using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
				return GetRepoAmountRequestResult(Result, newAccountState);
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
		public async Task<ActionResult<BankAccountViewModel>> DecreaceAccountAmount(BankAccountAmountEditModel amountEditModel)
		{
			if (ModelState.IsValid)
			{
				var (Result, newAccountState) = await _repoManager.BankAccountRepository.DescreaseAmount(amountEditModel.AcctountId, amountEditModel.Amount);
				return GetRepoAmountRequestResult(Result, newAccountState);
			}
			else
			{
				return BadRequest(amountEditModel);
			}
		}

		/// <summary>
		/// Перевести деньги из одной валюты в другую.
		/// </summary>
		/// <param name="model">Модель.</param>
		/// <returns>Результат перевода.</returns>
		[HttpPost(ApiRoutes.BankAccountRoutes.ExchangeCurrency)]
		public async Task<ActionResult<IEnumerable<BankAccountViewModel>>> ExchaneCurrency (CurrencyExchangeEditModel model)
		{
			if (ModelState.IsValid)
			{
				var (Result, bankAccounts) = await _repoManager.BankAccountRepository.ExchangeCurrencyAsync(model.WalletId, model.OriginCurrencyId, model.DestinationCurrencyId, model.Amount);
				return GetRepoExchangeRequestResult(Result, bankAccounts);
			}
			else
			{
				return BadRequest(model);
			}
		}

		//TODO: Replace to generic.
		/// <summary>
		/// Сгенерировать ответ по полученным данным из непозитория.
		/// </summary>
		/// <param name="Result">Результат работы репозитория.</param>
		/// <param name="newAccountState">Новое состояние счета.</param>
		/// <returns>ActionResult</returns>
		private ActionResult<BankAccountViewModel> GetRepoAmountRequestResult(BankRepoActionResults Result, BankAccountViewModel newAccountState)
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
		private ActionResult<IEnumerable<BankAccountViewModel>> GetRepoExchangeRequestResult(BankRepoActionResults Result, IEnumerable<BankAccountViewModel> newAccountState)
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
