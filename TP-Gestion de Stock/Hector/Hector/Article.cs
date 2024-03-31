using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Hector
{
    public class Article
    {
        /// <summary>
        /// Stocke les objets Article déjà créé 
        /// </summary>
        private static Dictionary<string, Article> DictionnaireArticles = new Dictionary<string, Article>();

        private string Description;
        private string Reference;
        private Marque Marque;
        private SousFamille SousFamille;
        private double PrixHT;
        private uint Quantite;

        /// <summary>
        /// Méthode qui crée un objet Article, si la réference est disponible
        /// </summary>
        /// <param name="NouvelleDescription">La description de l'article</param>
        /// <param name="NouvelleReference">La référence de l'article</param>
        /// <param name="NouvelleMarque">La Marque de l'article</param>
        /// <param name="NouvelleSousFamille">La Sous-Famille de l'article</param>
        /// <param name="NouveauPrixHT">Le prix hors taxe de l'article</param>
        /// <param name="NouvelleQuantite">La quantite de cet article</param>
        /// <returns>NouvelArticle</returns>
        public static Article CreerArticle(string NouvelleDescription, string NouvelleReference, Marque NouvelleMarque, SousFamille NouvelleSousFamille, double NouveauPrixHT, uint NouvelleQuantite)
        {
            try
            {
                if (DictionnaireArticles.ContainsKey(NouvelleReference))
                {
                    throw new Exception(Exception.ERREUR_REFERENCE_DEJA_ASSIGNEE);
                }

                Article NouvelArticle = new Article(NouvelleDescription, NouvelleReference, NouvelleMarque, NouvelleSousFamille, NouveauPrixHT, NouvelleQuantite);
                DictionnaireArticles.Add(NouvelleReference, NouvelArticle);

                BaseDeDonnees.GetInstance().AjoutArticleBdd(NouvelArticle);

                return NouvelArticle;
            }
            catch (Exception Exception)
            {
                Exception.AfficherMessageErreur();

                return null;
            }
        }

        /// <summary>
        /// Méthode qui crée un objet Article, si la réference est disponible
        /// </summary>
        /// <param name="NouvelleDescription">La description de l'article</param>
        /// <param name="NouvelleReference">La référence de l'article</param>
        /// <param name="NouvelleMarque">La Marque de l'article</param>
        /// <param name="NouvelleSousFamille">La Sous-Famille de l'article</param>
        /// <param name="NouveauPrixHT">Le prix hors taxe de l'article</param>
        /// <param name="NouvelleQuantite">La quantite de cet article</param>
        /// <returns>NouvelArticle</returns>
        public static Article CreerArticleDepuisSQLite(string NouvelleDescription, string NouvelleReference, Marque NouvelleMarque, SousFamille NouvelleSousFamille, double NouveauPrixHT, uint NouvelleQuantite)
        {
            if (!DictionnaireArticles.ContainsKey(NouvelleReference))
            { 
                Article NouvelArticle = new Article(NouvelleDescription, NouvelleReference, NouvelleMarque, NouvelleSousFamille, NouveauPrixHT, NouvelleQuantite);
                DictionnaireArticles.Add(NouvelleReference, NouvelArticle);

                return NouvelArticle;
            } 

            return null;
        }

        /// <summary>
        /// Méthode qui crée un objet Article, utile lors de la lecture du fichier .csv, pour eviter d'avoir une popup pour chaque doublons
        /// </summary>
        /// <param name="NouvelleDescription">La description de l'article</param>
        /// <param name="NouvelleReference">La référence de l'article</param>
        /// <param name="NouvelleMarque">La Marque de l'article</param>
        /// <param name="NouvelleSousFamille">La Sous-Famille de l'article</param>
        /// <param name="NouveauPrixHT">Le prix hors taxe de l'article</param>
        /// <param name="NouvelleQuantite">La quantite de cet article</param>
        /// <returns>NouvelArticle</returns>
        public static Article CreerArticleDepuisCSV(string NouvelleDescription, string NouvelleReference, Marque NouvelleMarque, SousFamille NouvelleSousFamille, double NouveauPrixHT, uint NouvelleQuantite)
        {
            if (!DictionnaireArticles.ContainsKey(NouvelleReference))
            {
                Article NouvelArticle = new Article(NouvelleDescription, NouvelleReference, NouvelleMarque, NouvelleSousFamille, NouveauPrixHT, NouvelleQuantite);
                DictionnaireArticles.Add(NouvelleReference, NouvelArticle);

                BaseDeDonnees.GetInstance().AjoutArticleBdd(NouvelArticle);

                return NouvelArticle;
            }

            return null;
        }

        private Article() { }
        private Article(Article ArticleParam) { }

        /// <summary>
        /// Constructeur de la classe Article
        /// </summary>
        /// <param name="NouvelleDescription">La description de l'article</param>
        /// <param name="NouvelleReference">La référence de l'article</param>
        /// <param name="NouvelleMarque">La Marque de l'article</param>
        /// <param name="NouvelleSousFamille">La Sous-Famille de l'article</param>
        /// <param name="NouveauPrixHT">Le prix hors taxe de l'article</param>
        /// <param name="NouvelleQuantite">La quantite de cet article</param>
        private Article(string NouvelleDescription, string NouvelleReference, Marque NouvelleMarque, SousFamille NouvelleSousFamille, double NouveauPrixHT, uint NouvelleQuantite)
        {
            this.Description = NouvelleDescription;
            this.Reference = NouvelleReference;
            this.Marque = NouvelleMarque;
            this.SousFamille = NouvelleSousFamille;
            this.PrixHT = NouveauPrixHT;
            this.Quantite = NouvelleQuantite;
        }

        /* Accesseurs des attributs de la classe Article */
        public string GetDescription() { return Description; }
        public void SetDescription(string NouvelleDescription) { Description = NouvelleDescription; }
        public string GetReference() { return Reference; }
        public uint SetReference(string NouvelleReference) {
            try
            {
                if (NouvelleReference != Reference && DictionnaireArticles.ContainsKey(NouvelleReference))
                {
                    throw new Exception(Exception.ERREUR_REFERENCE_DEJA_ASSIGNEE);
                }
                Reference = NouvelleReference;

                return Exception.RETOUR_NORMAL;
            }
            catch (Exception ExceptionAttrapee)
            {
                ExceptionAttrapee.AfficherMessageErreur();

                return Exception.RETOUR_ERREUR;
            }
        }
        public Marque GetMarque() { return Marque; }
        public void SetMarque(Marque NouvelleMarque) { Marque = NouvelleMarque; }
        public SousFamille GetSousFamille() { return SousFamille; }
        public void SetSousFamille(SousFamille NouvelleSousFamille) { SousFamille = NouvelleSousFamille; }
        public double GetPrixHT() { return PrixHT; }
        public void SetPrixHT(double NouveauPrixHT) { PrixHT = NouveauPrixHT; }
        public uint GetQuantite() { return Quantite; }
        public void SetQuantite(uint NouvelleQuantite) { Quantite = NouvelleQuantite; }

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

        public static Article GetArticleExistant(string RefArticle)
        {
            try
            {
                if (!DictionnaireArticles.ContainsKey(RefArticle))
                {
                    throw new Exception(Exception.ERREUR_OBJET_INNEXISTANT);
                }

                return DictionnaireArticles[RefArticle];
            }
            catch (Exception Exception)
            {
                Exception.AfficherMessageErreur();

                return null;
            }
        }


        public static List<Article> GetListeArticles()
        {
            List<Article> ListeArticles = new List<Article>();

            foreach (var Couple in DictionnaireArticles)
            {
                ListeArticles.Add(Couple.Value);
            }

            return ListeArticles;
        }


        public static void ViderDictionnaireArticles()
        {
            DictionnaireArticles.Clear();
        }

        /// <summary>
        /// Méthode qui permet de supprimer un article de la liste
        /// </summary>
        /// <param name="Reference">La référence de l'article à supprimer</param>
        /// <returns> res, la liste des articles dans le terminal </returns>
        /// <returns> - true si l'article a été supprimé,
        ///           - false si l'article n'a pas été supprimé </returns>
        public static bool SupprimerArticle(string Reference)
        {
            try
            {
                MessageBox.Show("La ref de l'article qui va etre supprimée est le suivant " + Reference);
                if (!DictionnaireArticles.ContainsKey(Reference))
                {
                    throw new Exception(Exception.ERREUR_REFERENCE_NON_EXISTANTE);
                }
                DictionnaireArticles.Remove(Reference);
                BaseDeDonnees.GetInstance().SupprimerArticleBdd(Reference);
                return true;
            }
            catch (Exception Exception)
            {
                Exception.AfficherMessageErreur();
                return false;
            }

        }
   

    }
}

