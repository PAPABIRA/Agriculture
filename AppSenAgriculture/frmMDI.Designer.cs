namespace AppSenAgriculture
{
    partial class frmMDI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramettreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lieuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnActionQuitter = new System.Windows.Forms.Button();
            this.btnActionDeconnexion = new System.Windows.Forms.Button();
            this.btnNavLieux = new System.Windows.Forms.Button();
            this.btnNavCategories = new System.Windows.Forms.Button();
            this.btnNavProduits = new System.Windows.Forms.Button();
            this.panelSidebarHeader = new System.Windows.Forms.Panel();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.btnNavUnites = new System.Windows.Forms.Button();
            this.btnNavStock = new System.Windows.Forms.Button();
            this.lblCommerce = new System.Windows.Forms.Label();
            this.btnNavCommande = new System.Windows.Forms.Button();
            this.btnNavFacture = new System.Windows.Forms.Button();
            this.btnNavClients = new System.Windows.Forms.Button();
            this.btnNavClients = new System.Windows.Forms.Button();
            this.btnNavFournisseurs = new System.Windows.Forms.Button();
            this.btnNavAdmins = new System.Windows.Forms.Button();
            this.lblSecurite = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelSidebarHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.paramettreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(574, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seDeToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(66, 26);
            this.actionToolStripMenuItem.Text = "&Action";
            // 
            // seDeToolStripMenuItem
            // 
            this.seDeToolStripMenuItem.Name = "seDeToolStripMenuItem";
            this.seDeToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.seDeToolStripMenuItem.Text = "&Déconnexion";
            this.seDeToolStripMenuItem.Click += new System.EventHandler(this.seDeToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.quitterToolStripMenuItem.Text = "&Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // paramettreToolStripMenuItem
            // 
            this.paramettreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produitToolStripMenuItem,
            this.cToolStripMenuItem,
            this.lieuToolStripMenuItem});
            this.paramettreToolStripMenuItem.Name = "paramettreToolStripMenuItem";
            this.paramettreToolStripMenuItem.Size = new System.Drawing.Size(96, 26);
            this.paramettreToolStripMenuItem.Text = "&Paramètres";
            // 
            // produitToolStripMenuItem
            // 
            this.produitToolStripMenuItem.Name = "produitToolStripMenuItem";
            this.produitToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.produitToolStripMenuItem.Text = "&Produits";
            this.produitToolStripMenuItem.Click += new System.EventHandler(this.produitToolStripMenuItem_Click);
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.cToolStripMenuItem.Text = "&Catégories";
            this.cToolStripMenuItem.Click += new System.EventHandler(this.cToolStripMenuItem_Click);
            // 
            // lieuToolStripMenuItem
            // 
            this.lieuToolStripMenuItem.Name = "lieuToolStripMenuItem";
            this.lieuToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.lieuToolStripMenuItem.Text = "&Lieux";
            this.lieuToolStripMenuItem.Click += new System.EventHandler(this.lieuToolStripMenuItem_Click);
            // 
            // panelSidebar
            // 
            this.panelSidebar.Controls.Add(this.btnNavAdmins);
            this.panelSidebar.Controls.Add(this.btnNavFournisseurs);
            this.panelSidebar.Controls.Add(this.btnNavClients);
            this.panelSidebar.Controls.Add(this.lblSecurite);
            this.panelSidebar.Controls.Add(this.btnNavFacture);
            this.panelSidebar.Controls.Add(this.btnNavCommande);
            this.panelSidebar.Controls.Add(this.lblCommerce);
            this.panelSidebar.Controls.Add(this.btnNavStock);
            this.panelSidebar.Controls.Add(this.btnNavLieux);
            this.panelSidebar.Controls.Add(this.btnNavUnites);
            this.panelSidebar.Controls.Add(this.btnNavCategories);
            this.panelSidebar.Controls.Add(this.btnNavProduits);
            this.panelSidebar.Controls.Add(this.panelSidebarHeader);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 30);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 569);
            this.panelSidebar.TabIndex = 2;
            // 
            // btnActionQuitter
            // 
            this.btnActionQuitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnActionQuitter.Location = new System.Drawing.Point(0, 481);
            this.btnActionQuitter.Name = "btnActionQuitter";
            this.btnActionQuitter.Size = new System.Drawing.Size(220, 44);
            this.btnActionQuitter.TabIndex = 5;
            this.btnActionQuitter.Text = "Quitter";
            this.btnActionQuitter.UseVisualStyleBackColor = true;
            this.btnActionQuitter.Click += new System.EventHandler(this.btnActionQuitter_Click);
            // 
            // btnActionDeconnexion
            // 
            this.btnActionDeconnexion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnActionDeconnexion.Location = new System.Drawing.Point(0, 525);
            this.btnActionDeconnexion.Name = "btnActionDeconnexion";
            this.btnActionDeconnexion.Size = new System.Drawing.Size(220, 44);
            this.btnActionDeconnexion.TabIndex = 4;
            this.btnActionDeconnexion.Text = "Déconnexion";
            this.btnActionDeconnexion.UseVisualStyleBackColor = true;
            this.btnActionDeconnexion.Click += new System.EventHandler(this.btnActionDeconnexion_Click);
            // 
            // btnNavLieux
            // 
            this.btnNavLieux.UseVisualStyleBackColor = true;
            this.btnNavLieux.Click += new System.EventHandler(this.btnNavLieux_Click);
            // 
            // btnNavUnites
            // 
            this.btnNavUnites.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavUnites.Location = new System.Drawing.Point(0, 196);
            this.btnNavUnites.Name = "btnNavUnites";
            this.btnNavUnites.Size = new System.Drawing.Size(220, 44);
            this.btnNavUnites.TabIndex = 9;
            this.btnNavUnites.Text = "Unités";
            this.btnNavUnites.UseVisualStyleBackColor = true;
            this.btnNavUnites.Click += new System.EventHandler(this.btnNavUnites_Click);
            // 
            // btnNavStock
            // 
            this.btnNavStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavStock.Location = new System.Drawing.Point(0, 240);
            this.btnNavStock.Name = "btnNavStock";
            this.btnNavStock.Size = new System.Drawing.Size(220, 44);
            this.btnNavStock.TabIndex = 10;
            this.btnNavStock.Text = "Stocks";
            this.btnNavStock.UseVisualStyleBackColor = true;
            this.btnNavStock.Click += new System.EventHandler(this.btnNavStock_Click);
            // 
            // lblCommerce
            // 
            this.lblCommerce.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCommerce.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCommerce.ForeColor = System.Drawing.Color.Gray;
            this.lblCommerce.Location = new System.Drawing.Point(0, 284);
            this.lblCommerce.Name = "lblCommerce";
            this.lblCommerce.Padding = new System.Windows.Forms.Padding(10, 20, 0, 5);
            this.lblCommerce.Size = new System.Drawing.Size(220, 45);
            this.lblCommerce.TabIndex = 11;
            this.lblCommerce.Text = "COMMERCE";
            // 
            // btnNavCommande
            // 
            this.btnNavCommande.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavCommande.Location = new System.Drawing.Point(0, 329);
            this.btnNavCommande.Name = "btnNavCommande";
            this.btnNavCommande.Size = new System.Drawing.Size(220, 44);
            this.btnNavCommande.TabIndex = 12;
            this.btnNavCommande.Text = "Commandes";
            this.btnNavCommande.UseVisualStyleBackColor = true;
            this.btnNavCommande.Click += new System.EventHandler(this.btnNavCommande_Click);
            // 
            // btnNavFacture
            // 
            this.btnNavFacture.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavFacture.Location = new System.Drawing.Point(0, 373);
            this.btnNavFacture.Name = "btnNavFacture";
            this.btnNavFacture.Size = new System.Drawing.Size(220, 44);
            this.btnNavFacture.TabIndex = 13;
            this.btnNavFacture.Text = "Factures";
            this.btnNavFacture.UseVisualStyleBackColor = true;
            this.btnNavFacture.Click += new System.EventHandler(this.btnNavFacture_Click);
            // 
            // btnNavCategories
            // 
            this.btnNavCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavCategories.Location = new System.Drawing.Point(0, 108);
            this.btnNavCategories.Name = "btnNavCategories";
            this.btnNavCategories.Size = new System.Drawing.Size(220, 44);
            this.btnNavCategories.TabIndex = 2;
            this.btnNavCategories.Text = "Catégories";
            this.btnNavCategories.UseVisualStyleBackColor = true;
            this.btnNavCategories.Click += new System.EventHandler(this.btnNavCategories_Click);
            // 
            // btnNavProduits
            // 
            this.btnNavProduits.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavProduits.Location = new System.Drawing.Point(0, 64);
            this.btnNavProduits.Name = "btnNavProduits";
            this.btnNavProduits.Size = new System.Drawing.Size(220, 44);
            this.btnNavProduits.TabIndex = 1;
            this.btnNavProduits.Text = "Produits";
            this.btnNavProduits.UseVisualStyleBackColor = true;
            this.btnNavProduits.Click += new System.EventHandler(this.btnNavProduits_Click);
            // 
            // lblSecurite
            // 
            this.lblSecurite.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSecurite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSecurite.ForeColor = System.Drawing.Color.Gray;
            this.lblSecurite.Location = new System.Drawing.Point(0, 196);
            this.lblSecurite.Name = "lblSecurite";
            this.lblSecurite.Padding = new System.Windows.Forms.Padding(10, 20, 0, 5);
            this.lblSecurite.Size = new System.Drawing.Size(220, 45);
            this.lblSecurite.Text = "SÉCURITÉ";
            // 
            // btnNavClients
            // 
            this.btnNavClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavClients.Location = new System.Drawing.Point(0, 241);
            this.btnNavClients.Name = "btnNavClients";
            this.btnNavClients.Size = new System.Drawing.Size(220, 44);
            this.btnNavClients.TabIndex = 6;
            this.btnNavClients.Text = "Clients";
            this.btnNavClients.UseVisualStyleBackColor = true;
            this.btnNavClients.Click += new System.EventHandler(this.btnNavClients_Click);
            // 
            // btnNavFournisseurs
            // 
            this.btnNavFournisseurs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavFournisseurs.Location = new System.Drawing.Point(0, 285);
            this.btnNavFournisseurs.Name = "btnNavFournisseurs";
            this.btnNavFournisseurs.Size = new System.Drawing.Size(220, 44);
            this.btnNavFournisseurs.TabIndex = 7;
            this.btnNavFournisseurs.Text = "Fournisseurs";
            this.btnNavFournisseurs.UseVisualStyleBackColor = true;
            this.btnNavFournisseurs.Click += new System.EventHandler(this.btnNavFournisseurs_Click);
            // 
            // btnNavAdmins
            // 
            this.btnNavAdmins.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavAdmins.Location = new System.Drawing.Point(0, 329);
            this.btnNavAdmins.Name = "btnNavAdmins";
            this.btnNavAdmins.Size = new System.Drawing.Size(220, 44);
            this.btnNavAdmins.TabIndex = 8;
            this.btnNavAdmins.Text = "Utilisateurs";
            this.btnNavAdmins.UseVisualStyleBackColor = true;
            this.btnNavAdmins.Click += new System.EventHandler(this.btnNavAdmins_Click);
            // 
            // panelSidebarHeader
            // 
            this.panelSidebarHeader.Controls.Add(this.lblSidebarTitle);
            this.panelSidebarHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSidebarHeader.Location = new System.Drawing.Point(0, 0);
            this.panelSidebarHeader.Name = "panelSidebarHeader";
            this.panelSidebarHeader.Size = new System.Drawing.Size(220, 64);
            this.panelSidebarHeader.TabIndex = 0;
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.AutoSize = true;
            this.lblSidebarTitle.Location = new System.Drawing.Point(12, 20);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(146, 25);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "Sen Agriculture";
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 599);
            this.ControlBox = false;
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMDI";
            this.Text = "Sen Agriculture :: Se connecter";
            this.Load += new System.EventHandler(this.frmMDI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebarHeader.ResumeLayout(false);
            this.panelSidebarHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paramettreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lieuToolStripMenuItem;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelSidebarHeader;
        private System.Windows.Forms.Label lblSidebarTitle;
        private System.Windows.Forms.Button btnNavProduits;
        private System.Windows.Forms.Button btnNavCategories;
        private System.Windows.Forms.Button btnNavLieux;
        private System.Windows.Forms.Button btnActionDeconnexion;
        private System.Windows.Forms.Button btnActionQuitter;
        private System.Windows.Forms.Button btnNavClients;
        private System.Windows.Forms.Button btnNavFournisseurs;
        private System.Windows.Forms.Button btnNavAdmins;
        private System.Windows.Forms.Label lblSecurite;
        private System.Windows.Forms.Button btnNavUnites;
        private System.Windows.Forms.Button btnNavStock;
        private System.Windows.Forms.Label lblCommerce;
        private System.Windows.Forms.Button btnNavCommande;
        private System.Windows.Forms.Button btnNavFacture;
    }
}