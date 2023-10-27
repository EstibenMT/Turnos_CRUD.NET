using Microsoft.EntityFrameworkCore;

namespace Turnos.Models
{
    public class TurnosContext:DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> options)
        : base(options)
        { 
        
        }

        public DbSet<Especialidad> Especialidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Especialidad>(entidad =>
            {
                entidad.ToTable("Especialidades");
                entidad.HasKey(e=>e.Id);
                entidad.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            });
        }
    }
}
