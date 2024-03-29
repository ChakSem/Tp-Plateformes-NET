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
    public partial class FormAddSousFamille : Form
    {
        public FormAddSousFamille()
        {
            InitializeComponent();

            foreach (Famille FamilleExistante in Famille.GetDictionnaireFamilles())
            {
                FamilleComboBox.Items.Add(FamilleExistante.GetNom());
            }

            FamilleComboBox.SelectedIndex = 0;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (NomSousFamilleTextBox.Text != "" && FamilleComboBox.Items.Count > 0)
            {
                Famille FamilleSelectionnee = Famille.GetFamilleExistante(FamilleComboBox.Text);
                SousFamille NouvelleSousFamillee = SousFamille.CreerSousFamille(NomSousFamilleTextBox.Text, FamilleSelectionnee);

                if (NouvelleSousFamillee != null)
                {
                    MessageBox.Show("Creer avec succes", "Tout bon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                if (NomSousFamilleTextBox.Text == "")
                    MessageBox.Show("Le champ Nom est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                    MessageBox.Show("Aucune Famille n'est selectionne", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
