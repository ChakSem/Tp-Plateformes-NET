using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    class Famille
    {
        private static Dictionary<string, Famille> FamillesObjects = new Dictionary<string, Famille>();

        private string Nom;

        /// <summary>
        /// Méthode permettant de récupérer un objet Famille avec NomParam en tant qu'attribut Nom. Le crée s'il n'existe pas déjà
        /// </summary>
        /// <param name="NomParam">Nom de la Famille que l'on souhaite</param>
        /// <returns> NouvelleFamille </returns>
        public static Famille CreateFamille(string NomParam)
        {
            if (FamillesObjects.ContainsKey(NomParam))
            {
                return FamillesObjects[NomParam];
            }
            else
            {
                Famille NouvelleFamille = new Famille(NomParam);
                FamillesObjects.Add(NomParam, NouvelleFamille);

                return NouvelleFamille;
            }
        }
        private Famille() { }
        private Famille(Famille FamilleParam) { }
        private Famille(string NouveauNom)
        {
            Nom = NouveauNom;
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
                if (FamillesObjects.ContainsKey(NouveauNom))
                {
                    throw new Exception(Exception.ERROR_NOM_IS_ALREADY_ASSIGNED);
                }
                Nom = NouveauNom;
            } catch (Exception ExceptionCatched) {
                ExceptionCatched.DisplayErrorMessage();
            }
        }
    }
}
