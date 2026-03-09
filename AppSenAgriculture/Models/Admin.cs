using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSenAgriculture.Models
{
    [Table("admins")]
    public class Admin
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nom_prenom")]
        public string NomPrenom { get; set; }

        [MaxLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("login")]
        public string Login { get; set; }

        [Required]
        [MaxLength(256)]
        [Column("mot_de_passe")]
        public string MotDePasse { get; set; }

        [MaxLength(50)]
        [Column("role")]
        public string Role { get; set; } = "Admin";

        [Column("est_actif")]
        public bool EstActif { get; set; } = true;
    }
}
