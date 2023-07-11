using BorjaProject.iws.api.Models;
using BorjaProject.iws.api.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace BorjaProject.iws.api.Datos
{
    public class BorjaDbContext: DbContext
    {
        public BorjaDbContext(DbContextOptions<BorjaDbContext> options): base(options)
        {

        }
        
        public DbSet<BorjaP> BorjaPs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BorjaP>().HasData(
                new BorjaP()
                {
                    Id = 1,
                    Name = "Karen Cruz",
                    Edad = 24,
                    Peso = 60
                },
                new BorjaP()
                {
                    Id = 2,
                    Name = "Arturo borja",
                    Edad = 25,
                    Peso = 90
                },
                new BorjaP()
                {
                    Id = 3,
                    Name = "Guerlain Varela",
                    Edad = 30,
                    Peso = 70
                }
            );
        }
    }
}
