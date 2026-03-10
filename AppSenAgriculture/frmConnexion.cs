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

        private void bnSeConnecter_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérification des identifiants
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

                // Vérification des identifiants via la base de données
                try
                {
                    using (var db = new Models.BdSenAgricultureContext())
                    {
                        string login = txtIdentifiant.Text.Trim();
                        string password = txtMotDePasse.Text.Trim();

                        // Recherche de l'administrateur
                        var admin = db.Admins.FirstOrDefault(a => a.Login == login && a.EstActif);

                        if (admin == null || admin.MotDePasse != password)
                        {
                            MessageBox.Show("Identifiant ou mot de passe incorrect !", 
                                "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtIdentifiant.Focus();
                            return;
                        }

                        // Connexion réussie
                        MessageBox.Show($"Bienvenue, {admin.NomPrenom} !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception dbEx)
                {
                    MessageBox.Show($"ERREUR DE CONNEXION À LA BASE DE DONNÉES:\n\n{dbEx.Message}\n\nVérifiez que MySQL est démarré et que la base 'bdsenagriculture' est configurée.", 
                        "Erreur Base de Données", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ouverture du formulaire principal
                frmMDI f = new frmMDI();
                f.Show();
                
                // Fermeture du formulaire de connexion
                this.Hide(); // Utiliser Hide au lieu de Close pour éviter les problèmes
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la connexion:\n\n{ex.Message}\n\nType: {ex.GetType().Name}", 
                    "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void lnkInscription_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Views.Securite.frmInscription f = new Views.Securite.frmInscription();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ouverture de l'inscription:\n\n{ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
