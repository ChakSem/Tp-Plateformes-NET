using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    class Famille
    { 
        private string Nom;
        private static Dictionary<string, Famille> FamillesObjects;
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
        
        /*Accesseurs*/
        public string GetNom()
        {
            return Nom;
        }

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
