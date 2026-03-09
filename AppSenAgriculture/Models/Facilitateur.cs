using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSenAgriculture.Models
{
    [Table("facilitateurs")]
    public class Facilitateur
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nom_prenom")]
        public string NomPrenom { get; set; }

        [MaxLength(200)]
        [Column("adresse")]
        public string Adresse { get; set; }

        [MaxLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [MaxLength(20)]
        [Column("telephone")]
        public string Telephone { get; set; }

        [MaxLength(50)]
        [Column("identifiant")]
        public string Identifiant { get; set; }

        [MaxLength(100)]
        [Column("zone_intervention")]
        public string ZoneIntervention { get; set; }

        [Column("est_actif")]
        public bool EstActif { get; set; } = true;
    }
}
