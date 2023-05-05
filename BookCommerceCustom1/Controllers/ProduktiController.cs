using BookCommerceCustom1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace BookCommerceCustom1.Controllers
{
	
	public class ProduktiController : Controller
	{
		private readonly Konteksti _konteksti;
		private readonly IWebHostEnvironment _hostEnvironment;

		public ProduktiController(Konteksti konteksti, IWebHostEnvironment hostEnvironment)
		{
			_konteksti = konteksti;
			_hostEnvironment = hostEnvironment;
		}
		public IActionResult Listo()
		{
			return View();
		}
		

	
		[HttpGet]
		public IActionResult ListoTeGjitha()
		{
			var productList = _konteksti.Produktet.Include(x => x.Kategoria).Include(x => x.Mbulesa).ToList();
			return Json(new { data = productList });
		}

		//POST
		[HttpDelete]
		public IActionResult Fshi(int id)
		{
			var obj = _konteksti.Produktet.FirstOrDefault(u => u.Id == id);
			if (obj == null)
			{
				return Json(new { statusi = false, mesazhi = "Nuk gjindet" });
			}

			var pathiIVjeter = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
			if (System.IO.File.Exists(pathiIVjeter))
			{
				System.IO.File.Delete(pathiIVjeter);
			}

			_konteksti.Produktet.Remove(obj);
			
			return Json(new { statusi = true, mesazhi = "U fshi me sukese" });

		}

	}
}
