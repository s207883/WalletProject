using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wallet.Core.Enums;
using Wallet.Core.ViewModels;

namespace Wallet.BLL.Interfaces
{
	/// <summary>
	/// Интерфейс репозитория счетов.
	/// </summary>
	public interface IBankAccountRepository
	{
		/// <summary>
		/// Увеличить количество денег на счете.
		/// </summary>
		/// <param name="accountId">Идентификатор счета.</param>
		/// <param name="amount">Количество.</param>
		/// <returns>Результат работы и новое состояние счета.</returns>
		Task<(BankRepoActionResults Result, BankAccountViewModel newValue)> IncreaseAmount(int accountId, long amount);

		/// <summary>
		/// Уменьшить количество денег на счете.
		/// </summary>
		/// <param name="accountId">Идентификатор счета.</param>
		/// <param name="amount">Количество.</param>
		/// <returns>Результат работы и новое состояние счета.</returns>
		Task<(BankRepoActionResults Result, BankAccountViewModel newValue)> DescreaseAmount(int accountId, long amount);


		/// <summary>
		/// Перевести деньги из одной валюты в другую.
		/// </summary>
		/// <returns>Результат и новое состояние счета.</returns>
		/// <param name="walletId">Идентификатор кошелька</param>
		/// <param name="originCurrencyId">Идентификатор валюты, которую нужно поменять.</param>
		/// <param name="destinationCurrencyId">Идентификатор валюты, на которую нужно поменять.</param>
		/// <param name="amountToExhange">Количество валюты для обмена.</param>
		/// <returns>Результат работы и новое состояние счетов.</returns>
		Task<(BankRepoActionResults Result, IEnumerable<BankAccountViewModel> bankAccounts)> ExchangeCurrencyAsync(int walletId, int originCurrencyId, int destinationCurrencyId, long amountToExhange);
	}
}
