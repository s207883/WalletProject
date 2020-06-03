using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wallet.Core.Constants;
using Wallet.Core.EditModels;
using Wallet.Services.CurrencyService;

namespace Wallet.WebAPI.Controllers
{
	public class CurrencyController : ControllerBase
	{
		private readonly ICurrencyService _currencyService;

		public CurrencyController(ICurrencyService currencyService)
		{
			_currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));
		}

		/// <summary>
		/// Конвертировать валюту.
		/// </summary>
		/// <param name="currencyModel">Модель.</param>
		/// <returns>Результат конвертации.</returns>
		[HttpPost(ApiRoutes.CurrencyRoutes.ConvertCurrency)]
		public async Task<ActionResult<float>> ConvertCurrency (CurrencyConvertEditModel currencyModel)
		{
			if (ModelState.IsValid)
			{
				var result = await _currencyService.GetCurrencyRateAsync(currencyModel.OriginCurrency, currencyModel.DestinationCurrency, currencyModel.Amount);
				if (result.HasValue && result.Value > 0)
				{
					return Ok(result.Value);
				}
				else
				{
					return Problem("Outer service sent no response or response was invalid.");
				}
			}
			else
			{
				return BadRequest(currencyModel);
			}
		}
	}
}
