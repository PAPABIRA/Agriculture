using System;
using System.ComponentModel.DataAnnotations;

namespace AppSenAgriculture.Models
{
    public class Commande
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Statut { get; set; }
    }
}
