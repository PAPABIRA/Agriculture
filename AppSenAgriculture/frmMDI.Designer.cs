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
            this.panelSidebar.Controls.Add(this.btnActionQuitter);
            this.panelSidebar.Controls.Add(this.btnActionDeconnexion);
            this.panelSidebar.Controls.Add(this.btnNavLieux);
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
            this.btnNavLieux.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavLieux.Location = new System.Drawing.Point(0, 152);
            this.btnNavLieux.Name = "btnNavLieux";
            this.btnNavLieux.Size = new System.Drawing.Size(220, 44);
            this.btnNavLieux.TabIndex = 3;
            this.btnNavLieux.Text = "Lieux";
            this.btnNavLieux.UseVisualStyleBackColor = true;
            this.btnNavLieux.Click += new System.EventHandler(this.btnNavLieux_Click);
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
    }
}