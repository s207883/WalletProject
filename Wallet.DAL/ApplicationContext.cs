using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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


			base.OnModelCreating(modelBuilder);
		}
	}
}
