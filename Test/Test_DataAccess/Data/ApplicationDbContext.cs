

using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data

{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        public DbSet<Categories> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(
                new Categories { Id=1,Name="Action",DisplayOrder=1},
                new Categories { Id=2,Name="Scifi",DisplayOrder=2},
                new Categories { Id=3 ,Name="History",DisplayOrder=3}
                );
        }


    }
}
