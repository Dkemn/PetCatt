using System.ComponentModel.DataAnnotations;

public enum SexoMascota
{
    Macho,
    Hembra
}

public class Mascota
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre de la mascota es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "La especie es obligatoria")]
    [StringLength(30, ErrorMessage = "La especie no puede superar los 30 caracteres")]
    public string Especie { get; set; }

    [StringLength(50, ErrorMessage = "La raza no puede superar los 50 caracteres")]
    public string? Raza { get; set; }

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de nacimiento")]
    public DateTime FechaNacimiento { get; set; }

    [Required(ErrorMessage = "El sexo es obligatorio")]
    [Display(Name = "Sexo")]
    public SexoMascota Sexo { get; set; }

    public ICollection<Vacuna>? Vacunas { get; set; }
}