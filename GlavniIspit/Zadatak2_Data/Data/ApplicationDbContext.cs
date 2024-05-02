using Microsoft.EntityFrameworkCore;
using Zadatak2_Data.Models;

namespace Zadatak2_Data.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
			: base(options) 
		{ 

		}

		public DbSet<TodoList> TodoList { get; set; }

		//seed je u zadatku 9, a zadatak 9 mi se nije dalo rješavati
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<TodoList>().HasData(
				new TodoList()
				{
					Id = 1,
					Title = "WC",
					Description = "Operi pod",
					IsCompleted = true,
				},
				new TodoList()
				{
					Id = 2,
					Title = "WC",
					Description = "Operi WC školjku",
					IsCompleted = false,
				},
				new TodoList()
				{
					Id = 3,
					Title = "Kuhinja",
					Description = "Operi pod",
					IsCompleted = false,
				});
		}
	}
}
