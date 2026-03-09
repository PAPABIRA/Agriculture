using System.Drawing;
using System.Windows.Forms;
using AppSenAgriculture.UI;

namespace AppSenAgriculture.Views.Securite
{
    partial class frmFacilitateur
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            pnlTop = new Panel(); lblTitre = new Label();
            pnlForm = new Panel();
            lblNomPrenom = new Label(); txtNomPrenom = new TextBox();
            lblAdresse = new Label(); txtAdresse = new TextBox();
            lblEmail = new Label(); txtEmail = new TextBox();
            lblTelephone = new Label(); txtTelephone = new TextBox();
            lblIdentifiant = new Label(); txtIdentifiant = new TextBox();
            lblZone = new Label(); txtZone = new TextBox();
            btnAjouter = new Button(); btnModifier = new Button();
            btnSupprimer = new Button(); btnReset = new Button();
            dgv = new DataGridView(); lblTotal = new Label();

            pnlTop.BackColor = Color.FromArgb(27, 94, 32);
            pnlTop.Dock = DockStyle.Top; pnlTop.Height = 55;
            lblTitre.Text = "👥  Gestion des Facilitateurs";
            lblTitre.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblTitre.ForeColor = Color.White; lblTitre.BackColor = Color.Transparent;
            lblTitre.Location = new Point(15, 13); lblTitre.Size = new Size(380, 28);
            pnlTop.Controls.Add(lblTitre);

            pnlForm.BackColor = Color.White; pnlForm.Dock = DockStyle.Left; pnlForm.Width = 310;

            int y = 15; int w = 260;
            void Field(Label l, string t, TextBox tb) {
                l.Text = t; l.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
                l.ForeColor = AppTheme.DarkGray; l.Location = new Point(15, y); l.Size = new Size(w, 16); y += 18;
                tb.BorderStyle = BorderStyle.FixedSingle; tb.Font = AppTheme.NormalFont;
                tb.BackColor = AppTheme.LightGray; tb.Location = new Point(15, y); tb.Size = new Size(w, 26); y += 36;
            }
            Field(lblNomPrenom, "Nom & Prénom *", txtNomPrenom);
            Field(lblAdresse, "Adresse", txtAdresse);
            Field(lblEmail, "Email", txtEmail);
            Field(lblTelephone, "Téléphone", txtTelephone);
            Field(lblIdentifiant, "Identifiant", txtIdentifiant);
            Field(lblZone, "Zone d'intervention", txtZone);

            void Btn(Button b, string t, Color c, int x, int by) {
                b.Text = t; b.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
                b.BackColor = c; b.ForeColor = Color.White; b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0; b.Cursor = Cursors.Hand;
                b.Location = new Point(x, by); b.Size = new Size(125, 32);
            }
            Btn(btnAjouter, "➕ Ajouter", AppTheme.PrimaryGreen, 15, y);
            Btn(btnModifier, "✏ Modifier", AppTheme.Warning, 150, y); y += 40;
            Btn(btnSupprimer, "🗑 Supprimer", AppTheme.Danger, 15, y);
            Btn(btnReset, "↺ Réinitialiser", AppTheme.MediumGray, 150, y);
            btnModifier.Enabled = btnSupprimer.Enabled = false;
            btnAjouter.Click += btnAjouter_Click; btnModifier.Click += btnModifier_Click;
            btnSupprimer.Click += btnSupprimer_Click; btnReset.Click += btnReset_Click;

            pnlForm.Controls.AddRange(new Control[] { lblNomPrenom, txtNomPrenom, lblAdresse, txtAdresse, lblEmail, txtEmail, lblTelephone, txtTelephone, lblIdentifiant, txtIdentifiant, lblZone, txtZone, btnAjouter, btnModifier, btnSupprimer, btnReset });

            dgv.Dock = DockStyle.Fill; dgv.BackgroundColor = Color.White; dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false; dgv.AllowUserToAddRows = false; dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.PaleGreen;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = AppTheme.PrimaryGreen;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 36; dgv.RowTemplate.Height = 32;
            dgv.SelectionChanged += dgv_SelectionChanged;

            lblTotal.Text = "Total : 0"; lblTotal.Font = AppTheme.SmallFont;
            lblTotal.ForeColor = AppTheme.MediumGray; lblTotal.Dock = DockStyle.Bottom;
            lblTotal.Height = 22; lblTotal.TextAlign = ContentAlignment.MiddleRight;

            this.AutoScaleDimensions = new SizeF(6F, 13F); this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = AppTheme.LightGray; this.ClientSize = new Size(1000, 650);
            this.Controls.Add(dgv); this.Controls.Add(lblTotal); this.Controls.Add(pnlForm); this.Controls.Add(pnlTop);
            this.Name = "frmFacilitateur"; this.Text = "Gestion des Facilitateurs";
        }

        private Panel pnlTop, pnlForm;
        private Label lblTitre, lblNomPrenom, lblAdresse, lblEmail, lblTelephone, lblIdentifiant, lblZone, lblTotal;
        private TextBox txtNomPrenom, txtAdresse, txtEmail, txtTelephone, txtIdentifiant, txtZone;
        private Button btnAjouter, btnModifier, btnSupprimer, btnReset;
        private DataGridView dgv;
    }
}
