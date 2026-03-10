using System;
using System.Linq;
using System.Windows.Forms;
using AppSenAgriculture.Models;

namespace AppSenAgriculture.Views
{
    public partial class frmStock : Form
    {
        private BdSenAgricultureContext _ctx = new BdSenAgricultureContext();
        private Stock _selected = null;

        public frmStock()
        {
            InitializeComponent();
            ChargerDonnees();
        }

        private void ChargerDonnees()
        {
            try
            {
                var list = _ctx.Stocks.ToList();
                dgv.DataSource = list;
                lblTotal.Text = $"Total : {list.Count} entrée(s) de stock";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement : " + ex.Message);
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is Stock s)
            {
                _selected = s;
                dtpDate.Value = s.Date;
                txtQuantite.Text = s.Quantite.ToString();
                txtPU.Text = s.PU.ToString();
                dtpDatePaiment.Value = s.DatePaiment;
                dtpDateDispo.Value = s.DateDispo;
                btnModifier.Enabled = btnSupprimer.Enabled = true;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;

            try
            {
                var s = new Stock
                {
                    Date = dtpDate.Value,
                    Quantite = decimal.Parse(txtQuantite.Text),
                    PU = decimal.Parse(txtPU.Text),
                    DatePaiment = dtpDatePaiment.Value,
                    DateDispo = dtpDateDispo.Value
                };
                _ctx.Stocks.Add(s);
                _ctx.SaveChanges();
                ChargerDonnees();
                Vider();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            if (!Valider()) return;

            try
            {
                var s = _ctx.Stocks.Find(_selected.Id);
                s.Date = dtpDate.Value;
                s.Quantite = decimal.Parse(txtQuantite.Text);
                s.PU = decimal.Parse(txtPU.Text);
                s.DatePaiment = dtpDatePaiment.Value;
                s.DateDispo = dtpDateDispo.Value;
                _ctx.SaveChanges();
                ChargerDonnees();
                Vider();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            if (MessageBox.Show("Supprimer cette entrée de stock ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var s = _ctx.Stocks.Find(_selected.Id);
                    _ctx.Stocks.Remove(s);
                    _ctx.SaveChanges();
                    ChargerDonnees();
                    Vider();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btnReset_Click(object sender, EventArgs e) => Vider();

        private bool Valider()
        {
            if (!decimal.TryParse(txtQuantite.Text, out _))
            {
                MessageBox.Show("Veuillez saisir une quantité valide.");
                return false;
            }
            if (!decimal.TryParse(txtPU.Text, out _))
            {
                MessageBox.Show("Veuillez saisir un prix unitaire valide.");
                return false;
            }
            return true;
        }

        private void Vider()
        {
            dtpDate.Value = DateTime.Now;
            txtQuantite.Clear();
            txtPU.Clear();
            dtpDatePaiment.Value = DateTime.Now;
            dtpDateDispo.Value = DateTime.Now;
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
