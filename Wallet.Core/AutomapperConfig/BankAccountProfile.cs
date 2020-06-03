using AutoMapper;
using Wallet.Core.ViewModels;
using Wallet.DAL.Models;

namespace Wallet.Core.AutomapperConfig
{
	/// <summary>
	/// Профиль автомаппера для счета.
	/// </summary>
	public class BankAccountProfile : Profile
	{
		public BankAccountProfile()
		{
			CreateMap<BankAccountViewModel, BankAccount>().ReverseMap();
		}
	}
}
