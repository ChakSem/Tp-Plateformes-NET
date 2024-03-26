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
        private string ChaineDeConnexion;

        public BaseDeDonnees()
        {
            CheminBdd = "";
            ChaineDeConnexion = "";
            GetDatabasePath();
        }

        /// <summary>
        /// Methode pour lire le nombre d'article dans la base de données
        /// </summary>
        /// <returns> Le nombre d'article dans la base de données </returns>

        public int LireNombreArticlesBdd()
        {
            int NombreArticles = 0;

            using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
            {
                
                //Debug
                Connexion.Open();

                string SQL_Query_ReadNumberOfArticles = "SELECT COUNT(*) FROM Articles";

                using (SQLiteCommand Command_ReadNumberOfArticles = new SQLiteCommand(SQL_Query_ReadNumberOfArticles, Connexion))
                {
                    NombreArticles = Convert.ToInt32(Command_ReadNumberOfArticles.ExecuteScalar());
                }
                Connexion.Close();
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
                ChaineDeConnexion = @"Data Source= " + FullDatabasePath;

            }

            catch (Exception Exception)
            {
                Exception.AfficherMessageErreur();
            }
        }

        public string ReadConnectionString()
        {
            try
            {
                if (ChaineDeConnexion == null)
                {
                    throw new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD);
                }

                return ChaineDeConnexion;
            }
            catch (Exception Exception)
            {
                Exception.AfficherMessageErreur();

                return null;
            }
        }

        /// <summary>
        /// Permets de modifier la chaine de connexion de la base de données.
        /// </summary>
        /// <param name="NewConnectionString">La nouvelle chaine de connexion</param>
        public void ModifyConnectionString(string NewConnectionString)
        {
            ChaineDeConnexion = NewConnectionString;
        }

        /// <summary>
        /// Permets d'ajouter des articles à la BDD.
        /// </summary>
        /// <param name="Articles"></param>
        public void AjoutArticlesBdd(List<Article> Articles)
        {
            foreach (Article ArticleExistant in Articles)
            {
                AjoutArticleBdd(ArticleExistant);
            }
        }

        /// <summary>
        /// Permets d'ajouter des articles à la BDD.
        /// </summary>
        /// <param name="Articles">Liste d'articles à ajouter</param>

        public void AjoutArticlesBdd()
        {
            foreach (Article ArticleExistant in Article.GetListeArticles())
            {
                Console.WriteLine(ArticleExistant.ToString());

                AjoutArticleBdd(ArticleExistant);
            }
        }

        /// <summary>
        /// Permets d'ajouter un article à la BDD.
        /// </summary>
        /// <param name="Article">Article à ajouter</param>
        /// <exception cref="A DEFINIR">L'ajout de l'article a échoué.</exception>

        public void AjoutArticleBdd(Article ArticleParam)
        {
            using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
            {
                //System.ArgumentException : 'Data Source cannot be empty.  Use :memory: to open an in-memory database'
                Connexion.Open();

                string Description = ArticleParam.GetDescription();
                string RefArticle = ArticleParam.GetReference();
                double PrixHT = ArticleParam.GetPrixHT();
                uint Quantite = ArticleParam.GetQuantite();
                int RefMarque = ArticleParam.GetMarque().GetRefMarque();
                int RefSousFamille = ArticleParam.GetSousFamille().GetRefSousFamille();

                string RequeteSQL = "INSERT INTO Articles (Description, RefArticle, PrixHT, Quantite, RefMarque, RefSousFamille) VALUES (@Description, @RefArticle, @PrixHT, @Quantite, @RefMarque, @RefSousFamille)";

                using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    CommandeSQL.Parameters.AddWithValue("@Description", Description);
                    CommandeSQL.Parameters.AddWithValue("@RefArticle", RefArticle);
                    CommandeSQL.Parameters.AddWithValue("@PrixHT", PrixHT);
                    CommandeSQL.Parameters.AddWithValue("@Quantite", Quantite);
                    CommandeSQL.Parameters.AddWithValue("@RefMarque", RefMarque);
                    CommandeSQL.Parameters.AddWithValue("@RefSousFamille", RefSousFamille);
                    CommandeSQL.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Permet de recuperer la Reference lorsqu'une Marque, une Famille, ou une SousFamille est inseree dans la base de donnee
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="Table"></param>
        /// <param name="Nom"></param>
        /// <returns></returns>
        private int GetReferenceGeneree(SQLiteConnection Connexion, string Table, string NomReference, string Nom)
        {
            string RequeteSQL = $"SELECT {NomReference} FROM {Table} WHERE Nom = @Nom";

            using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
            {
                CommandeSQL.Parameters.AddWithValue("@Nom", Nom);

                object result = CommandeSQL.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Permets d'ajouter les Marques d'une liste à la BDD.
        /// </summary>
        public void AjoutMarquesBdd()
        {
            foreach (Marque MarqueExistante in Marque.GetListeMarques())
            {
                if (MarqueExistante.GetRefMarque() == -1)
                    AjoutMarqueBdd(MarqueExistante);
            }
        }

        /// <summary>
        /// Permets d'ajouter les Marques d'une liste à la BDD.
        /// </summary>
        public void AjoutMarqueBdd(Marque MarqueParam)
        {
            using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
            {
                Connexion.Open();

                string Nom = MarqueParam.GetNom();
                int RefMarque = MarqueParam.GetRefMarque();

                if (RefMarque != -1)
                {
                    string RequeteSQL = "INSERT INTO Marques (RefMarque, NaNomme) VALUES (@RefMarque, @Nom)";

                    using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                    {
                        CommandeSQL.Parameters.AddWithValue("@Nom", Nom);
                        CommandeSQL.Parameters.AddWithValue("@RefMarque", RefMarque);
                        CommandeSQL.ExecuteNonQuery();
                    }
                }
                else
                {
                    string RequeteSQL = "INSERT INTO Marques (Nom) VALUES (@Nom)";

                    using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                    {
                        CommandeSQL.Parameters.AddWithValue("@Nom", Nom);
                        CommandeSQL.ExecuteScalar();
                    }

                    /* On recupere la Reference generee lors de l'insertion */
                    int RefMarqueGeneree = GetReferenceGeneree(Connexion, "Marques", "RefMarque", Nom);
                    MarqueParam.DefineRefMarque(RefMarqueGeneree);
                }
            }
        }

        /// <summary>
        /// Permets d'ajouter les SousFamilles d'une liste à la BDD.
        /// </summary>
        public void AjoutSousFamillesBdd()
        {
            foreach (SousFamille SousFamilleExistante in SousFamille.GetListeSousFamilles())
            {
                if (SousFamilleExistante.GetRefSousFamille() == -1)
                    AjoutSousFamilleBdd(SousFamilleExistante);
            }
        }

        /// <summary>
        /// Permets d'ajouter les SousFamilles d'une liste à la BDD.
        /// </summary>
        public void AjoutSousFamilleBdd(SousFamille SousFamilleParam)
        {
            using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
            {
                Connexion.Open();

                string Nom = SousFamilleParam.GetNom();
                int RefSousFamille = SousFamilleParam.GetRefSousFamille();
                int RefFamille = SousFamilleParam.GetFamille().GetRefFamille();

                if (RefSousFamille != -1)
                {
                    string RequeteSQL = "INSERT INTO SousFamilles (RefSousFamille, Nom, RefFamille) VALUES (@RefSousFamille, @Nom)";

                    using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                    {
                        CommandeSQL.Parameters.AddWithValue("@Nom", Nom);
                        CommandeSQL.Parameters.AddWithValue("@RefSousFamille", RefSousFamille);
                        CommandeSQL.ExecuteNonQuery();
                    }
                }
                else
                {
                    string RequeteSQL = "INSERT INTO SousFamilles (Nom, RefFamille) VALUES (@Nom, @RefFamille)";

                    using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                    {
                        CommandeSQL.Parameters.AddWithValue("@Nom", Nom);
                        CommandeSQL.Parameters.AddWithValue("@RefFamille", RefFamille);
                        CommandeSQL.ExecuteNonQuery();
                    }

                    /* On recupere la Reference generee lors de l'insertion */
                    int RefSousFamilleGeneree = GetReferenceGeneree(Connexion, "SousFamilles", "RefSousFamille", Nom);
                    SousFamilleParam.DefineRefSousFamille(RefSousFamilleGeneree);
                }
            }
        }

        /// <summary>
        /// Permets d'ajouter les Familles d'une liste à la BDD.
        /// </summary>
        public void AjoutFamillesBdd()
        {
            foreach (Famille FamilleExistante in Famille.GetDictionnaireFamilles())
            {
                if (FamilleExistante.GetRefFamille() == -1)
                    AjoutFamilleBdd(FamilleExistante);
            }
        }

        /// <summary>
        /// Permets d'ajouter les Familles d'une liste à la BDD.
        /// </summary>
        public void AjoutFamilleBdd(Famille FamilleParam)
        {
            using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
            {
                Connexion.Open();

                string Nom = FamilleParam.GetNom();
                int RefFamille = FamilleParam.GetRefFamille();

                if (RefFamille != -1)
                {
                    string RequeteSQL = "INSERT INTO Familles (RefFamille, Name) VALUES (@RefFamille, @Name)";

                    using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                    {
                        CommandeSQL.Parameters.AddWithValue("@Nom", Nom);
                        CommandeSQL.Parameters.AddWithValue("@RefFamille", RefFamille);
                        CommandeSQL.ExecuteNonQuery();
                    }
                }
                else
                {
                    string RequeteSQL = "INSERT INTO Familles (Nom) VALUES (@Nom)";

                    using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                    {
                        CommandeSQL.Parameters.AddWithValue("@Nom", Nom);
                        CommandeSQL.ExecuteNonQuery();
                    }

                    /* On recupere la Reference generee lors de l'insertion */
                    int RefFamilleGeneree = GetReferenceGeneree(Connexion, "Familles", "RefFamille", Nom);
                    FamilleParam.DefineRefFamille(RefFamilleGeneree);
                }
            }
        }

        /// <summary>
        /// Permets de lire la liste des Marques
        /// </summary>
        public void LireMarquesBdd()
        {
            using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
            {
                Connexion.Open();

                string SQL_Query_ReadFamilies = "SELECT RefMarque, Nom FROM Marques";

                using (SQLiteCommand Command_ReadFamilies = new SQLiteCommand(SQL_Query_ReadFamilies, Connexion))
                {
                    using (SQLiteDataReader Reader = Command_ReadFamilies.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            string Nom = Reader.GetString(1);
                            Marque NouvelleMarque = Marque.CreateMarque(Nom);
                            NouvelleMarque.DefineRefMarque(Reader.GetInt32(0));
                        }
                    }
                }
                Connexion.Close();
            }
        }

        /// <summary>
        /// Permets de lire la liste des Familles
        /// </summary>
        public void LireFamillesBdd()
        {
            using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
            {
                Connexion.Open();

                string SQL_Query_ReadFamilies = "SELECT RefFamille, Nom FROM Familles";

                using (SQLiteCommand Command_ReadFamilies = new SQLiteCommand(SQL_Query_ReadFamilies, Connexion))
                {
                    using (SQLiteDataReader Reader = Command_ReadFamilies.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            string Name = Reader.GetString(1);
                            Famille NouvelleFamille = Famille.CreateFamille(Name);
                            NouvelleFamille.DefineRefFamille(Reader.GetInt32(0));
                        }
                    }
                }
                Connexion.Close();
            }
        }

        /// <summary>
        /// Permets de lire la liste des sous-familles.
        /// </summary>
        public void LireSousFamillesBdd()
        {
            using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
            {
                Connexion.Open();

                string SQL_Query_ReadSubFamilies = "SELECT s.RefSousFamille, s.Nom, f.Nom FROM SousFamilles s JOIN Familles f ON s.RefFamille = f.RefFamille"; 

                using (SQLiteCommand Command_ReadSubFamilies = new SQLiteCommand(SQL_Query_ReadSubFamilies, Connexion))
                {
                    using (SQLiteDataReader Reader = Command_ReadSubFamilies.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            int RefSousFamille = Reader.GetInt32(0);
                            string Nom = Reader.GetString(1);
                            Famille FamilleExistante = Famille.GetFamilleExistante(Reader.GetString(2));
                            SousFamille NouvelleSousFamille = SousFamille.CreateSousFamille(Nom, FamilleExistante);
                            NouvelleSousFamille.DefineRefSousFamille(RefSousFamille);
                        }
                    }
                }
                Connexion.Close();
            }
        }

        /// <summary>
        /// Permets de lire la liste des articles.
        /// </summary>
        public void LireArticlesBdd()
        {
            using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
            {
                Connexion.Open();

                string SQL_Query_ReadArticles = "SELECT a.Description, a.RefArticle, a.PrixHT, a.Quantite, s.Nom, m.Nom FROM Articles a " +
                "JOIN Marques m ON a.RefMarque = m.RefMarque JOIN SousFamilles s ON a.RefSousFamille = s.RefSousFamille";


                using (SQLiteCommand Command_ReadArticles = new SQLiteCommand(SQL_Query_ReadArticles, Connexion))
                {
                    using (SQLiteDataReader Reader = Command_ReadArticles.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            string Description = Reader.GetString(0);
                            string RefArticle = Reader.GetString(1);
                            double PrixHT = Reader.GetDouble(2);
                            uint Quantite = (uint) Reader.GetInt32(3);
                            Marque MarqueExistante = Marque.GetMarqueExistante(Reader.GetString(4));
                            SousFamille SousFamilleExistante = SousFamille.GetSousFamilleExistante(Reader.GetString(5));

                            Article article = Article.CreateArticleSansException(Description, RefArticle, MarqueExistante, SousFamilleExistante, PrixHT, Quantite);
                        }
                    }
                }
                Connexion.Close();
            }
        }

        public void ViderDonnees()
        {
            using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
            {
                Connexion.Open();

                string RequeteSQL = "DELETE FROM Articles";
                using (SQLiteCommand Command_DeleteArticles = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    Command_DeleteArticles.ExecuteNonQuery();
                }

                RequeteSQL = "DELETE FROM Marques";
                using (SQLiteCommand Command_DeleteMarques = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    Command_DeleteMarques.ExecuteNonQuery();
                }

                RequeteSQL = "DELETE FROM SousFamilles";
                using (SQLiteCommand Command_DeleteSousFamilles = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    Command_DeleteSousFamilles.ExecuteNonQuery();
                }

                RequeteSQL = "DELETE FROM Familles";
                using (SQLiteCommand Command_DeleteFamilles = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    Command_DeleteFamilles.ExecuteNonQuery();
                }

                Connexion.Close();
            }

            Article.ViderDictionnaireArticles();
            Marque.ViderDictionnairesMarques();
            SousFamille.ViderDictionnaireSousFamilles();
            Famille.ViderDictionnaireFamilles();
        }
    }
}
