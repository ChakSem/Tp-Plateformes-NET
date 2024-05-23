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
    public partial class FormModifyMarque : Form
    {
        private Marque MarqueSelectionnee;

        public FormModifyMarque(Marque MarqueParam)
        {
            InitializeComponent();

            MarqueSelectionnee = MarqueParam;
            NomMarqueTextBox.Text = MarqueParam.GetNom();
        }

        private void BoutonModifier_Click(object sender, EventArgs e)
        {
            try
            {
                string NouveauNom = NomMarqueTextBox.Text;

                if (Marque.NomAttribue(NouveauNom) == true)
                {
                    throw new Exception(Exception.ERREUR_NOM_DEJA_ASSIGNEE);
                }

                if (BaseDeDonnees.GetInstance().ModifierMarqueBdd(MarqueSelectionnee.GetRefMarque(), NouveauNom) == Exception.RETOUR_ERREUR)
                {
                    return;
                }
                MarqueSelectionnee.SetNom(NomMarqueTextBox.Text);

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
