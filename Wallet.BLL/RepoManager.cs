using System;
using Wallet.BLL.Interfaces;

namespace Wallet.BLL
{
	/// <summary>
	/// Менеджер репозиториев.
	/// </summary>
	public class RepoManager
	{
		private readonly IWalletRepository _walletRepository;
		private readonly IBankAccountRepository _bankAccountRepository;
		private readonly IUserRepository _userRepository;

		/// <summary>
		/// Репозиторий кошельков.
		/// </summary>
		public IWalletRepository WalletRepository => _walletRepository;

		/// <summary>
		/// Репозиторий счетов.
		/// </summary>
		public IBankAccountRepository BankAccountRepository => _bankAccountRepository;

		/// <summary>
		/// Репозиторий пользователей.
		/// </summary>
		public IUserRepository UserRepository => _userRepository;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="walletRepository">Реализация репозитория кошельков</param>
		/// <param name="bankAccountRepository">Реализация репозитория счетов.</param>
		/// <param name="userRepository">Реализация репозитория пользователей.</param>
		public RepoManager(IWalletRepository walletRepository, IBankAccountRepository bankAccountRepository, IUserRepository userRepository)
		{
			_walletRepository = walletRepository ?? throw new ArgumentNullException(nameof(walletRepository));
			_bankAccountRepository = bankAccountRepository ?? throw new ArgumentNullException(nameof(bankAccountRepository));
			_userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
		}
	}
}
