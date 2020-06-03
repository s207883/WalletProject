using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Wallet.Services.CurrencyService
{

	//API Doc. https://free.currencyconverterapi.com/

	public class CurrencyService : ICurrencyService
	{
		//TODO: Hide the secret
		private readonly string _apiKey = "ec2d7725f5fbf6cf1073";
		private readonly Uri _baseAddress = new Uri("https://free.currconv.com");
		private readonly HttpClient _client;

		public CurrencyService()
		{
			_client = new HttpClient { BaseAddress = _baseAddress };
		}

		/// <inheritdoc/>
		public async Task<float?> GetCurrencyRateAsync(string from, string to, float amount)
		{
			if (string.IsNullOrWhiteSpace(from))
			{
				//TODO: Log this
				throw new ArgumentException("From cannot be null", nameof(from));
			}

			if (string.IsNullOrWhiteSpace(to))
			{
				//TODO: Log this
				throw new ArgumentException("To cannot be null", nameof(to));
			}
			if (amount <= 0)
			{
				//TODO: Log this
				throw new ArgumentException("Amount must be positive number", nameof(amount));
			}

			try
			{
				// /api/v7/convert?apiKey=ec2d7725f5fbf6cf1073&q=USD_PHP&compact=y
				var fullPath = $"{_baseAddress}api/v7/convert?apiKey={_apiKey}&q={from}_{to}&compact=y";
				var result = await _client.GetAsync(fullPath);

				var resultContent = await result.Content.ReadAsStringAsync();

				if (resultContent.Contains("val"))
				{
					var parsingResult = ParseResponse(resultContent);
					if (parsingResult.HasValue)
					{
						return amount * parsingResult.Value;
					}
				}
				return null;
			}
			catch (Exception)
			{
				//TODO: Log this
				return null;
			}
		}

		private float? ParseResponse(string response)
		{
			if (string.IsNullOrWhiteSpace(response))
			{
				return null;
			}
			else
			{
				var valIndex = response.LastIndexOf("val") + 5;
				
				var stringResult = string.Concat(response.Skip(valIndex).TakeWhile(ch => Char.IsDigit(ch)|| ch == '.' || ch == ','));
				if (string.IsNullOrEmpty(stringResult))
				{
					return null;
				}

				var result = Convert.ToDouble(stringResult.Replace('.',','));
				return (float)result;
			}
		}
	}
}
