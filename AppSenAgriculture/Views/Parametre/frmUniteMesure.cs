using System;
using System.Linq;
using System.Windows.Forms;
using AppSenAgriculture.Models;

namespace AppSenAgriculture.Views.Parametre
{
    /// <summary>
    /// Formulaire de gestion des unités de mesure (Kg, Sac, Litre, etc.).
    /// </summary>
    public partial class frmUniteMesure : Form
    {
        private BdSenAgricultureContext _ctx = new BdSenAgricultureContext();
        private UniteMesure _selected = null;

        public frmUniteMesure()
        {
            InitializeComponent();
            ChargerDonnees();
        }

        /// <summary>
        /// Charge la liste des unités de mesure depuis la base de données.
        /// </summary>
        private void ChargerDonnees()
        {
            try
            {
                var list = _ctx.UnitesMesure.ToList();
                dgv.DataSource = list;
                lblTotal.Text = $"Total : {list.Count} unité(s)";
                
                // Personnalisation des entêtes de colonnes
                if (dgv.Columns["IdUniteMesure"] != null)
                    dgv.Columns["IdUniteMesure"].HeaderText = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement : " + ex.Message);
            }
        }

        /// <summary>
        /// Remplit le formulaire lorsqu'une unité est sélectionnée dans la grille.
        /// </summary>
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

        /// <summary>
        /// Ajoute une nouvelle unité de mesure après validation.
        /// </summary>
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

        /// <summary>
        /// Modifie l'unité de mesure sélectionnée.
        /// </summary>
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

        /// <summary>
        /// Supprime l'unité de mesure sélectionnée.
        /// </summary>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            if (MessageBox.Show("Supprimer cette unité ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        /// <summary>
        /// Réinitialise les champs de saisie.
        /// </summary>
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
