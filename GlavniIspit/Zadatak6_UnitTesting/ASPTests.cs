using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using Zadatak1_ASP.NET.Controllers;
using Zadatak1_ASP.NET.Models;
using Zadatak2_Data.Data;

namespace Zadatak6_UnitTesting
{
	public class ASPTests
	{
		[Fact]
		public void IndexSuccess()
		{
			var controller = new OsobaController();
			var result = controller.Index();
			var view = Assert.IsType<ViewResult>(result);
			var model = Assert.IsAssignableFrom<IEnumerable<Osoba>>(view.Model);
			Assert.Equal(2, model.Count());
		}
	}
}