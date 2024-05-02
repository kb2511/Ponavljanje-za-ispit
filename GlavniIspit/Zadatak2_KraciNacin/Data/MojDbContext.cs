using Microsoft.EntityFrameworkCore;
using Zadatak2_KraciNacin.Models;

namespace Zadatak2_KraciNacin.Data
{
	public class MojDbContext : DbContext
	{
		public MojDbContext(DbContextOptions<MojDbContext> options) 
			: base(options) 
		{
			
		}

		public DbSet<Todo> Todo { get; set; }
	}
}
