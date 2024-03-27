using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Dansvotre TreeView(Partie gauche) vous ajouterez plusieurs éléments qui permettront de charger votre ListView(Partie
// droite) selon certains critères.
//  • Nœudsracines(Nœudsdepremierniveau) :
//  • Nœud«Touslesarticles »: Chargera la liste complète des articles dans le ListView.
//  • Nœud«Familles»:Chargerala liste des familles dans le ListView.
//  • Nœud«Marques»:Chargeralaliste des marques dans le ListView.
//  • Lenœud«Familles»devradisposer de la liste complète des familles » en tant que nœuds enfants, et chaque nœud enfant
//  « famille » devra disposer des « sous-familles ».
//  • Unclicsurunnœud«famille» chargera la liste des « sous-familles » dans le ListView.
//  • Unclic sur un nœud « sous-famille » chargera la liste des « articles » appartenant à cette sous-famille dans le
//  • Unclic sur un nœud « sous-famille » chargera la liste des « articles » appartenant à cette sous-famille dans le
//  ListView.
//  • Lenœud«Marques»devraavoirennœudsenfantslaliste complète des marques.
//  • Unclicsurunnœud«marque»chargeralaliste des « articles » appartenantà cette marque dans le ListView.
//  • Danschacundescas, vous devrez gérer le trie des données à l’écran (exclusivement dans l’objet « ListView
//  », n’utilisez pas
//  de requête) via un clic sur les entêtes de colonne.Cette option devra permettre de trier de manière ascendante et
//  descendante et je le répète : sans recharger les données.
namespace Hector
{
    public partial class FormMain : Form
    {


        public FormMain()
        {
            InitializeComponent();
            ChargerTreeView(TreeView);
        }

        /// <summary>
        /// Quand on appuie sur actualiser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChargerTreeView(TreeView);
            MessageBox.Show("Some text", "Some title",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport FormImport = new FormImport();
            FormImport.ShowDialog();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExport FormExport = new FormExport();
            FormExport.ShowDialog();
        }

        /// <summary>
        /// Methode qui permet de chager le TreeView
        /// </summary>
        /// <param name="treeView"></param>
        private static void ChargerTreeView(TreeView treeView)
        {
            //On vide le TreeView
            treeView.Nodes.Clear();

            //On ajoute les noeuds racines
            TreeNode NoeudTousLesArticles = new TreeNode("Tous les articles");
            TreeNode NoeudFamilles = new TreeNode("Familles");
            TreeNode NoeudMarques = new TreeNode("Marques");

            //On ajoute les noeuds racines au TreeView
            treeView.Nodes.Add(NoeudTousLesArticles);
            treeView.Nodes.Add(NoeudFamilles);
            treeView.Nodes.Add(NoeudMarques);

            //On ajoute les sous-familles
            foreach (Famille FamilleExistante in Famille.GetDictionnaireFamilles())
            {
                TreeNode NoeudFamille = new TreeNode(FamilleExistante.GetNom());
                NoeudFamilles.Nodes.Add(NoeudFamille);

                foreach (SousFamille SousFamilleExistante in SousFamille.GetListeSousFamilles())
                {
                    TreeNode NoeudSousFamille = new TreeNode(SousFamilleExistante.GetNom());
                    NoeudFamille.Nodes.Add(NoeudSousFamille);
                }
            }

            //On ajoute les marques
            foreach (Marque MarqueExistante in Marque.GetListeMarques())
            {
                TreeNode NoeudMarque = new TreeNode(MarqueExistante.GetNom());
                NoeudMarques.Nodes.Add(NoeudMarque);
            }
        }
    }
}
