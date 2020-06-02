using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wallet.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CurrencyController : ControllerBase
	{
		/// <summary>
		/// Test
		/// </summary>
		/// <returns>return</returns>
		[HttpGet]
		public string TestMethod ()
		{
			return Guid.NewGuid().ToString();
		}
	}
}
