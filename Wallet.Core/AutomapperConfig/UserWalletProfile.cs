using AutoMapper;
using Wallet.Core.ViewModels;
using Wallet.DAL.Models;

namespace Wallet.Core.AutomapperConfig
{
	/// <summary>
	/// Профиль автомаппера для кошелька.
	/// </summary>
	public class UserWalletProfile : Profile
	{
		public UserWalletProfile()
		{
			CreateMap<UserWalletViewModel, UserWallet>().ReverseMap();
		}
	}
}
