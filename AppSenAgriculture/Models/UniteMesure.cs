using System.ComponentModel.DataAnnotations;

namespace AppSenAgriculture.Models
{
    public class UniteMesure
    {
        [Key]
        public int IdUniteMesure { get; set; }

        [Required, MaxLength(100)]
        public string Libelle { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Symbole { get; set; }
    }
}
