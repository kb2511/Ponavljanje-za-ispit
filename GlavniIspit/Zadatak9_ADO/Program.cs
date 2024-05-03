using Microsoft.Data.SqlClient;
using Zadatak2_Data.Models;

var todos = GetTodoLists();
foreach (var item in todos)
{
	Console.WriteLine("Id: " + item.Id);
	Console.WriteLine("Title: " + item.Title);
	Console.WriteLine("Description: " + item.Description);
	Console.WriteLine("Done: " + item.IsCompleted);
	Console.WriteLine("-------------------------------");
}
Console.ReadKey();

List<TodoList> GetTodoLists()
{
	List<TodoList> list = new List<TodoList>();
	string connString = "data source=localhost; initial catalog=GlavniTodoList; Integrated Security=True; Multiple Active Result Sets=True; Trust Server Certificate=True;";
	using (SqlConnection connection = new SqlConnection(connString))
	{
		connection.Open();
		string query = "SELECT * FROM TodoList";
		SqlCommand cmd = new SqlCommand(query, connection);

		using (SqlDataReader reader = cmd.ExecuteReader())
		{
			while (reader.Read())
			{
				TodoList todoList = new TodoList()
				{
					Id = reader.GetInt32(reader.GetOrdinal("Id")),
					Title = reader.GetString(reader.GetOrdinal("Title")),
					Description = reader.GetString(reader.GetOrdinal("Description")),
					IsCompleted = reader.GetBoolean(reader.GetOrdinal("IsCompleted"))
				};

				list.Add(todoList);
			}
		}
	}

	return list;

}