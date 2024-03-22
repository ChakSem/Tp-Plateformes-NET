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
    public partial class FormAddMarque : Form
    {
        public FormAddMarque()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {

            if (RefArticlesTextBox.Text == "")
            {
                MessageBox.Show("Le champ Référence est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Marque.CreateMarque(RefArticlesTextBox.Text);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
