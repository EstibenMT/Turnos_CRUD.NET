using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turnos.Models
{
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "Debes ingresar un nombre")]
        [StringLength(50, ErrorMessage = "El campo debe tener máximo 50 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Debes ingresar un apellido")]
        [StringLength(50, ErrorMessage = "El campo debe tener máximo 50 caracteres")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "Debes ingresar una dirección")]
        [StringLength(250, ErrorMessage = "El campo debe tener máximo 250 caracteres")]
        [Display(Name = "Dirección")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "Debes ingresar un télefono")]
        [StringLength(20, ErrorMessage = "El campo debe tener máximo 20 caracteres")]
        [Display(Name = "Télefono")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Debes ingresar un email")]
        [StringLength(100, ErrorMessage = "El campo debe tener máximo 100 caracteres")]
        public string? Email { get; set; }

        public List<Turno>? Turno { get; set; }
    }
}
