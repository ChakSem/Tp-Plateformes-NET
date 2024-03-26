using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    class Exception : System.Exception
    {
        public const uint ERREUR_REFERENCE_DEJA_ASSIGNEE = 0;
        public const uint ERREUR_NOM_DEJA_ASSIGNEE = 1;
        public const uint ERREUR_FAMILLE_NE_CORRESPOND_PAS = 2;
        public const uint ERREUR_FICHIER_NON_TROUVE= 3;
        public const uint ERREUR_CONNECTION_A_LA_BDD= 4;
        public const uint ERREUR_OBJET_INNEXISTANT = 5;
        public const uint ERREUR_REFERENCE_AUTOGENEREE_DEJA_ASSIGNEE = 6;
        public const uint ERREUR_REFERENCE_DEJA_DEFINIE = 7;

        private uint ErrorCode;
        public uint GetErrorCode()
        {
            return ErrorCode;
        }

        public void SetCodeError(uint ErrorCodeParam)
        {
            ErrorCode = ErrorCodeParam;
        }

        public Exception(uint ErrorCodeParam)
        {
            ErrorCode = ErrorCodeParam;
        }

        public void DisplayErrorMessage()
        {
            string ErrorMessage = "";
            switch (ErrorCode)
            {
                case ERREUR_REFERENCE_DEJA_ASSIGNEE:
                    ErrorMessage = "Un article existe deja pour cette reference";
                break;
                case ERREUR_NOM_DEJA_ASSIGNEE:
                    ErrorMessage = "Un objet existe deja pour ce nom";
                    break;
                case ERREUR_FAMILLE_NE_CORRESPOND_PAS:
                    ErrorMessage = "La sous-famille existante a ce nom n'est pas de la famille indiquee";
                    break;
                case ERREUR_FICHIER_NON_TROUVE:
                    ErrorMessage = "Le fichier n'a pu être trouve";
                    break;
                case ERREUR_CONNECTION_A_LA_BDD:
                    ErrorMessage = "La connection avec la base de donnee a echouee";
                    break;
                case ERREUR_OBJET_INNEXISTANT:
                    ErrorMessage = "Aucun objet n'existe pour ce nom";
                    break;
                case ERREUR_REFERENCE_AUTOGENEREE_DEJA_ASSIGNEE:
                    ErrorMessage = "La reference a deja ete assignee";
                    break;
                case ERREUR_REFERENCE_DEJA_DEFINIE:
                    ErrorMessage = "La reference a deja ete definie pour cet objet";
                    break;
                default:
                    ErrorMessage = "Une erreur inconnue est survenue";
                    break;
            }

            System.Windows.Forms.MessageBox.Show(ErrorMessage, "Erreur code - " + ErrorCode,
            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}