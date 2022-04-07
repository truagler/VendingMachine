using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DBModel;
using DbContext = System.Data.Entity.DbContext;

namespace VendingMachine.Models.Context
{
	public class DrinksAndEatContext: DbContext
	{
		public System.Data.Entity.DbSet<DrinksAndEatsDb> Products { get; set; }

		public DrinksAndEatContext()
		{
			Database.Create();
		}
		
		protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Drinks;Username=postgres;Password=123");
		}
	}
}