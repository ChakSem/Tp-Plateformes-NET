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
        /// Méthode permettant de selectionner le chemin du fichier .csv pour l'export des données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionFichier_Click(object sender, EventArgs e)
        {

            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Filter = "Fichiers CSV|*.csv";
            SaveFileDialog.Title = "Selectionnez le chemin où sauvegarder";
            SaveFileDialog.ShowDialog();
            CheminCsvAExporter = SaveFileDialog.FileName;

            if (CheminCsvAExporter != "")
            {
                CheminTextBox.Text = CheminCsvAExporter;
            }
        }

        /// <summary>
        /// Lance l'extraction des données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonExtraire_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheminCsvAExporter != "")
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
            // Si Parser lève une excpetion lors de l'extraction, on attrape l'erreur et on l'affiche
            catch (Exception ExceptionAttrapee)
            {
                ExceptionAttrapee.AfficherMessageErreur();
            }

        }
    }
}
