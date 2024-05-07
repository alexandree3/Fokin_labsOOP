using Microsoft.EntityFrameworkCore;
using OOP_LABA3.Models;

namespace OOP_LABA3
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
		public DbSet<Human> Humans { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Office> Offices { get; set; }
	    public DbSet<OOP_LABA3.Models.OfficeJob> OfficeJob { get; set; } = default!;

	}
}
