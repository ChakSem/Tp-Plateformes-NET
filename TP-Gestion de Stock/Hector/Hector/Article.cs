using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hector
{
    class Article
    {
        private string Description;
        private string Reference;
        private Marque Marque;
        private SousFamille SousFamille;
        private double PrixHT;

        /**
        * Constructeur de la classe Article
        * Entrées:
        * - string Description: la Description de l'article
        * - string Reference: la référence de l'article
        * - string Marque: la Marque de l'article
        * - string Famille: la Famille de l'article
        * - string SousFamille: la sous-Famille de l'article
        * - double PrixHT: le prix hors taxe de l'article
        * Sortie:
        */
        public Article(string NouvelleDescription, string NouvelleReference, Marque NouvelleMarque, SousFamille NouvelleSousFamille, double NouveauPrixHT)
        {
            this.Description = NouvelleDescription;
            this.Reference = NouvelleReference;
            this.Marque = NouvelleMarque;
            this.SousFamille = NouvelleSousFamille;
            this.PrixHT = NouveauPrixHT;
        }

        /* Accesseurs des attributs de la classe Article */
        public string GetDescription() { return Description; }
        public void SetDescription(string NouvelleDescription) { Description = NouvelleDescription; }
        public string GetReference() { return Reference; }
        public void SetReference(string NouvelleReference) { Reference = NouvelleReference; }
        public Marque GetMarque() { return Marque; }
        public void SetMarque(Marque NouvelleMarque) { Marque = NouvelleMarque; }
        public SousFamille GetSousFamille() { return SousFamille; }
        public void SetSousFamille(SousFamille NouvelleSousFamille) { SousFamille = NouvelleSousFamille; }
        public double GetPrixHT() { return PrixHT; }
        public void SetPrixHT(double NouveauPrixHT) { PrixHT = NouveauPrixHT; }

        /** 
        * Méthode qui permet d'afficher les articles de la liste (POUR LE DEBUG)
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
                res += article.GetDescription() + " " + article.GetReference() + " " + article.GetMarque() + " " + article.GetSousFamille().GetFamille() + " " + article.GetSousFamille() + " " + article.GetPrixHT() + "\n";
            }
            Console.WriteLine(res); // Affichage dans le terminal
            return res;
        }
    }


}

