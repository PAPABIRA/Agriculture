using System.Drawing;
using System.Windows.Forms;
using AppSenAgriculture.UI;

namespace AppSenAgriculture.Views
{
    partial class frmFacture
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new Panel();
            this.lblTitre = new Label();
            this.pnlForm = new Panel();
            this.lblDate = new Label();
            this.dtpDate = new DateTimePicker();
            this.btnAjouter = new Button();
            this.btnModifier = new Button();
            this.btnSupprimer = new Button();
            this.btnReset = new Button();
            this.dgv = new DataGridView();
            this.lblTotal = new Label();

            this.pnlTop.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();

            // ── pnlTop ─────────────────────────────────────────
            this.pnlTop.BackColor = AppTheme.PrimaryGreen;
            this.pnlTop.Controls.Add(this.lblTitre);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 55;

            this.lblTitre.Text = "🧾  Gestion des Factures";
            this.lblTitre.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            this.lblTitre.ForeColor = Color.White;
            this.lblTitre.Location = new Point(15, 13);
            this.lblTitre.Size = new Size(300, 28);

            // ── pnlForm ────────────────────────────────────────
            this.pnlForm.BackColor = Color.White;
            this.pnlForm.Dock = DockStyle.Left;
            this.pnlForm.Width = 310;
            this.pnlForm.Padding = new Padding(15);

            int y = 20;
            int w = 260;

            this.lblDate.Text = "Date *";
            this.lblDate.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            this.lblDate.ForeColor = AppTheme.DarkGray;
            this.lblDate.Location = new Point(15, y);
            this.lblDate.Size = new Size(w, 16);
            y += 18;

            this.dtpDate.Format = DateTimePickerFormat.Short;
            this.dtpDate.Location = new Point(15, y);
            this.dtpDate.Size = new Size(w, 26);
            y += 40;

            void StyleBtn(Button b, string text, Color color, int x, int by)
            {
                b.Text = text;
                b.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
                b.BackColor = color;
                b.ForeColor = Color.White;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Cursor = Cursors.Hand;
                b.Location = new Point(x, by);
                b.Size = new Size(125, 32);
            }

            StyleBtn(this.btnAjouter, "➕ Ajouter", AppTheme.PrimaryGreen, 15, y);
            StyleBtn(this.btnModifier, "✏ Modifier", AppTheme.Warning, 150, y);
            y += 40;
            StyleBtn(this.btnSupprimer, "🗑 Supprimer", AppTheme.Danger, 15, y);
            StyleBtn(this.btnReset, "↺ Réinitialiser", AppTheme.MediumGray, 150, y);

            this.btnModifier.Enabled = this.btnSupprimer.Enabled = false;

            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            this.pnlForm.Controls.AddRange(new Control[] {
                this.lblDate, this.dtpDate,
                this.btnAjouter, this.btnModifier, this.btnSupprimer, this.btnReset
            });

            // ── DataGridView ───────────────────────────────────
            this.dgv.Dock = DockStyle.Fill;
            this.dgv.BackgroundColor = Color.White;
            this.dgv.BorderStyle = BorderStyle.None;
            this.dgv.RowHeadersVisible = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.PaleGreen;
            this.dgv.ColumnHeadersDefaultCellStyle.ForeColor = AppTheme.PrimaryGreen;
            this.dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            this.dgv.RowTemplate.Height = 32;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);

            // ── lblTotal ───────────────────────────────────────
            this.lblTotal.Dock = DockStyle.Bottom;
            this.lblTotal.Height = 25;
            this.lblTotal.TextAlign = ContentAlignment.MiddleRight;
            this.lblTotal.Padding = new Padding(0, 0, 10, 0);
            this.lblTotal.ForeColor = AppTheme.MediumGray;
            this.lblTotal.Font = AppTheme.SmallFont;
            this.lblTotal.Text = "Total : 0 facture(s)";

            // ── Form ────────────────────────────────────────────
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = AppTheme.LightGray;
            this.ClientSize = new Size(800, 500);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmFacture";
            this.Text = "Gestion des Factures";

            this.pnlTop.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
        }

        private Panel pnlTop, pnlForm;
        private Label lblTitre, lblDate, lblTotal;
        private DateTimePicker dtpDate;
        private Button btnAjouter, btnModifier, btnSupprimer, btnReset;
        private DataGridView dgv;
    }
}
