using Machine.Models.DBmodel;
using Microsoft.EntityFrameworkCore;

namespace Machine.Models
{
	public sealed class MachineDbContext: DbContext
	{
		public DbSet<ProductDB> Product { get; set; }
		public DbSet<OrderDB> Order { get; set; }
		public DbSet<CoinDB> Coin { get; set; }

		public MachineDbContext(DbContextOptions<MachineDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}