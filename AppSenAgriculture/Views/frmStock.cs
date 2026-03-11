using System;
using System.Linq;
using System.Windows.Forms;
using AppSenAgriculture.Models;

namespace AppSenAgriculture.Views
{
    /// <summary>
    /// Formulaire de gestion des entrants de stock.
    /// Permet de tracer les approvisionnements en marchandises.
    /// </summary>
    public partial class frmStock : Form
    {
        // Contexte EF6 pour les opérations CRUD
        private BdSenAgricultureContext _ctx = new BdSenAgricultureContext();
        
        // Stock actuellement sélectionné dans la grille pour modification ou suppression
        private Stock _selected = null;

        public frmStock()
        {
            InitializeComponent();
            ChargerDonnees();
        }

        /// <summary>
        /// Récupère la liste complète des stocks depuis la base de données et l'affiche dans la grille.
        /// </summary>
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

        /// <summary>
        /// Se déclenche quand l'utilisateur clique sur une ligne de la grille.
        /// Remplit les champs du formulaire avec les données de l'entrée sélectionnée.
        /// </summary>
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
                
                // Active les boutons de modification et suppression
                btnModifier.Enabled = btnSupprimer.Enabled = true;
            }
        }

        /// <summary>
        /// Ajoute une nouvelle entrée de stock.
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // Vérifie la validité des saisies numériques
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
                _ctx.SaveChanges(); // Enregistre dans MySQL
                
                ChargerDonnees(); // Rafraîchit la grille
                Vider();         // Réinitialise le formulaire
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// Met à jour l'entrée de stock sélectionnée.
        /// </summary>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            if (!Valider()) return;

            try
            {
                // On récupère l'entité fraîche depuis le contexte pour être sûr de la modifier
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

        /// <summary>
        /// Supprime l'entrée de stock sélectionnée après confirmation.
        /// </summary>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;
            
            if (MessageBox.Show("Supprimer cette entrée de stock ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        /// <summary>
        /// Réinitialise les champs du formulaire.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e) => Vider();

        /// <summary>
        /// Validation métier : vérifie que les nombres sont bien formés.
        /// </summary>
        /// <returns>True si tout est OK.</returns>
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

        /// <summary>
        /// Vide les contrôles de saisie et désactive les boutons d'action unitaire.
        /// </summary>
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

        /// <summary>
        /// Nettoyage des ressources (dispose du contexte) à la fermeture du formulaire.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _ctx?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
