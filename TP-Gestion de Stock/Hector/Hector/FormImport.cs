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
    public partial class FormImport : Form
    {
        public FormImport()
        {
            InitializeComponent();
        }

        private void ImportButton(object sender, EventArgs e)
        {
            /* On apelle la methode ImporterCSV de la classe ImporterCSV */
            string path = ImportCsvFile(sender, e);
            /*on ecrie le chemin du fichier dans le label*/
            FilePathLabel.Text = path;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void CheckBoxAjout_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxEcrasement.Checked = !CheckBoxAjout.Checked;
        }

        private void CheckBoxEcrasement_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxAjout.Checked = !CheckBoxEcrasement.Checked;
        }

        private string ImportCsvFile(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Fichiers CSV|*.csv";
            OpenFileDialog.Title = "Selectionnez un fichier CSV";
            OpenFileDialog.ShowDialog();
            return OpenFileDialog.FileName;
           

        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            /*On realise l'importation des articles*/
            string path = FilePathLabel.Text;
            if (path != null)
            {
                FilePathLabel.Text = path;
            }
            //Article.AfficherArticles(articles);
            if (CheckBoxAjout.Checked)
            {
                foreach (Article article in articles)
                {

                    
                }
            }
            else
            {
                foreach (Article article in articles)
                {
                    
                }
            }
        }
    }
}
