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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Some text", "Some title",
    MessageBoxButtons.OK, MessageBoxIcon.Error);

            //FormArticle formArticle = new FormArticle();
            //formArticle.ShowDialog();
        }

        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport FormImport = new FormImport();
            FormImport.ShowDialog();
        }

        private void exporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExport FormExport = new FormExport();
            FormExport.ShowDialog();
        }
    }
}
