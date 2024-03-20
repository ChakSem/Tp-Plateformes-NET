using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    class SousFamille
    {
        private string Nom;
        private Famille Famille;
        /*Attribut pour verifier la sous famille n'exite pas en doublon*/
        private static List<string> ListeSousFamille = new List<string>();
        
        private SousFamille(string NouveauNom, Famille NouvelleFamille)
        {
            if (ListeSousFamille.Contains(NouveauNom))
            {
                throw new Exception("La sous famille existe déjà");
            }
            else
            {
                ListeSousFamille.Add(NouveauNom);
                Nom = NouveauNom;
                Famille = NouvelleFamille;
            }
        }

        public string GetNom()
        {
            return Nom;
        }

        public void SetNom(string NouveauNom)
        {
            Nom = NouveauNom;
        }

        public Famille GetFamille()
        {
            return Famille;
        }

        public void SetFamille(Famille NouvelleFamille)
        {
            Famille = NouvelleFamille;
        }
    }
}
