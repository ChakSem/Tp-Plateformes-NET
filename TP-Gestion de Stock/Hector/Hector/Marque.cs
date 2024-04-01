using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    public class Marque
    {
        /// <summary>
        /// Stocke les objets Marque déjà créé 
        /// </summary>
        private static Dictionary<string, Marque> DictionnaireMarques= new Dictionary<string, Marque>();

        private string Nom;
        private int RefMarque;

        /// <summary>
        /// Permet d'obtenir un objet Marque à patir de son nom
        /// </summary>
        /// <param name="NomParam"> Nom de la Marque que l'on veut </param>
        /// <returns> Marque </returns>
        public static Marque GetMarqueExistante(string NomParam)
        {
            try
            {
                if (NomAttribue(NomParam) == false)
                {
                    throw new Exception(Exception.ERREUR_OBJET_INNEXISTANT);
                }

                return DictionnaireMarques[NomParam];
            } catch (Exception Exception)
            {
                Exception.AfficherMessageErreur();

                return null;
            }
        }

        /// <summary>
        /// Méthode permettant de récupérer un objet Marque avec NomParam en tant qu'attribut Nom. Le crée s'il n'existe pas déjà
        /// </summary>
        /// <param name="NomParam">Nom de la Marque que l'on souhaite</param>
        /// <returns> NouvelleMarque </returns>
        public static Marque CreerMarque(string NomParam)
        {
            if(NomAttribue(NomParam) == true)
            {
                return DictionnaireMarques[NomParam];
            } else
            {
                Marque NouvelleMarque = new Marque(NomParam);
                DictionnaireMarques.Add(NomParam, NouvelleMarque);

                BaseDeDonnees.GetInstance().AjoutMarqueBdd(NouvelleMarque);

                return NouvelleMarque;
            }
        }
        
        /// <summary>
        /// Méthode permettant de récupérer un objet Marque avec NomParam en tant qu'attribut Nom. Le crée s'il n'existe pas déjà
        /// </summary>
        /// <param name="NomParam">Nom de la Marque que l'on souhaite</param>
        /// <returns> NouvelleMarque </returns>
        public static Marque CreerMarqueDepuisSQLite(string NomParam)
        {
            if (NomAttribue(NomParam) == false)
            {
                Marque NouvelleMarque = new Marque(NomParam);
                DictionnaireMarques.Add(NomParam, NouvelleMarque);

                return NouvelleMarque;
            }

            return null;
        }
        
        /// <summary>
         /// Méthode permettant de récupérer un objet Marque avec NomParam en tant qu'attribut Nom. Le crée s'il n'existe pas déjà
         /// </summary>
         /// <param name="NomParam">Nom de la Marque que l'on souhaite</param>
         /// <returns> NouvelleMarque </returns>
        public static Marque CreerMarqueDepuisCSV(string NomParam)
        {
            if (NomAttribue(NomParam) == true)
            {
                Marque MarqueExistante = DictionnaireMarques[NomParam];

                return MarqueExistante;
            }
            Marque NouvelleMarque = new Marque(NomParam);
            DictionnaireMarques.Add(NomParam, NouvelleMarque);

            BaseDeDonnees.GetInstance().AjoutMarqueBdd(NouvelleMarque);

            return NouvelleMarque;
        }
        private Marque() { }
        private Marque(Marque NouvelleMarque) { }


        /// <summary>
        /// Constructeur utilisé par la méthode CreateMarque
        /// </summary>
        /// <param name="NomParam">Nom de la Marque que l'on souhaite</param>
        private Marque(string NomParam)
        {
            Nom = NomParam;
            RefMarque = Global.REFERENCE_NON_ASSIGNEE; // Sera modifiée lorsque la marque sera saisie dans la base de donnée
        }

        /// <summary>
        /// Accesseur en lecture de l'attribut Nom
        /// </summary>
        /// <returns> Nom </returns>
        public string GetNom()
        {
            return Nom;
        }


        /// <summary>
        /// Accesseur en lecture de l'attribut RefMarque
        /// </summary>
        /// <returns> RefMarque </returns>
        public int GetRefMarque()
        {
            return RefMarque;
        }

        /// <summary>
        /// Accesseur en écriture de l'attribut RefMarque, appelée lorsque l'objet est inserée, de sorte à rapporter la reference ainsi generee dans l'objet
        /// </summary>
        /// <param name="NouvelleRefMarque">La reference autogeneree</param>
        public void DefineRefMarque(int NouvelleRefMarque)
        {
            try
            {
                if (RefMarque != Global.REFERENCE_NON_ASSIGNEE) // Si la réference a été générée (la sous-famille a été ajouté à la base de donnée)
                {
                    throw new Exception(Exception.ERREUR_REFERENCE_DEJA_DEFINIE);
                }
                foreach (Marque MarqueExistante in DictionnaireMarques.Values)
                {
                    if (MarqueExistante.GetRefMarque() == NouvelleRefMarque)
                    {
                        throw new Exception(Exception.ERREUR_REFERENCE_AUTOGENEREE_DEJA_ASSIGNEE);
                    }
                }

                RefMarque = NouvelleRefMarque;
            }
            catch (Exception ExceptionCatched)
            {
                ExceptionCatched.AfficherMessageErreur();
            }
        }

        /// <summary>
        /// Verifie que le NouveauNom est un nom disponible
        /// </summary>
        /// <param name="NouveauNom"></param>
        /// <returns>   - true : Si une Marque avec cette réference existe
        ///             - false : Sinon </returns>
        public static bool NomAttribue(string NouveauNom)
        {
            if (DictionnaireMarques.ContainsKey(NouveauNom))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Accesseur en écriture de l'attribut Nom
        /// </summary>
        /// <param name="NouveauNom">Le Nom que l'on souhaite définir</param>
        /// <returns> Une valeur indiquant si la modification a réussie </returns>
        public uint SetNom(string NouveauNom)
        {
            try
            {
                if (Nom != NouveauNom && NomAttribue(NouveauNom))
                {
                    throw new Exception(Exception.ERREUR_NOM_DEJA_ASSIGNEE);
                }
                DictionnaireMarques.Remove(Nom);
                DictionnaireMarques.Add(NouveauNom, this);

                Nom = NouveauNom;

                return Exception.RETOUR_NORMAL;
            }
            catch (Exception ExceptionCatched)
            {
                ExceptionCatched.AfficherMessageErreur();

                return Exception.RETOUR_ERREUR;
            }
        }

        /// <summary>
        /// Renvoie une liste correspondant au dictionnaire DictionnaireMarques
        /// </summary>
        /// <returns> DictionnaireSousFamilles.ToList() </returns>
        public static List<Marque> GetListeMarques()
        {
            List<Marque> ListeMarques = new List<Marque>();

            foreach (var Couple in DictionnaireMarques)
            {
                ListeMarques.Add(Couple.Value);
            }

            return ListeMarques;
        }

        /// <summary>
        /// Vide le dictionnaire DictionnaireMarques
        /// </summary>
        public static void ViderDictionnaireMarques()
        {
            DictionnaireMarques.Clear();
        }

        /// <summary>
        /// Indique si un Article appartient à la Marque
        /// </summary>
        /// <returns>   - true : Si au moins un Article appartient à cette marque
        ///             - false : Sinon </returns>
        public bool MarqueUtilisee()
        {
            foreach (Article ArticleExistant in Article.GetListeArticles())
            {
                if (ArticleExistant.GetMarque().GetNom() == Nom)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Méthode qui permet de supprimer  une famille
        /// </summary>
        /// <returns> Une valeur indiquant si la suppression a réussie </returns>

        public uint SupprimerMarque()
        {
            try
            {
                if (MarqueUtilisee() == true)
                {
                    throw new Exception(Exception.ERREUR_OBJET_UTILISEE);
                }

                DictionnaireMarques.Remove(Nom);
                BaseDeDonnees.GetInstance().SupprimerFamilleBdd(RefMarque);

                return Exception.RETOUR_NORMAL;
            }
            catch (Exception Exception)
            {
                Exception.AfficherMessageErreur();

                return Exception.RETOUR_ERREUR;
            }
        }
    }
}
