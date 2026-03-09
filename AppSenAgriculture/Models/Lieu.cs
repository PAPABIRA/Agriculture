using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Models
{
    //j'avais déjà une table "Lieu" dans la base de données, mais elle n'était pas bonne
    [Table("LieuxApp")]
    public class Lieu
    {
        [Key]
        public int IdLieu { get; set; }

        
        [Required, MaxLength(100)]
        public string Libelle { get; set; }
        
       
        [MaxLength(2000)]
        public string DescriptionLieu { get; set; }

        [MaxLength(200)]
        public string Adresse { get; set; }

        [MaxLength(50)]
        public string Ville { get; set; }

        [MaxLength(20)]
        public string Telephone { get; set; }
    }
}
