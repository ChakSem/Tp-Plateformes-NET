using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    class Famille
    {
        /// <summary>
        /// Stocke les objets Famille déjà créé 
        /// </summary>
        private static Dictionary<string, Famille> DictionnaireFamilles= new Dictionary<string, Famille>();

        private string Nom;
        private int RefFamille;

        /// <summary>
        /// Permet d'obtenir un objet Famille à patir de son nom
        /// </summary>
        /// <param name="NomParam"> Nom de la Famille que l'on veut </param>
        /// <returns> Famille </returns>
        public static Famille GetFamilleExistante(string NomParam)
        {
            try
            {
                if (!DictionnaireFamilles.ContainsKey(NomParam))
                {
                    throw new Exception(Exception.ERREUR_OBJET_INNEXISTANT);
                }

                return DictionnaireFamilles[NomParam];
            }
            catch (Exception Exception)
            {
                Exception.DisplayErrorMessage();

                return null;
            }
        }

        /// <summary>
        /// Méthode permettant de récupérer un objet Famille avec NomParam en tant qu'attribut Nom. Le crée s'il n'existe pas déjà
        /// </summary>
        /// <param name="NomParam">Nom de la Famille que l'on souhaite</param>
        /// <returns> NouvelleFamille </returns>
        public static Famille CreateFamille(string NomParam)
        {
            if (DictionnaireFamilles.ContainsKey(NomParam))
            {
                return DictionnaireFamilles[NomParam];
            }
            else
            {
                Famille NouvelleFamille = new Famille(NomParam);
                DictionnaireFamilles.Add(NomParam, NouvelleFamille);

                return NouvelleFamille;
            }
        }
        private Famille() { }
        private Famille(Famille FamilleParam) { }

        /// <summary>
        /// Constructeur de confort de la classe Famille
        /// </summary>
        /// <param name="NouveauNom"></param>
        private Famille(string NouveauNom)
        {
            Nom = NouveauNom;
            RefFamille = -1;
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
        /// Accesseur en écriture de l'attribut Nom
        /// </summary>
        /// <param name="NouveauNom">Le Nom que l'on souhaite définir</param>
        public void SetNom(string NouveauNom)
        {
            try
            {
                if (DictionnaireFamilles.ContainsKey(NouveauNom))
                {
                    throw new Exception(Exception.ERREUR_NOM_DEJA_ASSIGNEE);
                }
                Nom = NouveauNom;
            } catch (Exception ExceptionCatched) {
                ExceptionCatched.DisplayErrorMessage();
            }
        }


        /// <summary>
        /// Accesseur en lecture de l'attribut RefFamille
        /// </summary>
        /// <returns> RefFamille </returns>
        public int GetRefFamille()
        {
            return RefFamille;
        }

        /// <summary>
        /// Accesseur en écriture de l'attribut RefFamille, appelée lorsque l'objet est inserée, de sorte à rapporter la reference ainsi generee dans l'objet
        /// </summary>
        /// <param name="NouvelleRefFamille">La reference autogeneree</param>
        public void DefineRefFamille(int NouvelleRefFamille)
        {
            try
            {
                if (RefFamille != -1)
                {
                    throw new Exception(Exception.ERREUR_REFERENCE_DEJA_DEFINIE);
                }
                foreach (Famille FamilleExistante in DictionnaireFamilles.Values)
                {
                    if (FamilleExistante.GetRefFamille() == NouvelleRefFamille)
                    {
                        throw new Exception(Exception.ERREUR_REFERENCE_AUTOGENEREE_DEJA_ASSIGNEE);
                    }
                }

                RefFamille = NouvelleRefFamille;
            }
            catch (Exception ExceptionCatched)
            {
                ExceptionCatched.DisplayErrorMessage();
            }
        }

        public static List<Famille> GetListeFamilles()
        {
            return DictionnaireFamilles.Values.ToList();
        }

        public static void ViderDictionnaireFamilles()
        {
            DictionnaireFamilles.Clear();
        }
    }
}
