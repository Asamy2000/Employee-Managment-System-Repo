using MVCAPPDAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCAPPDAL.Context
{
	public class MVCAPPDbContext : IdentityDbContext<AppUser>
	{
		public MVCAPPDbContext(DbContextOptions<MVCAPPDbContext> options) : base(options)
		{

		}


		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		// => optionsBuilder.UseSqlServer("Server = .; Database = EFGDb ; Trusted_Connection = true; MultipleActiveResultSets = true;");

		public DbSet<Department> Departments { get; set; }
		public DbSet<Employee> Employees { get; set; }
 

	}
}
