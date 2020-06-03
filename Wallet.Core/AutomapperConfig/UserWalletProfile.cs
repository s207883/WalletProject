using AutoMapper;
using Wallet.Core.ViewModels;
using Wallet.DAL.Models;

namespace Wallet.Core.AutomapperConfig
{
	public class UserWalletProfile : Profile
	{
		public UserWalletProfile()
		{
			CreateMap<UserWalletViewModel, UserWallet>().ReverseMap();
		}
	}
}
