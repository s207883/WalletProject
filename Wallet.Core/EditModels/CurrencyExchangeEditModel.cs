using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Core.EditModels
{
	public class CurrencyExchangeEditModel
	{
		public int WalletId { get; set; }
		public int OriginCurrencyId { get; set; }
		public int DestinationCurrencyId { get; set; }
		public float Amount { get; set; }
	}
}
