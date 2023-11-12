using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Models
{
    public class TurnosContext:DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> options)
        : base(options)
        { 
        
        }

        public DbSet<Especialidad>? Especialidades { get; set; }
        public DbSet<Paciente>? Pacientes { get; set; }
        public DbSet<Medico>? Medico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Especialidad>(entidad =>
            {
                entidad.ToTable("Especialidades");
                entidad.HasKey(e=>e.IdEspecialidad);

                entidad.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Paciente>(entidad =>
            {
                entidad.ToTable("Pacientes");
                entidad.HasKey(e => e.IdPaciente);

                entidad.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            }
            );
        }

        

    }
}
