using System;
using System.Linq;
using System.Windows.Forms;
using AppSenAgriculture.Models;

namespace AppSenAgriculture.Views
{
    public partial class frmFacture : Form
    {
        private BdSenAgricultureContext _ctx = new BdSenAgricultureContext();
        private Facture _selected = null;

        public frmFacture()
        {
            InitializeComponent();
            ChargerDonnees();
        }

        private void ChargerDonnees()
        {
            try
            {
                var list = _ctx.Factures.ToList();
                dgv.DataSource = list;
                lblTotal.Text = $"Total : {list.Count} facture(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement : " + ex.Message);
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is Facture f)
            {
                _selected = f;
                dtpDate.Value = f.Date;
                btnModifier.Enabled = btnSupprimer.Enabled = true;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new Facture
                {
                    Date = dtpDate.Value
                };
                _ctx.Factures.Add(f);
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
                var f = _ctx.Factures.Find(_selected.IdFact);
                f.Date = dtpDate.Value;
                _ctx.SaveChanges();
                ChargerDonnees();
                Vider();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            if (MessageBox.Show("Supprimer cette facture ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var f = _ctx.Factures.Find(_selected.IdFact);
                    _ctx.Factures.Remove(f);
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
            dtpDate.Value = DateTime.Now;
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
