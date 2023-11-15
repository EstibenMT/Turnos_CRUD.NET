using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turnos.Models
{
    public class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMedico { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [StringLength(50, ErrorMessage= "El campo debe tener máximo 50 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un apellido")]
        [StringLength(50, ErrorMessage= "El campo debe tener máximo 50 caracteres")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "Debe ingresar un dirección")]
        [Display(Name = "Dirección")]
        [StringLength(250, ErrorMessage= "El campo debe tener máximo 250 caracteres")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "Debe ingresar un télefono")]
        [Display(Name = "Teléfono")]
        [StringLength(20, ErrorMessage= "El campo debe tener máximo 20 caracteres")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar un email")]
        [EmailAddress(ErrorMessage = "No es una dirección de Email válida")]
        [StringLength(50, ErrorMessage= "El campo debe tener máximo 50 caracteres")]
        public string? Email { get; set; }

        [Display(Name = "Horario desde")]
        [Required(ErrorMessage = "Debe ingresar un hora")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionDesde { get; set; }

        [Display(Name = "Horario hasta")]
        [Required(ErrorMessage = "Debe ingresar un hora")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionHasta { get; set; }

        public List<MedicoEspecialidad>? MedicosEspecialidad { get; set; }
        public List<Turno>? Turno { get; set; }
    }
}
