
using MauiAppEjercicio1_3.Modelos;
using MauiAppEjercicio1_3.Utilidades;
using Microsoft.EntityFrameworkCore;

namespace MauiAppEjercicio1_3.DataAccess
{
    public class PersonaDbContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexionDB = $"Filename={ConexionDB.DevolverRuta("personas.db")}";
            optionsBuilder.UseSqlite(conexionDB);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity => 
            {
                entity.HasKey(col => col.IdPersona);
                entity.Property(col => col.IdPersona).IsRequired().ValueGeneratedOnAdd();
            });
        }

    }
}
