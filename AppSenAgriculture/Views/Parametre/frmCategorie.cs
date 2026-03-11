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

namespace AppSenAgriculture.Views.Parametre
{
    /// <summary>
    /// Formulaire de gestion des catégories de produits.
    /// Permet de regrouper les produits par famille (ex: Céréales, Engrais).
    /// </summary>
    public partial class frmCategorie : Form
    {
        private int? _selectedIdCategorie = null;

        public frmCategorie()
        {
            try
            {
                InitializeComponent();
                this.Load += frmCategorie_Load;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'initialisation: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCategorie_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Rafraîchit la grille des catégories en interrogeant la base de données.
        /// Utilise une projection (Select) pour ne récupérer que les champs nécessaires.
        /// </summary>
        private void RefreshGrid()
        {
            try
            {
                using (var db = new BdSenAgricultureContext())
                {
                    var data = db.Categories
                        .OrderBy(c => c.Libelle)
                        .Select(c => new
                        {
                            c.IdCategorie,
                            c.Libelle,
                            c.DescriptionCategorie
                        })
                        .ToList();

                    gridCategories.DataSource = data;
                    
                    // Configuration du DataGridView
                    gridCategories.Columns["IdCategorie"].Visible = false;
                    gridCategories.Columns["Libelle"].HeaderText = "Libellé";
                    gridCategories.Columns["Libelle"].Width = 200;
                    gridCategories.Columns["DescriptionCategorie"].HeaderText = "Description";
                    gridCategories.Columns["DescriptionCategorie"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des catégories: {ex.Message}", "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                
                var row = gridCategories.Rows[e.RowIndex];
                if (row?.Cells == null) return;

                _selectedIdCategorie = Convert.ToInt32(row.Cells["IdCategorie"].Value);
                txtLibelle.Text = Convert.ToString(row.Cells["Libelle"].Value) ?? string.Empty;
                txtDescription.Text = Convert.ToString(row.Cells["DescriptionCategorie"].Value) ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sélection: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            try
            {
                _selectedIdCategorie = null;
                txtLibelle.Text = string.Empty;
                txtDescription.Text = string.Empty;
                gridCategories.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du nettoyage du formulaire: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bouton "Nouveau" : prépare le formulaire pour créer une nouvelle catégorie.
        /// On vide tous les champs et on place le curseur sur le libellé pour commencer la saisie.
        /// </summary>
        private void btnNouveau_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
                txtLibelle.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la création: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bouton "Enregistrer" : sauvegarde une catégorie (nouvelle ou modifiée).
        /// 
        /// Comportement :
        /// - Si une catégorie est sélectionnée dans la grille → modification
        /// - Sinon → création d'une nouvelle catégorie
        /// - Le libellé est obligatoire, la description est optionnelle
        /// </summary>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                var libelle = (txtLibelle.Text ?? string.Empty).Trim();
                var description = (txtDescription.Text ?? string.Empty).Trim();

                // Validation : le libellé est obligatoire pour identifier la catégorie
                if (string.IsNullOrWhiteSpace(libelle))
                {
                    MessageBox.Show("Le libellé est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLibelle.Focus();
                    return;
                }

                using (var db = new BdSenAgricultureContext())
                {
                    Categorie entity;
                    // Modification si une catégorie est sélectionnée
                    if (_selectedIdCategorie.HasValue)
                    {
                        entity = db.Categories.FirstOrDefault(c => c.IdCategorie == _selectedIdCategorie.Value);
                        if (entity == null)
                        {
                            MessageBox.Show("Catégorie introuvable (elle a peut-être été supprimée).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            RefreshGrid();
                            return;
                        }
                    }
                    else
                    {
                        // Création d'une nouvelle catégorie
                        entity = new Categorie();
                        db.Categories.Add(entity);
                    }

                    entity.Libelle = libelle;
                    // Description optionnelle : null si vide
                    entity.DescriptionCategorie = string.IsNullOrWhiteSpace(description) ? null : description;

                    db.SaveChanges();
                }

                MessageBox.Show("Catégorie enregistrée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement de la catégorie: {ex.Message}", "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bouton "Supprimer" : supprime définitivement la catégorie sélectionnée.
        /// 
        /// Attention : si des produits utilisent cette catégorie, la suppression peut échouer
        /// à cause des contraintes de clé étrangère dans la base de données.
        /// </summary>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selectedIdCategorie.HasValue)
                {
                    MessageBox.Show("Sélectionnez une catégorie à supprimer.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Confirmation avant suppression définitive
                var confirm = MessageBox.Show("Supprimer cette catégorie ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                using (var db = new BdSenAgricultureContext())
                {
                    var entity = db.Categories.FirstOrDefault(c => c.IdCategorie == _selectedIdCategorie.Value);
                    if (entity == null)
                    {
                        RefreshGrid();
                        return;
                    }

                    db.Categories.Remove(entity);
                    db.SaveChanges();
                }

                MessageBox.Show("Catégorie supprimée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression de la catégorie: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
