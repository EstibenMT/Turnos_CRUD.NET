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
    }
}
