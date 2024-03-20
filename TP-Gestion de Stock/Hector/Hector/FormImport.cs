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

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ImportCsvFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers CSV|*.csv";
            openFileDialog.Title = "Selectionnez un fichier CSV";
            openFileDialog.ShowDialog();
            string path = openFileDialog.FileName;
            List<Article> articles = Parser.Parse(path);
            foreach (Article article in articles)
            {
                Console.WriteLine(article.GetDescription());
            }

        }
    }
}
