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
                if (ReferenceAssignee(NouvelleReference) == true)
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
            if (ReferenceAssignee(NouvelleReference) == false)
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
            try
            if (ReferenceAssignee(NouvelleReference) == false)
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
            catch (Exception Exception)
            {
                throw new Exception(Exception.ARTICLE_DEJA_EXISTANT);
            }
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

        /// <summary>
        /// Accesseur en écriture de l 'attribut réference
        /// </summary>
        /// <param name="NouvelleReference"> Reference que l'on veut définir </param>
        /// <returns> Une valeur indiquant si la modification a réussie </returns>
        public uint SetReference(string NouvelleReference)
        {
            try
            {
                if (NouvelleReference != Reference && ReferenceAssignee(NouvelleReference))
                {
                    throw new Exception(Exception.ERREUR_REFERENCE_DEJA_ASSIGNEE);
                }
                DictionnaireArticles.Remove(Reference);
                DictionnaireArticles.Add(NouvelleReference, this);

                Reference = NouvelleReference;

                return Exception.RETOUR_NORMAL;
            }
            catch (Exception ExceptionAttrapee)
            {
                ExceptionAttrapee.AfficherMessageErreur();

                return Exception.RETOUR_ERREUR; // Si la réference n'a pas pu être changée (car déjà assignée)
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
        /// <returns> String contenenat les données de l'article </returns>
        public static string AfficherArticles(List<Article> Articles)
        {
            string Affichage = "";
            foreach (Article Article in Articles)
            {
                Affichage += Article.GetDescription() + " " + Article.GetReference() + " " + Article.GetMarque().GetNom() + " "
                    + Article.GetSousFamille().GetFamille().GetNom() + " " + Article.GetSousFamille().GetNom() + " " + Article.GetPrixHT() + "\n";
            }
            Console.WriteLine(Affichage); // Affichage dans le terminal
            return Affichage;
        }

        /// <summary>
        /// Permet de vérifier si une réference est déjà assignée à un Article
        /// </summary>
        /// <param name="RefArticle"></param>
        /// <returns>   - true : Si un Article avec cette réference existe
        ///             - false : Sinon </returns>
        public static bool ReferenceAssignee(string RefArticle)
        {
            if (DictionnaireArticles.ContainsKey(RefArticle))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Renvoi l'article correspondant à la réference passée en paramètre
        /// </summary>
        /// <param name="RefArticle"> Réference de l'article souhaité </param>
        /// <returns> Article correspondant </returns>
        public static Article GetArticleExistant(string RefArticle)
        {
            try
            {
                if (!ReferenceAssignee(RefArticle))
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

        /// <summary>
        /// Renvoie une liste correspondant au dictionnaire DictionnaireArticles
        /// </summary>
        /// <returns> Liste des Articles existants </returns>
        public static List<Article> GetListeArticles()
        {
            List<Article> ListeArticles = new List<Article>();

            foreach (var Couple in DictionnaireArticles)
            {
                ListeArticles.Add(Couple.Value);
            }

            return ListeArticles;
        }

        /// <summary>
        /// Permet de vider DictionnaireArticles
        /// </summary>
        public static void ViderDictionnaireArticles()
        {
            DictionnaireArticles.Clear();
        }

        /// <summary>
        /// Méthode permettant de gérer la suppression d'un Article
        /// </summary>
        public void SupprimerArticle()
        {
            DictionnaireArticles.Remove(Reference);
            BaseDeDonnees.GetInstance().SupprimerArticleBdd(Reference);
        }
    }
}

