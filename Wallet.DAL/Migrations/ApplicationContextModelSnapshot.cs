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

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("UserWalletId")
                        .HasColumnType("int");

                    b.HasKey("BankAccountId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("UserWalletId");

                    b.ToTable("BankAccount");
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
                });

            modelBuilder.Entity("Wallet.DAL.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserName")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
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

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserWallets");
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
                        .WithOne("UserWallet")
                        .HasForeignKey("Wallet.DAL.Models.UserWallet", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}