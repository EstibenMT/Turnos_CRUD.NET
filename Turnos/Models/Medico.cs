using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turnos.Models
{
    public class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMedico { get; set; }
        public string? Name { get; set; }
        public string? Apelido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public DateTime HorarioAtencionDesde { get; set; }
        public DateTime HorarioAtencionHasta { get; set; }
    }
}
