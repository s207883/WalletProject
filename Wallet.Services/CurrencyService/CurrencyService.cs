using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wallet.DAL.Models;

namespace Wallet.Services.CurrencyService
{
	//API Doc. https://fixer.io/documentation

	/// <summary>
	/// Сервис конвертации валюты.
	/// </summary>
	public class CurrencyService
	{
		//TODO: Hide the secret
		private readonly string _apiKey = "bf9f8f7f22f6fa489b4708ecf13b20d9";
        private readonly Uri _baseAddress = new Uri("http://data.fixer.io/api/convert");
        private readonly HttpClient _client;

		public CurrencyService()
		{
            _client = new HttpClient { BaseAddress = _baseAddress};
		}

		/// <summary>
		/// Перевести валюту.
		/// </summary>
		/// <param name="from">Из какой валюты.</param>
		/// <param name="to">В какую валюту.</param>
		/// <returns>Результат перевода или null.</returns>
		public async Task<long?> GetCurrencyRateAsync(string from, string to, float amount)
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
                var fullPath = $"{_baseAddress}/?access_key={_apiKey}&from={from}&to={to}";
                var result = await _client.GetAsync(fullPath);

                var resultContent = await result.Content.ReadAsStringAsync();

                var parsedResult = JsonConvert.DeserializeObject<Root>(resultContent);

				return parsedResult.result;
			}
			catch (Exception)
			{
				//TODO: Log this
				return null;
			}
		}
	}

	#region Parsing models
	class Query
	{
		[SuppressMessage("Style", "IDE1006:Стили именования", Justification = "<Ожидание>")]
		public string from { get; set; }

		[SuppressMessage("Style", "IDE1006:Стили именования", Justification = "<Ожидание>")]
		public string to { get; set; }

		[SuppressMessage("Style", "IDE1006:Стили именования", Justification = "<Ожидание>")]
		public int amount { get; set; }
	}

	class Info
	{
		[SuppressMessage("Style", "IDE1006:Стили именования", Justification = "<Ожидание>")]
		public int timestamp { get; set; }

		[SuppressMessage("Style", "IDE1006:Стили именования", Justification = "<Ожидание>")]
		public double rate { get; set; }
	}

	class Root
	{
		[SuppressMessage("Style", "IDE1006:Стили именования", Justification = "<Ожидание>")]
		public string success { get; set; }

		[SuppressMessage("Style", "IDE1006:Стили именования", Justification = "<Ожидание>")]
		public Query query { get; set; }

		[SuppressMessage("Style", "IDE1006:Стили именования", Justification = "<Ожидание>")]
		public Info info { get; set; }

		[SuppressMessage("Style", "IDE1006:Стили именования", Justification = "<Ожидание>")]
		public string historical { get; set; }

		[SuppressMessage("Style", "IDE1006:Стили именования", Justification = "<Ожидание>")]
		public string date { get; set; }

		[SuppressMessage("Style", "IDE1006:Стили именования", Justification = "<Ожидание>")]
		public long result { get; set; }
	}
	#endregion

}
