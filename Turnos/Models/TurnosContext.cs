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
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico>? Medicos { get; set; }
        public DbSet<MedicoEspecialidad>? MedicoEspecialidades { get; set; }
        public DbSet<Turno>? Turnos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad =>
            {
                entidad.ToTable("Especialidades");
                entidad.HasKey(e => e.IdEspecialidad);

                entidad.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            }
            );

            modelBuilder.Entity<Paciente>(entidad =>
            {
                entidad.ToTable("Pacientes");
                entidad.HasKey(p => p.IdPaciente);

                entidad.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p => p.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(p => p.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            }
            );

            modelBuilder.Entity<Medico>(entidad =>
            {
                entidad.ToTable("Medicos");
                entidad.HasKey(m => m.IdMedico);

                entidad.Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(m => m.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(m => m.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(m => m.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(m => m.HorarioAtencionDesde)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(m => m.HorarioAtencionHasta)
                .IsRequired()
                .IsUnicode(false);


            }
            );

            modelBuilder.Entity<MedicoEspecialidad>().HasKey(x => new { x.IdMedico, x.IdEspecialidad });

            modelBuilder.Entity<MedicoEspecialidad>()
                .HasOne(x => x.Medico)                 // Establece la relación uno a uno con la entidad IdMedico
                .WithMany(p => p.MedicosEspecialidad) // Indica que la entidad MedicoEspecialidad tiene una relación uno a muchos con p
                .HasForeignKey(p => p.IdMedico);       // Define la clave foránea en la entidad MedicoEspecialidad, relacionada con IdMedico

            modelBuilder.Entity<MedicoEspecialidad>()
                .HasOne(x => x.Especialidad)
                .WithMany(p => p.MedicoEspecialidad)
                .HasForeignKey(p => p.IdEspecialidad);

            modelBuilder.Entity<Turno>(entidad =>
            {
                entidad.ToTable("Turnos");
                entidad.HasKey(t => t.IdTurno);

                entidad.Property(t => t.IdPaciente)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(t => t.IdMedico)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(t => t.FechaHoraInicio)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(t => t.FechaHoraFin)
                .IsRequired()
                .IsUnicode(false);
            }
            );


            modelBuilder.Entity<Turno>()
                .HasOne(x => x.Paciente)
                .WithMany(t => t.Turno)
                .HasForeignKey(t => t.IdPaciente);

            modelBuilder.Entity<Turno>()
                .HasOne(x => x.Medico)
                .WithMany(t => t.Turno)
                .HasForeignKey(t => t.IdMedico);
        }
    }
}
