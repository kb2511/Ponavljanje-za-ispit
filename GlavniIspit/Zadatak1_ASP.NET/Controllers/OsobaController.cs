using Microsoft.AspNetCore.Mvc;
using Zadatak1_ASP.NET.Models;

namespace Zadatak1_ASP.NET.Controllers
{
	public class OsobaController : Controller
	{
		public IActionResult Index()
		{
			List<Osoba> osobe = new List<Osoba>()
			{
				new Osoba()
				{
					Ime = "Ana",
					Prezime = "Anic"
				},
				new Osoba()
				{
					Ime = "Ivo",
					Prezime = "Ivic"
				}
			};

			return View(osobe);
		}
	}
}
