using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.BLL.Interfaces;
using Wallet.Core.Enums;
using Wallet.Core.ViewModels;
using Wallet.DAL;

namespace Wallet.BLL.Implementations
{
	/// <summary>
	/// Репозиторий пользователя.
	/// </summary>
	public class WalletRepository : IWalletRepository
	{
		private readonly ApplicationContext _applicationContext;
		private readonly IMapper _mapper;

		public WalletRepository(ApplicationContext applicationContext, IMapper mapper)
		{
			_applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		/// <inheritdoc/>
		public async Task<(WalletRepoActionResult result, IEnumerable<UserWalletViewModel> userWallets)> GetUserWalletByUserIdAsync(int userId)
		{
			#region Param check
			
			if (userId <= 0)
			{
				return (WalletRepoActionResult.WrongIdentity, null);
			}

			#endregion

			var user = await _applicationContext.Users
				.AsNoTracking()
				.Include(usr => usr.UserWallets)
				.ThenInclude(wlt => wlt.BankAccounts)
				.FirstOrDefaultAsync(usr => usr.UserId == userId);
			if (user == default)
			{
				return (WalletRepoActionResult.UserNotFound, null);
			}

			var userWalletViewModel = _mapper.Map<IEnumerable<UserWalletViewModel>>(user.UserWallets);
			return (WalletRepoActionResult.Success, userWalletViewModel);
		}

		/// <inheritdoc/>
		public async Task<(WalletRepoActionResult result, UserWalletViewModel UserWalletViewModel)> GetUserWalletByWalletIdAsync(int walletId)
		{
			#region Param check

			if (walletId <= 0)
			{
				return (WalletRepoActionResult.WrongIdentity, null);
			}

			#endregion

			var userWallet = await _applicationContext.UserWallets
				.AsNoTracking()
				.Include(wlt => wlt.BankAccounts)
				.FirstOrDefaultAsync(wlt => wlt.UserWalletId == walletId);
			if (userWallet == default)
			{
				return (WalletRepoActionResult.WalletNotFound, null);
			}

			var walletViewModel = _mapper.Map<UserWalletViewModel>(userWallet);
			return (WalletRepoActionResult.Success, walletViewModel);
		}
	}
}
