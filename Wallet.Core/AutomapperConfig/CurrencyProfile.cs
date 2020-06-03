using AutoMapper;
using Wallet.Core.ViewModels;
using Wallet.DAL.Models;

namespace Wallet.Core.AutomapperConfig
{
	/// <summary>
	/// Профиль автомаппера для валюты.
	/// </summary>
	public class CurrencyProfile : Profile
	{
		public CurrencyProfile()
		{
			CreateMap<Currency, CurrencyViewModel>().ReverseMap();
		}
	}
}
