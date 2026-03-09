using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdSenAgricultureContext:DbContext
    {
        //constructeur qui passe la chaine de connexion au contexte de base
        public BdSenAgricultureContext(): base("conSenAgriculture")
        {

        }

        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Produit> Produits { get; set; }

        public DbSet<UniteMesure> UnitesMesure { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Commande> Commandes { get; set; }

        public DbSet<Facture> Factures { get; set; }
    }
}
