using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    /// <summary>
    /// Classe gérant la communication avec le fichier .sqlite
    /// </summary>
    class BaseDeDonnees
    {
        private string ChaineDeConnexion;
        private string CheminAbsolu;

        private static BaseDeDonnees Instance; // Cette classe a été définie en singleton pour ne pas avoir à réinitialiser les chemins à chaque appel

        /// <summary>
        /// Méthode gérant l'ouverture d'une instance, ou renvoie l'instante déjà ouverte, si cette méthode a déjà été appelée 
        /// </summary>
        /// <returns></returns>
        public static BaseDeDonnees GetInstance()
        {
            if (Instance == null)
            {
                Instance =  new BaseDeDonnees();
            }

            return Instance;
        }

        /// <summary>
        /// 
        /// </summary>
        private BaseDeDonnees()
        {
            CheminAbsolu = "";
            ChaineDeConnexion = "";
            GetCheminBaseDeDonnee();

            Console.WriteLine(CheminAbsolu);
        }

        private BaseDeDonnees(BaseDeDonnees BaseDeDonneesParam) { }

        /// <summary>
        /// Accesseur en lecture du chemin de la base de données
        /// </summary>
        /// <returns> CheminAbsolu </returns>
        public string GetCheminAbsolu()
        {
            return CheminAbsolu;
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
        /// Permets de génerer le chemin absolu du fichier Hector.SQLite
        /// </summary>
        public void GetCheminBaseDeDonnee()
        {
            string CheminProjet = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string NomBDD = "Hector.SQLite";
            string CheminComplet = Path.Combine(CheminProjet, NomBDD);

            try
            {
                if (!File.Exists(CheminComplet))
                {
                    throw new Exception(Exception.ERREUR_FICHIER_NON_TROUVE);
                }
                this.CheminAbsolu = CheminComplet;
                ChaineDeConnexion = @"Data Source= " + CheminComplet;
            }

            catch (Exception Exception)
            {
                Exception.AfficherMessageErreur();
            }
        }

        /// <summary>
        /// Permets d'ajouter un article à la BDD
        /// </summary>
        /// <param name="ArticleParam">Article à ajouter</param>
        public void AjoutArticleBdd(Article ArticleParam)
        {
            try
            {
                using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
                {
                    Connexion.Open();
                    string RefArticle = ArticleParam.GetReference();
                    string Description = ArticleParam.GetDescription();
                    double PrixHT = ArticleParam.GetPrixHT();
                    uint Quantite = ArticleParam.GetQuantite();
                    int RefMarque = ArticleParam.GetMarque().GetRefMarque();
                    int RefSousFamille = ArticleParam.GetSousFamille().GetRefSousFamille();

                    string RequeteSQL = "INSERT INTO Articles (Description, RefArticle, PrixHT, Quantite, RefMarque, RefSousFamille) VALUES (@Description, @RefArticle, @PrixHT, @Quantite, @RefMarque, @RefSousFamille)";
                    //On ajoute l'article à la BDD
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
                    Connexion.Close();

                }
            }
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();
            }
        }

        /// <summary>
        /// Permet de recuperer la reference, genérée après qu'une Marque, une Famille, ou une SousFamille est inseree dans la base de donnee
        /// </summary>
        /// <param name="Connexion"> Connexion SQLiteConnection ouverte </param>
        /// <param name="Table"></param>
        /// <param name="IntituleReference"></param>
        /// <param name="Nom"></param>
        /// <returns></returns>
        private int GetReferenceGeneree(SQLiteConnection Connexion, string Table, string IntituleReference, string Nom)
        {
            string RequeteSQL = $"SELECT {IntituleReference} FROM {Table} WHERE Nom = @Nom";

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
                    return Global.REFERENCE_NON_ASSIGNEE;
                }
            }
        }

        public void AjoutMarqueBdd(Marque MarqueParam)
        {
            try
            {
                using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
                {
                    Connexion.Open();

                    string Nom = MarqueParam.GetNom();
                    int RefMarque = MarqueParam.GetRefMarque();

                    if (RefMarque == Global.REFERENCE_NON_ASSIGNEE) // Si la réference de la marque n'a pas encore été générée
                    {
                        string RequeteSQL = "INSERT INTO Marques (Nom) VALUES (@Nom)";

                        using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                        {
                            CommandeSQL.Parameters.AddWithValue("@Nom", Nom);
                            CommandeSQL.ExecuteNonQuery();
                        }

                        /* On recupere la Reference generee lors de l'insertion */
                        int RefMarqueGeneree = GetReferenceGeneree(Connexion, "Marques", "RefMarque", Nom);
                        MarqueParam.DefineRefMarque(RefMarqueGeneree);
                    }
                    else
                    {
                        string RequeteSQL = "INSERT INTO Marques (RefMarque, Nom) VALUES (@RefMarque, @Nom)";

                        using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                        {
                            CommandeSQL.Parameters.AddWithValue("@Nom", Nom);
                            CommandeSQL.Parameters.AddWithValue("@RefMarque", RefMarque);
                            CommandeSQL.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();
            }
        }




        /// <summary>
        /// Permets d'ajouter les SousFamilles d'une liste à la BDD.
        /// </summary>
        public void AjoutSousFamilleBdd(SousFamille SousFamilleParam)
        {
            try
            {
                using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
                {
                    Connexion.Open();

                    string Nom = SousFamilleParam.GetNom();
                    int RefSousFamille = SousFamilleParam.GetRefSousFamille();
                    int RefFamille = SousFamilleParam.GetFamille().GetRefFamille();

                    if (RefSousFamille == Global.REFERENCE_NON_ASSIGNEE) // Si la réference de la sous-famille n'a pas encore été générée
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
                    else
                    {
                        string RequeteSQL = "INSERT INTO SousFamilles (RefSousFamille, Nom, RefFamille) VALUES (@RefSousFamille, @Nom)";

                        using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                        {
                            CommandeSQL.Parameters.AddWithValue("@Nom", Nom);
                            CommandeSQL.Parameters.AddWithValue("@RefSousFamille", RefSousFamille);
                            CommandeSQL.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();
            }
        }

        /// <summary>
        /// Permets d'ajouter les Familles d'une liste à la BDD.
        /// </summary>
        public void AjoutFamilleBdd(Famille FamilleParam)
        {
            try { 
                using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
                {
                    Connexion.Open();

                    string Nom = FamilleParam.GetNom();
                    int RefFamille = FamilleParam.GetRefFamille();

                    if (RefFamille == Global.REFERENCE_NON_ASSIGNEE) // Si la réference de la famille n'a pas encore été générée
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
                    else
                    {
                        string RequeteSQL = "INSERT INTO Familles (RefFamille, Name) VALUES (@RefFamille, @Name)";

                        using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                        {
                            CommandeSQL.Parameters.AddWithValue("@Nom", Nom);
                            CommandeSQL.Parameters.AddWithValue("@RefFamille", RefFamille);
                            CommandeSQL.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();
            }
        }

        /// <summary>
        /// Permets de lire la liste des Marques
        /// </summary>
        public void LireMarquesBdd()
        {
            try
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
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();
            }
        }

        /// <summary>
        /// Permets de lire la liste des Familles
        /// </summary>
        public void LireFamillesBdd()
        {
            try
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
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();
            }
        }

        /// <summary>
        /// Permets de lire la liste des sous-familles.
        /// </summary>
        public void LireSousFamillesBdd()
        {
            try
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
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();
            }
        }

        /// <summary>
        /// Permets de lire la liste des articles.
        /// </summary>
        public void LireArticlesBdd()
        {
            try
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
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();
            }
        }

        public void ViderDonnees()
        {
            try
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

            }
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();
            }

            Article.ViderDictionnaireArticles();
            Marque.ViderDictionnaireMarques();
            SousFamille.ViderDictionnaireSousFamilles();
            Famille.ViderDictionnaireFamilles();
        }

        /// <summary>
        /// Methode qui permet de mettre à jour les modification d'un article dans la base de données
        /// </summary>
        /// <param name="NouvelleRefArticle"></param>
        /// <param name="NouvelleDescription"></param>
        /// <param name="NouveauPrixHT"></param>
        /// <param name="NouvelleQuantite"></param>
        /// <param name="NouvelleRefMarque"></param>
        /// <param name="NouvelleRefSousFamille"></param>
        /// <param name="ReferenceAvantModification"> Reference avant modification, pour pouvoir mettre à jour même si la reference change </param>
        /// <returns></returns>
        public uint ModifierArticleBdd(string NouvelleRefArticle, string NouvelleDescription, double NouveauPrixHT, uint NouvelleQuantite, int NouvelleRefMarque, 
            int NouvelleRefSousFamille, string ReferenceAvantModification)
        {
            try
            {
                using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
                {
                    Connexion.Open();
                    string RequeteSQL = "UPDATE Articles SET RefArticle = @RefArticle, Description = @Description, PrixHT = @PrixHT, Quantite = @Quantite, RefMarque = @RefMarque, " +
                        "RefSousFamille = @RefSousFamille WHERE RefArticle = @RefArticleAvantModification";

                    using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                    {
                        CommandeSQL.Parameters.AddWithValue("@RefArticle", NouvelleRefArticle);
                        CommandeSQL.Parameters.AddWithValue("@Description", NouvelleDescription);
                        CommandeSQL.Parameters.AddWithValue("@PrixHT", NouveauPrixHT);
                        CommandeSQL.Parameters.AddWithValue("@Quantite", NouvelleQuantite);
                        CommandeSQL.Parameters.AddWithValue("@RefMarque", NouvelleRefMarque);
                        CommandeSQL.Parameters.AddWithValue("@RefSousFamille", NouvelleRefSousFamille);
                        CommandeSQL.Parameters.AddWithValue("@RefArticleAvantModification", ReferenceAvantModification);

                        CommandeSQL.ExecuteNonQuery();
                    }
                    Connexion.Close();
                }

                return Exception.RETOUR_NORMAL;
            }
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();

                return Exception.RETOUR_ERREUR;
            }
        }

        /// <summary>
        /// Methode qui permet de modifier une marque de la base de données
        /// </summary>
        /// <param name="RefMarque"></param>
        /// <param name="NouveauNom"></param>
        /// <returns></returns>
        public uint ModifierMarqueBdd(int RefMarque, string NouveauNom)
        {
            try
            {
                using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
                {
                    Connexion.Open();
                    string RequeteSQL = "UPDATE Marques SET Nom=@Nom WHERE RefMarque = @RefMarque";

                    using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                    {
                        CommandeSQL.Parameters.AddWithValue("@Nom", NouveauNom);
                        CommandeSQL.Parameters.AddWithValue("@RefMarque", RefMarque);

                        CommandeSQL.ExecuteNonQuery();
                    }
                    Connexion.Close();
                }

                return Exception.RETOUR_NORMAL;
            }
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();

                return Exception.RETOUR_ERREUR;
            }
        }

        /// <summary>
        /// Methode qui permet de modifier une sous-famille de la base de données
        /// </summary>
        /// <param name="RefSousFamille"></param>
        /// <param name="NouveauNom"></param>
        /// <param name="RefFamille"></param>
        /// <returns></returns>
        public uint ModifierSousFamilleBdd(int RefSousFamille, string NouveauNom, int RefFamille)
        {
            try
            {
                using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
                {
                    Connexion.Open();
                    string RequeteSQL = "UPDATE SousFamilles SET Nom=@Nom, RefFamille = @RefFamille WHERE RefSousFamille = @RefSousFamille";

                    using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                    {
                        CommandeSQL.Parameters.AddWithValue("@Nom", NouveauNom);
                        CommandeSQL.Parameters.AddWithValue("@RefFamille", RefFamille);
                        CommandeSQL.Parameters.AddWithValue("@RefSousFamille", RefSousFamille);

                        CommandeSQL.ExecuteNonQuery();
                    }
                    Connexion.Close();
                }

                return Exception.RETOUR_NORMAL;
            }
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();

                return Exception.RETOUR_ERREUR;
            }
        }

        /// <summary>
        /// Methode qui permet de modifier une famille de la base de données
        /// </summary>
        /// <param name="RefFamille"></param>
        /// <param name="NouveauNom"></param>
        /// <returns></returns>
        public uint ModifierFamilleBdd(int RefFamille, string NouveauNom)
        {
            try
            {
                using (SQLiteConnection Connexion = new SQLiteConnection(ChaineDeConnexion))
                {
                    Connexion.Open();
                    string RequeteSQL = "UPDATE Familles SET Nom=@Nom WHERE RefFamille = @RefFamille";

                    using (SQLiteCommand CommandeSQL = new SQLiteCommand(RequeteSQL, Connexion))
                    {
                        CommandeSQL.Parameters.AddWithValue("@Nom", NouveauNom);
                        CommandeSQL.Parameters.AddWithValue("@RefFamille", RefFamille);

                        CommandeSQL.ExecuteNonQuery();
                    }
                    Connexion.Close();
                }

                return Exception.RETOUR_NORMAL;
            }
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();

                return Exception.RETOUR_ERREUR;
            }
        }

        /// <summary>
        /// Methode qui permet de suppimer un article de la base de données
        /// </summary>
        /// <param name="RefArticle">La référence de l'article à supprimer</param>
        public void SupprimerArticleBdd(string RefArticle)
        {
            try
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
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();
            }
        }

        /// <summary>
        /// Methode qui permet de supprimer une marque de la base de données
        /// </summary>
        /// <param name="RefMarque">La référence de la marque à supprimer</param>
        public void SupprimerMarqueBdd(int RefMarque)
        {
            try
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
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();
            }
        }

        /// <summary>
        /// Methode qui permet de supprimer une sous-famille de la base de données
        /// </summary>
        /// <param name="RefSousFamille">La référence de la sous-famille à supprimer</param>
        public void SupprimerSousFamilleBdd(int RefSousFamille)
        {
            try
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
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();
            }
        }

        /// <summary>
        /// Methode qui permet de supprimer une famille de la base de données
        /// </summary>
        /// <param name="RefFamille">La référence de la famille à supprimer</param>
        public void SupprimerFamilleBdd(int RefFamille)
        {
            try
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
            catch (SQLiteException)
            {
                new Exception(Exception.ERREUR_CONNECTION_A_LA_BDD).AfficherMessageErreur();
            }
        }
    }
}
