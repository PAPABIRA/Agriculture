using System;
using System.Linq;
using System.Windows.Forms;
using AppSenAgriculture.Models;

namespace AppSenAgriculture.Views.Securite
{
    /// <summary>
    /// Formulaire de création de compte pour les administrateurs.
    /// Permet d'enregistrer un nouvel utilisateur avec des validations métier.
    /// </summary>
    public partial class frmInscription : Form
    {
        public frmInscription()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ferme le formulaire d'inscription sans rien enregistrer.
        /// </summary>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Gère la validation et l'enregistrement du nouvel administrateur.
        /// </summary>
        private void btnSInscrire_Click(object sender, EventArgs e)
        {
            // Récupération et nettoyage des saisies
            string nom = txtNom.Text.Trim();
            string email = txtEmail.Text.Trim();
            string login = txtLogin.Text.Trim();
            string pass = txtPass.Text.Trim();
            string confirm = txtConfirm.Text.Trim();

            // 1. Validation : Vérifie que les champs obligatoires sont remplis
            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Veuillez remplir les champs obligatoires (Nom, Login, Mot de passe).", 
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validation : Vérifie que le mot de passe et sa confirmation sont identiques
            if (confirm != pass)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.", 
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Utilisation du contexte Entity Framework pour interagir avec MySQL
                using (var db = new BdSenAgricultureContext())
                {
                    // 3. Validation : Vérifie l'unicité du login (on ne peut pas avoir deux admins avec le même identifiant)
                    if (db.Admins.Any(a => a.Login == login))
                    {
                        MessageBox.Show("Cet identifiant est déjà utilisé par un autre administrateur.", 
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLogin.Focus();
                        return;
                    }

                    // 4. Création de l'objet Admin (Mapping vers la table 'admins')
                    var nouvelAdmin = new Admin
                    {
                        NomPrenom = nom,
                        Email = email,
                        Login = login,
                        MotDePasse = pass, // Stockage en texte clair (pas de hachage selon la demande utilisateur)
                        Role = "Admin",
                        EstActif = true     // Le compte est activé par défaut à la création
                    };

                    // Ajout à la collection locale et sauvegarde physique dans la base de données
                    db.Admins.Add(nouvelAdmin);
                    db.SaveChanges(); // C'est ici que la requête SQL INSERT est réellement exécutée

                    MessageBox.Show("Compte créé avec succès ! Vous pouvez maintenant vous connecter.", 
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Close(); // Fermeture après succès
                }
            }
            catch (Exception ex)
            {
                // Gestion des erreurs de base de données (serveur MySQL éteint, erreur de schéma, etc.)
                MessageBox.Show($"Erreur lors de la création du compte : {ex.Message}", 
                    "Erreur Base de Données", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
