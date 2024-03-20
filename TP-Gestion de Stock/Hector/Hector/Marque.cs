using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    class Marque
    {
        private string Nom;
        private static Dictionary<string, Marque> MarquesObjects;
        
        public static Marque CreateMarque(string NouveauNom)
        {
            if( MarquesObjects.ContainsKey(NouveauNom))
            {
                return MarquesObjects[NouveauNom];
            } else
            {
                Marque NouvelleMarque = new Marque(NouveauNom);
                MarquesObjects.Add(NouveauNom, NouvelleMarque);

                return NouvelleMarque;
            }
        }
        private Marque() { }
        private Marque(Marque NouvelleMarque) { }

        private Marque(string NouveauNom)
        {
            Nom = NouveauNom;
        }

        public string GetNom()
        {
            return Nom;
        }

        public void SetNom(string NouveauNom)
        {
            try
            {
                if (MarquesObjects.ContainsKey(NouveauNom))
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

    }
}
