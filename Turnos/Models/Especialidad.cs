using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turnos.Models
{
    public class Especialidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEspecialidad { get; set; }
        [StringLength(200, ErrorMessage = "El campo descripccion debe tener maximo 200 caracteres")]
        [Required (ErrorMessage = "Debe ingresar una descripción")]
        [Display(Name = "Descripción", Prompt = "Ingrese una descripción")]
        public string? Descripcion { get; set; }
        public List<MedicoEspecialidad>? MedicoEspecialidad { get; set; }
    }
}
