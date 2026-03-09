using System.Drawing;
using System.Windows.Forms;
using AppSenAgriculture.UI;

namespace AppSenAgriculture.Views.Securite
{
    partial class frmClient
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Déclarations
            this.pnlTop        = new Panel();
            this.lblTitre      = new Label();
            this.txtRecherche  = new TextBox();
            this.lblRecherche  = new Label();
            this.pnlForm       = new Panel();
            this.lblNomPrenom  = new Label();
            this.txtNomPrenom  = new TextBox();
            this.lblAdresse    = new Label();
            this.txtAdresse    = new TextBox();
            this.lblEmail      = new Label();
            this.txtEmail      = new TextBox();
            this.lblTelephone  = new Label();
            this.txtTelephone  = new TextBox();
            this.lblIdentifiant= new Label();
            this.txtIdentifiant= new TextBox();
            this.lblProfession = new Label();
            this.txtProfession = new TextBox();
            this.pnlBoutons    = new Panel();
            this.btnAjouter    = new Button();
            this.btnModifier   = new Button();
            this.btnSupprimer  = new Button();
            this.btnBloquer    = new Button();
            this.btnDebloquer  = new Button();
            this.btnReinitialiser = new Button();
            this.btnImprimer   = new Button();
            this.dgvClients    = new DataGridView();
            this.lblTotal      = new Label();
            this.pnlTop.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlBoutons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvClients).BeginInit();
            this.SuspendLayout();

            // ── pnlTop ─────────────────────────────────────────
            pnlTop.BackColor = AppTheme.PrimaryGreen;
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 55;
            pnlTop.Controls.Add(lblTitre);
            pnlTop.Controls.Add(txtRecherche);
            pnlTop.Controls.Add(lblRecherche);

            lblTitre.Text = "🔒  Gestion des Clients";
            lblTitre.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblTitre.ForeColor = Color.White;
            lblTitre.Location = new Point(15, 13);
            lblTitre.Size = new Size(320, 28);
            lblTitre.BackColor = Color.Transparent;

            lblRecherche.Text = "🔍";
            lblRecherche.Font = new Font("Segoe UI", 11f);
            lblRecherche.ForeColor = Color.White;
            lblRecherche.BackColor = Color.Transparent;
            lblRecherche.Location = new Point(600, 17);
            lblRecherche.Size = new Size(25, 22);

            txtRecherche.BorderStyle = BorderStyle.FixedSingle;
            txtRecherche.Font = AppTheme.NormalFont;
            txtRecherche.BackColor = Color.White;
            txtRecherche.Location = new Point(630, 16);
            txtRecherche.Size = new Size(220, 24);
            txtRecherche.PlaceholderText = "Rechercher un client...";
            txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);

            // ── pnlForm (gauche) ───────────────────────────────
            pnlForm.BackColor = Color.White;
            pnlForm.Dock = DockStyle.Left;
            pnlForm.Width = 310;
            pnlForm.Padding = new Padding(15);

            int ly = 20;
            int lw = 260;

            void AddField(Label lbl, string text, TextBox txt, ref int y)
            {
                lbl.Text = text;
                lbl.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
                lbl.ForeColor = AppTheme.DarkGray;
                lbl.Location = new Point(15, y);
                lbl.Size = new Size(lw, 16);
                y += 18;

                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = AppTheme.NormalFont;
                txt.BackColor = AppTheme.LightGray;
                txt.Location = new Point(15, y);
                txt.Size = new Size(lw, 26);
                y += 34;
            }

            AddField(lblNomPrenom,  "Nom & Prénom *", txtNomPrenom,  ref ly);
            AddField(lblAdresse,    "Adresse",        txtAdresse,    ref ly);
            AddField(lblEmail,      "Email",          txtEmail,      ref ly);
            AddField(lblTelephone,  "Téléphone",      txtTelephone,  ref ly);
            AddField(lblIdentifiant,"Identifiant",    txtIdentifiant,ref ly);
            AddField(lblProfession, "Profession",     txtProfession, ref ly);

            pnlForm.Controls.AddRange(new Control[] {
                lblNomPrenom, txtNomPrenom, lblAdresse, txtAdresse,
                lblEmail, txtEmail, lblTelephone, txtTelephone,
                lblIdentifiant, txtIdentifiant, lblProfession, txtProfession
            });

            // ── pnlBoutons (sous le form gauche) ──────────────
            pnlBoutons.BackColor = Color.White;
            pnlBoutons.Dock = DockStyle.Bottom;
            pnlBoutons.Height = 110;
            pnlBoutons.Parent = pnlForm;

            void StyleBtn(Button b, string text, Color color, int x, int y2, int w = 125)
            {
                b.Text = text;
                b.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
                b.BackColor = color;
                b.ForeColor = Color.White;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Cursor = Cursors.Hand;
                b.Location = new Point(x, y2);
                b.Size = new Size(w, 32);
            }

            StyleBtn(btnAjouter,      "➕ Ajouter",       AppTheme.PrimaryGreen,  15,  15);
            StyleBtn(btnModifier,     "✏ Modifier",       AppTheme.Warning,       150, 15);
            StyleBtn(btnSupprimer,    "🗑 Supprimer",      AppTheme.Danger,        15,  55);
            StyleBtn(btnReinitialiser,"↺ Réinitialiser",  AppTheme.MediumGray,    150, 55);
            StyleBtn(btnImprimer,     "🖨 Imprimer",       AppTheme.DarkGray,      15,  95, 260);

            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnBloquer.Enabled = false;
            btnDebloquer.Enabled = false;

            btnAjouter.Click     += new System.EventHandler(this.btnAjouter_Click);
            btnModifier.Click    += new System.EventHandler(this.btnModifier_Click);
            btnSupprimer.Click   += new System.EventHandler(this.btnSupprimer_Click);
            btnReinitialiser.Click += new System.EventHandler(this.btnReinitialiser_Click);
            btnImprimer.Click    += new System.EventHandler(this.btnImprimer_Click);

            // Boutons Bloquer/Débloquer séparés dans pnlForm
            StyleBtn(btnBloquer,   "🚫 Bloquer",   Color.FromArgb(183, 28, 28), 15,  130);
            StyleBtn(btnDebloquer, "✅ Débloquer",  Color.FromArgb(27, 94, 32),  150, 130);

            btnBloquer.Click   += new System.EventHandler(this.btnBloquer_Click);
            btnDebloquer.Click += new System.EventHandler(this.btnDebloquer_Click);

            pnlForm.Controls.AddRange(new Control[] {
                btnAjouter, btnModifier, btnSupprimer, btnReinitialiser, btnImprimer,
                btnBloquer, btnDebloquer
            });

            // ── DataGridView ───────────────────────────────────
            dgvClients.Dock = DockStyle.Fill;
            dgvClients.BackgroundColor = Color.White;
            dgvClients.BorderStyle = BorderStyle.None;
            dgvClients.GridColor = AppTheme.PaleGreen;
            dgvClients.RowHeadersVisible = false;
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.ReadOnly = true;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.Font = AppTheme.NormalFont;
            dgvClients.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.PaleGreen;
            dgvClients.ColumnHeadersDefaultCellStyle.ForeColor = AppTheme.PrimaryGreen;
            dgvClients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvClients.ColumnHeadersHeight = 36;
            dgvClients.RowTemplate.Height = 32;
            dgvClients.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 253, 248);
            dgvClients.SelectionChanged += new System.EventHandler(this.dgvClients_SelectionChanged);

            // ── lblTotal ───────────────────────────────────────
            lblTotal.Text = "Total : 0 client(s)";
            lblTotal.Font = AppTheme.SmallFont;
            lblTotal.ForeColor = AppTheme.MediumGray;
            lblTotal.Dock = DockStyle.Bottom;
            lblTotal.Height = 22;
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            lblTotal.Padding = new Padding(0, 0, 10, 0);

            // ── Form ────────────────────────────────────────────
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = AppTheme.LightGray;
            this.ClientSize = new Size(1000, 650);
            this.Controls.Add(dgvClients);
            this.Controls.Add(lblTotal);
            this.Controls.Add(pnlForm);
            this.Controls.Add(pnlTop);
            this.Name = "frmClient";
            this.Text = "Gestion des Clients";

            pnlTop.ResumeLayout(false);
            pnlForm.ResumeLayout(false);
            pnlBoutons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvClients).EndInit();
            this.ResumeLayout(false);
        }

        // Contrôles
        private Panel pnlTop, pnlForm, pnlBoutons;
        private Label lblTitre, lblRecherche, lblNomPrenom, lblAdresse, lblEmail;
        private Label lblTelephone, lblIdentifiant, lblProfession, lblTotal;
        private TextBox txtRecherche, txtNomPrenom, txtAdresse, txtEmail;
        private TextBox txtTelephone, txtIdentifiant, txtProfession;
        private Button btnAjouter, btnModifier, btnSupprimer, btnBloquer;
        private Button btnDebloquer, btnReinitialiser, btnImprimer;
        private DataGridView dgvClients;
    }
}
