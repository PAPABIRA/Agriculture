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
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
            // Centralise le look & feel : on évite de disperser les réglages UI
            // dans le Designer, et on garde une UI cohérente.
            ApplyMenuTheme();
            ApplySidebarTheme();
        }

        private void ApplyMenuTheme()
        {
            // MenuStrip look & feel (modern, dark)
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Renderer = new ModernMenuRenderer();
            menuStrip1.BackColor = Color.FromArgb(15, 23, 42);
            menuStrip1.ForeColor = Color.WhiteSmoke;
            menuStrip1.Padding = new Padding(10, 6, 10, 6);
            menuStrip1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);

            // Labels (fix typos + consistent naming)
            actionToolStripMenuItem.Text = "&Action";
            seDeToolStripMenuItem.Text = "&Déconnexion";
            quitterToolStripMenuItem.Text = "&Quitter";

            paramettreToolStripMenuItem.Text = "&Paramètres";
            produitToolStripMenuItem.Text = "&Produits";
            cToolStripMenuItem.Text = "&Catégories";
            lieuToolStripMenuItem.Text = "&Lieux";

            // A simple separator improves readability
            if (actionToolStripMenuItem.DropDownItems.Count == 2 &&
                !(actionToolStripMenuItem.DropDownItems[1] is ToolStripSeparator))
            {
                actionToolStripMenuItem.DropDownItems.Insert(1, new ToolStripSeparator());
            }

            // La navigation principale passe par la barre latérale.
            // On garde le menu du haut surtout pour les actions globales.
            paramettreToolStripMenuItem.Visible = false;
        }

        private void ApplySidebarTheme()
        {
            if (panelSidebar == null) return;

            panelSidebar.BackColor = Color.FromArgb(15, 23, 42);
            panelSidebar.Padding = new Padding(10, 10, 10, 10);

            if (panelSidebarHeader != null)
            {
                panelSidebarHeader.BackColor = Color.FromArgb(15, 23, 42);
            }

            if (lblSidebarTitle != null)
            {
                lblSidebarTitle.ForeColor = Color.WhiteSmoke;
                lblSidebarTitle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            }

            StyleSidebarButton(btnNavProduits);
            StyleSidebarButton(btnNavCategories);
            StyleSidebarButton(btnNavLieux);
            StyleSidebarButton(btnNavClients);
            StyleSidebarButton(btnNavFournisseurs);
            StyleSidebarButton(btnNavAdmins);
            StyleSidebarButton(btnActionDeconnexion, isDanger: false);
            StyleSidebarButton(btnActionQuitter, isDanger: true);
        }

        private void StyleSidebarButton(Button btn, bool isDanger = false)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Height = 44;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(12, 0, 12, 0);
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn.ForeColor = Color.WhiteSmoke;
            btn.BackColor = isDanger ? Color.FromArgb(127, 29, 29) : Color.FromArgb(30, 41, 59); // red-900 / slate-800
            btn.Cursor = Cursors.Hand;
        }

        private void OpenChild(Form f)
        {
            // Un seul écran "métier" à la fois : c'est plus simple pour l'utilisateur
            // et ça évite d'empiler des formulaires MDI ouverts.
            fermer();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        /// <summary>
        /// Ferme tous les formulaires enfants ouverts
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
                MessageBox.Show($"Erreur lors de la fermeture des formulaires: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Ouvrir le formulaire de Produit
        /// </summary>
        private void produitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChild(new frmProduit());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ouverture du formulaire Produit: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se déconnecter de l'application 
        /// </summary>
        private void seDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmConnexion f = new frmConnexion();
                f.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la déconnexion: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Quitter l'application
        /// </summary>
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la fermeture: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ouvre le formulaire de Categorie
        /// </summary>
        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChild(new frmCategorie());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ouverture du formulaire Catégorie: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {
            try
            {
                // Configuration simple et robuste
                this.Text = "Sen Agriculture :: Menu Principal";
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement du formulaire MDI: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ouvre le formulaire de Lieu
        /// </summary>
        private void lieuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChild(new frmLieu());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ouverture du formulaire Lieux: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNavProduits_Click(object sender, EventArgs e) => produitToolStripMenuItem_Click(sender, e);

        private void btnNavCategories_Click(object sender, EventArgs e) => cToolStripMenuItem_Click(sender, e);

        private void btnNavLieux_Click(object sender, EventArgs e) => lieuToolStripMenuItem_Click(sender, e);
        
        private void btnNavClients_Click(object sender, EventArgs e) => OpenChild(new AppSenAgriculture.Views.Securite.frmClient());

        private void btnNavFournisseurs_Click(object sender, EventArgs e) => OpenChild(new AppSenAgriculture.Views.Securite.frmFacilitateur());

        private void btnNavAdmins_Click(object sender, EventArgs e) => OpenChild(new AppSenAgriculture.Views.Securite.frmAdmin());

        private void btnActionDeconnexion_Click(object sender, EventArgs e) => seDeToolStripMenuItem_Click(sender, e);

        private void btnActionQuitter_Click(object sender, EventArgs e) => quitterToolStripMenuItem_Click(sender, e);
    }
}
