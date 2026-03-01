using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace GestionMarche
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public double Prix { get; set; }
    }

    public partial class Form1 : Form
    {
        private List<Produit> produits = new List<Produit>();

        // Labels pour stats
        private Label statLblTotalProduits;
        private Label statLblTotalStock;
        private Label statLblRupture;

        public Form1()
        {
            InitializeComponent();
            Database.InitializeDatabase();
            InitializeStatsLabels();
            LoadProduits();
            LoadProduitsCombo();
            LoadVentes();
            InitializeListView();
        }

        // =================== Produits ===================
        private void LoadProduits()
        {
            produits.Clear();
            try
            {
                using (var conn = Database.GetConnection())
                {
                    string query = "SELECT * FROM Produits";
                    using (var cmd = new SQLiteCommand(query, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produits.Add(new Produit
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nom = reader["Nom"].ToString(),
                                Quantite = Convert.ToInt32(reader["Quantite"]),
                                Prix = Convert.ToDouble(reader["Prix"])
                            });
                        }
                    }
                }

                dgvProduits.DataSource = produits.Select(p => new { p.Id, p.Nom, p.Quantite, p.Prix }).ToList();
                UpdateListView();
                UpdateStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur LoadProduits : " + ex.Message);
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                !int.TryParse(txtQuantite.Text, out int quantite) ||
                !double.TryParse(txtPrix.Text, out double prix))
            {
                MessageBox.Show("Veuillez entrer des valeurs valides !");
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    string query = "INSERT INTO Produits (Nom, Quantite, Prix) VALUES (@nom, @quantite, @prix)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nom", txtNom.Text.Trim());
                        cmd.Parameters.AddWithValue("@quantite", quantite);
                        cmd.Parameters.AddWithValue("@prix", prix);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadProduits();
                LoadProduitsCombo();
                txtNom.Clear();
                txtQuantite.Clear();
                txtPrix.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvProduits.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvProduits.CurrentRow.Cells["Id"].Value);

            if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                !int.TryParse(txtQuantite.Text, out int quantite) ||
                !double.TryParse(txtPrix.Text, out double prix))
            {
                MessageBox.Show("Veuillez entrer des valeurs valides !");
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    string query = "UPDATE Produits SET Nom=@nom, Quantite=@quantite, Prix=@prix WHERE Id=@id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nom", txtNom.Text.Trim());
                        cmd.Parameters.AddWithValue("@quantite", quantite);
                        cmd.Parameters.AddWithValue("@prix", prix);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadProduits();
                LoadProduitsCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvProduits.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvProduits.CurrentRow.Cells["Id"].Value);

            var confirm = MessageBox.Show("Supprimer ce produit ?", "Confirmer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var conn = Database.GetConnection())
                {
                    string query = "DELETE FROM Produits WHERE Id=@id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadProduits();
                LoadProduitsCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
            }
        }

        // =================== Ventes ===================
        private void LoadProduitsCombo()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    string query = "SELECT Id, Nom, Quantite FROM Produits";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbProduits.DataSource = dt;
                    cmbProduits.DisplayMember = "Nom";
                    cmbProduits.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur LoadProduitsCombo : " + ex.Message);
            }
        }

        private void LoadVentes()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    string query = @"SELECT Ventes.Id, Produits.Nom AS Produit, Ventes.QuantiteVendue, Ventes.DateVente 
                                     FROM Ventes 
                                     INNER JOIN Produits ON Ventes.ProduitId = Produits.Id";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvVentes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur LoadVentes : " + ex.Message);
            }
        }

        private void btnEnregistrerVente_Click(object sender, EventArgs e)
        {
            if (cmbProduits.SelectedValue == null || !int.TryParse(txtQuantiteVendue.Text, out int quantiteVendue))
            {
                MessageBox.Show("Veuillez sélectionner un produit et entrer une quantité valide !");
                return;
            }

            int produitId = Convert.ToInt32(cmbProduits.SelectedValue);

            try
            {
                using (var conn = Database.GetConnection())
                {
                    int stock = Convert.ToInt32(new SQLiteCommand($"SELECT Quantite FROM Produits WHERE Id={produitId}", conn).ExecuteScalar());

                    if (quantiteVendue <= 0)
                    {
                        MessageBox.Show("La quantité vendue doit être supérieure à 0.");
                        return;
                    }

                    if (quantiteVendue > stock)
                    {
                        MessageBox.Show($"Stock insuffisant. Stock actuel : {stock}");
                        return;
                    }

                    string query = "INSERT INTO Ventes (ProduitId, QuantiteVendue, DateVente) VALUES (@prodId, @quantite, @date)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@prodId", produitId);
                        cmd.Parameters.AddWithValue("@quantite", quantiteVendue);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.ExecuteNonQuery();
                    }

                    string updateProd = "UPDATE Produits SET Quantite = Quantite - @q WHERE Id = @id";
                    using (var cmd2 = new SQLiteCommand(updateProd, conn))
                    {
                        cmd2.Parameters.AddWithValue("@q", quantiteVendue);
                        cmd2.Parameters.AddWithValue("@id", produitId);
                        cmd2.ExecuteNonQuery();
                    }
                }

                LoadVentes();
                LoadProduits();
                LoadProduitsCombo();
                txtQuantiteVendue.Clear();
                cmbProduits.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement de la vente : " + ex.Message);
            }
        }

        // =================== ListView Recherche ===================
        private void InitializeListView()
        {
            listViewProduits.Clear();
            listViewProduits.View = View.Details;
            listViewProduits.Columns.Add("Nom", 150);
            listViewProduits.Columns.Add("Quantité", 70);
            listViewProduits.Columns.Add("Prix", 70);
            UpdateListView();
        }

        private void UpdateListView()
        {
            if (listViewProduits == null) return;

            listViewProduits.Items.Clear();
            foreach (var p in produits)
            {
                ListViewItem item = new ListViewItem(p.Nom);
                item.SubItems.Add(p.Quantite.ToString());
                item.SubItems.Add(p.Prix.ToString("0.00"));
                listViewProduits.Items.Add(item);
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            if (listViewProduits == null) return;

            string search = txtRechercher.Text.Trim().ToLower();
            listViewProduits.Items.Clear();

            foreach (var p in produits)
            {
                if (p.Nom.ToLower().Contains(search))
                {
                    ListViewItem item = new ListViewItem(p.Nom);
                    item.SubItems.Add(p.Quantite.ToString());
                    item.SubItems.Add(p.Prix.ToString("0.00"));
                    listViewProduits.Items.Add(item);
                }
            }
        }

        // =================== Stats / Dashboard ===================
        private void InitializeStatsLabels()
        {
            statLblTotalProduits = new Label { Location = new Point(10, 10), Size = new Size(300, 25) };
            statLblTotalStock = new Label { Location = new Point(10, 40), Size = new Size(300, 25) };
            statLblRupture = new Label { Location = new Point(10, 70), Size = new Size(500, 25) };

            statLblTotalProduits.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            statLblTotalStock.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            statLblRupture.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            statLblTotalProduits.ForeColor = Color.DarkBlue;
            statLblTotalStock.ForeColor = Color.DarkGreen;
            statLblRupture.ForeColor = Color.DarkRed;

            tabPageStats.Controls.Add(statLblTotalProduits);
            tabPageStats.Controls.Add(statLblTotalStock);
            tabPageStats.Controls.Add(statLblRupture);
        }

        private void UpdateStats()
        {
            int totalProduits = produits.Count;
            int totalStock = produits.Sum(p => p.Quantite);
            var rupture = produits.Where(p => p.Quantite == 0).ToList();

            statLblTotalProduits.Text = "Total produits : " + totalProduits;
            statLblTotalStock.Text = "Stock total : " + totalStock;
            statLblRupture.Text = "Produits en rupture : " + (rupture.Count > 0 ? string.Join(", ", rupture.Select(p => p.Nom)) : "Aucun");
        }

        // =================== Export PDF ===================
        private void btnExporterPDF_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF Files|*.pdf", FileName = "Produits.pdf" })
                {
                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    PdfDocument doc = new PdfDocument();
                    doc.Info.Title = "Liste des Produits";
                    PdfPage page = doc.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    XFont font = new XFont("Verdana", 12, XFontStyle.Regular);

                    int yPoint = 40;
                    gfx.DrawString("Liste des Produits", new XFont("Verdana", 14, XFontStyle.Bold), XBrushes.Black, new XPoint(40, yPoint));
                    yPoint += 40;

                    foreach (var p in produits)
                    {
                        gfx.DrawString($"Nom: {p.Nom} | Quantité: {p.Quantite} | Prix: {p.Prix:0.00}", font, XBrushes.Black, new XPoint(40, yPoint));
                        yPoint += 25;
                    }

                    doc.Save(sfd.FileName);
                    MessageBox.Show("PDF exporté avec succès !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur Export PDF : " + ex.Message);
            }
        }

        private void dgvProduits_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProduits.CurrentRow == null) return;

            txtNom.Text = dgvProduits.CurrentRow.Cells["Nom"].Value.ToString();
            txtQuantite.Text = dgvProduits.CurrentRow.Cells["Quantite"].Value.ToString();
            txtPrix.Text = dgvProduits.CurrentRow.Cells["Prix"].Value.ToString();
        }
    }
}
