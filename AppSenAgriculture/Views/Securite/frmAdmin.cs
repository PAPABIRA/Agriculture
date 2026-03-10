using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AppSenAgriculture.Models;
using AppSenAgriculture.UI;

namespace AppSenAgriculture.Views.Securite
{
    public partial class frmAdmin : Form
    {
        private BdSenAgricultureContext _ctx = new BdSenAgricultureContext();
        private Admin _selected = null;

        public frmAdmin() { InitializeComponent(); ChargerDonnees(); }

        private void ChargerDonnees()
        {
            try { dgv.DataSource = _ctx.Admins.ToList(); lblTotal.Text = $"Total : {_ctx.Admins.Count()}"; }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgv_SelectionChanged(object s, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is Admin a)
            {
                _selected = a;
                txtNomPrenom.Text = a.NomPrenom; txtEmail.Text = a.Email;
                txtLogin.Text = a.Login; txtRole.Text = a.Role;
                btnModifier.Enabled = btnSupprimer.Enabled = true;
            }
        }

        private void btnAjouter_Click(object s, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomPrenom.Text) || string.IsNullOrWhiteSpace(txtLogin.Text)) return;
            _ctx.Admins.Add(new Admin { NomPrenom = txtNomPrenom.Text.Trim(), Email = txtEmail.Text.Trim(), Login = txtLogin.Text.Trim(), MotDePasse = "1234", Role = txtRole.Text.Trim() });
            _ctx.SaveChanges(); ChargerDonnees(); Vider();
        }

        private void btnModifier_Click(object s, EventArgs e)
        {
            if (_selected == null) return;
            var a = _ctx.Admins.Find(_selected.Id);
            a.NomPrenom = txtNomPrenom.Text.Trim(); a.Email = txtEmail.Text.Trim();
            a.Login = txtLogin.Text.Trim(); a.Role = txtRole.Text.Trim();
            _ctx.SaveChanges(); ChargerDonnees(); Vider();
        }

        private void btnSupprimer_Click(object s, EventArgs e)
        {
            if (_selected == null) return;
            if (MessageBox.Show($"Supprimer {_selected.NomPrenom} ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { _ctx.Admins.Remove(_ctx.Admins.Find(_selected.Id)); _ctx.SaveChanges(); ChargerDonnees(); Vider(); }
        }

        private void btnReset_Click(object s, EventArgs e) => Vider();
        private void Vider() { txtNomPrenom.Clear(); txtEmail.Clear(); txtLogin.Clear(); txtRole.Clear(); _selected = null; btnModifier.Enabled = btnSupprimer.Enabled = false; }
        protected override void OnFormClosing(FormClosingEventArgs e) { _ctx?.Dispose(); base.OnFormClosing(e); }
    }
}


