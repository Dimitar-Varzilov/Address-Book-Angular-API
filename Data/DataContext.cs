using Microsoft.EntityFrameworkCore;

namespace AddressBookAPI.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Address> Address { get; set; }

		public DbSet<AddressComment> AddressComments { get; set; }
	}
}
