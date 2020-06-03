using System.Threading.Tasks;

namespace Wallet.Services.CurrencyService
{

	/// <summary>
	/// Интерфейс сервиса конвертации валюты.
	/// </summary>
	public interface ICurrencyService
	{
		/// <summary>
		/// Перевести валюту.
		/// </summary>
		/// <param name="from">Из какой валюты.</param>
		/// <param name="to">В какую валюту.</param>
		/// <returns>Результат перевода или null.</returns>
		Task<float?> GetCurrencyRateAsync(string from, string to, float amount);
	}
}
