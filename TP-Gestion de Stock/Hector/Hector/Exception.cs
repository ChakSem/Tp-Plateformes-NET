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
        public const uint ERREUR_CHEMIN_VIDE = 8;

        private uint CodeErreur;
        public uint GetCodeErreur()
        {
            return CodeErreur;
        }

        public void SetCodeErreur(uint CodeErreurParam)
        {
            CodeErreur = CodeErreurParam;
        }

        public Exception(uint NouveauCodeErreur)
        {
            CodeErreur = NouveauCodeErreur;
        }

        public void AfficherMessageErreur()
        {
            string MessageErreur = "";
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
                default:
                    MessageErreur = "Une erreur inconnue est survenue";
                    break;
            }

            System.Windows.Forms.MessageBox.Show(MessageErreur, "Erreur code - " + CodeErreur,
            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}