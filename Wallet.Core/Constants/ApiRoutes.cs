namespace Wallet.Core.Constants
{
	/// <summary>
	/// Маршуты API
	/// </summary>
	public static class ApiRoutes
	{
		/// <summary>
		/// Корневой маршрут API
		/// </summary>
		public const string Root = "api";

		/// <summary>
		/// Маршрут счетов.
		/// </summary>
		public static class BankAccountRoutes
		{
			/// <summary>
			/// Маршрут счетов.
			/// </summary>
			public const string Path = "bankAccount";

			/// <summary>
			/// Increase amount endpoint.
			/// </summary>
			public const string IncreaseAccountAmount = Root + "/" + Path + "/" + "increaceAccountAmount";

			/// <summary>
			/// Decrease amount endpoint.
			/// </summary>
			public const string DecreaseAccountAcount = Root + "/" + Path + "/" + "decreaseAccountAcount";
		}

		public static class CurrencyRoutes
		{
			/// <summary>
			/// Currency route.
			/// </summary>
			public const string Path = "currency";

			/// <summary>
			/// Currency convertation endpoint.
			/// </summary>
			public const string ConvertCurrency = Root + "/" + Path + "/" + "convertCurrency";
		}
		public static class UserRoutes
		{
			/// <summary>
			/// User route.
			/// </summary>
			public const string Path = "user";

			/// <summary>
			/// Get user model endpoint.
			/// </summary>
			public const string GetUserById = Root + "/" + Path + "/" + "getUserById";
		}
	}
}
