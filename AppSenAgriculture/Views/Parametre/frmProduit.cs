using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppSenAgriculture.Models;
using System.Data.Entity;
using System.Globalization;

namespace AppSenAgriculture.Views.Parametre
{
    /// <summary>
    /// Formulaire de gestion du catalogue produit.
    /// Gère les relations entre produits et catégories.
    /// </summary>
    public partial class frmProduit : Form
    {
        private int? _selectedIdProduit = null;

        public frmProduit()
        {
            InitializeComponent();
            this.Load += frmProduit_Load;
        }

        private void frmProduit_Load(object sender, EventArgs e)
        {
            LoadCategories();
            RefreshGrid();
        }

        /// <summary>
        /// Remplit la liste déroulante des catégories pour l'association produit-catégorie.
        /// </summary>
        private void LoadCategories()
        {
            try
            {
                using (var db = new BdSenAgricultureContext())
                {
                    var cats = db.Categories
                        .OrderBy(c => c.Libelle)
                        .Select(c => new { c.IdCategorie, c.Libelle })
                        .ToList();

                    cboCategorie.DataSource = cats;
                    cboCategorie.DisplayMember = "Libelle";
                    cboCategorie.ValueMember = "IdCategorie";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des catégories: {ex.Message}", "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Charge la liste des produits avec leurs catégories associées (via .Include).
        /// </summary>
        private void RefreshGrid()
        {
            try
            {
                using (var db = new BdSenAgricultureContext())
                {
                    var data = db.Produits
                        .Include(p => p.Categorie)
                        .OrderBy(p => p.LibelleProduit)
                        .Select(p => new
                        {
                            p.IdProduit,
                            p.LibelleProduit,
                            p.DescriptionProduit,
                            p.PrixUnitaireMin,
                            p.PrixUnitaireMax,
                            p.CategorieId,
                            Categorie = p.Categorie.Libelle
                        })
                        .ToList();

                    gridProduits.DataSource = data;
                }

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des produits: {ex.Message}", "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = gridProduits.Rows[e.RowIndex];
            if (row?.Cells == null) return;

            _selectedIdProduit = Convert.ToInt32(row.Cells["IdProduit"].Value);
            txtLibelle.Text = Convert.ToString(row.Cells["LibelleProduit"].Value) ?? string.Empty;
            txtDescription.Text = Convert.ToString(row.Cells["DescriptionProduit"].Value) ?? string.Empty;
            txtPrixMin.Text = Convert.ToString(row.Cells["PrixUnitaireMin"].Value) ?? string.Empty;
            txtPrixMax.Text = Convert.ToString(row.Cells["PrixUnitaireMax"].Value) ?? string.Empty;

            var catIdObj = row.Cells["CategorieId"].Value;
            if (catIdObj != null)
            {
                cboCategorie.SelectedValue = Convert.ToInt32(catIdObj);
            }
        }

        private void ClearForm()
        {
            _selectedIdProduit = null;
            txtLibelle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPrixMin.Text = string.Empty;
            txtPrixMax.Text = string.Empty;
            gridProduits.ClearSelection();
        }

        private bool TryGetDecimal(TextBox txt, out decimal value)
        {
            var raw = (txt.Text ?? string.Empty).Trim();
            return decimal.TryParse(raw, NumberStyles.Number, CultureInfo.CurrentCulture, out value);
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            var libelle = (txtLibelle.Text ?? string.Empty).Trim();
            var description = (txtDescription.Text ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(libelle))
            {
                MessageBox.Show("Le libellé est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLibelle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("La description est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return;
            }

            if (!TryGetDecimal(txtPrixMin, out var prixMin))
            {
                MessageBox.Show("Prix unitaire min invalide.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrixMin.Focus();
                return;
            }

            if (!TryGetDecimal(txtPrixMax, out var prixMax))
            {
                MessageBox.Show("Prix unitaire max invalide.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrixMax.Focus();
                return;
            }

            if (prixMin <= 0 || prixMax <= 0)
            {
                MessageBox.Show("Les prix doivent être supérieurs à 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboCategorie.SelectedValue == null)
            {
                MessageBox.Show("Sélectionne une catégorie.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var categorieId = Convert.ToInt32(cboCategorie.SelectedValue);

            try
            {
                using (var db = new BdSenAgricultureContext())
                {
                    Produit entity;
                    if (_selectedIdProduit.HasValue)
                    {
                        entity = db.Produits.FirstOrDefault(p => p.IdProduit == _selectedIdProduit.Value);
                        if (entity == null)
                        {
                            MessageBox.Show("Produit introuvable (il a peut-être été supprimé).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            RefreshGrid();
                            return;
                        }
                    }
                    else
                    {
                        entity = new Produit();
                        db.Produits.Add(entity);
                    }

                    entity.LibelleProduit = libelle;
                    entity.DescriptionProduit = description;
                    entity.PrixUnitaireMin = prixMin;
                    entity.PrixUnitaireMax = prixMax;
                    entity.CategorieId = categorieId;

                    db.SaveChanges();
                }

                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement du produit: {ex.Message}", "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (!_selectedIdProduit.HasValue)
            {
                MessageBox.Show("Sélectionne un produit à supprimer.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Supprimer ce produit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var db = new BdSenAgricultureContext())
                {
                    var entity = db.Produits.FirstOrDefault(p => p.IdProduit == _selectedIdProduit.Value);
                    if (entity == null)
                    {
                        RefreshGrid();
                        return;
                    }

                    db.Produits.Remove(entity);
                    db.SaveChanges();
                }

                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression du produit: {ex.Message}", "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
