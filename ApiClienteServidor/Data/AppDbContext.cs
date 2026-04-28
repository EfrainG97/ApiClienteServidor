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
        public DbSet<Alumno> Alumno { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Persona>().HasData(
                new Persona { 
                    Id = 1, Nombre = "Juan Pérez", 
                    Edad = 28, 
                    Cantidad = 5, 
                    Descripcion = "Descripción de Juan Pérez" 
                },
                new Persona { 
                    Id = 2, Nombre = "María Gómez", 
                    Edad = 34, 
                    Cantidad = 3, 
                    Descripcion = "Descripción de María Gómez" 
                },
                new Persona { 
                    Id = 3, Nombre = "Carlos Rodríguez", 
                    Edad = 22, 
                    Cantidad = 7, 
                    Descripcion = "Descripción de Carlos Rodríguez" 
                },
                new Persona { 
                    Id = 4, Nombre = "Ana López", 
                    Edad = 41, 
                    Cantidad = 2, 
                    Descripcion = "Descripción de Ana López" 
                },
                new Persona { 
                    Id = 5, Nombre = "Luis Fernández", 
                    Edad = 30, 
                    Cantidad = 4, 
                    Descripcion = "Descripción de Luis Fernández" 
                }
            );
        }

    }
}
