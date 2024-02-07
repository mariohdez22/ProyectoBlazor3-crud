using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrud.Shared
{
    public class PersonalDTO
    {
        [Required]
        public int IdPersonal { get; set; }

        [Required(ErrorMessage = "El campo(0) es obligatorio.")]
        public string Nombres { get; set; } = null!;

        RuleFor(x => x.Nombres)
        .NotEmpty().WithMessage("{PropertyName} no debe estar vacío.")
        .Length(2, 50).WithMessage("{PropertyName} debe tener entre {MinLength} y {MaxLength} caracteres.");

        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "El formato del número de celular no es válido.")]
        public string Celular { get; set; } = null!;

        [EmailAddress(ErrorMessage = "El campo {0} no es una dirección de correo electrónico válida.")]
        public string Correo { get; set; } = null!;

        RuleFor(x => x.Correo)
        .EmailAddress().WithMessage("El {PropertyName} proporcionado no es válido.");

        [Required]
        public int IdRangoPersonal { get; set; }

        public RangoPersonalDTO? RangosPersonales { get; set; } = null!;
    }
}
