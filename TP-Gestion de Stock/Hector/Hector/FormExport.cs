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

            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Filter = "Fichiers CSV|*.csv";
            SaveFileDialog.Title = "Selectionnez le chemin où sauvegarder";
            SaveFileDialog.ShowDialog();
            CheminCsvAExporter = SaveFileDialog.FileName;

            if (CheminCsvAExporter != null)
            {
                CheminLabel.Text = CheminCsvAExporter;

                Parseur.ExtraireDonnees(CheminCsvAExporter);
            }
        }
    }
}
