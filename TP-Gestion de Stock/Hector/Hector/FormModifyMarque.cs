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
    public partial class FormModifyMarque : Form
    {
        private Marque MarqueSelectionnee;

        public FormModifyMarque(Marque MarqueParam)
        {
            InitializeComponent();

            NomMarqueTextBox.Text = MarqueSelectionnee.GetNom();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (MarqueSelectionnee.SetNom(NomMarqueTextBox.Text) == Exception.RETOUR_ERREUR)
            {
                return;
            }

            MessageBox.Show("Modifier avec succes", "Tout bon", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
