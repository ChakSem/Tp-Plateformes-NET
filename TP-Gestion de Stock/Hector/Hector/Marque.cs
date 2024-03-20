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
        private static Dictionary<string, Marque> MarquesObjects = new Dictionary<string, Marque>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NouveauNom"></param>
        /// <returns></returns>
        public static Marque CreateMarque(string NouveauNom)
        {
            //System.NullReferenceException : 'La référence d'objet n'est pas définie à une instance d'un objet.'
            if( MarquesObjects.ContainsKey(NouveauNom) )
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
