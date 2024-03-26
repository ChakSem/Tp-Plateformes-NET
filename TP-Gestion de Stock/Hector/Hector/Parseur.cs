using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Hector
{
    class Parseur
    {
        /// <summary>
        /// Methode qui permet de parser un fichier csv
        /// </summary>
        /// <param name="path"> Le chemin du fichier csv </param>
        /// <returns> La liste des Article </returns>
        public static List<Article> Parse(string path)
        {
            List<Article> Articles = new List<Article>();

            try
            {
                if (path == "")
                {
                    // On retourne une liste vide si le chemin est vide
                    throw new Exception(Exception.ERREUR_CHEMIN_VIDE);
                }
                // On crée une liste d'Articles

                // On lit le fichier ligne par ligne
                string[] lines = System.IO.File.ReadAllLines(path, Encoding.GetEncoding("iso-8859-1"));
                for (int i = 1; i < lines.Length; i++)// On commence à 1 pour ne pas prendre en compte la première ligne
                {
                    string[] values = lines[i].Split(';');
                    string Description = values[0];
                    string Reference = values[1];

                    Marque Marque = Marque.CreateMarque(values[2]);
                    Famille Famille = Famille.CreateFamille(values[3]);
                    SousFamille SousFamille = SousFamille.CreateSousFamille(values[4], Famille);

                    double PrixHT = double.Parse(values[5]);
                    uint Quantite = ExtraireQuantite(Description); // On extrait la quantite de la Description

                    Article NouvelArticle = Article.CreateArticleSansException(Description, Reference, Marque, SousFamille, PrixHT, Quantite);

                    if (NouvelArticle != null)
                    {
                        Articles.Add(NouvelArticle);
                    }
                }

                return Articles;
            } catch (Exception Exception)
            {
                Exception.AfficherMessageErreur();

                return Articles;
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

