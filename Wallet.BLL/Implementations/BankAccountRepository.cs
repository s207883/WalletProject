using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.BLL.Interfaces;
using Wallet.Core.Enums;
using Wallet.Core.ViewModels;
using Wallet.DAL;
using Wallet.DAL.Models;
using Wallet.Services.CurrencyService;

namespace Wallet.BLL.Implementations
{
	public class BankAccountRepository : IBankAccountRepository
	{
		private readonly ApplicationContext _applicationContext;
		private readonly IMapper _mapper;
		private readonly ICurrencyService _currencyService;

		public BankAccountRepository(ApplicationContext applicationContext, IMapper mapper, ICurrencyService currencyService)
		{
			_applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			_currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));
		}


		/// <inheritdoc/>
		public async Task<(BankRepoActionResults Result, BankAccountViewModel newAccountState)> DescreaseAmount(int accountId, float amount)
		{
			#region Param check
			if (accountId <= 0)
			{
				return (BankRepoActionResults.AccountNotFound, null);
			}
			if (amount <= 0)
			{
				return (BankRepoActionResults.WrongAmount, null);
			}
			#endregion

			var account = await _applicationContext.BankAccounts.FirstOrDefaultAsync(acc => acc.BankAccountId == accountId);

			if (account == default)
			{
				return (BankRepoActionResults.AccountNotFound, null);
			}
			if (account.Amount < amount)
			{
				var currentAccountState = _mapper.Map<BankAccountViewModel>(account);

				return (BankRepoActionResults.NotEnouthMoney, currentAccountState);
			}

			account.Amount -= amount;

			await _applicationContext.SaveChangesAsync();

			var result = _mapper.Map<BankAccountViewModel>(account);


			return (BankRepoActionResults.Success, result);
		}

		/// <inheritdoc/>
		public async Task<(BankRepoActionResults Result, BankAccountViewModel newAccountState)> IncreaseAmount(int accountId, float amount)
		{
			#region Param check
			if (accountId <= 0)
			{
				return (BankRepoActionResults.AccountNotFound, null);
			}
			if (amount <= 0)
			{
				return (BankRepoActionResults.WrongAmount, null);
			}
			#endregion

			var account = await _applicationContext.BankAccounts.FirstOrDefaultAsync(acc => acc.BankAccountId == accountId);

			if (account == default)
			{
				return (BankRepoActionResults.AccountNotFound, null);
			}

			account.Amount += amount;

			await _applicationContext.SaveChangesAsync();

			var result = _mapper.Map<BankAccountViewModel>(account);

			return (BankRepoActionResults.Success, result);
		}

		/// <inheritdoc/>
		public async Task<(BankRepoActionResults Result, IEnumerable<BankAccountViewModel> bankAccounts)> ExchangeCurrencyAsync(int walletId, int originCurrencyId, int destinationCurrencyId, float amountToExhange)
		{
			#region Param check
			if (walletId <= 0)
			{
				return (BankRepoActionResults.WalletNotFound, null);
			}
			if (originCurrencyId <= 0 || destinationCurrencyId <= 0)
			{
				return (BankRepoActionResults.CurrencyNotFound, null);
			}
			if (amountToExhange <= 0)
			{
				return (BankRepoActionResults.WrongAmount, null);
			}
			#endregion

			var userWallet = await _applicationContext.UserWallets
				.Include(w => w.BankAccounts)
				.ThenInclude(ba => ba.Currency)
				.FirstOrDefaultAsync(wallet => wallet.UserWalletId == walletId);

			var originAccount = userWallet.BankAccounts
				.FirstOrDefault(acc => acc.CurrencyId == originCurrencyId);
			if (originAccount == default)
			{
				return (BankRepoActionResults.AccountNotFound, null);
			}
			if (originAccount.Amount < amountToExhange)
			{
				var currentAccountState = _mapper.Map<BankAccountViewModel>(originAccount);

				return (BankRepoActionResults.NotEnouthMoney, new List<BankAccountViewModel> { currentAccountState });
			}

			var destinationCurrency = await _applicationContext.Currencies
				.AsNoTracking()
				.FirstOrDefaultAsync(cur => cur.CurrencyId == destinationCurrencyId);
			if (destinationCurrency == default)
			{
				return (BankRepoActionResults.CurrencyNotFound, null);
			}

			var destinationAccount = userWallet.BankAccounts
				.FirstOrDefault(acc => acc.CurrencyId == destinationCurrencyId);
			if (destinationAccount == default)
			{
				destinationAccount = new BankAccount { UserWalletId = walletId, CurrencyId = destinationCurrencyId, Amount = 0 };
			}

			var serivceResult = await _currencyService.GetCurrencyRateAsync(originAccount.Currency.CurrencyName, destinationCurrency.CurrencyName, amountToExhange);
			if (serivceResult.HasValue && serivceResult.Value > 0)
			{
				originAccount.Amount -= amountToExhange;
				destinationAccount.Amount += serivceResult.Value;

				await _applicationContext.SaveChangesAsync();

				var originViewModel = _mapper.Map<BankAccountViewModel>(originAccount);
				var destinationViewModel = _mapper.Map<BankAccountViewModel>(destinationAccount);

				return (BankRepoActionResults.Success, new List<BankAccountViewModel> { originViewModel, destinationViewModel });
			}
			else
			{
				return (BankRepoActionResults.OutterServiceFailure, null);
			}
		}
	}
}
