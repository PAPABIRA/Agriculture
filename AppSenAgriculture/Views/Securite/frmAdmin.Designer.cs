using System.Drawing;
using System.Windows.Forms;
using AppSenAgriculture.UI;

namespace AppSenAgriculture.Views.Securite
{
    partial class frmAdmin
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            pnlTop = new Panel(); lblTitre = new Label(); pnlForm = new Panel();
            lblNomPrenom = new Label(); txtNomPrenom = new TextBox();
            lblEmail = new Label(); txtEmail = new TextBox();
            lblLogin = new Label(); txtLogin = new TextBox();
            lblRole = new Label(); txtRole = new TextBox();
            btnAjouter = new Button(); btnModifier = new Button();
            btnSupprimer = new Button(); btnReset = new Button();
            dgv = new DataGridView(); lblTotal = new Label();

            pnlTop.BackColor = Color.FromArgb(13, 71, 161); pnlTop.Dock = DockStyle.Top; pnlTop.Height = 55;
            lblTitre.Text = "🛡  Gestion des Administrateurs"; lblTitre.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblTitre.ForeColor = Color.White; lblTitre.BackColor = Color.Transparent;
            lblTitre.Location = new Point(15, 13); lblTitre.Size = new Size(400, 28);
            pnlTop.Controls.Add(lblTitre);

            pnlForm.BackColor = Color.White; pnlForm.Dock = DockStyle.Left; pnlForm.Width = 310;
            int y = 15; int w = 260;
            void F(Label l, string t, TextBox tb) {
                l.Text = t; l.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold); l.ForeColor = AppTheme.DarkGray;
                l.Location = new Point(15, y); l.Size = new Size(w, 16); y += 18;
                tb.BorderStyle = BorderStyle.FixedSingle; tb.Font = AppTheme.NormalFont; tb.BackColor = AppTheme.LightGray;
                tb.Location = new Point(15, y); tb.Size = new Size(w, 26); y += 36;
            }
            F(lblNomPrenom, "Nom & Prénom *", txtNomPrenom); F(lblEmail, "Email", txtEmail);
            F(lblLogin, "Login *", txtLogin); F(lblRole, "Rôle", txtRole);
            txtRole.Text = "Admin";

            void B(Button b, string t, Color c, int x, int by) {
                b.Text = t; b.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold); b.BackColor = c; b.ForeColor = Color.White;
                b.FlatStyle = FlatStyle.Flat; b.FlatAppearance.BorderSize = 0; b.Cursor = Cursors.Hand;
                b.Location = new Point(x, by); b.Size = new Size(125, 32);
            }
            B(btnAjouter, "➕ Ajouter", Color.FromArgb(13,71,161), 15, y);
            B(btnModifier, "✏ Modifier", AppTheme.Warning, 150, y); y += 40;
            B(btnSupprimer, "🗑 Supprimer", AppTheme.Danger, 15, y);
            B(btnReset, "↺ Réinitialiser", AppTheme.MediumGray, 150, y);
            btnModifier.Enabled = btnSupprimer.Enabled = false;
            btnAjouter.Click += btnAjouter_Click; btnModifier.Click += btnModifier_Click;
            btnSupprimer.Click += btnSupprimer_Click; btnReset.Click += btnReset_Click;

            pnlForm.Controls.AddRange(new Control[] { lblNomPrenom, txtNomPrenom, lblEmail, txtEmail, lblLogin, txtLogin, lblRole, txtRole, btnAjouter, btnModifier, btnSupprimer, btnReset });

            dgv.Dock = DockStyle.Fill; dgv.BackgroundColor = Color.White; dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false; dgv.AllowUserToAddRows = false; dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(227, 242, 253);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(13, 71, 161);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 36; dgv.RowTemplate.Height = 32;
            dgv.SelectionChanged += dgv_SelectionChanged;

            lblTotal.Text = "Total : 0"; lblTotal.Font = AppTheme.SmallFont; lblTotal.ForeColor = AppTheme.MediumGray;
            lblTotal.Dock = DockStyle.Bottom; lblTotal.Height = 22; lblTotal.TextAlign = ContentAlignment.MiddleRight;

            this.AutoScaleDimensions = new SizeF(6F, 13F); this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = AppTheme.LightGray; this.ClientSize = new Size(1000, 650);
            this.Controls.Add(dgv); this.Controls.Add(lblTotal); this.Controls.Add(pnlForm); this.Controls.Add(pnlTop);
            this.Name = "frmAdmin"; this.Text = "Gestion des Administrateurs";
        }

        private Panel pnlTop, pnlForm;
        private Label lblTitre, lblNomPrenom, lblEmail, lblLogin, lblRole, lblTotal;
        private TextBox txtNomPrenom, txtEmail, txtLogin, txtRole;
        private Button btnAjouter, btnModifier, btnSupprimer, btnReset;
        private DataGridView dgv;
    }
}
