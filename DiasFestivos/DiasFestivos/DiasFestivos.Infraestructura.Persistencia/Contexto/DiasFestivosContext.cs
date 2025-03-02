using DiasFestivos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DiasFestivos.Infraestructura.Persistencia.Contexto
{
    public class DiasFestivosContext : DbContext
    {
        public DiasFestivosContext(DbContextOptions<DiasFestivosContext> options) : base(options)
        {
        }

        public DbSet<Tipo> Tipos { get; set; }  // Corregido el nombre
        public DbSet<Festivo> Festivos { get; set; }  // Corregido el nombre

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tipo>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique(); // Cambiado de 'Tipos' a 'Nombre' (si aplica)
            });

            modelBuilder.Entity<Festivo>(entidad =>
            {
                entidad.HasKey(e => e.Id);

                // Definir la clave foránea correctamente
                entidad.HasOne(f => f.Tipo)
                       .WithMany() // Si `Tipo` tiene una lista de festivos, sería .WithMany(t => t.Festivos)
                       .HasForeignKey(f => f.IdTipo);
            });
        }
    }
}

