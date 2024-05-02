using Microsoft.EntityFrameworkCore;
using Zadatak2_Data.Data;
using Zadatak2_Data.Interfaces;
using Zadatak2_Data.Models;

namespace Zadatak2_Data.Services
{
	public class TodoService : ITodoService
	{
		private readonly ApplicationDbContext _context;
		public TodoService(ApplicationDbContext context) 
		{
			_context = context;
		}
		public async Task<TodoList> Create(TodoList todoList)
		{
			var result = _context.TodoList.Add(todoList);
			await _context.SaveChangesAsync();
			return result.Entity;
		}

		public async Task<TodoList?> Delete(int id)
		{
			var todoListDb = await _context.TodoList.FirstOrDefaultAsync(l => l.Id == id);

			if(todoListDb != null)
			{
				_context.TodoList.Remove(todoListDb);
				await _context.SaveChangesAsync();
			}

			return todoListDb;
		}

		public async Task<IEnumerable<TodoList>> GetAll()
		{
			return await _context.TodoList.ToListAsync();
		}

		public async Task<TodoList?> GetById(int id)
		{
			return await _context.TodoList.FirstOrDefaultAsync(l => l.Id == id);
		}

		public async Task<TodoList?> Update(TodoList todoList)
		{
			var todoListDb = await _context.TodoList.FirstOrDefaultAsync(l => l.Id == todoList.Id);

			if (todoListDb != null)
			{
				todoListDb.Title = todoList.Title;
				todoListDb.Description = todoList.Description;
				todoListDb.IsCompleted = todoList.IsCompleted;
				await _context.SaveChangesAsync();
			}

			return todoListDb;
		}
	}
}
