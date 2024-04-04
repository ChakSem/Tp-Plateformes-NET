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
    public partial class FormAddFamille : Form
    {
        private Famille NouvelleFamille;

        /// <summary>
        /// Accesseur en lecture de la Famille crée
        /// </summary>
        /// <returns> NouvelleFamille </returns>
        public Famille GetFamille()
        {
            return NouvelleFamille;
        }

        /// <summary>
        /// Constructeur de la classe FormAddFamille
        /// </summary>
        public FormAddFamille()
        {
            InitializeComponent();
            NouvelleFamille = null;
        }

        /// <summary>
        /// Méthode permettant de créer une famille
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if(NomFamilleTextBox.Text != "")
            {
                NouvelleFamille = Famille.CreerFamille(NomFamilleTextBox.Text);

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
        /// <summary>
        /// Méthode permettant de fermer la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
