﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    class BaseDeDonnees
    {
        private string CheminBdd;
        private string ChaineDeConnexion;

        private static BaseDeDonnees Instance;

        public static BaseDeDonnees GetInstance()
        {
            if (Instance == null)
            {
                Instance =  new BaseDeDonnees();
            }

            return Instance;
        }

        private BaseDeDonnees()
        {
            CheminBdd = "";
            ChaineDeConnexion = "";
            GetCheminBaseDeDonnee();
        }

        private BaseDeDonnees(BaseDeDonnees BaseDeDonneesParam) { }

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

                string RequeteSQL = "SELECT COUNT(*) FROM Articles";

                using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    NombreArticles = Convert.ToInt32(CommandeSQL.ExecuteScalar());
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
                GetCheminBaseDeDonnee();
            }
            return CheminBdd;
        }

        /// <summary>
        /// Permets d'obtenir le chemin de la base de données et de l'associer à l'attribut de l'objet base de données.
        /// </summary>
        /// <exception cref="A DEFINIR">Le fichier de base de données n'a pas été trouvé.</exception>
        public void GetCheminBaseDeDonnee()
        {
            string DossierSolution = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string NomBDD = "Hector.SQLite";
            string CheminComplet = Path.Combine(DossierSolution, NomBDD);

            try
            {
                if (!File.Exists(CheminComplet))
                {
                    throw new Exception(Exception.ERREUR_FICHIER_NON_TROUVE);
                }
                this.CheminBdd = CheminComplet;
                ChaineDeConnexion = @"Data Source= " + CheminComplet;

            }

            catch (Exception Exception)
            {
                Exception.AfficherMessageErreur();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> ChaineDeConnexion </returns>
        public string LireChaineDeConnexion()
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
        public void SetChaineDeConnexion(string NouvelleChaineDeConnexion)
        {
            ChaineDeConnexion = NouvelleChaineDeConnexion;
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

                    Console.WriteLine("Marque " + Nom + " cree avec la ref " + RefMarqueGeneree);
                }
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

                string RequeteSQL = "SELECT RefMarque, Nom FROM Marques";

                using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    using (SQLiteDataReader LecteurDonneeSQL = CommandeSQL.ExecuteReader())
                    {
                        while (LecteurDonneeSQL.Read())
                        {
                            string Nom = LecteurDonneeSQL.GetString(1);
                            Marque NouvelleMarque = Marque.CreerMarqueDepuisSQLite(Nom);

                            if(NouvelleMarque != null)
                                NouvelleMarque.DefineRefMarque(LecteurDonneeSQL.GetInt32(0));

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

                string RequeteSQL = "SELECT RefFamille, Nom FROM Familles";

                using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    using (SQLiteDataReader LecteurDonneeSQL = CommandeSQL.ExecuteReader())
                    {
                        while (LecteurDonneeSQL.Read())
                        {
                            string Nom = LecteurDonneeSQL.GetString(1);
                            Famille NouvelleFamille = Famille.CreerFamilleDepuisSQLite(Nom);

                            if (NouvelleFamille != null)
                                NouvelleFamille.DefineRefFamille(LecteurDonneeSQL.GetInt32(0));
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

                string RequeteSQL = "SELECT s.RefSousFamille, s.Nom, f.Nom FROM SousFamilles s JOIN Familles f ON s.RefFamille = f.RefFamille"; 

                using (SQLiteCommand Command_ReadSubFamilies = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    using (SQLiteDataReader LecteurDonneeSQL = Command_ReadSubFamilies.ExecuteReader())
                    {
                        while (LecteurDonneeSQL.Read())
                        {
                            int RefSousFamille = LecteurDonneeSQL.GetInt32(0);
                            string Nom = LecteurDonneeSQL.GetString(1);
                            string NomFamille = LecteurDonneeSQL.GetString(2);
                            Famille FamilleExistante = Famille.GetFamilleExistante(NomFamille);
                            SousFamille NouvelleSousFamille = SousFamille.CreerSousFamilleDepuisSQLite(Nom, FamilleExistante);

                            if (NouvelleSousFamille != null)
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

                string RequeteSQL = "SELECT a.Description, a.RefArticle, a.PrixHT, a.Quantite, s.Nom, m.Nom FROM Articles a " +
                "JOIN Marques m ON a.RefMarque = m.RefMarque JOIN SousFamilles s ON a.RefSousFamille = s.RefSousFamille";


                using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    using (SQLiteDataReader LecteurDonneeSQL = CommandeSQL.ExecuteReader())
                    {
                        while (LecteurDonneeSQL.Read())
                        {
                            string Description = LecteurDonneeSQL.GetString(0);
                            string RefArticle = LecteurDonneeSQL.GetString(1);
                            double PrixHT = LecteurDonneeSQL.GetDouble(2);
                            uint Quantite = (uint)LecteurDonneeSQL.GetInt32(3);
                            SousFamille SousFamilleExistante = SousFamille.GetSousFamilleExistante(LecteurDonneeSQL.GetString(4));
                            Marque MarqueExistante = Marque.GetMarqueExistante(LecteurDonneeSQL.GetString(5));

                            Article NouvelArticle = Article.CreerArticleDepuisSQLite(Description, RefArticle, MarqueExistante, SousFamilleExistante, PrixHT, Quantite);
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
                using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    CommandeSQL.ExecuteNonQuery();
                }

                RequeteSQL = "DELETE FROM Marques";
                using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    CommandeSQL.ExecuteNonQuery();
                }

                RequeteSQL = "DELETE FROM SousFamilles";
                using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    CommandeSQL.ExecuteNonQuery();
                }

                RequeteSQL = "DELETE FROM Familles";
                using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                { 
                    CommandeSQL.ExecuteNonQuery();
                }

                Connexion.Close();
            }

            Article.ViderDictionnaireArticles();
            Marque.ViderDictionnairesMarques();
            SousFamille.ViderDictionnaireSousFamilles();
            Famille.ViderDictionnaireFamilles();
        }

        /// <summary>
        /// Methode qui permet de suppimer un article de la base de données
        /// </summary>
        /// <param name="RefArticle">La référence de l'article à supprimer</param>
        /// <exception cref="A DEFINIR">La suppression de l'article a échoué.</exception>
        
        public void SupprimerArticleBdd(string RefArticle)
        {
            using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
            {
                Connexion.Open();
                string RequeteSQL = "DELETE FROM Articles WHERE RefArticle = @RefArticle";

                using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    CommandeSQL.Parameters.AddWithValue("@RefArticle", RefArticle);
                    CommandeSQL.ExecuteNonQuery();
                }
                Connexion.Close();
            }
        }

        /// <summary>
        /// Methode qui permet de supprimer une marque de la base de données
        /// </summary>
        /// <param name="RefMarque">La référence de la marque à supprimer</param>
        /// <exception cref="A DEFINIR">La suppression de la marque a échoué.</exception>
        
        public void SupprimerMarqueBdd(int RefMarque)
        {
            using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
            {
                Connexion.Open();

                string RequeteSQL = "DELETE FROM Marques WHERE RefMarque = @RefMarque";

                using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    CommandeSQL.Parameters.AddWithValue("@RefMarque", RefMarque);
                    CommandeSQL.ExecuteNonQuery();
                }
                Connexion.Close();
            }
        }

        /// <summary>
        /// Methode qui permet de supprimer une sous-famille de la base de données
        /// </summary>
        /// <param name="RefSousFamille">La référence de la sous-famille à supprimer</param>
        /// <exception cref="A DEFINIR">La suppression de la sous-famille a échoué.</exception>
        
        public void SupprimerSousFamilleBdd(int RefSousFamille)
        {
            using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
            {
                Connexion.Open();

                string RequeteSQL = "DELETE FROM SousFamilles WHERE RefSousFamille = @RefSousFamille";

                using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    CommandeSQL.Parameters.AddWithValue("@RefSousFamille", RefSousFamille);
                    CommandeSQL.ExecuteNonQuery();
                }
                Connexion.Close();
            }
        }

        /// <summary>
        /// Methode qui permet de supprimer une famille de la base de données
        /// </summary>
        /// <param name="RefFamille">La référence de la famille à supprimer</param>
        /// <exception cref="A DEFINIR">La suppression de la famille a échoué.</exception>
        public void SupprimerFamilleBdd(int RefFamille)
        {
            using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
            {
                Connexion.Open();

                string RequeteSQL = "DELETE FROM Familles WHERE RefFamille = @RefFamille";

                using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                {
                    CommandeSQL.Parameters.AddWithValue("@RefFamille", RefFamille);
                    CommandeSQL.ExecuteNonQuery();
                }
                Connexion.Close();
            }
        }
    }


}
