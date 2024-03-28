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

            foreach(SousFamille SousFamilleExistante in SousFamille.GetDictionnaireSousFamilles())
                RefSousFamilleComboBox.Items.Add(SousFamilleExistante.GetNom());

            foreach (Marque MarqueExistante in Marque.GetDictionnaireMarques())
                RefMarqueComboBox.Items.Add(MarqueExistante.GetNom());
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
            //On récupère les sous

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
