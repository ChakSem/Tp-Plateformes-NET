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
    public partial class FormExport : Form
    {
        private string CheminCsvAExporter;

        public FormExport()
        {
            InitializeComponent();
        }

        private void CheckBoxAjout_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxEcrasement.Checked = !CheckBoxAjout.Checked;
        }
        private void CheckBoxEcrasement_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxAjout.Checked = !CheckBoxEcrasement.Checked;
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {

            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Filter = "Fichiers CSV|*.csv";
            SaveFileDialog.Title = "Selectionnez le chemin où sauvegarder";
            SaveFileDialog.ShowDialog();
            CheminCsvAExporter = SaveFileDialog.FileName;

            if (CheminCsvAExporter != null)
            {
                FilePathLabel.Text = CheminCsvAExporter;

                Parseur.ExtraireDonnees(CheminCsvAExporter);
            }
        }
    }
}
