using System;
using System.Linq;
using System.Windows.Forms;
using AppSenAgriculture.Models;

namespace AppSenAgriculture.Views.Securite
{
    public partial class frmInscription : Form
    {
        public frmInscription()
        {
            InitializeComponent();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSInscrire_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string email = txtEmail.Text.Trim();
            string login = txtLogin.Text.Trim();
            string pass = txtPass.Text.Trim();
            string confirm = txtConfirm.Text.Trim();

            // Validations
            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Veuillez remplir les champs obligatoires (Nom, Login, Mot de passe).", 
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pass != confirm)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.", 
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new BdSenAgricultureContext())
                {
                    // Vérifier si le login existe déjà
                    if (db.Admins.Any(a => a.Login == login))
                    {
                        MessageBox.Show("Cet identifiant est déjà utilisé par un autre administrateur.", 
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLogin.Focus();
                        return;
                    }

                    // Création de l'administrateur
                    var nouvelAdmin = new Admin
                    {
                        NomPrenom = nom,
                        Email = email,
                        Login = login,
                        MotDePasse = pass, // On reste sur du texte clair pour le moment comme convenu
                        Role = "Admin",
                        EstActif = true
                    };

                    db.Admins.Add(nouvelAdmin);
                    db.SaveChanges();

                    MessageBox.Show("Compte créé avec succès ! Vous pouvez maintenant vous connecter.", 
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la création du compte : {ex.Message}", 
                    "Erreur Base de Données", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
