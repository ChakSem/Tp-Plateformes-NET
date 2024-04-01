using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel;

namespace Hector
{
    class Parseur
    {
        public static uint NOMBRE_ARTICLES_CREE;
        public static uint NOMBRE_ARTICLES_MIS_A_JOUR;

        /// <summary>
        /// Methode qui permet de parser un fichier csv
        /// </summary>
        /// <param name="path"> Le chemin du fichier csv </param>
        /// <returns> La liste des Article </returns>
        public static void Parse(string path, BackgroundWorker BarreDeProgression)
        {
            uint NombreArticlesCrees = 0;

            try
            {
                if (path == "")
                {
                    throw new Exception(Exception.ERREUR_CHEMIN_VIDE);
                }

                // On initie les variables correspondants à l'évolution du nombre d'articles au cours de la méthode Parse
                Parseur.NOMBRE_ARTICLES_CREE = 0;
                Parseur.NOMBRE_ARTICLES_MIS_A_JOUR = 0;

                string[] lines = System.IO.File.ReadAllLines(path, Encoding.GetEncoding("iso-8859-1"));
                int NombreDeLignes = lines.Length;
                for (int i = 1; i < NombreDeLignes; i++)// On commence à 1 pour ne pas prendre en compte la première ligne
                {
                    string[] values = lines[i].Split(';');

                    string Description = values[0];
                    string Reference = values[1];

                    Marque Marque = Marque.CreerMarqueDepuisCSV(values[2]);
                    Famille Famille = Famille.CreerFamilleDepuisCSV(values[3]);
                    SousFamille SousFamille = SousFamille.CreerSousFamilleDepuisCSV(values[4], Famille);

                    double PrixHT = double.Parse(values[5]);
                    uint Quantite = ExtraireQuantite(Description); // On extrait la quantite de la Description

                    Article NouvelArticle = Article.CreerArticleDepuisCSV(Description, Reference, Marque, SousFamille, PrixHT, Quantite);

                    if (NouvelArticle != null)
                    {
                        NombreArticlesCrees ++;
                    }

                    BarreDeProgression.ReportProgress((int)(((i+1) / (double)NombreDeLignes) * 100));
                }

            } catch (Exception Exception)
            {
                Exception.AfficherMessageErreur();
            }
        }

        public static void ExtraireDonnees(string CheminDExportation) {

            Encoding Encodage = Encoding.UTF8;

            using (StreamWriter Ecrivain = new StreamWriter(CheminDExportation, false, Encodage))
            {
                Ecrivain.WriteLine("Description; Ref; Marque; Famille; Sous - Famille; Prix H.T.");

                foreach (Article ArticleAExtraire in Article.GetListeArticles()) {
                    Ecrivain.WriteLine(ArticleAExtraire.GetDescription() + ";"
                        + ArticleAExtraire.GetReference() + ";"
                        + ArticleAExtraire.GetMarque().GetNom() + ";"
                        + ArticleAExtraire.GetSousFamille().GetFamille().GetNom() + ";"
                        + ArticleAExtraire.GetSousFamille().GetNom() + ";"
                        + ArticleAExtraire.GetPrixHT());
                }
            }
        }

        /// <summary>
        /// Permet de lire la Quantite dans la Description de l'objet Article
        /// </summary>
        /// <param name="Description">Description de l'Article</param>
        /// <returns>Quantite</returns>
        private static uint ExtraireQuantite(string Description)
        {
            string RegexQuantite = @"^\d+";

            Match RegexTrouve = Regex.Match(Description, RegexQuantite);

            if(RegexTrouve.Success)
            {
                uint Quantite = Convert.ToUInt32(RegexTrouve.Value);
                return Quantite;
            }

            return 1;
        }
        
    }
}

