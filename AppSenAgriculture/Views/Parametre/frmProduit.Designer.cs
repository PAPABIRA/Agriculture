namespace AppSenAgriculture.Views.Parametre
{
    partial class frmProduit
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelFormulaire = new System.Windows.Forms.Panel();
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblLibelle = new System.Windows.Forms.Label();
            this.txtLibelle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblPrixMin = new System.Windows.Forms.Label();
            this.txtPrixMin = new System.Windows.Forms.TextBox();
            this.lblPrixMax = new System.Windows.Forms.Label();
            this.txtPrixMax = new System.Windows.Forms.TextBox();
            this.lblCategorie = new System.Windows.Forms.Label();
            this.cboCategorie = new System.Windows.Forms.ComboBox();
            this.panelBoutons = new System.Windows.Forms.Panel();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.gridProduits = new System.Windows.Forms.DataGridView();
            this.panelFormulaire.SuspendLayout();
            this.panelBoutons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProduits)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFormulaire
            // 
            this.panelFormulaire.BackColor = System.Drawing.Color.White;
            this.panelFormulaire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFormulaire.Controls.Add(this.lblTitre);
            this.panelFormulaire.Controls.Add(this.lblLibelle);
            this.panelFormulaire.Controls.Add(this.txtLibelle);
            this.panelFormulaire.Controls.Add(this.lblDescription);
            this.panelFormulaire.Controls.Add(this.txtDescription);
            this.panelFormulaire.Controls.Add(this.lblPrixMin);
            this.panelFormulaire.Controls.Add(this.txtPrixMin);
            this.panelFormulaire.Controls.Add(this.lblPrixMax);
            this.panelFormulaire.Controls.Add(this.txtPrixMax);
            this.panelFormulaire.Controls.Add(this.lblCategorie);
            this.panelFormulaire.Controls.Add(this.cboCategorie);
            this.panelFormulaire.Controls.Add(this.panelBoutons);
            this.panelFormulaire.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFormulaire.Location = new System.Drawing.Point(0, 0);
            this.panelFormulaire.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelFormulaire.Name = "panelFormulaire";
            this.panelFormulaire.Size = new System.Drawing.Size(1200, 246);
            this.panelFormulaire.TabIndex = 0;
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTitre.Location = new System.Drawing.Point(27, 12);
            this.lblTitre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(207, 29);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Gestion Produits";
            // 
            // lblLibelle
            // 
            this.lblLibelle.AutoSize = true;
            this.lblLibelle.Location = new System.Drawing.Point(27, 55);
            this.lblLibelle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLibelle.Name = "lblLibelle";
            this.lblLibelle.Size = new System.Drawing.Size(50, 16);
            this.lblLibelle.TabIndex = 1;
            this.lblLibelle.Text = "Libellé:";
            // 
            // txtLibelle
            // 
            this.txtLibelle.Location = new System.Drawing.Point(107, 52);
            this.txtLibelle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(265, 22);
            this.txtLibelle.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(27, 92);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(78, 16);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(107, 89);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(332, 48);
            this.txtDescription.TabIndex = 4;
            // 
            // lblPrixMin
            // 
            this.lblPrixMin.AutoSize = true;
            this.lblPrixMin.Location = new System.Drawing.Point(467, 55);
            this.lblPrixMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrixMin.Name = "lblPrixMin";
            this.lblPrixMin.Size = new System.Drawing.Size(101, 16);
            this.lblPrixMin.TabIndex = 5;
            this.lblPrixMin.Text = "Prix Min (FCFA):";
            // 
            // txtPrixMin
            // 
            this.txtPrixMin.Location = new System.Drawing.Point(587, 52);
            this.txtPrixMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrixMin.Name = "txtPrixMin";
            this.txtPrixMin.Size = new System.Drawing.Size(132, 22);
            this.txtPrixMin.TabIndex = 6;
            // 
            // lblPrixMax
            // 
            this.lblPrixMax.AutoSize = true;
            this.lblPrixMax.Location = new System.Drawing.Point(467, 92);
            this.lblPrixMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrixMax.Name = "lblPrixMax";
            this.lblPrixMax.Size = new System.Drawing.Size(105, 16);
            this.lblPrixMax.TabIndex = 7;
            this.lblPrixMax.Text = "Prix Max (FCFA):";
            // 
            // txtPrixMax
            // 
            this.txtPrixMax.Location = new System.Drawing.Point(587, 89);
            this.txtPrixMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrixMax.Name = "txtPrixMax";
            this.txtPrixMax.Size = new System.Drawing.Size(132, 22);
            this.txtPrixMax.TabIndex = 8;
            // 
            // lblCategorie
            // 
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Location = new System.Drawing.Point(467, 129);
            this.lblCategorie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategorie.Name = "lblCategorie";
            this.lblCategorie.Size = new System.Drawing.Size(69, 16);
            this.lblCategorie.TabIndex = 9;
            this.lblCategorie.Text = "Catégorie:";
            // 
            // cboCategorie
            // 
            this.cboCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategorie.FormattingEnabled = true;
            this.cboCategorie.Location = new System.Drawing.Point(547, 126);
            this.cboCategorie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboCategorie.Name = "cboCategorie";
            this.cboCategorie.Size = new System.Drawing.Size(265, 24);
            this.cboCategorie.TabIndex = 10;
            // 
            // panelBoutons
            // 
            this.panelBoutons.Controls.Add(this.btnNouveau);
            this.panelBoutons.Controls.Add(this.btnEnregistrer);
            this.panelBoutons.Controls.Add(this.btnSupprimer);
            this.panelBoutons.Location = new System.Drawing.Point(830, 47);
            this.panelBoutons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelBoutons.Name = "panelBoutons";
            this.panelBoutons.Size = new System.Drawing.Size(307, 98);
            this.panelBoutons.TabIndex = 11;
            // 
            // btnNouveau
            // 
            this.btnNouveau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnNouveau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouveau.ForeColor = System.Drawing.Color.White;
            this.btnNouveau.Location = new System.Drawing.Point(13, 12);
            this.btnNouveau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(87, 37);
            this.btnNouveau.TabIndex = 0;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = false;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.Location = new System.Drawing.Point(113, 12);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(87, 37);
            this.btnEnregistrer.TabIndex = 1;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(213, 12);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(87, 37);
            this.btnSupprimer.TabIndex = 2;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // gridProduits
            // 
            this.gridProduits.AllowUserToAddRows = false;
            this.gridProduits.AllowUserToDeleteRows = false;
            this.gridProduits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProduits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridProduits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProduits.Location = new System.Drawing.Point(16, 258);
            this.gridProduits.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridProduits.MultiSelect = false;
            this.gridProduits.Name = "gridProduits";
            this.gridProduits.ReadOnly = true;
            this.gridProduits.RowHeadersWidth = 51;
            this.gridProduits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProduits.Size = new System.Drawing.Size(1168, 455);
            this.gridProduits.TabIndex = 1;
            this.gridProduits.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            // 
            // frmProduit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1200, 738);
            this.Controls.Add(this.gridProduits);
            this.Controls.Add(this.panelFormulaire);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmProduit";
            this.Text = "Gestion des Produits";
            this.panelFormulaire.ResumeLayout(false);
            this.panelFormulaire.PerformLayout();
            this.panelBoutons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProduits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFormulaire;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblLibelle;
        private System.Windows.Forms.TextBox txtLibelle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPrixMin;
        private System.Windows.Forms.TextBox txtPrixMin;
        private System.Windows.Forms.Label lblPrixMax;
        private System.Windows.Forms.TextBox txtPrixMax;
        private System.Windows.Forms.Label lblCategorie;
        private System.Windows.Forms.ComboBox cboCategorie;
        private System.Windows.Forms.Panel panelBoutons;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.DataGridView gridProduits;
    }
}