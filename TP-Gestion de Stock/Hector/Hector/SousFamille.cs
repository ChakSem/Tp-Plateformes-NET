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
        private static Dictionary<string, SousFamille> SousFamillesObjects;

        public static SousFamille CreateSousFamille(string NomParam, Famille FamilleParam)
        {
            if (SousFamillesObjects.ContainsKey(NomParam))
            {
                return SousFamillesObjects[NomParam];
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
        
        private SousFamille(string NouveauNom, Famille FamilleParam)
        {
            Nom = NouveauNom;
            Famille = FamilleParam;
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
