using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    class Marque
    {
        /// <summary>
        /// Stocke les objets Marque déjà créé 
        /// </summary>
        private static Dictionary<string, Marque> MarquesObjects = new Dictionary<string, Marque>();

        private string Nom;

        /// <summary>
        /// Méthode permettant de récupérer un objet Marque avec NomParam en tant qu'attribut Nom. Le crée s'il n'existe pas déjà
        /// </summary>
        /// <param name="NomParam">Nom de la Marque que l'on souhaite</param>
        /// <returns> NouvelleMarque </returns>
        public static Marque CreateMarque(string NomParam)
        {
            //System.NullReferenceException : 'La référence d'objet n'est pas définie à une instance d'un objet.'
            if( MarquesObjects.ContainsKey(NomParam) )
            {
                return MarquesObjects[NomParam];
            } else
            {
                Marque NouvelleMarque = new Marque(NomParam);
                MarquesObjects.Add(NomParam, NouvelleMarque);

                return NouvelleMarque;
            }
        }
        private Marque() { }
        private Marque(Marque NouvelleMarque) { }


        /// <summary>
        /// Constructeur utilisé par la méthode CreateMarque
        /// </summary>
        /// <param name="NomParam">Nom de la Marque que l'on souhaite</param>
        private Marque(string NomParam)
        {
            Nom = NomParam;
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
