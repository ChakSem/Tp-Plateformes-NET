using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hector
{
    public partial class FormAddFamille : Form
    {
        public FormAddFamille()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if(NomFamilleTextBox.Text != "")
            {
                Famille NouvelleFamille = Famille.CreerFamille(NomFamilleTextBox.Text);

                if (NouvelleFamille != null)
                {
                    MessageBox.Show("Creer avec succes", "Tout bon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Le champ Nom est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
