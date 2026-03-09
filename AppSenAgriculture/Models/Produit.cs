using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Models
{
    public class Produit
    {
        [Key]
        public int IdProduit { get; set; }

        [Required, MaxLength(100)]
        public string LibelleProduit { get; set; }

        [Required, MaxLength(5000)]
        public string DescriptionProduit { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix unitaire minimum doit être supérieur à 0")]
        public decimal PrixUnitaireMin { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix unitaire maximum doit être supérieur à 0")]
        public decimal PrixUnitaireMax { get; set; }

        //mettre relation entre Produit et Categorie
        public int CategorieId { get; set; }

        [ForeignKey("CategorieId")]
         
        public virtual Categorie Categorie { get; set; }
    }
}
