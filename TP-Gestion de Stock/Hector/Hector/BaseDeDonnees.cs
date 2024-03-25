using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    class BaseDeDonnees
    {
        private string CheminBdd;
        private string ConnectionString;

        public BaseDeDonnees()
        {
            CheminBdd = "";
            ConnectionString = "";
            GetDatabasePath();
            System.Console.WriteLine("BDD : " + CheminBdd);
            System.Console.WriteLine("Connection : " + ConnectionString);
        }

        /// <summary>
        /// Methode pour lire le nombre d'article dans la base de données
        /// </summary>
        /// <returns> Le nombre d'article dans la base de données </returns>

        public int LireNombreArticlesBdd()
        {
            int NombreArticles = 0;

            using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString))
            {
                
                //Debug
                System.Console.WriteLine(ConnectionString);
                Connection.Open();

                string SQL_Query_ReadNumberOfArticles = "SELECT COUNT(*) FROM Articles";

                using (SQLiteCommand Command_ReadNumberOfArticles = new SQLiteCommand(SQL_Query_ReadNumberOfArticles, Connection))
                {
                    NombreArticles = Convert.ToInt32(Command_ReadNumberOfArticles.ExecuteScalar());
                }
                Connection.Close();
            }

            return NombreArticles;
        }

        /// <summary>
        /// Getter qui permet d'acceder au chemin de la base de données
        /// </summary>
        /// <returns> Le chemin de la base de données </returns>
        public string LireCheminBdd()
        {
            if (CheminBdd == null)
            {
                GetDatabasePath();
            }
            return CheminBdd;
        }

        /// <summary>
        /// Permets d'obtenir le chemin de la base de données et de l'associer à l'attribut de l'objet base de données.
        /// </summary>
        /// <exception cref="A DEFINIR">Le fichier de base de données n'a pas été trouvé.</exception>
        public void GetDatabasePath()
        {
            string SolutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string DatabaseName = "Hector.SQLite";
            string FullDatabasePath = Path.Combine(SolutionDirectory, DatabaseName);

            try
            {
                if (!File.Exists(FullDatabasePath))
                {
                    throw new Exception(Exception.ERREUR_FICHIER_NON_TROUVE);
                }
                this.CheminBdd = FullDatabasePath;
                ConnectionString = @"Data Source= " + FullDatabasePath;

            }

            catch (Exception Exception)
            {
                Exception.DisplayErrorMessage();
            }
        }

        public string ReadConnectionString()
        {
            try
            {
                if (ConnectionString == null)
                {
                    throw new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD);
                }

                return ConnectionString;
            }
            catch (Exception Exception)
            {
                Exception.DisplayErrorMessage();

                return null;
            }
        }

        /// <summary>
        /// Permets de modifier la chaine de connexion de la base de données.
        /// </summary>
        /// <param name="NewConnectionString">La nouvelle chaine de connexion</param>
        public void ModifyConnectionString(string NewConnectionString)
        {
            ConnectionString = NewConnectionString;
        }
        /// <summary>
        /// Permets d'ajouter des articles à la BDD.
        /// </summary>
        /// <param name="Articles">Liste d'articles à ajouter</param>
        /// <exception cref="A DEFINIR">L'ajout des articles a échoué.</exception>

        public void AjoutArticlesBdd(List<Article> Articles)
        {
            foreach (Article article in Articles)
            {
                using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString))
                {
                    Connection.Open();

                    string Description = article.GetDescription();
                    string Reference = article.GetReference();
                    double PrixHT = article.GetPrixHT();
                    string Marque = article.GetMarque().GetNom();
                    string SousFamille = article.GetSousFamille().GetNom();
                    string Famille = article.GetSousFamille().GetFamille().GetNom();

                    string SQL_Query_AddArticle = "INSERT INTO Articles (Description, RefArticle, PrixHT, Marque, SousFamille, Famille) VALUES (@Description, @RefArticle, @PrixHT, @Marque, @SousFamille, @Famille)";

                    using (SQLiteCommand Command_AddArticle = new SQLiteCommand(SQL_Query_AddArticle, Connection))
                    {
                        Command_AddArticle.Parameters.AddWithValue("@Description", Description);
                        Command_AddArticle.Parameters.AddWithValue("@RefArticle", Reference);
                        Command_AddArticle.Parameters.AddWithValue("@PrixHT", PrixHT);
                        Command_AddArticle.Parameters.AddWithValue("@Marque", Marque);
                        Command_AddArticle.Parameters.AddWithValue("@SousFamille", SousFamille);
                        Command_AddArticle.Parameters.AddWithValue("@Famille", Famille);
                        int RowsAffected = Command_AddArticle.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Permets d'ajouter un article à la BDD.
        /// </summary>
        /// <param name="article">Article à ajouter</param>
        /// <exception cref="A DEFINIR">L'ajout de l'article a échoué.</exception>

        public void AjoutArticleBdd(Article article)
        {
            using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString))
            {
                //System.ArgumentException : 'Data Source cannot be empty.  Use :memory: to open an in-memory database'
                Connection.Open();

                string Description = article.GetDescription();
                string Reference = article.GetReference();
                double PrixHT = article.GetPrixHT();
                string Marque = article.GetMarque().GetNom();
                string SousFamille = article.GetSousFamille().GetNom();
                string Famille = article.GetSousFamille().GetFamille().GetNom();

                string SQL_Query_AddArticle = "INSERT INTO Articles (Description, RefArticle, PrixHT, Marque, SousFamille, Famille) VALUES (@Description, @RefArticle, @PrixHT, @Marque, @SousFamille, @Famille)";

                using (SQLiteCommand Command_AddArticle = new SQLiteCommand(SQL_Query_AddArticle, Connection))
                {
                    Command_AddArticle.Parameters.AddWithValue("@Description", Description);
                    Command_AddArticle.Parameters.AddWithValue("@RefArticle", Reference);
                    Command_AddArticle.Parameters.AddWithValue("@PrixHT", PrixHT);
                    Command_AddArticle.Parameters.AddWithValue("@Marque", Marque);
                    Command_AddArticle.Parameters.AddWithValue("@SousFamille", SousFamille);
                    Command_AddArticle.Parameters.AddWithValue("@Famille", Famille);
                    int RowsAffected = Command_AddArticle.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Permets d'ajouter les marques d'une liste à la BDD.
        /// </summary>
        public void AjoutMarquesBdd()
        {
            foreach (Marque marque in Marque.GetListeMarques())
            {
                using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString))
                {
                    Connection.Open();

                    string BrandName = marque.GetNom();

                    string SQL_Query_AddBrand = "INSERT INTO Brands (Name) VALUES (@Name)";

                    using (SQLiteCommand Command_AddBrand = new SQLiteCommand(SQL_Query_AddBrand, Connection))
                    {
                        Command_AddBrand.Parameters.AddWithValue("@Name", BrandName);
                        int RowsAffected = Command_AddBrand.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Permets de lire la liste des familles.
        /// </summary>
        public void LireFamillesBdd()
        {
            using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();

                string SQL_Query_ReadFamilies = "SELECT nom FROM familles";

                using (SQLiteCommand Command_ReadFamilies = new SQLiteCommand(SQL_Query_ReadFamilies, Connection))
                {
                    using (SQLiteDataReader Reader = Command_ReadFamilies.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            string Name = Reader.GetString(1);
                            Famille famille = Famille.CreateFamille(Name);
                        }
                    }
                }
                Connection.Close();
            }
        }

        /// <summary>
        /// Permets de lire la liste des sous-familles.
        /// </summary>
        public void LireSousFamillesBdd()
        {
            using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();

                string SQL_Query_ReadSubFamilies = "SELECT s.Nom f.Nom FROM Sous-Famille s NATURAL JOIN Famille f";

                using (SQLiteCommand Command_ReadSubFamilies = new SQLiteCommand(SQL_Query_ReadSubFamilies, Connection))
                {
                    using (SQLiteDataReader Reader = Command_ReadSubFamilies.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            string Nom = Reader.GetString(0);
                            string NomFamille = Reader.GetString(1);
                            Famille Famille = Famille.CreateFamille(NomFamille);
                            SousFamille SousFamille = SousFamille.CreateSousFamille(Nom, Famille);
                        }
                    }
                }
                Connection.Close();
            }
        }

        /// <summary>
        /// Permets de lire la liste des articles.
        /// </summary>
        public void LireArticlesBdd()
        {
            using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();

                string SQL_Query_ReadArticles = "SELECT Description, RefArticle, PrixHT, Quantite, s.Nom, m.Nom, f.Nom FROM Articles NATURAL JOIN Marques m NATURAL JOIN SousFamille s NATURAL JOIN Famille f";

                using (SQLiteCommand Command_ReadArticles = new SQLiteCommand(SQL_Query_ReadArticles, Connection))
                {
                    using (SQLiteDataReader Reader = Command_ReadArticles.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            string Description = Reader.GetString(0);
                            string Reference = Reader.GetString(1);
                            double PrixHT = Reader.GetDouble(2);
                            uint Quantite = (uint)Reader.GetInt32(3);
                            Marque Marque = Marque.CreateMarque(Reader.GetString(4));
                            Famille Famille = Famille.CreateFamille(Reader.GetString(6));
                            SousFamille SousFamille = SousFamille.CreateSousFamille(Reader.GetString(5), Famille);

                            Article article = Article.CreateArticle(Description, Reference, Marque, SousFamille, PrixHT);
                        }
                    }
                }
                Connection.Close();
            }
        }

        public void ViderDonnees()
        {
            Article.ViderDictionnaireArticles();
            Marque.ViderDictionnairesMarques();
            SousFamille.ViderDictionnaireSousFamilles();
            Famille.ViderDictionnaireFamilles();
        }
    }
}
