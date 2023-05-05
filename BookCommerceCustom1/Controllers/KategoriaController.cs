using BookCommerceCustom1.Data;
using BookCommerceCustom1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookCommerceCustom1.Controllers
{

	public class KategoriaController : Controller
	{
		private readonly Konteksti _konteksti;

		public KategoriaController(Konteksti konteksti
			)
		{
			_konteksti = konteksti;
		}
		public IActionResult Listo()
		{
			var lista = _konteksti.Kategorite.ToList();
			return View(lista);
		}

		public IActionResult Krijo()
		{
			var entiteti = new Kategoria();
			return View(entiteti);
		}
		
		
		
	}
}
