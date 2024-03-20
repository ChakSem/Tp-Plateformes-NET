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
        /*Attibut pour verifier que la famille n'est pas en doublon dans la liste des familles*/
        private static List<string> ListeFamille = new List<string>();

        private Famille(string NouveauNom)
        {
            if (ListeFamille.Contains(NouveauNom))
            {
                throw new Exception("La famille existe déjà");
            }
            else
            {
                ListeFamille.Add(NouveauNom);
                Nom = NouveauNom;
            }
        }
        
        /*Accesseurs*/
        public string GetNom()
        {
            return Nom;
        }

        public void SetNom(string NouveauNom)
        {
            Nom = NouveauNom;
        }
    }
}
