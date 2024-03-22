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
    public partial class FormAddArticle : Form
    {
        public FormAddArticle()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CreateButton_Click(object sender, EventArgs e)
        {

            /*On vérifie que les champs obligatoires sont remplis */
            if (RefArticlesTextBox.Text == "" || RefSousFamilleComboBox.Text == "" || RefMarqueComboBox.Text == "" || DescriptionTextBox.Text == "" || QuantiteTextBox.Text == "" || PrixHTTextBox.Text == "")
            {
                MessageBox.Show("Un ou plusieurs champs sont vides", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            /*On crée l'obejet marque marque et la sous-famille en fonction de la combobox */

            /*On crée l'article*/
            

        }

        private void RefSousFamilleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //On récupère les sous-familles
            List<SousFamille> sousFamilles = SousFamille.GetSousFamilles();
            //On récupère la sous-famille sélectionnée
            SousFamille sousFamille = sousFamilles[RefSousFamilleComboBox.SelectedIndex];

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
