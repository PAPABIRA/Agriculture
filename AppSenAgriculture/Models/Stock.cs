using System;
using System.ComponentModel.DataAnnotations;

namespace AppSenAgriculture.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime DatePaiment { get; set; }

        public decimal Quantite { get; set; }

        public DateTime DateDispo { get; set; }

        public decimal PU { get; set; }
    }
}
