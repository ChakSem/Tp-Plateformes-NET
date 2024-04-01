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
    public partial class FormAddMarque : Form
    {

        /// <summary>
        /// Constructeur de la classe FormAddMarque
        /// </summary>
        public FormAddMarque()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Méthode permettant de créer une marque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (NomMarqueTextBox.Text != "")
            {
                Marque NouvelleMarque = Marque.CreerMarque(NomMarqueTextBox.Text);

                if (NouvelleMarque != null)
                {
                    MessageBox.Show("Creer avec succes", "Tout bon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            } else
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
