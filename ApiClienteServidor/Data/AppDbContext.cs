using Microsoft.EntityFrameworkCore;
using ApiClienteServidor.Models;

namespace ApiClienteServidor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Persona> Persona { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Persona>().HasData(
                new Persona { Id = 1, Nombre = "Juan Pérez", Edad = 28 },
                new Persona { Id = 2, Nombre = "María Gómez", Edad = 34 },
                new Persona { Id = 3, Nombre = "Carlos Rodríguez", Edad = 22 },
                new Persona { Id = 4, Nombre = "Ana López", Edad = 41 },
                new Persona { Id = 5, Nombre = "Luis Fernández", Edad = 30 }
            );
        }


    }
}
