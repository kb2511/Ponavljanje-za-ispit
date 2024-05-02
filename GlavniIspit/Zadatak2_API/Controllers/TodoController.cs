using Microsoft.AspNetCore.Mvc;
using Zadatak2_Data.Interfaces;
using Zadatak2_Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zadatak2_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoController : ControllerBase
	{
		private readonly ITodoService _todoService;
		public TodoController(ITodoService todoService) 
		{
			_todoService = todoService;
		}
		// GET: api/<TodoController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<TodoList>>> GetAll()
		{
			try
			{
				var result = await _todoService.GetAll();
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		// GET api/<TodoController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<TodoList>> GetById(int id)
		{
			try
			{
				var todoList = await _todoService.GetById(id);

				if(todoList == null)
				{
					return NotFound();
				}

				return Ok(todoList);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		// POST api/<TodoController>
		[HttpPost]
		public async Task<ActionResult> Create([FromBody] TodoList todoList)
		{
			try
			{
				if(!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				var createdTodoList = await _todoService.Create(todoList);

				return Ok(createdTodoList);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		// PUT api/<TodoController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> Update(int id, [FromBody] TodoList todoList)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				if (id != todoList.Id)
				{
					return BadRequest("Todo list Id missmatch!");
				}

				var todoListToUpdate = await _todoService.GetById(id);

				if (todoListToUpdate == null)
				{
					return BadRequest("Todo list with this Id not found!");
				}

				var result = await _todoService.Update(todoList);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		// DELETE api/<TodoController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				var todoListToDelete = await _todoService.GetById(id);

				if (todoListToDelete == null)
				{
					return NotFound("Todo list with this Id not found!");
				}

				var result = await _todoService.Delete(id);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
