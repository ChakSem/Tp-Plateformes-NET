using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace Hector
{
    class Database
    {
        private string DatabasePath;
        private string ConnectionString;
        private List<Marque> MarqueList;
        private List<Famille> FamilleList;
        private List<SousFamille> SousFamilleList;
        private List<Article> ArticleList;

        public Database()
        {
            DatabasePath = "";
            ConnectionString = "";
            MarqueList = new List<Marque>();
            FamilleList = new List<Famille>();
            SousFamilleList = new List<SousFamille>();
            ArticleList = new List<Article>();
        }

        /// <summary>
        /// Getter qui permet d'acceder au chemin de la base de données
        /// </summary>
        /// <returns> Le chemin de la base de données </returns>
        public string ReadDatabasePath()
        {
            if (DatabasePath == null)
            {
                GetDatabasePath();
            }
            return DatabasePath;
        }

        /// <summary>
        /// Permets d'obtenir le chemin de la base de données et de l'associer à l'attribut de l'objet base de données.
        /// </summary>
        /// <exception cref="A DEFINIR">Le fichier de base de données n'a pas été trouvé.</exception>
        public void GetDatabasePath()
        {
            string ExecutablePath = AppDomain.CurrentDomain.BaseDirectory;
            string DatabaseName = "Hector.SQLite";
            string FullDatabasePath = Path.Combine(ExecutablePath, DatabaseName);

            if (!File.Exists(FullDatabasePath))
            {
                throw new FileNotFoundException("Database file not found.", FullDatabasePath);
            }

            this.DatabasePath = FullDatabasePath;
            ConnectionString = $"Data Source={FullDatabasePath};Version=3;";
        }

        public string ReadConnectionString()
        {
            if (ConnectionString == null)
            {
                throw new Exception("Database file not found.");
            }
            return ConnectionString;
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
        /// Permets de lire la liste des marques.
        /// </summary>
        /// <returns> La liste des marques </returns>
        public List<Marque> ReadBrandList()
        {
            return MarqueList;
        }
        /// <summary>
        /// Permets d'ajouter les marques d'une liste à la BDD.
        /// </summary>
        public void AddAllBrandsToDatabase()
        {
            foreach (Marque marque in MarqueList)
            {
                using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString))
                {
                    Connection.Open();

                    string BrandName = marque.GetNom();

                    if (!IsBrandNamePresentInDatabase(BrandName, Connection))
                    {
                        string SQL_Query_AddBrand = "INSERT INTO Brands (Name) VALUES (@Name)";

                        using (SQLiteCommand Command_AddBrand = new SQLiteCommand(SQL_Query_AddBrand, Connection))
                        {
                            Command_AddBrand.Parameters.AddWithValue("@Name", BrandName);
                            int RowsAffected = Command_AddBrand.ExecuteNonQuery();
                        }
                    }
                    Connection.Close();
                }
            }
        }




        /// <summary>
        /// Permets de lire la liste des familles.
        /// </summary>
        /// 
        public void ReadAllFamiliesFromDatabase()
        {
            FamilleList.Clear();

            using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();

                string SQL_Query_ReadFamilies = "SELECT * FROM Families";

                using (SQLiteCommand Command_ReadFamilies = new SQLiteCommand(SQL_Query_ReadFamilies, Connection))
                {
                    using (SQLiteDataReader Reader = Command_ReadFamilies.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            int Reference = Reader.GetInt32(0);
                            string Name = Reader.GetString(1);
                            Famille famille = new Famille(Reference, Name);
                            FamilleList.Add(famille);
                        }
                    }
                }
                Connection.Close();
            }
        }

        /// <summary>
        /// Permets de lire la liste des sous-familles.
        /// </summary>
        /// 
        public void ReadAllSubFamiliesFromDatabase()
        {
            SousFamilleList.Clear();

            using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();

                string SQL_Query_ReadSubFamilies = "SELECT * FROM SubFamilies";

                using (SQLiteCommand Command_ReadSubFamilies = new SQLiteCommand(SQL_Query_ReadSubFamilies, Connection))
                {
                    using (SQLiteDataReader Reader = Command_ReadSubFamilies.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            int Reference = Reader.GetInt32(0);
                            string Name = Reader.GetString(1);
                            int FamilyReference = Reader.GetInt32(2);
                            Famille Family = GetFamilyFromReference(FamilyReference);
                            SousFamille sousFamille = new SousFamille(Reference, Name, Family);
                            SousFamilleList.Add(sousFamille);
                        }
                    }
                }
                Connection.Close();
            }
        }

        /// <summary>
        /// Permets de lire la liste des articles.
        /// </summary>

        public void ReadAllArticlesFromDatabase()
        {
            ArticleList.Clear();

            using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();

                string SQL_Query_ReadArticles = "SELECT * FROM Articles";

                using (SQLiteCommand Command_ReadArticles = new SQLiteCommand(SQL_Query_ReadArticles, Connection))
                {
                    using (SQLiteDataReader Reader = Command_ReadArticles.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            int Reference = Reader.GetInt32(0);
                            string Name = Reader.GetString(1);
                            int BrandReference = Reader.GetInt32(2);
                            Marque Brand = GetBrandFromReference(BrandReference);
                            int SubFamilyReference = Reader.GetInt32(3);
                            SousFamille SubFamily = GetSubFamilyFromReference(SubFamilyReference);
                            Article article = new Article(Reference, Name, Brand, SubFamily);
                            ArticleList.Add(article);
                        }
                    }
                }
                Connection.Close();
            }
        }

        /// <summary>
        /// Permets de vérifier si une marque est déjà présente dans la base de données.
        /// </summary>
        /// <param name="BrandName">Le nom de la marque à vérifier</param>
        /// <param name="Connection">La connexion à la base de données</param>
        /// <returns> Vrai si la marque est déjà présente, faux sinon </returns>
        public bool IsBrandNamePresentInDatabase(string BrandName, SQLiteConnection Connection)
        {
            string SQL_Query_CountBrand = "SELECT COUNT(*) FROM Brands WHERE Name = @Name";

            using (SQLiteCommand Command_CountBrand = new SQLiteCommand(SQL_Query_CountBrand, Connection))
            {
                Command_CountBrand.Parameters.AddWithValue("@Name", BrandName);
                int NumberOfRows = Convert.ToInt32(Command_CountBrand.ExecuteScalar());

                if (NumberOfRows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Permets de vérifier si une famille est déjà présente dans la base de données.
        /// </summary>
        /// <param name="FamilyName">Le nom de la famille à vérifier</param>
        /// <param name="Connection">La connexion à la base de données</param>
        /// <returns> Vrai si la famille est déjà présente, faux sinon </returns>
        public bool IsFamilyNamePresentInDatabase(string FamilyName, SQLiteConnection Connection)
        {
            string SQL_Query_CountFamily = "SELECT COUNT(*) FROM Families WHERE Name = @Name";

            using (SQLiteCommand Command_CountFamily = new SQLiteCommand(SQL_Query_CountFamily, Connection))
            {
                Command_CountFamily.Parameters.AddWithValue("@Name", FamilyName);
                int NumberOfRows = Convert.ToInt32(Command_CountFamily.ExecuteScalar());

                if (NumberOfRows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Permets de vérifier si une sous-famille est déjà présente dans la base de données.
        /// </summary>
        /// <param name="SubFamilyName">Le nom de la sous-famille à vérifier</param>
        /// <param name="Connection">La connexion à la base de données</param>
        /// <returns> Vrai si la sous-famille est déjà présente, faux sinon </returns>

        public bool IsSubFamilyNamePresentInDatabase(string SubFamilyName, SQLiteConnection Connection)
        {
            string SQL_Query_CountSubFamily = "SELECT COUNT(*) FROM SubFamilies WHERE Name = @Name";

            using (SQLiteCommand Command_CountSubFamily = new SQLiteCommand(SQL_Query_CountSubFamily, Connection))
            {
                Command_CountSubFamily.Parameters.AddWithValue("@Name", SubFamilyName);
                int NumberOfRows = Convert.ToInt32(Command_CountSubFamily.ExecuteScalar());

                if (NumberOfRows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }



        /// <summary>
        /// Permets de lire la liste des familles.
        /// </summary>
        /// <returns> La liste des familles </returns>
        public List<Famille> ReadFamilyList()
        {
            return FamilleList;
        }




        /// <summary>
        /// Permets de lire la liste des sous-familles.
        /// </summary>
        /// <returns> La liste des sous-familles </returns>
        public List<SousFamille> ReadSubFamilyList()
        {
            return SousFamilleList;
        }

        /// <summary>
        /// Permets de lire la liste des articles.
        /// </summary>
        /// <returns> La liste des articles </returns>
        public List<Article> ReadArticleList()
        {
            return ArticleList;
        }

        /// <summary>
        /// Permets de lire la liste des articles d'une famille.
        /// </summary>
        /// <param name="FamilyName">Le nom de la famille</param>
        /// <returns> La liste des articles de la famille </returns>
        /// <exception cref="A DEFINIR">La famille n'a pas été trouvée.</exception>

        public List<Article> ReadArticleListFromFamily(string FamilyName)
        {
            List<Article> ArticleListFromFamily = new List<Article>();

            foreach (Article article in ArticleList)
            {
                if (article.GetFamily().GetNom() == FamilyName)
                {
                    ArticleListFromFamily.Add(article);
                }
            }

            return ArticleListFromFamily;
        }

        /// <summary>
        /// Permets de lire la liste des articles d'une sous-famille.
        /// </summary>
        /// <param name="SubFamilyName">Le nom de la sous-famille</param>
        /// <returns> La liste des articles de la sous-famille </returns>
        /// <exception cref="A DEFINIR">La sous-famille n'a pas été trouvée.</exception>
        /// 
        public List<Article> ReadArticleListFromSubFamily(string SubFamilyName)
        {
            List<Article> ArticleListFromSubFamily = new List<Article>();

            foreach (Article article in ArticleList)
            {
                if (article.GetSubFamily().GetNom() == SubFamilyName)
                {
                    ArticleListFromSubFamily.Add(article);
                }
            }

            return ArticleListFromSubFamily;
        }

        /// <summary>
        /// Permets de lire la liste des articles d'une marque.
        /// </summary>
        /// <param name="BrandName">Le nom de la marque</param>
        /// <returns> La liste des articles de la marque </returns>
        /// <exception cref="A DEFINIR">La marque n'a pas été trouvée.</exception>

        public List<Article> ReadArticleListFromBrand(string BrandName)
        {
            List<Article> ArticleListFromBrand = new List<Article>();

            foreach (Article article in ArticleList)
            {
                if (article.GetBrand().GetNom() == BrandName)
                {
                    ArticleListFromBrand.Add(article);
                }
            }

            return ArticleListFromBrand;
        }



    }
}
