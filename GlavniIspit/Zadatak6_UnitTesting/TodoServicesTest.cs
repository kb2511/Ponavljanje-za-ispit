using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak1_ASP.NET.Models;
using Zadatak2_API.Controllers;
using Zadatak2_Data.Data;
using Zadatak2_Data.Interfaces;
using Zadatak2_Data.Models;
using Zadatak2_Data.Services;

namespace Zadatak6_UnitTesting
{
	public class TodoServicesTest
	{
		[Fact]
		public async Task GetByIdSuccess()
		{
			var mockTodoService = new Mock<ITodoService>();
			mockTodoService.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync(new TodoList());

			var todoController = new TodoController(mockTodoService.Object);

			var result = await todoController.GetById(1);

			var okRes = Assert.IsType<OkObjectResult>(result.Result);

			var model = Assert.IsType<TodoList>(okRes.Value);
		}

		[Fact]
		public async Task GetByIdFailed()
		{
			var mockTodoService = new Mock<ITodoService>();
			mockTodoService.Setup(s => s.GetById(It.IsAny<int>())).ReturnsAsync((TodoList)null);

			var todoController = new TodoController(mockTodoService.Object);

			var result = await todoController.GetById(1);

			Assert.IsType<NotFoundResult>(result.Result);
		}
	}
}
