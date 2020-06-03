using AutoMapper;
using Wallet.Core.ViewModels;
using Wallet.DAL.Models;

namespace Wallet.Core.AutomapperConfig
{
	/// <summary>
	/// Профиль автомаппера для пользователя.
	/// </summary>
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserViewModel, User>().ReverseMap();
		}
	}
}
