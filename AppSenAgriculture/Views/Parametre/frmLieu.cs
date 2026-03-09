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
    public partial class frmLieu : Form
    {
        private int? _selectedIdLieu = null;

        public frmLieu()
        {
            try
            {
                InitializeComponent();
                this.Load += frmLieu_Load;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'initialisation: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLieu_Load(object sender, EventArgs e)
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

        private void RefreshGrid()
        {
            try
            {
                using (var db = new BdSenAgricultureContext())
                {
                    // Vérification de la connexion et de la table
                    try
                    {
                        var count = db.Lieux.Count();
                    }
                    catch (Exception connEx)
                    {
                        MessageBox.Show($"Erreur lors de la connexion à la table LieuxApp:\n{connEx.Message}\n\n" +
                            $"Vérifiez que la table 'LieuxApp' existe dans la base de données.\n\n" +
                            $"Exécutez le script SQL 'creer_table_lieuxapp.sql' pour créer la table.\n\n" +
                            $"Détails: {connEx.InnerException?.Message ?? connEx.Message}", 
                            "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var data = db.Lieux
                        .OrderBy(l => l.Libelle)
                        .Select(l => new
                        {
                            l.IdLieu,
                            l.Libelle,
                            l.DescriptionLieu,
                            l.Adresse,
                            l.Ville,
                            l.Telephone
                        })
                        .ToList();

                    gridLieux.DataSource = data;
                    
                    // Configuration du DataGridView
                    if (gridLieux.Columns.Count > 0)
                    {
                        gridLieux.Columns["IdLieu"].Visible = false;
                        gridLieux.Columns["Libelle"].HeaderText = "Libellé";
                        gridLieux.Columns["Libelle"].Width = 150;
                        gridLieux.Columns["DescriptionLieu"].HeaderText = "Description";
                        gridLieux.Columns["DescriptionLieu"].Width = 200;
                        gridLieux.Columns["Adresse"].HeaderText = "Adresse";
                        gridLieux.Columns["Adresse"].Width = 150;
                        gridLieux.Columns["Ville"].HeaderText = "Ville";
                        gridLieux.Columns["Ville"].Width = 120;
                        gridLieux.Columns["Telephone"].HeaderText = "Téléphone";
                        gridLieux.Columns["Telephone"].Width = 120;
                    }
                }

                ClearForm();
            }
            catch (System.Data.Entity.Core.EntityException entityEx)
            {
                MessageBox.Show($"Erreur de connexion à la base de données:\n{entityEx.Message}\n\nVérifiez que la table 'LieuxApp' existe dans la base de données.\n\nVous pouvez exécuter le script SQL 'creer_table_lieuxapp.sql' pour créer la table.", 
                    "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Erreur lors du chargement des lieux:\n{ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\n\nDétails: {ex.InnerException.Message}";
                }
                MessageBox.Show(errorMessage, "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                
                var row = gridLieux.Rows[e.RowIndex];
                if (row?.Cells == null) return;

                _selectedIdLieu = Convert.ToInt32(row.Cells["IdLieu"].Value);
                txtLibelle.Text = Convert.ToString(row.Cells["Libelle"].Value) ?? string.Empty;
                txtDescription.Text = Convert.ToString(row.Cells["DescriptionLieu"].Value) ?? string.Empty;
                txtAdresse.Text = Convert.ToString(row.Cells["Adresse"].Value) ?? string.Empty;
                txtVille.Text = Convert.ToString(row.Cells["Ville"].Value) ?? string.Empty;
                txtTelephone.Text = Convert.ToString(row.Cells["Telephone"].Value) ?? string.Empty;
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
                _selectedIdLieu = null;
                txtLibelle.Text = string.Empty;
                txtDescription.Text = string.Empty;
                txtAdresse.Text = string.Empty;
                txtVille.Text = string.Empty;
                txtTelephone.Text = string.Empty;
                gridLieux.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du nettoyage du formulaire: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                var libelle = (txtLibelle.Text ?? string.Empty).Trim();
                var description = (txtDescription.Text ?? string.Empty).Trim();
                var adresse = (txtAdresse.Text ?? string.Empty).Trim();
                var ville = (txtVille.Text ?? string.Empty).Trim();
                var telephone = (txtTelephone.Text ?? string.Empty).Trim();

                if (string.IsNullOrWhiteSpace(libelle))
                {
                    MessageBox.Show("Le libellé est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLibelle.Focus();
                    return;
                }

                using (var db = new BdSenAgricultureContext())
                {
                    // Test de connexion et vérification de la table
                    try
                    {
                        var test = db.Lieux.Count();
                    }
                    catch (Exception testEx)
                    {
                        MessageBox.Show($"Erreur lors de la connexion à la table LieuxApp:\n{testEx.Message}\n\n" +
                            $"Vérifiez que:\n" +
                            $"1. La table 'LieuxApp' existe dans la base de données 'bdsenagriculture'\n" +
                            $"2. Exécutez le script SQL 'creer_table_lieuxapp.sql' pour créer la table\n" +
                            $"3. La connexion à la base de données est correcte\n" +
                            $"4. Les permissions sont correctes\n\n" +
                            $"Détails: {testEx.InnerException?.Message ?? testEx.Message}", 
                            "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Lieu entity;
                    if (_selectedIdLieu.HasValue)
                    {
                        entity = db.Lieux.FirstOrDefault(l => l.IdLieu == _selectedIdLieu.Value);
                        if (entity == null)
                        {
                            MessageBox.Show("Lieu introuvable (il a peut-être été supprimé).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            RefreshGrid();
                            return;
                        }
                    }
                    else
                    {
                        entity = new Lieu();
                        db.Lieux.Add(entity);
                    }

                    entity.Libelle = libelle;
                    entity.DescriptionLieu = string.IsNullOrWhiteSpace(description) ? null : description;
                    entity.Adresse = string.IsNullOrWhiteSpace(adresse) ? null : adresse;
                    entity.Ville = string.IsNullOrWhiteSpace(ville) ? null : ville;
                    entity.Telephone = string.IsNullOrWhiteSpace(telephone) ? null : telephone;

                    db.SaveChanges();
                }

                MessageBox.Show("Lieu enregistré avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException dbEx)
            {
                var innerEx = dbEx.InnerException;
                string errorMessage = $"Erreur lors de l'enregistrement du lieu:\n{dbEx.Message}";
                if (innerEx != null)
                {
                    errorMessage += $"\n\nDétails: {innerEx.Message}";
                }
                MessageBox.Show(errorMessage, "Erreur de base de données", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Core.EntityException entityEx)
            {
                MessageBox.Show($"Erreur de connexion à la base de données:\n{entityEx.Message}\n\nVérifiez que la table 'Lieux' existe dans la base de données.", 
                    "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                string errorMessage = $"Erreur lors de l'enregistrement du lieu:\n{ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\n\nDétails: {ex.InnerException.Message}";
                }
                MessageBox.Show(errorMessage, "Erreur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_selectedIdLieu.HasValue)
                {
                    MessageBox.Show("Sélectionnez un lieu à supprimer.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show("Supprimer ce lieu ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                using (var db = new BdSenAgricultureContext())
                {
                    var entity = db.Lieux.FirstOrDefault(l => l.IdLieu == _selectedIdLieu.Value);
                    if (entity == null)
                    {
                        RefreshGrid();
                        return;
                    }

                    db.Lieux.Remove(entity);
                    db.SaveChanges();
                }

                MessageBox.Show("Lieu supprimé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression du lieu: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
