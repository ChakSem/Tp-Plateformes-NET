using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    /// <summary>
    /// Classe permettant de gérer les fenêtres d'erreurs
    /// </summary>
    class Exception : System.Exception
    {
        // Code de renvoi, utilisé par les méthodes qui indique si elles ont réussis à s'éxecuter ou si une exception a été levée
        public const uint RETOUR_NORMAL = 0;
        public const uint RETOUR_ERREUR = 1;

        // Codes d'erreur
        public const uint ERREUR_REFERENCE_DEJA_ASSIGNEE = 0;
        public const uint ERREUR_NOM_DEJA_ASSIGNEE = 1;
        public const uint ERREUR_FAMILLE_NE_CORRESPOND_PAS = 2;
        public const uint ERREUR_FICHIER_NON_TROUVE= 3;
        public const uint ERREUR_CONNECTION_A_LA_BDD= 4;
        public const uint ERREUR_OBJET_INNEXISTANT = 5;
        public const uint ERREUR_REFERENCE_AUTOGENEREE_DEJA_ASSIGNEE = 6;
        public const uint ERREUR_REFERENCE_DEJA_DEFINIE = 7;
        public const uint ERREUR_CHEMIN_VIDE = 8;
        public const uint ERREUR_OBJET_DEJA_EXISTANT = 9;
        public const uint ERREUR_PARSING_DOUBLE = 10;
        public const uint ERREUR_PARSING_UINT = 11; 
        public const uint ERREUR_REFERENCE_NON_EXISTANTE = 12;
        public const uint ERREUR_OBJET_UTILISEE = 13;
        public const uint ARTICLE_DEJA_EXISTANT = 14;


        private uint CodeErreur;
        /// <summary>
        /// Acceseur en lecture du code d'erreur
        /// </summary>
        /// <returns></returns>
        public uint GetCodeErreur()
        {
            return CodeErreur;
        }

        /// <summary>
        /// Acceseur en écriture du code d'erreur
        /// </summary>
        /// <param name="CodeErreurParam"></param>
        public void SetCodeErreur(uint CodeErreurParam)
        {
            CodeErreur = CodeErreurParam;
        }

        /// <summary>
        /// Constructeur de la classe Exception
        /// </summary>
        /// <param name="NouveauCodeErreur"></param>
        public Exception(uint NouveauCodeErreur)
        {
            CodeErreur = NouveauCodeErreur;
        }

        /// <summary>
        /// Méthode gérant l'ouverture de la fenêtre associée au code d'erreur définie
        /// </summary>
        public void AfficherMessageErreur()
        {
            string MessageErreur;
            switch (CodeErreur)
            {
                case ERREUR_REFERENCE_DEJA_ASSIGNEE:
                    MessageErreur = "Un article existe deja pour cette reference";
                break;
                case ERREUR_NOM_DEJA_ASSIGNEE:
                    MessageErreur = "Un objet existe deja pour ce nom";
                    break;
                case ERREUR_FAMILLE_NE_CORRESPOND_PAS:
                    MessageErreur = "La sous-famille existante a ce nom n'est pas de la famille indiquee";
                    break;
                case ERREUR_FICHIER_NON_TROUVE:
                    MessageErreur = "Le fichier n'a pu être trouve";
                    break;
                case ERREUR_CONNECTION_A_LA_BDD:
                    MessageErreur = "La connection avec la base de donnee a echouee";
                    break;
                case ERREUR_OBJET_INNEXISTANT:
                    MessageErreur = "Aucun objet n'existe pour ce nom";
                    break;
                case ERREUR_REFERENCE_AUTOGENEREE_DEJA_ASSIGNEE:
                    MessageErreur = "La reference a deja ete assignee";
                    break;
                case ERREUR_REFERENCE_DEJA_DEFINIE:
                    MessageErreur = "La reference a deja ete definie pour cet objet";
                    break;
                case ERREUR_CHEMIN_VIDE:
                    MessageErreur = "Le chemin du fichier est vide";
                    break;
                case ERREUR_OBJET_DEJA_EXISTANT:
                    MessageErreur = "L'objet qui devait être cree existe deja";
                    break;
                case ERREUR_PARSING_DOUBLE:
                    MessageErreur = "Le parsing en double a echoue";
                    break;
                case ERREUR_PARSING_UINT:
                    MessageErreur = "Le parsing en uint a echoue";
                    break;
                case ERREUR_REFERENCE_NON_EXISTANTE:
                    MessageErreur = "La Reference est introuvable";
                    break;
                case ERREUR_OBJET_UTILISEE:
                    MessageErreur = "Cet objet ne peut etre supprime, il est utilse par un autre objet";
                    break;
                default:
                    MessageErreur = "Une erreur inconnue est survenue";
                    break;
            }

            System.Windows.Forms.MessageBox.Show(MessageErreur, "Erreur code - " + CodeErreur,
            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}