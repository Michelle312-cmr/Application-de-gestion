namespace GestionMarche
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] { "Nom", "Quantité", "Prix" }, -1);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageProduits = new System.Windows.Forms.TabPage();
            this.dgvProduits = new System.Windows.Forms.DataGridView();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtQuantite = new System.Windows.Forms.TextBox();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.txtRechercher = new System.Windows.Forms.TextBox();
            this.listViewProduits = new System.Windows.Forms.ListView();
            this.btnExporterPDF = new System.Windows.Forms.Button();
            this.tabPageVentes = new System.Windows.Forms.TabPage();
            this.dgvVentes = new System.Windows.Forms.DataGridView();
            this.cmbProduits = new System.Windows.Forms.ComboBox();
            this.txtQuantiteVendue = new System.Windows.Forms.TextBox();
            this.btnEnregistrerVente = new System.Windows.Forms.Button();
            this.tabPageStats = new System.Windows.Forms.TabPage();
            this.lblTotalProduits = new System.Windows.Forms.Label();
            this.lblTotalStock = new System.Windows.Forms.Label();
            this.lblRupture = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageProduits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduits)).BeginInit();
            this.tabPageVentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentes)).BeginInit();
            this.tabPageStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageProduits);
            this.tabControl1.Controls.Add(this.tabPageVentes);
            this.tabControl1.Controls.Add(this.tabPageStats);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 550);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageProduits
            // 
            this.tabPageProduits.Controls.Add(this.listViewProduits);
            this.tabPageProduits.Controls.Add(this.txtRechercher);
            this.tabPageProduits.Controls.Add(this.btnRechercher);
            this.tabPageProduits.Controls.Add(this.dgvProduits);
            this.tabPageProduits.Controls.Add(this.txtNom);
            this.tabPageProduits.Controls.Add(this.txtQuantite);
            this.tabPageProduits.Controls.Add(this.txtPrix);
            this.tabPageProduits.Controls.Add(this.btnAjouter);
            this.tabPageProduits.Controls.Add(this.btnModifier);
            this.tabPageProduits.Controls.Add(this.btnSupprimer);
            this.tabPageProduits.Controls.Add(this.btnExporterPDF);
            this.tabPageProduits.Location = new System.Drawing.Point(4, 22);
            this.tabPageProduits.Name = "tabPageProduits";
            this.tabPageProduits.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProduits.Size = new System.Drawing.Size(792, 524);
            this.tabPageProduits.TabIndex = 0;
            this.tabPageProduits.Text = "Produits";
            this.tabPageProduits.UseVisualStyleBackColor = true;
            // 
            // dgvProduits
            // 
            this.dgvProduits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduits.Location = new System.Drawing.Point(10, 10);
            this.dgvProduits.MultiSelect = false;
            this.dgvProduits.Name = "dgvProduits";
            this.dgvProduits.ReadOnly = true;
            this.dgvProduits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduits.Size = new System.Drawing.Size(770, 250);
            this.dgvProduits.TabIndex = 0;
            this.dgvProduits.SelectionChanged += new System.EventHandler(this.dgvProduits_SelectionChanged);
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(10, 270);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(200, 20);
            this.txtNom.TabIndex = 1;
            // 
            // txtQuantite
            // 
            this.txtQuantite.Location = new System.Drawing.Point(220, 270);
            this.txtQuantite.Name = "txtQuantite";
            this.txtQuantite.Size = new System.Drawing.Size(100, 20);
            this.txtQuantite.TabIndex = 2;
            // 
            // txtPrix
            // 
            this.txtPrix.Location = new System.Drawing.Point(330, 270);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(100, 20);
            this.txtPrix.TabIndex = 3;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(10, 300);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(75, 30);
            this.btnAjouter.TabIndex = 4;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(100, 300);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(75, 30);
            this.btnModifier.TabIndex = 5;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(190, 300);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(75, 30);
            this.btnSupprimer.TabIndex = 6;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnRechercher
            // 
            this.btnRechercher.Location = new System.Drawing.Point(700, 270);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(80, 23);
            this.btnRechercher.TabIndex = 7;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = true;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // txtRechercher
            // 
            this.txtRechercher.Location = new System.Drawing.Point(570, 270);
            this.txtRechercher.Name = "txtRechercher";
            this.txtRechercher.Size = new System.Drawing.Size(120, 20);
            this.txtRechercher.TabIndex = 8;
            // 
            // listViewProduits
            // 
            this.listViewProduits.GridLines = true;
            this.listViewProduits.HideSelection = false;
            this.listViewProduits.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listViewProduits.Location = new System.Drawing.Point(10, 340);
            this.listViewProduits.Name = "listViewProduits";
            this.listViewProduits.Size = new System.Drawing.Size(770, 150);
            this.listViewProduits.TabIndex = 9;
            this.listViewProduits.UseCompatibleStateImageBehavior = false;
            this.listViewProduits.View = System.Windows.Forms.View.Details;
            // 
            // btnExporterPDF
            // 
            this.btnExporterPDF.Location = new System.Drawing.Point(440, 300);
            this.btnExporterPDF.Name = "btnExporterPDF";
            this.btnExporterPDF.Size = new System.Drawing.Size(100, 30);
            this.btnExporterPDF.TabIndex = 10;
            this.btnExporterPDF.Text = "Exporter PDF";
            this.btnExporterPDF.UseVisualStyleBackColor = true;
            this.btnExporterPDF.Click += new System.EventHandler(this.btnExporterPDF_Click);
            // 
            // tabPageVentes
            // 
            this.tabPageVentes.Controls.Add(this.dgvVentes);
            this.tabPageVentes.Controls.Add(this.cmbProduits);
            this.tabPageVentes.Controls.Add(this.txtQuantiteVendue);
            this.tabPageVentes.Controls.Add(this.btnEnregistrerVente);
            this.tabPageVentes.Location = new System.Drawing.Point(4, 22);
            this.tabPageVentes.Name = "tabPageVentes";
            this.tabPageVentes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVentes.Size = new System.Drawing.Size(792, 524);
            this.tabPageVentes.TabIndex = 1;
            this.tabPageVentes.Text = "Ventes";
            this.tabPageVentes.UseVisualStyleBackColor = true;
            // 
            // dgvVentes
            // 
            this.dgvVentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentes.Location = new System.Drawing.Point(10, 10);
            this.dgvVentes.MultiSelect = false;
            this.dgvVentes.Name = "dgvVentes";
            this.dgvVentes.ReadOnly = true;
            this.dgvVentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentes.Size = new System.Drawing.Size(770, 250);
            this.dgvVentes.TabIndex = 0;
            // 
            // cmbProduits
            // 
            this.cmbProduits.Location = new System.Drawing.Point(10, 270);
            this.cmbProduits.Name = "cmbProduits";
            this.cmbProduits.Size = new System.Drawing.Size(200, 21);
            this.cmbProduits.TabIndex = 1;
            // 
            // txtQuantiteVendue
            // 
            this.txtQuantiteVendue.Location = new System.Drawing.Point(220, 270);
            this.txtQuantiteVendue.Name = "txtQuantiteVendue";
            this.txtQuantiteVendue.Size = new System.Drawing.Size(100, 20);
            this.txtQuantiteVendue.TabIndex = 2;
            // 
            // btnEnregistrerVente
            // 
            this.btnEnregistrerVente.Location = new System.Drawing.Point(330, 265);
            this.btnEnregistrerVente.Name = "btnEnregistrerVente";
            this.btnEnregistrerVente.Size = new System.Drawing.Size(150, 30);
            this.btnEnregistrerVente.TabIndex = 3;
            this.btnEnregistrerVente.Text = "Enregistrer Vente";
            this.btnEnregistrerVente.UseVisualStyleBackColor = true;
            this.btnEnregistrerVente.Click += new System.EventHandler(this.btnEnregistrerVente_Click);
            // 
            // tabPageStats
            // 
            this.tabPageStats.Controls.Add(this.lblTotalProduits);
            this.tabPageStats.Controls.Add(this.lblTotalStock);
            this.tabPageStats.Controls.Add(this.lblRupture);
            this.tabPageStats.Location = new System.Drawing.Point(4, 22);
            this.tabPageStats.Name = "tabPageStats";
            this.tabPageStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStats.Size = new System.Drawing.Size(792, 524);
            this.tabPageStats.TabIndex = 2;
            this.tabPageStats.Text = "Stats";
            this.tabPageStats.UseVisualStyleBackColor = true;
            // 
            // lblTotalProduits
            // 
            this.lblTotalProduits.AutoSize = true;
            this.lblTotalProduits.Location = new System.Drawing.Point(20, 30);
            this.lblTotalProduits.Name = "lblTotalProduits";
            this.lblTotalProduits.Size = new System.Drawing.Size(92, 13);
            this.lblTotalProduits.TabIndex = 0;
            this.lblTotalProduits.Text = "Total produits : 0";
            // 
            // lblTotalStock
            // 
            this.lblTotalStock.AutoSize = true;
            this.lblTotalStock.Location = new System.Drawing.Point(20, 60);
            this.lblTotalStock.Name = "lblTotalStock";
            this.lblTotalStock.Size = new System.Drawing.Size(74, 13);
            this.lblTotalStock.TabIndex = 1;
            this.lblTotalStock.Text = "Stock total : 0";
            // 
            // lblRupture
            // 
            this.lblRupture.AutoSize = true;
            this.lblRupture.Location = new System.Drawing.Point(20, 90);
            this.lblRupture.Name = "lblRupture";
            this.lblRupture.Size = new System.Drawing.Size(91, 13);
            this.lblRupture.TabIndex = 2;
            this.lblRupture.Text = "Produits en rupture : Aucun";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Gestion Marché";
            this.tabControl1.ResumeLayout(false);
            this.tabPageProduits.ResumeLayout(false);
            this.tabPageProduits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduits)).EndInit();
            this.tabPageVentes.ResumeLayout(false);
            this.tabPageVentes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentes)).EndInit();
            this.tabPageStats.ResumeLayout(false);
            this.tabPageStats.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageProduits;
        private System.Windows.Forms.TabPage tabPageVentes;
        private System.Windows.Forms.TabPage tabPageStats;
        private System.Windows.Forms.DataGridView dgvProduits;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtQuantite;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.TextBox txtRechercher;
        private System.Windows.Forms.ListView listViewProduits;
        private System.Windows.Forms.Button btnExporterPDF;
        private System.Windows.Forms.DataGridView dgvVentes;
        private System.Windows.Forms.ComboBox cmbProduits;
        private System.Windows.Forms.TextBox txtQuantiteVendue;
        private System.Windows.Forms.Button btnEnregistrerVente;
        private System.Windows.Forms.Label lblTotalProduits;
        private System.Windows.Forms.Label lblTotalStock;
        private System.Windows.Forms.Label lblRupture;
    }
}
