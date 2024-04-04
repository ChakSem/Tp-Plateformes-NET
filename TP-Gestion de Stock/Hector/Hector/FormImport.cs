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

        /// <summary>
        /// Constructeur de la classe FormImport
        /// </summary>
        public FormImport()
        {
            InitializeComponent();
            Parseur = new Parseur(); // Initialisation de Parseur
            ObjetBackgroundWorker.ProgressChanged += backgroundWorker1_ProgressChanged;
        }
        /// <summary>
        /// Méthode permettant de mettre à jour la barre de progression
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BarreDeProgression.Value = e.ProgressPercentage;
        }

        //this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
        private void progressBar1_Click(object sender, EventArgs e)
        {
            //this.progressBar1.Value = 0;
        }
        /// <summary>
        /// Méthode permettant de cocher la case Ajout si la case Ecrasement est cochée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxEcrasement_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxAjout.Checked = !CheckBoxEcrasement.Checked;
        }
        /// <summary>
        /// Méthode permettant de cocher la case Ecrasement si la case Ajout est cochée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxAjout_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxEcrasement.Checked = !CheckBoxAjout.Checked;
        }
        /// <summary>
        /// Méthode permettant d'importer un fichier CSV en cliquant sur le bouton Importer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportButton(object sender, EventArgs e)
        {
            CheminCsvAImpoter = ImportCsvFile(sender, e);
            CheminLabel.Text = CheminCsvAImpoter;
        }
        /// <summary>
        /// Méthode permettant d'importer un fichier CSV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private string ImportCsvFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers CSV|*.csv";
            openFileDialog.Title = "Sélectionnez un fichier CSV";
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        /// <summary>
        /// Méthode permettant de terminer l'importation en cliquant sur le bouton Terminer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinishButton_Click(object sender, EventArgs e)
        {
            if (!ObjetBackgroundWorker.IsBusy)
            {
                BDD = BaseDeDonnees.GetInstance();

                ObjetBackgroundWorker.WorkerReportsProgress = true;
                ObjetBackgroundWorker.DoWork -= backgroundWorker1_DoWork;
                ObjetBackgroundWorker.DoWork += backgroundWorker1_DoWork;
                ObjetBackgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Méthode permettant de vider la base de données en cliquant sur le bouton Vider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker BarreDeProgression = sender as BackgroundWorker; // On récupère le worker

            // Si l'import est lancé en ecrasement, la base de donnée SQLite est vidée
            if (CheckBoxEcrasement.Checked)
            {
                BDD.ViderDonnees();
            }
            // Sinon, si l'import est lancé en ajout, les données de la base de donnée SQLite sont chargées de nouveau
            if (CheckBoxAjout.Checked)
            {
                BaseDeDonnees BDD = BaseDeDonnees.GetInstance();

                BDD.LireMarquesBdd();
                BDD.LireFamillesBdd();
                BDD.LireSousFamillesBdd();
                BDD.LireArticlesBdd();
            }

            // On crée et recupere les objets Article à importer dans la BDD ( et on cree les objets Marque, Familles et SousFamilles qui n'existent pas encore )

            Parseur.Parse(CheminCsvAImpoter, BarreDeProgression);

            int NombreArticleTotal = Article.GetListeArticles().Count;

            MessageBox.Show("L'intégration des données a été effectuée avec succès.\n\n" + "Vous avez ajouté " + Parseur.NOMBRE_ARTICLES_CREE + 
                " nouveaux article(s) dans la base de données. \n" + Parseur.NOMBRE_ARTICLES_MIS_A_JOUR + " articles ont été mis à jour \n" + 
                "Il y a desormais " + NombreArticleTotal + " articles dans la BDD", "Succès de l'intégration", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
