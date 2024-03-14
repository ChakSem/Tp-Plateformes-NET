using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string openfileName;
        bool modified;
        DateTime lastModified;

        public Form1(string arg)
        {
            InitializeComponent();
            
            this.Size = new Size(Properties.Settings.Default.TailleX, Properties.Settings.Default.TailleY);

            this.StartPosition = FormStartPosition.Manual;
            if(Properties.Settings.Default.PositionX > 0 && Properties.Settings.Default.PositionY > 0)
                this.Location = new Point(Properties.Settings.Default.PositionX, Properties.Settings.Default.PositionY);

            if (File.Exists(arg))
            {
                openfileName = arg;

                using (StreamReader Sr = File.OpenText(openfileName))
                { 
                    string Ligne;
                    while ((Ligne = Sr.ReadLine()) != null)
                    {
                        textBox1.Text = String.Empty;
                        textBox1.AppendText(Ligne + Environment.NewLine);
                    }


                    Sr.Dispose();
                    Sr.Close();
                }

                hasBeenSaved();

            } else
            {
                openfileName = "new file";
                hasBeenModified();
                lastModified = File.GetLastWriteTime(openfileName);
            }

            textBox1.ForeColor = Properties.Settings.Default.Couleur;
            textBox1.Font = Properties.Settings.Default.Police;
        }

        private void hasBeenSaved()
        {
            modified = false;
            this.Text = "Éditeur de fichier texte - " + Path.GetFileName(openfileName);
            lastModified = DateTime.Now;
        }

        private void hasBeenModified()
        {
            modified = true;
            this.Text = "Éditeur de fichier texte - " + Path.GetFileName(openfileName) + "*";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            hasBeenModified();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.ShowDialog(null);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            openfileName = openFileDialog1.FileName;

            using (StreamReader Sr = File.OpenText(openfileName))
            { // Equivalent à try, rien à voir avec le using au dessus
                string Ligne;
                while ((Ligne = Sr.ReadLine()) != null)
                {

                    // Affichons dans notre console, le contenue du fichier
                    textBox1.Text = String.Empty;
                    textBox1.AppendText(Ligne + Environment.NewLine);
                }


                Sr.Dispose();
                Sr.Close();
            }

            hasBeenSaved();
        }

        private void enregistrerSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = openfileName;
            saveFileDialog1.ShowDialog(null);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            openfileName = saveFileDialog1.FileName;

            if (!File.Exists(openfileName))
            {
                System.IO.FileStream fileCreated = File.Create(openfileName);
                fileCreated.Dispose();
                fileCreated.Close();
            }
            using (StreamWriter Sw = new StreamWriter(openfileName))
            {
                Sw.Write(textBox1.Text);

                Sw.Dispose();
                Sw.Close();
            }

            hasBeenSaved();
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Rectangle screenBounds = Screen.GetWorkingArea(this);

            if (screenBounds.Contains(this.Bounds))
            {
                Properties.Settings.Default.TailleX = this.Size.Width;
                Properties.Settings.Default.TailleY = this.Size.Height;
                Properties.Settings.Default.PositionX = this.Location.X;
                Properties.Settings.Default.PositionY = this.Location.Y;

            }
            else
            {
                int newX = Math.Max(screenBounds.Left, Math.Min(screenBounds.Right - this.Width, this.Left));
                int newY = Math.Max(screenBounds.Top, Math.Min(screenBounds.Bottom - this.Height, this.Top));

                Properties.Settings.Default.TailleX = this.Size.Width;
                Properties.Settings.Default.TailleY = this.Size.Height;
                Properties.Settings.Default.PositionX = newX;
                Properties.Settings.Default.PositionY = newY;
            }

            Properties.Settings.Default.Couleur = textBox1.ForeColor;
            Properties.Settings.Default.Police = textBox1.Font;

            Properties.Settings.Default.Save();

            if (modified)
            {
                var result = MessageBox.Show("Toutes modifications sera perdu", "Sauvegarder", MessageBoxButtons.YesNoCancel); ;
                if (result == DialogResult.Yes)
                {
                    using (StreamWriter Sw = new StreamWriter(openfileName))
                    {
                        Sw.Write(textBox1.Text);

                        Sw.Dispose();
                        Sw.Close();
                    }
                }
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Le contenu semble avoir été modifié", "Recharger", MessageBoxButtons.YesNo); ;
            if (result == DialogResult.Yes)
            {
                using (StreamReader Sr = File.OpenText(openfileName))
                { // Equivalent à try, rien à voir avec le using au dessus
                    string Ligne;
                    while ((Ligne = Sr.ReadLine()) != null)
                    {

                        // Affichons dans notre console, le contenue du fichier
                        textBox1.Text = String.Empty;
                        textBox1.AppendText(Ligne + Environment.NewLine);
                    }

                    Sr.Dispose();
                    Sr.Close();
                }
            }


        }

        private void changerLaCouleurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
                textBox1.ForeColor = colorDialog1.Color;
        }

        private void changerLaPoliceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Font = fontDialog1.Font;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            DateTime currentModified = File.GetLastWriteTime(openfileName);

            if (currentModified > lastModified) {
                var result = MessageBox.Show("Le contenu semble avoir été modifié", "Recharger", MessageBoxButtons.YesNo); ;
                if (result == DialogResult.Yes)
                {
                    using (StreamReader Sr = File.OpenText(openfileName))
                    { // Equivalent à try, rien à voir avec le using au dessus
                        string Ligne;
                        while ((Ligne = Sr.ReadLine()) != null)
                        {

                            // Affichons dans notre console, le contenue du fichier
                            textBox1.Text = String.Empty;
                            textBox1.AppendText(Ligne + Environment.NewLine);
                        }


                        Sr.Dispose();
                        Sr.Close();
                    }

                    hasBeenSaved();
                }
            } 
        }
    }
}
