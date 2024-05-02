using Microsoft.AspNetCore.Mvc;
using Zadatak8_MVC.Models;
using Zadatak8_MVC.Repository;

namespace Zadatak8_MVC.Controllers
{
	public class TodoController : Controller
	{
		private readonly List<Todo> todoList;
		public TodoController() 
		{
			var todoRepo = new TodoRepository();
			todoRepo.SeedTodoList();
			todoList = todoRepo.TodoList;
		}
		public IActionResult Index()
		{
			return View(todoList);
		}

		public ActionResult Details(int id)
		{
			var todo = todoList.FirstOrDefault(x => x.Id == id);
			return View(todo);
		}
	}
}
