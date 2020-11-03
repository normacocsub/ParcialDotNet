using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Persona
    {
        [Key]
        [Column(TypeName = "varchar(13)")]
        [Required(ErrorMessage = "Proporcione una identificacion")]
        [StringLength(13, ErrorMessage = "Identificacion muy larga")]
        public string Identificacion { get; set; }
        [Column(TypeName = "varchar(25)")]
        [Required(ErrorMessage = "Proporcione un nombre")]
        [StringLength(25, ErrorMessage = "Nombre demasiado largo")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(25)")]
        [Required(ErrorMessage = "Proporcione una apellido")]
        [StringLength(25, ErrorMessage = "apellido muy largo")]
        public string Apellidos { get; set; }
        [Column(TypeName = "varchar(10)")]
        [Required(ErrorMessage = "Proporcione una opcion de sexo")]
        [SexoValidacion(ErrorMessage = "El sexo debe ser valido")]
        public string Sexo { get; set; }
        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Proporcione una edad")]
        public int Edad { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string Departamento { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string Ciudad { get; set; }
        public Ayudas Ayudas { get; set; }


        public void AgregarAyuda(Ayudas ayuda)
        {
            Ayudas = ayuda;
        }

        public class SexoValidacion : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if ((value.ToString().ToLower() == "masculino") || (value.ToString().ToLower() == "femenino"))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
        }
    }
}
