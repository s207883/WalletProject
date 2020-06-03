using Microsoft.EntityFrameworkCore;
using Wallet.DAL.Models;

namespace Wallet.DAL
{
	/// <summary>
	/// Основной контекст приложения.
	/// </summary>
	public class ApplicationContext : DbContext
	{
		/// <summary>
		/// Пользователи.
		/// </summary>
		public DbSet<User> Users { get; set; }

		/// <summary>
		/// Кошельки пользователей.
		/// </summary>
		public DbSet<UserWallet> UserWallets { get; set; }

		/// <summary>
		/// Валюты.
		/// </summary>
		public DbSet<Currency> Currencies { get; set; }

		/// <summary>
		/// Счета.
		/// </summary>
		public DbSet<BankAccount> BankAccounts { get; set; }

		/// <summary>
		/// Основной контекст приложения.
		/// </summary>
		/// <param name="options">Параметры.</param>
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region User table

			modelBuilder.Entity<User>()
				.HasOne(user => user.UserWallet)
				.WithOne(wallet => wallet.User);

			#endregion

			#region User wallet table

			modelBuilder.Entity<UserWallet>()
				.HasMany(uw => uw.BankAccounts)
				.WithOne(ba => ba.UserWallet);

			#endregion

			#region DB Initial state
			modelBuilder.Entity<Currency>().HasData(
				new Currency { CurrencyId = 1, CurrencyName = "RUB"},
				new Currency { CurrencyId = 2, CurrencyName = "EUR"},
				new Currency { CurrencyId = 3, CurrencyName = "USD"}
				);

			modelBuilder.Entity<User>().HasData(
				new User { UserId = 1, UserName = "Ivanov"},
				new User { UserId = 2, UserName = "Petrov"},
				new User { UserId = 3, UserName = "Eelon Musk"}
				);

			modelBuilder.Entity<UserWallet>().HasData(
				new UserWallet { UserId = 1, UserWalletId = 1},
				new UserWallet { UserId = 2, UserWalletId = 2},
				new UserWallet { UserId = 3, UserWalletId = 3}
				);

			modelBuilder.Entity<BankAccount>().HasData(
				new BankAccount { BankAccountId = 1, UserWalletId = 1, CurrencyId = 1, Amount = 1000 },
				new BankAccount { BankAccountId = 2, UserWalletId = 1, CurrencyId = 2, Amount = 2000 },
				new BankAccount { BankAccountId = 3, UserWalletId = 1, CurrencyId = 3, Amount = 3000 },

				new BankAccount { BankAccountId = 4, UserWalletId = 2, CurrencyId = 1, Amount = 5000 },
				new BankAccount { BankAccountId = 5, UserWalletId = 2, CurrencyId = 3, Amount = 8000 },

				new BankAccount { BankAccountId = 6, UserWalletId = 3, CurrencyId = 3, Amount = 30000000 }
				);
			#endregion

			base.OnModelCreating(modelBuilder);
		}
	}
}
