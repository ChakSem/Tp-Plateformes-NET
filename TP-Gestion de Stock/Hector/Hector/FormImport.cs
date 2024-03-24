using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;


namespace Hector
{
    public partial class FormImport : Form
    {
        private BaseDeDonnees BDD;
        private Parseur Parseur;
        private string CheminCsvAImpoter;
        private List<Article> ArticlesAImporter;

        private int NombreArticleAvantImport;
        private int NombreArticleApresImport;
        private int NombreArticleAjoutee;

        public FormImport()
        {
            InitializeComponent();
            Parseur = new Parseur(); // Initialisation de Parseur
        }
        //this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
        private void progressBar1_Click(object sender, EventArgs e)
        {
            //this.progressBar1.Value = 0;
        }

        private void CheckBoxEcrasement_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxAjout.Checked = !CheckBoxEcrasement.Checked;
        }

        private void CheckBoxAjout_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxEcrasement.Checked = !CheckBoxAjout.Checked;
        }

        private void ImportButton(object sender, EventArgs e)
        {
            CheminCsvAImpoter = ImportCsvFile(sender, e);
            FilePathLabel.Text = CheminCsvAImpoter;
        }

        private string ImportCsvFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers CSV|*.csv";
            openFileDialog.Title = "Sélectionnez un fichier CSV";
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            BDD = new BaseDeDonnees();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker worker = sender as BackgroundWorker; // On récupère le worker
            ArticlesAImporter = Parseur.Parse(CheminCsvAImpoter);
            NombreArticleAvantImport = BDD.LireNombreArticlesBdd();
            int NombreArticleDansFichier = Parseur.GetNbArticles(CheminCsvAImpoter);

            if (CheckBoxEcrasement.Checked)
            {
                BDD.ViderDonnees();
            }
            // On ajoute les informations dans la BDD tout en mettant à jour la barre de progression
            for (int i = 0; i < ArticlesAImporter.Count; i++)
            {
                BDD.AjoutArticleBdd(ArticlesAImporter[i]);
                worker.ReportProgress((i + 1) * 100 / NombreArticleDansFichier);
            }
            NombreArticleApresImport = BDD.LireNombreArticlesBdd();
            NombreArticleAjoutee = NombreArticleApresImport - NombreArticleAvantImport;

            MessageBox.Show("L'intégration des données a été effectuée avec succès.\n\n" +
                "Vous avez ajouté " + NombreArticleAjoutee + " article(s) dans la base de données. \n" +
                "Il y a maintenant " + NombreArticleApresImport + " article(s) dans la base de données.", "Succès de l'intégration", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
