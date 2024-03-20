using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hector
{
    class Exception : System.Exception
    {
        public const uint ERROR_NOM_IS_ALREADY_ASSIGNED = 1;
        public const uint ERROR_FAMILLE_DOESN_T_MATCH = 2;

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
            //qDebug() << "ERREUR : ";
            switch (ErrorCode)
            {
                case ERROR_NOM_IS_ALREADY_ASSIGNED:
                    //qDebug() << "Le nom de profil saisi est deja affecte";
                    break;
                case ERROR_FAMILLE_DOESN_T_MATCH:
                    break;
                default:
                    //qDebug() << "INCONNUE"
                    break;
            }
        }
    }
}