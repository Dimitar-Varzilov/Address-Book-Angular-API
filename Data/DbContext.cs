using AddressBookAPI;
using Microsoft.EntityFrameworkCore;

namespace AddressBookAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

		public DbSet<AddressType> AddressTypes { get; set; }

		public DbSet<AddressComment> AddressComments { get; set; }
	}
}
