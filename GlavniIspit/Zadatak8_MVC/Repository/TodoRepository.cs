using Zadatak8_MVC.Models;

namespace Zadatak8_MVC.Repository
{
	public class TodoRepository
	{
		public List<Todo> TodoList { get; set; }
		public void SeedTodoList() 
		{
			if(TodoList == null)
			{
				TodoList = new List<Todo>()
				{
					new Todo()
					{
						Id = 1,
						Title = "WC",
						Description = "Operi pod",
						IsCompleted = true,
					},
					new Todo()
					{
						Id = 2,
						Title = "WC",
						Description = "Operi WC školjku",
						IsCompleted = false,
					},
					new Todo()
					{
						Id = 3,
						Title = "Kuhinja",
						Description = "Operi pod",
						IsCompleted = false,
					},
					new Todo()
					{
						Id = 4,
						Title = "Kuhinja",
						Description = "Operi sudje",
						IsCompleted = false,
					},
					new Todo()
					{
						Id = 5,
						Title = "Dnevni",
						Description = "Obrisi prasinu",
						IsCompleted = false,
					}
				};
			}
			
		}

	}
}
