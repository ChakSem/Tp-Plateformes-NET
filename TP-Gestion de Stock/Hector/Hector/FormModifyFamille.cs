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

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            if (FamilleSelectionnee.SetNom(NomFamilleTextBox.Text) == Exception.RETOUR_ERREUR)
            {
                return;
            }

            MessageBox.Show("Modifier avec succes", "Tout bon", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
