using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCrud.Server.Models.Entidades
{
    public class RangoPersonal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRangoPersonal { get; set; }

        [Required]
        public string Rangos { get; set; } = string.Empty;

        public virtual ICollection<Personal> Personales { get; } = new List<Personal>();
    }
}
