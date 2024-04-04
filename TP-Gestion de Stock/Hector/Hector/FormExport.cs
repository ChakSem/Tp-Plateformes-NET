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
    public partial class FormExport : Form
    {
        private string CheminCsvAExporter;
        /// <summary>
        /// Constructeur de la classe FormExport
        /// </summary>
        public FormExport()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Méthode permettant de fermer la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers CSV|*.csv";
            openFileDialog.Title = "Selectionnez le fichier à importer";
            openFileDialog.ShowDialog();
            CheminCsvAExporter = openFileDialog.FileName;
            if (CheminCsvAExporter != null)
            {
                CheminLabel.Text = CheminCsvAExporter;
            }

    
        }


        private void BoutonExtraire_Click(object sender, EventArgs e)
        {
            if (CheminCsvAExporter != null)
            {
                Parseur.ExtraireDonnees(CheminCsvAExporter);
                MessageBox.Show("Exportation réussie");
                this.Close();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un fichier à exporter");
            }

        }
    }
}
