using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Core.ViewModels;
using Wallet.DAL.Models;

namespace Wallet.Core.AutomapperConfig
{
	public class CurrencyProfile : Profile
	{
		public CurrencyProfile()
		{
			CreateMap<Currency, CurrencyViewModel>().ReverseMap();
		}
	}
}
