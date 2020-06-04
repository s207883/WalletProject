using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.BLL;
using Wallet.Core.Constants;
using Wallet.Core.EditModels;
using Wallet.Core.Enums;
using Wallet.Core.Extentions;
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
				if (Result == BankRepoActionResults.Success)
				{
					return Ok(newAccountState);
				}
				else
				{
					return BadRequest(Result.GetDescription());
				}
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

				if (Result == BankRepoActionResults.Success)
				{
					return Ok(newAccountState);
				}
				else
				{
					return BadRequest(Result.GetDescription());
				}
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

				if (Result == BankRepoActionResults.Success)
				{
					return Ok(bankAccounts);
				}
				else
				{
					return BadRequest(Result.GetDescription());
				}
			}
			else
			{
				return BadRequest(model);
			}
		}
	}
}
