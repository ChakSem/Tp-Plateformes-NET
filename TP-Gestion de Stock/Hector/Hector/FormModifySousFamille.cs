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
    public partial class FormModifySousFamille : Form
    {
        SousFamille SousFamilleSelectionnee;

        public FormModifySousFamille(SousFamille SousFamilleParam)
        {
            InitializeComponent();
            SousFamilleSelectionnee = SousFamilleParam;

            string NomFamilleSousFamilleSelectionnee = SousFamilleSelectionnee.GetFamille().GetNom();
            foreach (Famille FamilleExistante in Famille.GetDictionnaireFamilles())
            {
                string Nom = FamilleExistante.GetNom();
                if (Nom != NomFamilleSousFamilleSelectionnee)
                    FamilleComboBox.Items.Add(Nom);
            }
            FamilleComboBox.Items.Add(NomFamilleSousFamilleSelectionnee);
            FamilleComboBox.SelectedIndex = 0;

            NomSousFamilleTextBox.Text = SousFamilleSelectionnee.GetNom();
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            Famille FamilleSelectionnee = Famille.GetFamilleExistante(FamilleComboBox.Text);

            if(SousFamilleSelectionnee.SetNom(NomSousFamilleTextBox.Text) == Exception.RETOUR_ERREUR)
            {
                return;
            }
            SousFamilleSelectionnee.SetFamille(FamilleSelectionnee);

            MessageBox.Show("Modifier avec succes", "Tout bon", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
