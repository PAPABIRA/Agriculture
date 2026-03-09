using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AppSenAgriculture.Models;
using AppSenAgriculture.UI;

namespace AppSenAgriculture.Views.Securite
{
    public partial class frmClient : Form
    {
        private BdSenAgricultureContext _ctx = new BdSenAgricultureContext();
        private Client _selectedClient = null;

        public frmClient()
        {
            InitializeComponent();
            ChargerClients();
        }

        // ── Chargement ────────────────────────────────────────
        private void ChargerClients()
        {
            try
            {
                var clients = _ctx.Clients.ToList();
                dgvClients.DataSource = clients;
                lblTotal.Text = $"Total : {clients.Count} client(s)";
                ConfigurerGrille();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement : " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurerGrille()
        {
            if (dgvClients.Columns.Count == 0) return;

            dgvClients.Columns["Id"].HeaderText = "ID";
            dgvClients.Columns["Id"].Width = 50;
            dgvClients.Columns["NomPrenom"].HeaderText = "Nom & Prénom";
            dgvClients.Columns["NomPrenom"].Width = 180;
            dgvClients.Columns["Telephone"].HeaderText = "Téléphone";
            dgvClients.Columns["Telephone"].Width = 120;
            dgvClients.Columns["Email"].HeaderText = "Email";
            dgvClients.Columns["Email"].Width = 180;
            dgvClients.Columns["Adresse"].HeaderText = "Adresse";
            dgvClients.Columns["Adresse"].Width = 180;
            dgvClients.Columns["Profession"].HeaderText = "Profession";
            dgvClients.Columns["Profession"].Width = 130;
            dgvClients.Columns["Identifiant"].HeaderText = "Identifiant";
            dgvClients.Columns["Identifiant"].Width = 120;
            dgvClients.Columns["EstBloque"].HeaderText = "Bloqué";
            dgvClients.Columns["EstBloque"].Width = 70;
        }

        // ── Sélection dans la grille ──────────────────────────
        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow?.DataBoundItem is Client c)
            {
                _selectedClient = c;
                RemplirFormulaire(c);
                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
                btnBloquer.Enabled = true;
                btnDebloquer.Enabled = true;
            }
        }

        private void RemplirFormulaire(Client c)
        {
            txtNomPrenom.Text = c.NomPrenom;
            txtAdresse.Text = c.Adresse;
            txtEmail.Text = c.Email;
            txtTelephone.Text = c.Telephone;
            txtIdentifiant.Text = c.Identifiant;
            txtProfession.Text = c.Profession;
        }

        private void ViderFormulaire()
        {
            txtNomPrenom.Clear();
            txtAdresse.Clear();
            txtEmail.Clear();
            txtTelephone.Clear();
            txtIdentifiant.Clear();
            txtProfession.Clear();
            _selectedClient = null;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnBloquer.Enabled = false;
            btnDebloquer.Enabled = false;
        }

        // ── CRUD ──────────────────────────────────────────────
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!ValiderFormulaire()) return;

            var client = new Client
            {
                NomPrenom   = txtNomPrenom.Text.Trim(),
                Adresse     = txtAdresse.Text.Trim(),
                Email       = txtEmail.Text.Trim(),
                Telephone   = txtTelephone.Text.Trim(),
                Identifiant = txtIdentifiant.Text.Trim(),
                Profession  = txtProfession.Text.Trim(),
                EstBloque   = false
            };

            try
            {
                _ctx.Clients.Add(client);
                _ctx.SaveChanges();
                ChargerClients();
                ViderFormulaire();
                MessageBox.Show("Client ajouté avec succès.", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (_selectedClient == null) return;
            if (!ValiderFormulaire()) return;

            try
            {
                var client = _ctx.Clients.Find(_selectedClient.Id);
                client.NomPrenom   = txtNomPrenom.Text.Trim();
                client.Adresse     = txtAdresse.Text.Trim();
                client.Email       = txtEmail.Text.Trim();
                client.Telephone   = txtTelephone.Text.Trim();
                client.Identifiant = txtIdentifiant.Text.Trim();
                client.Profession  = txtProfession.Text.Trim();

                _ctx.SaveChanges();
                ChargerClients();
                ViderFormulaire();
                MessageBox.Show("Client modifié avec succès.", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_selectedClient == null) return;

            var result = MessageBox.Show(
                $"Supprimer le client « {_selectedClient.NomPrenom} » ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                var client = _ctx.Clients.Find(_selectedClient.Id);
                _ctx.Clients.Remove(client);
                _ctx.SaveChanges();
                ChargerClients();
                ViderFormulaire();
                MessageBox.Show("Client supprimé.", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBloquer_Click(object sender, EventArgs e)
        {
            if (_selectedClient == null) return;
            SetBlocage(true);
        }

        private void btnDebloquer_Click(object sender, EventArgs e)
        {
            if (_selectedClient == null) return;
            SetBlocage(false);
        }

        private void SetBlocage(bool bloquer)
        {
            try
            {
                var client = _ctx.Clients.Find(_selectedClient.Id);
                client.EstBloque = bloquer;
                _ctx.SaveChanges();
                ChargerClients();
                string msg = bloquer ? "Client bloqué." : "Client débloqué.";
                MessageBox.Show(msg, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReinitialiser_Click(object sender, EventArgs e)
        {
            ViderFormulaire();
            ChargerClients();
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fonctionnalité d'impression à implémenter avec Crystal Reports ou FastReport.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Recherche ─────────────────────────────────────────
        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            string terme = txtRecherche.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(terme))
            {
                ChargerClients();
                return;
            }

            var resultats = _ctx.Clients
                .Where(c => c.NomPrenom.ToLower().Contains(terme)
                         || c.Telephone.Contains(terme)
                         || c.Email.ToLower().Contains(terme))
                .ToList();

            dgvClients.DataSource = resultats;
            lblTotal.Text = $"Total : {resultats.Count} résultat(s)";
        }

        // ── Validation ────────────────────────────────────────
        private bool ValiderFormulaire()
        {
            if (string.IsNullOrWhiteSpace(txtNomPrenom.Text))
            {
                MessageBox.Show("Le nom et prénom sont obligatoires.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomPrenom.Focus();
                return false;
            }
            return true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _ctx?.Dispose();
        }
    }
}
