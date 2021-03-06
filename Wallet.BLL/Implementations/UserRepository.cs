﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
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
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationContext _applicationContext;
		private readonly IMapper _mapper;

		public UserRepository(ApplicationContext applicationContext, IMapper mapper)
		{
			_applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		/// <inheritdoc/>
		public async Task<(UserRepoActionsResult Result, UserViewModel UserViewModel)> GetUserByIdAsync(int userId)
		{
			#region Param check
			
			if (userId <= 0)
			{
				return (UserRepoActionsResult.WrongIdentity, null);
			}

			#endregion

			var user = await _applicationContext.Users
				.AsNoTracking()
				.Include(usr => usr.UserWallets)
				.ThenInclude(wlt => wlt.BankAccounts)
				.ThenInclude(cur => cur.Currency)
				.FirstOrDefaultAsync(usr => usr.UserId == userId);

			if (user == default)
			{
				return (UserRepoActionsResult.IdentityNotFound, null);
			}

			var userViewModel = _mapper.Map<UserViewModel>(user);
			return (UserRepoActionsResult.Success, userViewModel);
		}
	}
}
