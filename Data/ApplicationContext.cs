using Microsoft.EntityFrameworkCore;
using New_folder.Models.Entities;

namespace New_folder.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public DbSet<Investment> Investments { get; set; }
        public DbSet<InvestmentType> InvestmentsTypes { get; set;}
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
