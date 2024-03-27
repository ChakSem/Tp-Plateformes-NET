using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    class Marque
    {
        /// <summary>
        /// Stocke les objets Marque déjà créé 
        /// </summary>
        private static Dictionary<string, Marque> DictionnairesMarques= new Dictionary<string, Marque>();

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
                if (!DictionnairesMarques.ContainsKey(NomParam))
                {
                    throw new Exception(Exception.ERREUR_OBJET_INNEXISTANT);
                }

                return DictionnairesMarques[NomParam];
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
            if(DictionnairesMarques.ContainsKey(NomParam) )
            {
                return DictionnairesMarques[NomParam];
            } else
            {
                Marque NouvelleMarque = new Marque(NomParam);
                DictionnairesMarques.Add(NomParam, NouvelleMarque);

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
            if (!DictionnairesMarques.ContainsKey(NomParam))
            {
                Marque NouvelleMarque = new Marque(NomParam);
                DictionnairesMarques.Add(NomParam, NouvelleMarque);

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
            if(!DictionnairesMarques.ContainsKey(NomParam) )
            {
                Marque NouvelleMarque = new Marque(NomParam);
                DictionnairesMarques.Add(NomParam, NouvelleMarque);

                BaseDeDonnees.GetInstance().AjoutMarqueBdd(NouvelleMarque);

                return NouvelleMarque;
            }

            return DictionnairesMarques[NomParam];
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
            RefMarque = -1;
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
                if (RefMarque != -1)
                {
                    throw new Exception(Exception.ERREUR_REFERENCE_DEJA_DEFINIE);
                }
                foreach (Marque MarqueExistante in DictionnairesMarques.Values)
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
        /// Accesseur en écriture de l'attribut Nom
        /// </summary>
        /// <param name="NouveauNom">Le Nom que l'on souhaite définir</param>
        public void SetNom(string NouveauNom)
        {
            try
            {
                if (DictionnairesMarques.ContainsKey(NouveauNom))
                {
                    throw new Exception(Exception.ERREUR_NOM_DEJA_ASSIGNEE);
                }
                Nom = NouveauNom;
            }
            catch (Exception ExceptionCatched)
            {
                ExceptionCatched.AfficherMessageErreur();
            }
        }

        public static List<Marque> GetDictionnaireMarques()
        {
            return DictionnairesMarques.Values.ToList();
        }

        public static void ViderDictionnairesMarques()
        {
            DictionnairesMarques.Clear();
        }
    }
}
