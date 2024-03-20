using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    class Parser
    {
        /**
        * Methode qui permet de parser un fichier csv
        * Entree: - string path: le chemin du fichier csv
        * Sortie: - List<Article>: la liste des articles
        */
        public static List<Article> Parse(string path)
        {
            /*On crée une liste d'articles*/
            List<Article> articles = new List<Article>();
            /*On lit le fichier ligne par ligne*/
            string[] lines = System.IO.File.ReadAllLines(path);

            for (int i = 1; i < lines.Length; i++)// On commence à 1 pour ne pas prendre en compte la première ligne
            {
                string[] values = lines[i].Split(';');
                string description = values[0];
                string reference = values[1];
                string marque = values[2];
                string famille = values[3];
                string sousFamille = values[4];
                double prixHT = double.Parse(values[5]);
                bool exist = false;

                //on verifie que l'article n'est pas deja dans la liste
                foreach (Article article in articles)
                {
                    if (article.GetReference() == reference)
                    {
                        exist = true;
                    }
                }
                if (!exist)
                    articles.Add(new Article(description, reference, marque, famille, sousFamille, prixHT));

            }
            return articles;
        }
    }
}

