using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Models
{
    /// <summary>
    /// Classe de contexte de base de données.
    /// C'est le cœur de l'accès aux données avec Entity Framework 6.
    /// Elle fait le pont entre vos classes C# et les tables MySQL.
    /// </summary>
    [DbConfigurationType(typeof(MySqlEFConfiguration))] // Indique à EF d'utiliser le connecteur MySQL
    public class BdSenAgricultureContext : DbContext
    {
        /// <summary>
        /// Constructeur : passe le nom de la chaîne de connexion (conSenAgriculture)
        /// définie dans le fichier App.config.
        /// </summary>
        public BdSenAgricultureContext() : base("conSenAgriculture")
        {
        }

        // Les DbSets représentent les tables de la base de données.
        // On peut les voir comme des collections d'objets en mémoire
        // qui sont synchronisées avec MySQL.

        /// <summary> Table des catégories de produits </summary>
        public DbSet<Categorie> Categories { get; set; }

        /// <summary> Table des produits </summary>
        public DbSet<Produit> Produits { get; set; }

        /// <summary> Table des unités de mesure (Kg, Sac, etc.) </summary>
        public DbSet<UniteMesure> UnitesMesure { get; set; }

        /// <summary> Table de suivi des stocks </summary>
        public DbSet<Stock> Stocks { get; set; }

        /// <summary> Table des commandes clients/fournisseurs </summary>
        public DbSet<Commande> Commandes { get; set; }

        /// <summary> Table des factures émises </summary>
        public DbSet<Facture> Factures { get; set; }

        /// <summary> Table des lieux de stockage ou de vente </summary>
        public DbSet<Lieu> Lieux { get; set; }

        /// <summary> Table des administrateurs du système </summary>
        public DbSet<Admin> Admins { get; set; }
    }
}
