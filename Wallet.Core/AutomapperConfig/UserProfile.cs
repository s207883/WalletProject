using AutoMapper;
using Wallet.Core.ViewModels;
using Wallet.DAL.Models;

namespace Wallet.Core.AutomapperConfig
{
	/// <summary>
	/// Профиль автомаппера для пользователя.
	/// </summary>
	class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserViewModel, User>().ReverseMap();
		}
	}
}
