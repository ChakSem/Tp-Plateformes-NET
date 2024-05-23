using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private bool contenuModifie = false; // On chek si le contenu a été modifié

        public Form1()
        {

            InitializeComponent();
            contenuModifie = false;

            /* Changement taille de police */
            textBox1.Font = new Font(textBox1.Font.FontFamily, Properties.Settings.Default.taillePolice, FontStyle.Regular);

            /* Changement couleur police */
            textBox1.ForeColor = ColorTranslator.FromHtml(Properties.Settings.Default.couleurPolice);

            /* Changement de taille */
            this.Width = Properties.Settings.Default.tailleX;
            this.Height = Properties.Settings.Default.tailleY;

            /* Changement de position */
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Properties.Settings.Default.positionX, Properties.Settings.Default.positionY);
        }


        /************************EXERCICE 5.3*************************************/
        /*Fermeture sans engistrement avec demande de confirmation              */
        /***********************************************************************/
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* Vérifie si le contenu a été modifié avant de fermer la fenêtre */
            if (contenuModifie)
            {
                /* Demande à l'utilisateur de confirmer la fermeture sans enregistrer */
                DialogResult result = MessageBox.Show("Le contenu a été modifié. Voulez-vous vraiment quitter sans enregistrer ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                {
                    /* Si l'utilisateur clique sur "Cancel", on annule la fermeture de la fenêtre */
                    e.Cancel = true;

                }
                else if (result == DialogResult.Yes)
                {
                    /* Si l'utilisateur clique sur "Oui", on ferme la fenêtre sans enregistrer */
                    e.Cancel = false;
                }
                else if (result == DialogResult.No)
                {
                    /* Si l'utilisateur clique sur "Non", on ferme et on sauvegarde par dessus */
                    toolStripMenuItem2_Click(sender, e);
                    e.Cancel = false;
                }
            }

            /* On modifie et sauvegarde les paramètres */
            Properties.Settings.Default.tailleX = this.Width;
            Properties.Settings.Default.tailleY = this.Height;

            /* On vérifie que la position est bien dans l'écran */
            if (this.Location.X > 0 & this.Location.X < Screen.PrimaryScreen.Bounds.Width)
            {
                Properties.Settings.Default.positionX = this.Location.X;
            }
            else if (this.Location.X < 0)
            {
                Properties.Settings.Default.positionX = 0;
            }
            else if (this.Location.X > Screen.PrimaryScreen.Bounds.Width)
            {
                Properties.Settings.Default.positionX = Screen.PrimaryScreen.Bounds.Width;
            }

            if (this.Location.Y > 0 & this.Location.Y < Screen.PrimaryScreen.Bounds.Height)
            {
                Properties.Settings.Default.positionY = this.Location.Y;
            }
            else if (this.Location.Y < 0)
            {
                Properties.Settings.Default.positionY = 0;
            }
            else if (this.Location.Y > Screen.PrimaryScreen.Bounds.Height)
            {
                Properties.Settings.Default.positionY = Screen.PrimaryScreen.Bounds.Height;
            }

            Properties.Settings.Default.Save();
        }

        /************************EXERCICE 5.2*************************************/
        /*Afficher un "*" dans le titre de la fenêtre si le contenu a été modifié*/
        /************************************************************************/
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
           /* Le contenu a été modifié, ajoute une étoile au titre de la fenêtre */
            if (!contenuModifie)
            {
                this.Text = this.Text + "*";
                contenuModifie = true;
            }

        }


        /************************EXERCICE  3 *************************************/
        /*Ouvrir un fichier texte dans un textBox                               */
        /***********************************************************************/
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /* Crée un OpenFileDialog */
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            /* Configure les propriétés de l'OpenFileDialog */
            // openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);// Environment.SpecialFolder.MyDocuments => Permet de récupérer le dossier Mes documents directement
            openFileDialog1.Filter = "Fichiers texte (*.txt)|*.txt";
            openFileDialog1.Title = "Ouvrir un fichier texte";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            /* Affiche la boîte de dialogue et attend que l'utilisateur choisisse un fichier */
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;

                /* Lecture du fichier */
                using (StreamReader Sr = File.OpenText(selectedFileName))
                {
                    string Ligne;
                    textBox1.Clear();

                    /* On remplit la texte box */
                    while ((Ligne = Sr.ReadLine()) != null)
                    {
                        textBox1.AppendText(Ligne + "\r\n");
                    }
                }
                /************************EXERCICE 5.1*************************************/
                /*Afficher le nom du fichier dans le titre de la fenêtre [nom du fichier]*/
                /************************************************************************/
                this.Text = "Éditeur de fichier texte [ " + Path.GetFileName(selectedFileName) + " ]";
                contenuModifie = false;
            }
        }
        /************************   EXERCICE 4  ***********************************/
        /*Enregistrer le contenu du TextBox dans un fichier texte avec une demande
        de confirmation si le fichier existe déjà                                */
        /************************************************************************/
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            /* Crée un OpenFileDialog */
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            /* Configure les propriétés de l'OpenFileDialog */
            //saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "Fichiers texte (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.Title = "Enregistrer sous ...";

            /* Affiche la boîte de dialogue et attend que l'utilisateur choisisse un fichier */
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Obtient le chemin du fichier sélectionné */ 
                string filePath = saveFileDialog1.FileName;

                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    sw.Write(textBox1.Text);
                }
            }
            contenuModifie = false;
            /************************EXERCICE 5.2*************************************/
            /*Retire le  "*" dans le titre de la fenêtre si le contenu a été modifié*/
            /************************************************************************/
            /* Retire l'étoile du titre de la fenêtre */
            this.Text = this.Text.TrimEnd('*');
        }


        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            // Créer une boîte de dialogue pour choisir la police */ 
            FontDialog fontDialog = new FontDialog();

            // Afficher la boîte de dialogue */ 
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                // Récupérer la taille de police choisie par l'utilisateur */ 
                float taillePolice = fontDialog.Font.Size;

                // Appliquer la nouvelle taille de police au TextBox */ 
                textBox1.Font = new Font(textBox1.Font.FontFamily, taillePolice);
                Properties.Settings.Default.taillePolice = taillePolice;
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            /* Créer une boîte de dialogue pour choisir la couleur */
            ColorDialog colorDialog = new ColorDialog();

            /* Afficher la boîte de dialogue
           if (colorDialog.ShowDialog() == DialogResult.OK)
           {
                /* Récupérer la couleur choisie par l'utilisateur */
            Color couleur = colorDialog.Color;

            /* Appliquer la nouvelle couleur au texte du TextBox */
            textBox1.ForeColor = couleur;
            Properties.Settings.Default.couleurPolice = ColorTranslator.ToHtml(couleur);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
