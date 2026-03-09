using System;
using System.ComponentModel.DataAnnotations;

namespace AppSenAgriculture.Models
{
    public class Facture
    {
        [Key]
        public int IdFact { get; set; }

        public DateTime Date { get; set; }
    }
}
