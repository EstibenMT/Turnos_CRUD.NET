using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turnos.Models
{
    public class Turno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTurno { get; set; }

        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public Paciente? Paciente { get; set; }
        public Medico? Medico { get; set; }

        [Display(Name ="Fecha hota inicio")]
        public DateTime FechaHoraInicio { get; set; }

        [Display(Name = "Fecha hota fin")]
        public DateTime FechaHoraFin { get; set; }

    }
}
