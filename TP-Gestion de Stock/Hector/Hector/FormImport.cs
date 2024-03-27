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
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
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
            if (!backgroundWorker1.IsBusy)
            {
                BDD = BaseDeDonnees.GetInstance();

                // Si on n'ajoute pas en ecrasement, on s'assure d'avoir les elements de la BDD chargees dans les objets
                if (CheckBoxAjout.Checked) { 
                    // A Voir
                }

                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.DoWork -= backgroundWorker1_DoWork;
                backgroundWorker1.DoWork += backgroundWorker1_DoWork;
                backgroundWorker1.RunWorkerAsync();

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker; // On récupère le worker

            /* Si on ouvre en ecrasement, on vide la BDD */
            if (CheckBoxEcrasement.Checked)
            {
                BDD.ViderDonnees();
            }

             // On crée et recupere les objets Article à importer dans la BDD ( et on cree les objets Marque, Familles et SousFamilles qui n'existent pas encore )

            NombreArticleAvantImport = BDD.LireNombreArticlesBdd();/*
            int NombreArticleDansFichier = ArticlesAImporter.Count;*/

            uint NombreArticleAjoutesAvecSucces = Parseur.Parse(CheminCsvAImpoter);

            worker.ReportProgress(100);
            
            NombreArticleApresImport = BDD.LireNombreArticlesBdd();
            NombreArticleAjoutee = NombreArticleApresImport - NombreArticleAvantImport;

            MessageBox.Show("L'intégration des données a été effectuée avec succès.\n\n" +
                "Vous avez ajouté " + NombreArticleAjoutee + " article(s) dans la base de données. \n" +
                "Il y a maintenant " + NombreArticleApresImport + " article(s) dans la base de données.", "Succès de l'intégration", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
