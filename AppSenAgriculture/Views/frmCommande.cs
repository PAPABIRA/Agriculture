using System;
using System.Linq;
using System.Windows.Forms;
using AppSenAgriculture.Models;

namespace AppSenAgriculture.Views
{
    public partial class frmCommande : Form
    {
        private BdSenAgricultureContext _ctx = new BdSenAgricultureContext();
        private Commande _selected = null;

        public frmCommande()
        {
            InitializeComponent();
            ChargerDonnees();
        }

        private void ChargerDonnees()
        {
            try
            {
                var list = _ctx.Commandes.ToList();
                dgv.DataSource = list;
                lblTotal.Text = $"Total : {list.Count} commande(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement : " + ex.Message);
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is Commande c)
            {
                _selected = c;
                dtpDate.Value = c.Date;
                cboStatut.SelectedItem = c.Statut;
                btnModifier.Enabled = btnSupprimer.Enabled = true;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (cboStatut.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un statut.");
                return;
            }

            try
            {
                var c = new Commande
                {
                    Date = dtpDate.Value,
                    Statut = cboStatut.SelectedItem.ToString()
                };
                _ctx.Commandes.Add(c);
                _ctx.SaveChanges();
                ChargerDonnees();
                Vider();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            if (cboStatut.SelectedIndex == -1) return;

            try
            {
                var c = _ctx.Commandes.Find(_selected.Id);
                c.Date = dtpDate.Value;
                c.Statut = cboStatut.SelectedItem.ToString();
                _ctx.SaveChanges();
                ChargerDonnees();
                Vider();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            if (MessageBox.Show("Supprimer cette commande ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var c = _ctx.Commandes.Find(_selected.Id);
                    _ctx.Commandes.Remove(c);
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
            cboStatut.SelectedIndex = -1;
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
