using BlazorCrud.Server.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.Models
{
    public class NominasDbContext : DbContext
    {
        public NominasDbContext(DbContextOptions<NominasDbContext> options) : base(options)
        {
            
        }

        public DbSet<Personal> Personals { get; set; }

        public DbSet<RangoPersonal> RangoPersonals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sembrando datos para RangoPersonal
            modelBuilder.Entity<RangoPersonal>().HasData(

                new RangoPersonal()
                { 
                    IdRangoPersonal = 1,
                    Rangos = "Administrador" 
                },
                new RangoPersonal()
                {
                    IdRangoPersonal = 2,
                    Rangos = "Gerente" 
                },
                new RangoPersonal()
                {
                    IdRangoPersonal = 3,
                    Rangos = "Colaborador"
                }
            );

            // Sembrando datos para Personal
            modelBuilder.Entity<Personal>().HasData(

                new Personal()
                {
                    IdPersonal = 1,
                    Nombres = "Juan",
                    Celular = "78793467", 
                    Correo = "juan@email.com", 
                    IdRangoPersonal = 1 
                },
                new Personal()
                { 
                    IdPersonal = 2,
                    Nombres = "María", 
                    Celular = "98873432",
                    Correo = "maria@email.com", 
                    IdRangoPersonal = 2 
                },
                new Personal()
                {
                    IdPersonal = 3,
                    Nombres = "Gerardo",
                    Celular = "66341289",
                    Correo = "gerardo@email.com",
                    IdRangoPersonal = 3
                }
            );
        }

    }
}
