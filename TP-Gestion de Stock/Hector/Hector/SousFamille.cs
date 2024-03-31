using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    public class SousFamille
    {
        /// <summary>
        /// Stocke les objets Sous-Famille déjà créé 
        /// </summary>
        private static Dictionary<string, SousFamille> DictionnaireSousFamilles= new Dictionary<string, SousFamille>();

        private string Nom;
        private int RefSousFamille;
        private Famille Famille;

        /// <summary>
        /// Permet d'obtenir un objet SousFamille à patir de son nom
        /// </summary>
        /// <param name="NomParam"> Nom de la SousFamille que l'on veut </param>
        /// <returns> SousFamille </returns>
        public static SousFamille GetSousFamilleExistante(string NomParam)
        {
            try
            {
                if (!DictionnaireSousFamilles.ContainsKey(NomParam))
                {
                    throw new Exception(Exception.ERREUR_OBJET_INNEXISTANT);
                }

                return DictionnaireSousFamilles[NomParam];
            }
            catch (Exception Exception)
            {
                Exception.AfficherMessageErreur();

                return null;
            }
        }

        /// <summary>
        /// Méthode permettant de récupérer un objet SousFamille avec NomParam en tant qu'attribut Nom. Le crée s'il n'existe pas déjà
        /// </summary>
        /// <param name="NomParam">Nom de la SousFamille que l'on souhaite</param>
        /// <param name="FamilleParam">Famille de la SousFamille</param>
        /// <returns> NouvelleSousFamille </returns>
        public static SousFamille CreerSousFamille(string NomParam, Famille FamilleParam)
        {
            if (DictionnaireSousFamilles.ContainsKey(NomParam))
            {
                try
                {
                    SousFamille SousFamilleExistante = DictionnaireSousFamilles[NomParam];
                    if (FamilleParam.GetNom() != SousFamilleExistante.GetFamille().GetNom())
                    {
                        throw new Exception(Exception.ERREUR_FAMILLE_NE_CORRESPOND_PAS);
                    }

                    return SousFamilleExistante;

                } catch (Exception Exception)
                {
                    Exception.AfficherMessageErreur();

                    return null;
                }
            }
            else
            {
                SousFamille NouvelleSousFamille = new SousFamille(NomParam, FamilleParam);
                DictionnaireSousFamilles.Add(NomParam, NouvelleSousFamille);

                BaseDeDonnees.GetInstance().AjoutSousFamilleBdd(NouvelleSousFamille);

                return NouvelleSousFamille;
            }
        }
        
        /// <summary>
        /// Méthode permettant de récupérer un objet SousFamille avec NomParam en tant qu'attribut Nom. Le crée s'il n'existe pas déjà
        /// </summary>
        /// <param name="NomParam">Nom de la SousFamille que l'on souhaite</param>
        /// <param name="FamilleParam">Famille de la SousFamille</param>
        /// <returns> NouvelleSousFamille </returns>
        public static SousFamille CreerSousFamilleDepuisSQLite(string NomParam, Famille FamilleParam)
        {
            if (!DictionnaireSousFamilles.ContainsKey(NomParam))
            {
                SousFamille NouvelleSousFamille = new SousFamille(NomParam, FamilleParam);
                DictionnaireSousFamilles.Add(NomParam, NouvelleSousFamille);

                return NouvelleSousFamille;
            }

            return null;
        }
        
        /// <summary>
        /// Méthode permettant de récupérer un objet SousFamille avec NomParam en tant qu'attribut Nom. Le crée s'il n'existe pas déjà
        /// </summary>
        /// <param name="NomParam">Nom de la SousFamille que l'on souhaite</param>
        /// <param name="FamilleParam">Famille de la SousFamille</param>
        /// <returns> NouvelleSousFamille </returns>
        public static SousFamille CreerSousFamilleDepuisCSV(string NomParam, Famille FamilleParam)
        {
            if (!DictionnaireSousFamilles.ContainsKey(NomParam))
            {
                SousFamille NouvelleSousFamille = new SousFamille(NomParam, FamilleParam);
                DictionnaireSousFamilles.Add(NomParam, NouvelleSousFamille);

                BaseDeDonnees.GetInstance().AjoutSousFamilleBdd(NouvelleSousFamille);

                return NouvelleSousFamille;
            }
            
            return DictionnaireSousFamilles[NomParam];
        }

        private SousFamille() { }
        private SousFamille(SousFamille SousFamilleParam) { }

        /// <summary>
        /// Constructeur utilisé par la méthode CreateSousFamille
        /// </summary>
        /// <param name="NomParam">Nom de la SousFamille que l'on souhaite</param>
        /// <param name="FamilleParam">Famille de la SousFamille</param>
        private SousFamille(string NouveauNom, Famille FamilleParam)
        {
            Nom = NouveauNom;
            Famille = FamilleParam;
            RefSousFamille = -1; // RefSousFamille non genere
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
                if (DictionnaireSousFamilles.ContainsKey(NouveauNom))
                {
                    throw new Exception(Exception.ERREUR_NOM_DEJA_ASSIGNEE);
                }
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
        /// Accesseur en lecture de l'attribut RefSousFamille
        /// </summary>
        /// <returns> RefSousFamille </returns>
        public int GetRefSousFamille()
        {
            return RefSousFamille;
        }

        /// <summary>
        /// Accesseur en écriture de l'attribut RefSousFamille, appelée lorsque l'objet est inserée, de sorte à rapporter la reference ainsi generee dans l'objet
        /// </summary>
        /// <param name="NouvelleRefSousFamille">La reference autogeneree</param>
        public void DefineRefSousFamille(int NouvelleRefSousFamille)
        {
            try
            {
                if(RefSousFamille != -1)
                {
                    throw new Exception(Exception.ERREUR_REFERENCE_DEJA_DEFINIE);
                }
                foreach (SousFamille SousFamilleExistante in DictionnaireSousFamilles.Values)
                {
                    if (SousFamilleExistante.GetRefSousFamille() == NouvelleRefSousFamille)
                    {
                        throw new Exception(Exception.ERREUR_REFERENCE_AUTOGENEREE_DEJA_ASSIGNEE);
                    }
                }

                RefSousFamille = NouvelleRefSousFamille;
            }
            catch (Exception ExceptionCatched)
            {
                ExceptionCatched.AfficherMessageErreur();
            }
        }

        /// <summary>
        /// Accesseur en lecture de l'attribut Famille
        /// </summary>
        /// <returns> Famille </returns>
        public Famille GetFamille()
        {
            return Famille;
        }

        /// <summary>
        /// Accesseur en écriture de l'attribut Famille
        /// </summary>
        /// <param name="NouvelleFamille">La Famille que l'on souhaite définir</param>
        public void SetFamille(Famille NouvelleFamille)
        {
            Famille = NouvelleFamille;
        }

        /// <summary>
        /// Renvoie une liste correspondant au dictionnaire DictionnaireSousFamilles
        /// </summary>
        /// <returns></returns>
        public static List<SousFamille> GetListeSousFamilles()
        {
            List<SousFamille> ListeSousFamilles = new List<SousFamille>();

            foreach (var Couple in DictionnaireSousFamilles)
            {
                ListeSousFamilles.Add(Couple.Value);
            }

            return ListeSousFamilles;
        }

        /// <summary>
        /// Vide le dictionnaire DictionnaireSousFamilles
        /// </summary>
        public static void ViderDictionnaireSousFamilles()
        {
            DictionnaireSousFamilles.Clear();
        }

        /// <summary>
        /// Indique si un Article appartient à la SousFamille
        /// </summary>
        /// <returns>   - true : Si au moins un Article appartient à cette sous-famille
        ///             - false : Sinon </returns>
        public bool SousFamilleUtilisee()
        {
            foreach (Article ArticleExistant in Article.GetListeArticles())
            {
                if (ArticleExistant.GetSousFamille().GetNom() == Nom)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Méthode qui permet de supprimer  une famille
        /// </summary>
        /// <returns> Une valeur indiquant si la modification a réussie </returns>
        public uint SupprimerSousFamille()
        {
            try
            {
                if (SousFamilleUtilisee() == true)
                {
                    throw new Exception(Exception.ERREUR_OBJET_UTILISEE);
                }

                DictionnaireSousFamilles.Remove(Nom);
                BaseDeDonnees.GetInstance().SupprimerFamilleBdd(RefSousFamille);

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
