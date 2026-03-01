using System.Data.SQLite;
using System.Windows.Forms;

namespace GestionMarche
{
    public class Database
    {
        private static string connectionString = "Data Source=marche.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static void InitializeDatabase()
        {
            
            using (var conn = GetConnection())
            {
                string createProduits = @"CREATE TABLE IF NOT EXISTS Produits (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Nom TEXT NOT NULL,
                                    Quantite INTEGER NOT NULL,
                                    Prix REAL NOT NULL
                                 );";

                string createVentes = @"CREATE TABLE IF NOT EXISTS Ventes (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    ProduitId INTEGER NOT NULL,
                                    QuantiteVendue INTEGER NOT NULL,
                                    DateVente TEXT NOT NULL,
                                    FOREIGN KEY(ProduitId) REFERENCES Produits(Id)
                                );";

                using (var cmd = new SQLiteCommand(createProduits, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SQLiteCommand(createVentes, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

