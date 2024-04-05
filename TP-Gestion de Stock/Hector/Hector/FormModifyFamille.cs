using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hector
{
    public partial class FormModifyFamille : Form
    {
        private Famille FamilleSelectionnee;
        public FormModifyFamille(Famille FamilleParam)
        {
            InitializeComponent();

            FamilleSelectionnee = FamilleParam;
            NomFamilleTextBox.Text = FamilleSelectionnee.GetNom();
        }

        private void BoutonModifier_Click(object sender, EventArgs e)
        {
            try
            {
                string NouveauNom = NomFamilleTextBox.Text;

                if (Marque.NomAttribue(NouveauNom) == true)
                {
                    throw new Exception(Exception.ERREUR_NOM_DEJA_ASSIGNEE);
                }

                if (BaseDeDonnees.GetInstance().ModifierFamilleBdd(FamilleSelectionnee.GetRefFamille(), NouveauNom) == Exception.RETOUR_ERREUR)
                {
                    return;
                }
                FamilleSelectionnee.SetNom(NouveauNom);

                MessageBox.Show("Modifier avec succes", "Tout bon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ExceptionAttrapee)
            {
                ExceptionAttrapee.AfficherMessageErreur();
            }
        }

        private void BoutonAnnulation_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
