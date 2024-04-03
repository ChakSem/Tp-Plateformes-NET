using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

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
        /// Permet de recuperer un objet Famille à patir de son nom
        /// </summary>
        /// <param name="NomParam"> Nom de la Famille de l'objet que l'on veut </param>
        /// <returns> Famille </returns>
        public static Famille GetFamilleExistante(string NomParam)
        {
            try
            {
                if (NomAttribue(NomParam) == false)
                {
                    throw new Exception(Exception.ERREUR_OBJET_INNEXISTANT);
                }

                return DictionnaireFamilles[NomParam];
            }
            catch (Exception ExceptionAttrapee)
            {
                ExceptionAttrapee.AfficherMessageErreur();

                return null;
            }
        }

        /// <summary>
        /// Méthode permettant de récupérer un objet Famille à partir de son Nom
        /// Le crée s'il n'existe pas déjà
        /// </summary>
        /// <param name="NomParam">Nom de la Famille que l'on souhaite</param>
        /// <returns>   Famille, si l'objet existe deja
        ///             NouvelleFamille, sinon </returns>
        public static Famille CreerFamille(string NomParam)
        {
            if (NomAttribue(NomParam) == true)
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
        /// Méthode permettant de récupérer crée un objet Famille avec NomParam en tant qu'attribut Nom, si aucunes Famille n'existent déjà avec ce nom
        /// Méthode utilisée lors de la récupération des données du fichier SQLite
        /// </summary>
        /// <param name="NomParam"> Nom de la Famille que l'on souhaite créer </param>
        /// <returns> NouvelleFamille </returns>
        public static Famille CreerFamilleDepuisSQLite(string NomParam)
        {
            if (NomAttribue(NomParam) == false)
            {
                Famille NouvelleFamille = new Famille(NomParam);
                DictionnaireFamilles.Add(NomParam, NouvelleFamille);

                return NouvelleFamille;
            }

            return null;
        }

        /// <summary>
        /// Méthode permettant de crée un objet Famille avec NomParam en tant qu'attribut Nom
        /// Si un objet portant ce nom existe déjà, le met à jour
        /// Utilisé lors du parsing de l'objet .csv
        /// </summary>
        /// <param name="NomParam"> Nom de la Famille que l'on souhaite </param>
        /// <returns>   NouvelleFamille, si aucune Famille avec ce nom n'existe déjà
        ///             FamilleExistante, sinon </returns>
        public static Famille CreerFamilleDepuisCSV(string NomParam)
        {
            if (NomAttribue(NomParam) == true)
            {
                Famille FamilleExistante = DictionnaireFamilles[NomParam];
                // Aucunes modifications, puisque Famille ne possède qu'un nom

                return FamilleExistante;
            }
            Famille NouvelleFamille = new Famille(NomParam);
            DictionnaireFamilles.Add(NomParam, NouvelleFamille);

            BaseDeDonnees.GetInstance().AjoutFamilleBdd(NouvelleFamille);

            return NouvelleFamille;
        }

        // Constructeurs par défaut et de recopie passés en privé, seul le constructeur de confort doit être utilisé
        private Famille() { }
        private Famille(Famille FamilleParam) { }

        /// <summary>
        /// Constructeur de confort de la classe Famille 
        /// Utilisée par la méthode CreerFamille
        /// </summary>
        /// <param name="NouveauNom"></param>
        private Famille(string NouveauNom)
        {
            Nom = NouveauNom;
            RefFamille = Global.REFERENCE_NON_ASSIGNEE; // Sera modifiéee lorsque la famille sera saisie dans la base de donnée
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
        /// Verifie que le NouveauNom n'est pas déjà attribuée à une Famille
        /// </summary>
        /// <param name="NouveauNom"></param>
        /// <returns>   - true : Si une Famille avec ce nom existe
        ///             - false : Sinon </returns>
        public static bool NomAttribue(string NouveauNom)
        {
            if (DictionnaireFamilles.ContainsKey(NouveauNom))
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
                // On vérifie que NouveauNom n'est pas déjà attribué
                if (Nom != NouveauNom && NomAttribue(NouveauNom))
                {
                    throw new Exception(Exception.ERREUR_NOM_DEJA_ASSIGNEE);
                }
                // On met à jour le dictionnaire en conséquence
                DictionnaireFamilles.Remove(Nom);
                DictionnaireFamilles.Add(NouveauNom, this);

                Nom = NouveauNom;

                return Exception.RETOUR_NORMAL;
            } catch (Exception ExceptionAttrapee) {
                ExceptionAttrapee.AfficherMessageErreur();

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
        /// Accesseur en écriture de l'attribut RefFamille, appelée lorsque l'objet est inserée, de sorte à repporter la réference ainsi generée dans l'objet
        /// </summary>
        /// <param name="NouvelleRefFamille"> La réference autogénérée par la base de données </param>
        public void DefineRefFamille(int NouvelleRefFamille)
        {
            try
            {
                if (RefFamille != Global.REFERENCE_NON_ASSIGNEE) // Si la réference a déjà été définie (la famille a déjà été ajouté à la base de donnée)
                {
                    throw new Exception(Exception.ERREUR_REFERENCE_DEJA_DEFINIE);
                }

                // On vérifie l'unicité des réferences
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
        /// <returns> DictionnaireFamilles.ToList() </returns>
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
                // On vérifie qu'aucunes sous-familles n'appartient à cette famille
                if (FamilleUtilisee() == true)
                {
                    throw new Exception(Exception.ERREUR_OBJET_UTILISEE);
                }
                // On supprime la famille de la base de donnée, une exception est levée si la requête DELETE échoue
                BaseDeDonnees.GetInstance().SupprimerFamilleBdd(RefFamille);

                DictionnaireFamilles.Remove(Nom);

                return Exception.RETOUR_NORMAL;
            }
            catch (Exception ExceptionAttrapee)
            {
                ExceptionAttrapee.AfficherMessageErreur();

                return Exception.RETOUR_ERREUR;
            }
        }
    }
}
