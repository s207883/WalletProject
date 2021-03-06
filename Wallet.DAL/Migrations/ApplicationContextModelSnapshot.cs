﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wallet.DAL;

namespace Wallet.DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wallet.DAL.Models.BankAccount", b =>
                {
                    b.Property<int>("BankAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("UserWalletId")
                        .HasColumnType("int");

                    b.HasKey("BankAccountId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("UserWalletId");

                    b.ToTable("BankAccounts");

                    b.HasData(
                        new
                        {
                            BankAccountId = 1,
                            Amount = 1000m,
                            CurrencyId = 1,
                            UserWalletId = 1
                        },
                        new
                        {
                            BankAccountId = 2,
                            Amount = 2000m,
                            CurrencyId = 2,
                            UserWalletId = 1
                        },
                        new
                        {
                            BankAccountId = 3,
                            Amount = 3000m,
                            CurrencyId = 3,
                            UserWalletId = 1
                        },
                        new
                        {
                            BankAccountId = 4,
                            Amount = 5000m,
                            CurrencyId = 1,
                            UserWalletId = 2
                        },
                        new
                        {
                            BankAccountId = 5,
                            Amount = 8000m,
                            CurrencyId = 3,
                            UserWalletId = 2
                        },
                        new
                        {
                            BankAccountId = 6,
                            Amount = 30000000m,
                            CurrencyId = 3,
                            UserWalletId = 3
                        });
                });

            modelBuilder.Entity("Wallet.DAL.Models.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrencyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CurrencyId");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            CurrencyId = 1,
                            CurrencyName = "RUB"
                        },
                        new
                        {
                            CurrencyId = 2,
                            CurrencyName = "EUR"
                        },
                        new
                        {
                            CurrencyId = 3,
                            CurrencyName = "USD"
                        });
                });

            modelBuilder.Entity("Wallet.DAL.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            UserName = "Ivanov"
                        },
                        new
                        {
                            UserId = 2,
                            UserName = "Petrov"
                        },
                        new
                        {
                            UserId = 3,
                            UserName = "Eelon Musk"
                        });
                });

            modelBuilder.Entity("Wallet.DAL.Models.UserWallet", b =>
                {
                    b.Property<int>("UserWalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserWalletId");

                    b.HasIndex("UserId");

                    b.ToTable("UserWallets");

                    b.HasData(
                        new
                        {
                            UserWalletId = 1,
                            UserId = 1
                        },
                        new
                        {
                            UserWalletId = 2,
                            UserId = 2
                        },
                        new
                        {
                            UserWalletId = 3,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Wallet.DAL.Models.BankAccount", b =>
                {
                    b.HasOne("Wallet.DAL.Models.Currency", "Currency")
                        .WithMany("BankAccounts")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wallet.DAL.Models.UserWallet", "UserWallet")
                        .WithMany("BankAccounts")
                        .HasForeignKey("UserWalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wallet.DAL.Models.UserWallet", b =>
                {
                    b.HasOne("Wallet.DAL.Models.User", "User")
                        .WithMany("UserWallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
