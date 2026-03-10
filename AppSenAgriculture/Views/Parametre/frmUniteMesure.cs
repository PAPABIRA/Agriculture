using System;
using System.Linq;
using System.Windows.Forms;
using AppSenAgriculture.Models;

namespace AppSenAgriculture.Views.Parametre
{
    public partial class frmUniteMesure : Form
    {
        private BdSenAgricultureContext _ctx = new BdSenAgricultureContext();
        private UniteMesure _selected = null;

        public frmUniteMesure()
        {
            InitializeComponent();
            ChargerDonnees();
        }

        private void ChargerDonnees()
        {
            try
            {
                var list = _ctx.UnitesMesure.ToList();
                dgv.DataSource = list;
                lblTotal.Text = $"Total : {list.Count} unité(s)";
                
                if (dgv.Columns["IdUniteMesure"] != null)
                    dgv.Columns["IdUniteMesure"].HeaderText = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement : " + ex.Message);
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is UniteMesure u)
            {
                _selected = u;
                txtLibelle.Text = u.Libelle;
                txtSymbole.Text = u.Symbole;
                btnModifier.Enabled = btnSupprimer.Enabled = true;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLibelle.Text))
            {
                MessageBox.Show("Le libellé est obligatoire.");
                return;
            }

            try
            {
                var u = new UniteMesure
                {
                    Libelle = txtLibelle.Text.Trim(),
                    Symbole = txtSymbole.Text.Trim()
                };
                _ctx.UnitesMesure.Add(u);
                _ctx.SaveChanges();
                ChargerDonnees();
                Vider();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            try
            {
                var u = _ctx.UnitesMesure.Find(_selected.IdUniteMesure);
                u.Libelle = txtLibelle.Text.Trim();
                u.Symbole = txtSymbole.Text.Trim();
                _ctx.SaveChanges();
                ChargerDonnees();
                Vider();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            if (MessageBox.Show("Supprimer cette unité ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var u = _ctx.UnitesMesure.Find(_selected.IdUniteMesure);
                    _ctx.UnitesMesure.Remove(u);
                    _ctx.SaveChanges();
                    ChargerDonnees();
                    Vider();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btnReset_Click(object sender, EventArgs e) => Vider();

        private void Vider()
        {
            txtLibelle.Clear();
            txtSymbole.Clear();
            _selected = null;
            btnModifier.Enabled = btnSupprimer.Enabled = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _ctx?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
