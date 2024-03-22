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
        * Sortie: - List<Article>: la liste des Articles
        */
        public static List<Article> Parse(string path)
        {
            if (path == "")
            {
                /*On retourne une liste vide si le chemin est vide*/
                return new List<Article>();
            }
            /*On crée une liste d'Articles*/

            List<Article> Articles = new List<Article>();
            /*On lit le fichier ligne par ligne*/
            string[] lines = System.IO.File.ReadAllLines(path, Encoding.GetEncoding("iso-8859-1"));
            for (int i = 1; i < lines.Length; i++)// On commence à 1 pour ne pas prendre en compte la première ligne
            {
                string[] values = lines[i].Split(';');
                string Description = values[0];
                string Reference = values[1];
                /*On verifie que la marque n'est pas deja dans la liste*/
                Marque Marque = Marque.CreateMarque(values[2]);
                /*On verifie que la famille n'est pas deja dans la liste*/
                Famille Famille = Famille.CreateFamille(values[3]);
                /*On verifie que la sous famille n'est pas deja dans la liste*/
                SousFamille SousFamille = SousFamille.CreateSousFamille(values[4], Famille);
                double PrixHT = double.Parse(values[5]);
                bool Exist = false;

                /*on verifie que l'article n'est pas deja dans la liste*/
                foreach (Article Article in Articles)
                {
                    if (Article.GetReference() == Reference)
                    {
                        Exist = true;
                    }
                }
                if (!Exist)
                {
                    Article NouvelArticle;
                    if ((NouvelArticle = Article.CreateArticle(Description, Reference, Marque, SousFamille, PrixHT)) != null)
                        Articles.Add(NouvelArticle);

                }
            }
            return Articles;
        }
    }
}

