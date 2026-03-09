using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AppSenAgriculture.Models;
using AppSenAgriculture.UI;

namespace AppSenAgriculture.Views.Securite
{
    public partial class frmFacilitateur : Form
    {
        private BdSenAgricultureContext _ctx = new BdSenAgricultureContext();
        private Facilitateur _selected = null;

        public frmFacilitateur() { InitializeComponent(); ChargerDonnees(); }

        private void ChargerDonnees()
        {
            try
            {
                dgv.DataSource = _ctx.Facilitateurs.ToList();
                lblTotal.Text = $"Total : {_ctx.Facilitateurs.Count()} facilitateur(s)";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgv_SelectionChanged(object s, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is Facilitateur f)
            {
                _selected = f;
                txtNomPrenom.Text = f.NomPrenom;
                txtAdresse.Text = f.Adresse;
                txtEmail.Text = f.Email;
                txtTelephone.Text = f.Telephone;
                txtIdentifiant.Text = f.Identifiant;
                txtZone.Text = f.ZoneIntervention;
                btnModifier.Enabled = btnSupprimer.Enabled = true;
            }
        }

        private void btnAjouter_Click(object s, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomPrenom.Text)) return;
            _ctx.Facilitateurs.Add(new Facilitateur
            {
                NomPrenom = txtNomPrenom.Text.Trim(),
                Adresse = txtAdresse.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telephone = txtTelephone.Text.Trim(),
                Identifiant = txtIdentifiant.Text.Trim(),
                ZoneIntervention = txtZone.Text.Trim()
            });
            _ctx.SaveChanges(); ChargerDonnees(); Vider();
        }

        private void btnModifier_Click(object s, EventArgs e)
        {
            if (_selected == null) return;
            var f = _ctx.Facilitateurs.Find(_selected.Id);
            f.NomPrenom = txtNomPrenom.Text.Trim();
            f.Adresse = txtAdresse.Text.Trim();
            f.Email = txtEmail.Text.Trim();
            f.Telephone = txtTelephone.Text.Trim();
            f.Identifiant = txtIdentifiant.Text.Trim();
            f.ZoneIntervention = txtZone.Text.Trim();
            _ctx.SaveChanges(); ChargerDonnees(); Vider();
        }

        private void btnSupprimer_Click(object s, EventArgs e)
        {
            if (_selected == null) return;
            if (MessageBox.Show($"Supprimer {_selected.NomPrenom} ?", "Confirmation",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _ctx.Facilitateurs.Remove(_ctx.Facilitateurs.Find(_selected.Id));
                _ctx.SaveChanges(); ChargerDonnees(); Vider();
            }
        }

        private void btnReset_Click(object s, EventArgs e) => Vider();

        private void Vider()
        {
            txtNomPrenom.Clear(); txtAdresse.Clear(); txtEmail.Clear();
            txtTelephone.Clear(); txtIdentifiant.Clear(); txtZone.Clear();
            _selected = null;
            btnModifier.Enabled = btnSupprimer.Enabled = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e) { _ctx?.Dispose(); base.OnFormClosing(e); }
    }
}
