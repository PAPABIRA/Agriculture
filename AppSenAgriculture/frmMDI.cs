using AppSenAgriculture.Views.Parametre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppSenAgriculture.UI;

namespace AppSenAgriculture
{
    /// <summary>
    /// Formulaire principal (MDI Parent) de l'application.
    /// Sert de conteneur pour tous les formulaires de gestion et gère la navigation latérale.
    /// </summary>
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
            
            // Initialisation du thème visuel pour garantir une cohérence graphique
            ApplyMenuTheme();
            ApplySidebarTheme();
        }

        /// <summary>
        /// Configure l'apparence du menu contextuel supérieur.
        /// </summary>
        private void ApplyMenuTheme()
        {
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Renderer = new ModernMenuRenderer();
            menuStrip1.BackColor = Color.FromArgb(15, 23, 42); // Fond sombre (Slate-900)
            menuStrip1.ForeColor = Color.WhiteSmoke;
            menuStrip1.Padding = new Padding(10, 6, 10, 6);
            menuStrip1.Font = new Font("Segoe UI", 10F);

            // Labellisation des menus avec raccourcis (Alt + lettre)
            actionToolStripMenuItem.Text = "&Action";
            seDeToolStripMenuItem.Text = "&Déconnexion";
            quitterToolStripMenuItem.Text = "&Quitter";

            paramettreToolStripMenuItem.Text = "&Paramètres";
            produitToolStripMenuItem.Text = "&Produits";
            cToolStripMenuItem.Text = "&Catégories";
            lieuToolStripMenuItem.Text = "&Lieux";

            // Masquage du menu Paramètres car on privilégie la barre latérale (Sidebar)
            paramettreToolStripMenuItem.Visible = false;
        }

        /// <summary>
        /// Configure l'apparence de la barre de navigation latérale.
        /// </summary>
        private void ApplySidebarTheme()
        {
            if (panelSidebar == null) return;

            panelSidebar.BackColor = Color.FromArgb(15, 23, 42);
            panelSidebar.Padding = new Padding(10);

            if (lblSidebarTitle != null)
            {
                lblSidebarTitle.ForeColor = Color.WhiteSmoke;
                lblSidebarTitle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            }

            // Application du style aux boutons de navigation
            StyleSidebarButton(btnNavProduits);
            StyleSidebarButton(btnNavCategories);
            StyleSidebarButton(btnNavLieux);
            StyleSidebarButton(btnNavUnites);
            StyleSidebarButton(btnNavStock);
            StyleSidebarButton(btnNavCommande);
            StyleSidebarButton(btnNavFacture);
            StyleSidebarButton(btnNavClients);
            StyleSidebarButton(btnNavFournisseurs);
            StyleSidebarButton(btnNavAdmins);
            StyleSidebarButton(btnActionDeconnexion, isDanger: false);
            StyleSidebarButton(btnActionQuitter, isDanger: true);
        }

        /// <summary>
        /// Applique un style "Flat modern" aux boutons de la sidebar.
        /// </summary>
        private void StyleSidebarButton(Button btn, bool isDanger = false)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Height = 44;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(12, 0, 12, 0);
            btn.Font = new Font("Segoe UI", 10F);
            btn.ForeColor = Color.WhiteSmoke;
            btn.BackColor = isDanger ? Color.FromArgb(127, 29, 29) : Color.FromArgb(30, 41, 59);
            btn.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Méthode générique pour ouvrir un formulaire enfant dans le conteneur MDI.
        /// Ferme automatiquement le formulaire précédent pour ne pas surcharger l'affichage.
        /// </summary>
        /// <param name="f">Le formulaire enfant à afficher.</param>
        private void OpenChild(Form f)
        {
            fermer(); // Ferme les enfants existants
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized; // L'enfant prend tout l'espace disponible
            f.Show();
        }

        /// <summary>
        /// Ferme tous les formulaires enfants ouverts.
        /// </summary>
        private void fermer()
        {
            try
            {
                foreach (Form child in this.MdiChildren)
                {
                    child.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la fermeture des formulaires: {ex.Message}");
            }
        }

        private void seDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // On réouvre la connexion et on ferme l'espace de travail
                frmConnexion f = new frmConnexion();
                f.Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // --- Handlers de clic pour la navigation ---

        private void btnNavProduits_Click(object sender, EventArgs e) => OpenChild(new frmProduit());

        private void btnNavCategories_Click(object sender, EventArgs e) => OpenChild(new frmCategorie());

        private void btnNavLieux_Click(object sender, EventArgs e) => OpenChild(new frmLieu());
        
        private void btnNavUnites_Click(object sender, EventArgs e) => OpenChild(new AppSenAgriculture.Views.Parametre.frmUniteMesure());

        private void btnNavStock_Click(object sender, EventArgs e) => OpenChild(new AppSenAgriculture.Views.frmStock());

        private void btnNavCommande_Click(object sender, EventArgs e) => OpenChild(new AppSenAgriculture.Views.frmCommande());

        private void btnNavFacture_Click(object sender, EventArgs e) => OpenChild(new AppSenAgriculture.Views.frmFacture());

        private void btnNavClients_Click(object sender, EventArgs e) => OpenChild(new AppSenAgriculture.Views.Securite.frmClient());

        private void btnNavFournisseurs_Click(object sender, EventArgs e) => OpenChild(new AppSenAgriculture.Views.Securite.frmFacilitateur());

        private void btnNavAdmins_Click(object sender, EventArgs e) => OpenChild(new AppSenAgriculture.Views.Securite.frmAdmin());

        private void btnActionDeconnexion_Click(object sender, EventArgs e) => seDeToolStripMenuItem_Click(sender, e);

        private void btnActionQuitter_Click(object sender, EventArgs e) => quitterToolStripMenuItem_Click(sender, e);

        private void frmMDI_Load(object sender, EventArgs e)
        {
            this.Text = "Sen Agriculture :: Menu Principal";
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
