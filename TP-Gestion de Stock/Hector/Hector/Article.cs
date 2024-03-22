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

        /// <summary>
        /// Constructeur de la classe Article
        /// </summary>
        /// <param name="NouvelleDescription">La description de l'article</param>
        /// <param name="NouvelleReference">La référence de l'article</param>
        /// <param name="NouvelleMarque">La Marque de l'article</param>
        /// <param name="NouvelleSousFamille">La Sous-Famille de l'article</param>
        /// <param name="NouveauPrixHT">Le prix hors taxe de l'article</param>
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

        /// <summary>
        /// Méthode qui permet d'afficher les articles de la liste (POUR LE DEBUG)
        /// </summary>
        /// <param name="Articles">La liste des articles</param>
        /// <returns> res, la liste des articles dans le terminal </returns>
        public static string AfficherArticles(List<Article> Articles)
        {
            string res = "";
            foreach (Article Article in Articles)
            {
                res += Article.GetDescription() + " " + Article.GetReference() + " " + Article.GetMarque().GetNom() + " " 
                    + Article.GetSousFamille().GetFamille().GetNom() + " " + Article.GetSousFamille().GetNom() + " " + Article.GetPrixHT() + "\n";
            }
            Console.WriteLine(res); // Affichage dans le terminal
            return res;
        }
    }


}

