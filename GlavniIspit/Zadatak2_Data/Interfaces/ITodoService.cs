using Zadatak2_Data.Models;

namespace Zadatak2_Data.Interfaces
{
	public interface ITodoService
	{
		Task<IEnumerable<TodoList>> GetAll();
		Task<TodoList> GetById(int id);
		Task<TodoList> Create(TodoList todoList);
		Task<TodoList> Update(TodoList todoList);
		Task<TodoList> Delete(int id);
	}
}
