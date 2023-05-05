using BookCommerceCustom1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookCommerceCustom1.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace BookCommerceCustom1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly Konteksti _konteksti;

		public HomeController(ILogger<HomeController> logger, Konteksti konteksti)
		{
			_logger = logger;
			_konteksti = konteksti;
		}

		public IActionResult Index()
		{
			var list = _konteksti.Produktet.Include(x => x.Kategoria)
				.Include(x => x.Mbulesa).ToList();
			return View(list);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult Detajet(int produktiId)
		{
			Shporta shporta = new()
			{
				Sasia = 1,
				ProduktiId = produktiId,
				Produkti = _konteksti.Produktet.
					Include(x => x.Kategoria).
					Include(x => x.Mbulesa).
					FirstOrDefault(u => u.Id == produktiId)
			};
			return View(shporta);
		}

		
	}
}