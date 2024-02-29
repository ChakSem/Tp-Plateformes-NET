using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
        
            while (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //tant que on a pas fini de lire le fichier tout le fichier 
                while(openFileDialog1.OpenFile() != null)
                {
                    //on lit le fichier
                    string file = openFileDialog1.FileName;
                    //on lite ligne par ligne
                    string[] lines = File.ReadAllLines(file);
                    //on affiche le contenu du fichier
                    foreach (string line in lines)
                    {
                        textBox1.Text = line;
                    }

                }
            }

        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        
        }
    }
}
