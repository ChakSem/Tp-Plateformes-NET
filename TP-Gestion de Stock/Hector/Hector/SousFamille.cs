using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    class SousFamille
    {
        private static Dictionary<string, SousFamille> SousFamillesObjects = new Dictionary<string, SousFamille>();

        private string Nom;
        private Famille Famille;

        /// <summary>
        /// Méthode permettant de récupérer un objet SousFamille avec NomParam en tant qu'attribut Nom. Le crée s'il n'existe pas déjà
        /// </summary>
        /// <param name="NomParam">Nom de la SousFamille que l'on souhaite</param>
        /// <param name="FamilleParam">Famille de la SousFamille</param>
        /// <returns> NouvelleSousFamille </returns>
        public static SousFamille CreateSousFamille(string NomParam, Famille FamilleParam)
        {
            if (SousFamillesObjects.ContainsKey(NomParam))
            {
                try
                {
                    SousFamille SousFamilleExistante = SousFamillesObjects[NomParam];
                    if (FamilleParam.GetNom() != SousFamilleExistante.GetFamille().GetNom())
                    {
                        throw new Exception(Exception.ERROR_FAMILLE_DOESN_T_MATCH);
                    }

                    return SousFamilleExistante;

                } catch (Exception Exception)
                {
                    Exception.DisplayErrorMessage();

                    return null;
                }
            }
            else
            {
                SousFamille NouvelleSousFamille = new SousFamille(NomParam, FamilleParam);
                SousFamillesObjects.Add(NomParam, NouvelleSousFamille);

                return NouvelleSousFamille;
            }
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
                if (SousFamillesObjects.ContainsKey(NouveauNom))
                {
                    throw new Exception(Exception.ERROR_NOM_IS_ALREADY_ASSIGNED);
                }
                Nom = NouveauNom;
            }
            catch (Exception ExceptionCatched)
            {
                ExceptionCatched.DisplayErrorMessage();
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
    }
}
