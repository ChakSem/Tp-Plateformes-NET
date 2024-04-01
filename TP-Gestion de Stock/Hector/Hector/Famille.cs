using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    public class Famille
    {
        /// <summary>
        /// Stocke les objets Famille déjà créé 
        /// </summary>
        private static Dictionary<string, Famille> DictionnaireFamilles = new Dictionary<string, Famille>();

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
                Exception.AfficherMessageErreur();

                return null;
            }
        }

        /// <summary>
        /// Méthode permettant de récupérer un objet Famille avec NomParam en tant qu'attribut Nom. Le crée s'il n'existe pas déjà
        /// </summary>
        /// <param name="NomParam">Nom de la Famille que l'on souhaite</param>
        /// <returns> NouvelleFamille </returns>
        public static Famille CreerFamille(string NomParam)
        {
            if (DictionnaireFamilles.ContainsKey(NomParam))
            {
                return DictionnaireFamilles[NomParam];
            }
            else
            {
                Famille NouvelleFamille = new Famille(NomParam);
                DictionnaireFamilles.Add(NomParam, NouvelleFamille);

                BaseDeDonnees.GetInstance().AjoutFamilleBdd(NouvelleFamille);

                return NouvelleFamille;
            }
        }

        /// <summary>
        /// Méthode permettant de récupérer un objet Famille avec NomParam en tant qu'attribut Nom. Le crée s'il n'existe pas déjà
        /// </summary>
        /// <param name="NomParam">Nom de la Famille que l'on souhaite</param>
        /// <returns> NouvelleFamille </returns>
        public static Famille CreerFamilleDepuisSQLite(string NomParam)
        {
            if (!DictionnaireFamilles.ContainsKey(NomParam))
            {
                Famille NouvelleFamille = new Famille(NomParam);
                DictionnaireFamilles.Add(NomParam, NouvelleFamille);

                return NouvelleFamille;
            }

            return null;
        }

        /// <summary>
        /// Méthode permettant de récupérer un objet Famille avec NomParam en tant qu'attribut Nom. Le crée s'il n'existe pas déjà
        /// </summary>
        /// <param name="NomParam">Nom de la Famille que l'on souhaite</param>
        /// <returns> NouvelleFamille </returns>
        public static Famille CreerFamilleDepuisCSV(string NomParam)
        {
            if (!DictionnaireFamilles.ContainsKey(NomParam))
            {
                Famille NouvelleFamille = new Famille(NomParam);
                DictionnaireFamilles.Add(NomParam, NouvelleFamille);

                BaseDeDonnees.GetInstance().AjoutFamilleBdd(NouvelleFamille);

                return NouvelleFamille;
            }

            return DictionnaireFamilles[NomParam];
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
            RefFamille = Global.REFERENCE_NON_ASSIGNEE; // Sera modifiée lorsque la famille sera saisie dans la base de donnée
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
        /// <returns> Une valeur indiquant si la modification a réussie </returns>
        public uint SetNom(string NouveauNom)
        {
            try
            {
                if (DictionnaireFamilles.ContainsKey(NouveauNom))
                {
                    throw new Exception(Exception.ERREUR_NOM_DEJA_ASSIGNEE);
                }
                Nom = NouveauNom;

                return Exception.RETOUR_NORMAL;
            } catch (Exception ExceptionCatched) {
                ExceptionCatched.AfficherMessageErreur();

                return Exception.RETOUR_ERREUR;
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
                if (RefFamille != Global.REFERENCE_NON_ASSIGNEE) // Si la réference a été générée (la sous-famille a été ajouté à la base de donnée)
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
            catch (Exception ExceptionAttrapee)
            {
                ExceptionAttrapee.AfficherMessageErreur();
            }
        }

        /// <summary>
        /// Renvoie une liste correspondant au dictionnaire DictionnaireFamilles
        /// </summary>
        /// <returns></returns>
        public static List<Famille> GetListeFamilles()
        {
            List<Famille> ListeFamilles= new List<Famille>();

            foreach (var Couple in DictionnaireFamilles)
            {
                ListeFamilles.Add(Couple.Value);
            }

            return ListeFamilles;
        }

        /// <summary>
        /// Vider DictionnaireFamilles
        /// </summary>
        public static void ViderDictionnaireFamilles()
        {
            DictionnaireFamilles.Clear();
        }

        /// <summary>
        /// Indique si la Famille a des SousFamilles
        /// </summary>
        /// <returns>   - true : Si au moins une SousFamille appartient à cette famille
        ///             - false : Sinon </returns>
        public bool FamilleUtilisee()
        {
            foreach (SousFamille SousFamilleExistante in SousFamille.GetListeSousFamilles()) 
            {
                if(SousFamilleExistante.GetFamille().GetNom() == Nom)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Méthode qui permet de supprimer une famille
        /// </summary>
        /// <returns> Une valeur indiquant si la suppression a réussie </returns>
        public uint SupprimerFamille()
        {
            try
            {
                if (FamilleUtilisee() == true)
                {
                    throw new Exception(Exception.ERREUR_OBJET_UTILISEE);
                }

                DictionnaireFamilles.Remove(Nom);
                BaseDeDonnees.GetInstance().SupprimerFamilleBdd(RefFamille);

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
