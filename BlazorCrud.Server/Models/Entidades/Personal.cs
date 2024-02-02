using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCrud.Server.Models.Entidades
{
    public class Personal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersonal { get; set; }

        [Required]
        public string Nombres { get; set; } = null!;

        [Required]
        public string Celular { get; set; } = null!;

        [Required]
        public string Correo { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(RangosPersonales))]  
        public int IdRangoPersonal { get; set; }

        public virtual RangoPersonal RangosPersonales { get; set; } = null!;
    }
}
