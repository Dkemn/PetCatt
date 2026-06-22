using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Vacuna
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de la vacuna es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "La fecha de aplicación es obligatoria")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de aplicación")]
    public DateTime FechaAplicacion { get; set; }

    [Required(ErrorMessage = "La fecha de próxima dosis es obligatoria")]
    [DataType(DataType.Date)]
    [Display(Name = "Próxima dosis")]
    public DateTime FechaProximaDosis { get; set; }

    [Required(ErrorMessage = "Debe seleccionar una mascota")]
    [ForeignKey("Mascota")]
    public int MascotaId { get; set; }

    public Mascota? Mascota { get; set; }
}