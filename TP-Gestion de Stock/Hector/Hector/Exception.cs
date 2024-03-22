using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    class Exception : System.Exception
    {
        public const uint ERROR_REFERENCE_IS_ALREADY_ASSIGNED = 0;
        public const uint ERROR_NOM_IS_ALREADY_ASSIGNED = 1;
        public const uint ERROR_FAMILLE_DOESN_T_MATCH = 2;
        public const uint ERROR_DATABASE_FILE_NOT_FOUND = 3;
        public const uint ERROR_DATABASE_CONNECTION= 4;

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
                case ERROR_REFERENCE_IS_ALREADY_ASSIGNED:
                    ErrorMessage = "Un article existe déjà pour cette réference";
                break;
                case ERROR_NOM_IS_ALREADY_ASSIGNED:
                    ErrorMessage = "Un objet existe déjà pour ce nom";
                    break;
                case ERROR_FAMILLE_DOESN_T_MATCH:
                    ErrorMessage = "La sous-famille existante à ce nom n'est pas de la famille indiquée";
                    break;
                case ERROR_DATABASE_FILE_NOT_FOUND:
                    ErrorMessage = "Le fichier n'a pu être trouvé";
                    break;
                case ERROR_DATABASE_CONNECTION:
                    ErrorMessage = "La connection avec la base de donnée a échouée";
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