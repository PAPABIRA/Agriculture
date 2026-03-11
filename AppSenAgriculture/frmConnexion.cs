using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSenAgriculture
{
    /// <summary>
    /// Formulaire de connexion à l'application.
    /// Gère l'authentification des administrateurs via la base de données MySQL.
    /// </summary>
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'initialisation du formulaire: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gère le clic sur le bouton de connexion.
        /// Vérifie les identifiants en base de données avant d'ouvrir l'espace MDI.
        /// </summary>
        private void bnSeConnecter_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validation de surface : vérifie que les champs ne sont pas vides
                if (string.IsNullOrWhiteSpace(txtIdentifiant.Text))
                {
                    MessageBox.Show("Veuillez entrer un identifiant", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIdentifiant.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMotDePasse.Text))
                {
                    MessageBox.Show("Veuillez entrer un mot de passe", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMotDePasse.Focus();
                    return;
                }

                // 2. Interrogation de la base de données via Entity Framework
                try
                {
                    using (var db = new Models.BdSenAgricultureContext())
                    {
                        string login = txtIdentifiant.Text.Trim();
                        string password = txtMotDePasse.Text.Trim();

                        // Recherche d'un administrateur correspondant au login et qui est actif
                        var admin = db.Admins.FirstOrDefault(a => a.Login == login && a.EstActif);

                        // Si l'admin n'existe pas ou si le mot de passe est incorrect
                        if (admin == null || admin.MotDePasse != password)
                        {
                            MessageBox.Show("Identifiant ou mot de passe incorrect !", 
                                "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtIdentifiant.Focus();
                            return;
                        }

                        // Connexion réussie : On affiche un message de bienvenue
                        MessageBox.Show($"Bienvenue, {admin.NomPrenom} !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception dbEx)
                {
                    // En cas d'erreur de connexion à MySQL
                    MessageBox.Show($"ERREUR DE CONNEXION À LA BASE DE DONNÉES:\n\n{dbEx.Message}\n\nVérifiez que MySQL est démarré et que la base 'bdsenagriculture' est configurée.", 
                        "Erreur Base de Données", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Passage au formulaire parent MDI
                frmMDI f = new frmMDI();
                f.Show();
                
                // On cache ce formulaire car il ne doit pas être fermé pour garder l'application active si c'est le formulaire principal
                this.Hide(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la connexion:\n\n{ex.Message}\n\nType: {ex.GetType().Name}", 
                    "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ferme proprement l'application.
        /// </summary>
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Voulez-vous vraiment quitter l'application ?", "Confirmation", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la fermeture:\n\n{ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ouvre le formulaire d'inscription pour créer un nouvel administrateur.
        /// </summary>
        private void lnkInscription_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Views.Securite.frmInscription f = new Views.Securite.frmInscription();
                f.ShowDialog(); // ShowDialog rend le formulaire modal (bloque le parent tant qu'il n'est pas fermé)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ouverture de l'inscription:\n\n{ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
