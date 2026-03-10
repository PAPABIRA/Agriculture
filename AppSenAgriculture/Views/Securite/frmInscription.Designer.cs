namespace AppSenAgriculture.Views.Securite
{
    partial class frmInscription
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelReg = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnSInscrire = new System.Windows.Forms.Button();
            this.panelReg.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelReg
            // 
            this.panelReg.BackColor = System.Drawing.Color.White;
            this.panelReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReg.Controls.Add(this.labelTitle);
            this.panelReg.Controls.Add(this.lblNom);
            this.panelReg.Controls.Add(this.txtNom);
            this.panelReg.Controls.Add(this.lblEmail);
            this.panelReg.Controls.Add(this.txtEmail);
            this.panelReg.Controls.Add(this.lblLogin);
            this.panelReg.Controls.Add(this.txtLogin);
            this.panelReg.Controls.Add(this.lblPass);
            this.panelReg.Controls.Add(this.txtPass);
            this.panelReg.Controls.Add(this.lblConfirm);
            this.panelReg.Controls.Add(this.txtConfirm);
            this.panelReg.Controls.Add(this.btnAnnuler);
            this.panelReg.Controls.Add(this.btnSInscrire);
            this.panelReg.Location = new System.Drawing.Point(50, 20);
            this.panelReg.Name = "panelReg";
            this.panelReg.Size = new System.Drawing.Size(531, 480);
            this.panelReg.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.labelTitle.Location = new System.Drawing.Point(100, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(260, 31);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Nouvel Administrateur";
            // 
            // lblNom
            // 
            this.lblNom.Location = new System.Drawing.Point(30, 65);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(150, 20);
            this.lblNom.Text = "Nom complet :";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(30, 85);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(340, 26);
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(30, 125);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(150, 20);
            this.lblEmail.Text = "Email :";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(30, 145);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(340, 26);
            // 
            // lblLogin
            // 
            this.lblLogin.Location = new System.Drawing.Point(30, 185);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(150, 20);
            this.lblLogin.Text = "Identifiant (Login) :";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(30, 205);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(340, 26);
            // 
            // lblPass
            // 
            this.lblPass.Location = new System.Drawing.Point(30, 245);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(150, 20);
            this.lblPass.Text = "Mot de passe :";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(30, 265);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(340, 26);
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // lblConfirm
            // 
            this.lblConfirm.Location = new System.Drawing.Point(30, 305);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(150, 20);
            this.lblConfirm.Text = "Confirmer :";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Location = new System.Drawing.Point(30, 325);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(340, 26);
            this.txtConfirm.UseSystemPasswordChar = true;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.btnAnnuler.Location = new System.Drawing.Point(30, 385);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(150, 35);
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnSInscrire
            // 
            this.btnSInscrire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSInscrire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSInscrire.ForeColor = System.Drawing.Color.White;
            this.btnSInscrire.Location = new System.Drawing.Point(220, 385);
            this.btnSInscrire.Name = "btnSInscrire";
            this.btnSInscrire.Size = new System.Drawing.Size(150, 35);
            this.btnSInscrire.Text = "S\'inscrire";
            this.btnSInscrire.Click += new System.EventHandler(this.btnSInscrire_Click);
            // 
            // frmInscription
            // 
            this.ClientSize = new System.Drawing.Size(631, 550);
            this.Controls.Add(this.panelReg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmInscription";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sen Agriculture :: Inscription";
            this.panelReg.ResumeLayout(false);
            this.panelReg.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelReg;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnSInscrire;
    }
}
