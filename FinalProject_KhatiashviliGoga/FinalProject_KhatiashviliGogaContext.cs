using FinalProject_KhatiashviliGoga.Entities;
using FinalProject_KhatiashviliGoga.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FinalProject_KhatiashviliGoga
{
    public class FinalProject_KhatiashviliGogaContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Person> Persons { get; set; }





        public FinalProject_KhatiashviliGogaContext()
        {

        }

        public FinalProject_KhatiashviliGogaContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            
        }
    }

}