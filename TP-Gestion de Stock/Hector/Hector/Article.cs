using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hector
{
s

    class Article
    {
        private string Description;
        private string Reference;
        private string Marque;
        private string Famille;
        private string SousFamille;
        private double PrixHT;

        /**
        * Constructeur de la classe Article
        * Entrées:
        * - string description: la description de l'article
        * - string reference: la référence de l'article
        * - string marque: la marque de l'article
        * - string famille: la famille de l'article
        * - string sousFamille: la sous-famille de l'article
        * - double prixHT: le prix hors taxe de l'article
        * Sortie:
        */
        public Article(string description, string reference, string marque, string famille, string sousFamille, double prixHT)
        {
            this.Description = description;
            this.Reference = reference;
            this.Marque = marque;
            this.Famille = famille;
            this.SousFamille = sousFamille;
            this.PrixHT = prixHT;
        }

        /* Accesseurs des attributs de la classe Article */
        public string GetDescription() { return Description; }
        public void SetDescription(string value) { Description = value; }
        public string GetReference() { return Reference; }
        public void SetReference(string value) { Reference = value; }
        public string GetMarque() { return Marque; }
        public void SetMarque(string value) { Marque = value; }
        public string GetFamille() { return Famille; }
        public void SetFamille(string value) { Famille = value; }
        public string GetSousFamille() { return SousFamille; }
        public void SetSousFamille(string value) { SousFamille = value; }
        public double GetPrixHT() { return PrixHT; }
        public void SetPrixHT(double value) { PrixHT = value; }

        /**
        * Méthode qui permet d'afficher les articles de la liste
        * Entrée: 
        * - List<Article> articles: la liste des articles
        * Sortie: 
        * - string: la liste des articles dans le terminal
        */
        public static string AfficherArticles(List<Article> articles)
        {
            string res = "";
            foreach (Article article in articles)
            {
                res += article.GetDescription() + " " + article.GetReference() + " " + article.GetMarque() + " " + article.GetFamille() + " " + article.GetSousFamille() + " " + article.GetPrixHT() + "\n";
            }
            Console.WriteLine(res); // Affichage dans le terminal
            return res;
        }
    }


}

