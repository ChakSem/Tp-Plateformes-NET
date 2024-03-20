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
            //FormArticle formArticle = new FormArticle();
            //formArticle.ShowDialog();
        }

        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FormImport formImport = new FormImport();
           formImport.ShowDialog();

           

        }

        private void exporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // FormExport formExport = new FormExport();
            //formExport.ShowDialog();

        }
    }
}
