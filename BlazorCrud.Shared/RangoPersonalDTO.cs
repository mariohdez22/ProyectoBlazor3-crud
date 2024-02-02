using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrud.Shared
{
    public class RangoPersonalDTO
    {
        public int IdRangoPersonal { get; set; }

        [Required]
        public string Rangos { get; set; } = string.Empty;

    }
}
