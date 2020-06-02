using Microsoft.EntityFrameworkCore.Migrations;

namespace Wallet.DAL.Migrations
{
    public partial class UserNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserWallets",
                columns: table => new
                {
                    UserWalletId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWallets", x => x.UserWalletId);
                    table.ForeignKey(
                        name: "FK_UserWallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    BankAccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserWalletId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    Amount = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.BankAccountId);
                    table.ForeignKey(
                        name: "FK_BankAccount_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccount_UserWallets_UserWalletId",
                        column: x => x.UserWalletId,
                        principalTable: "UserWallets",
                        principalColumn: "UserWalletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyId", "CurrencyName" },
                values: new object[,]
                {
                    { 1, "RUB" },
                    { 2, "EUR" },
                    { 3, "USD" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, "Ivanov" },
                    { 2, "Petrov" },
                    { 3, "Eelon Musk" }
                });

            migrationBuilder.InsertData(
                table: "UserWallets",
                columns: new[] { "UserWalletId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UserWallets",
                columns: new[] { "UserWalletId", "UserId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "UserWallets",
                columns: new[] { "UserWalletId", "UserId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "BankAccount",
                columns: new[] { "BankAccountId", "Amount", "CurrencyId", "UserWalletId" },
                values: new object[,]
                {
                    { 1, 1000L, 1, 1 },
                    { 2, 2000L, 2, 1 },
                    { 3, 3000L, 3, 1 },
                    { 4, 5000L, 1, 2 },
                    { 5, 8000L, 3, 2 },
                    { 6, 30000000L, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_CurrencyId",
                table: "BankAccount",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_UserWalletId",
                table: "BankAccount",
                column: "UserWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWallets_UserId",
                table: "UserWallets",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "UserWallets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
