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
        public int IdPersonal { get; set; }

        [Required]
        public string Nombres { get; set; } = null!;

        [Required]
        public string Celular { get; set; } = null!;

        [Required]
        public string Correo { get; set; } = null!;

        [Required]
        public int IdRangoPersonal { get; set; }

        public RangoPersonalDTO? RangosPersonales { get; set; } = null!;
    }
}
