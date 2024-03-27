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
            ImporterDonneesFichierSQLite();
            ChargerTreeView();
        }

        public void ImporterDonneesFichierSQLite()
        {
            BaseDeDonnees BDD = BaseDeDonnees.GetInstance();

            BDD.LireMarquesBdd();
            BDD.LireFamillesBdd();
            BDD.LireSousFamillesBdd();
            BDD.LireArticlesBdd();
        }

        /// <summary>
        /// Quand on appuie sur actualiser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ImporterDonneesFichierSQLite();
            ChargerTreeView();
        }

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

        private void ChargerTreeView()
        {
            //TreeviewParam est le TreeView que l'on veut charger

 
            TreeViewParam.Nodes.Clear();
            //On ajoute les noeuds racines
            TreeNode NoeudTousLesArticles = new TreeNode("Tous les articles");
            TreeNode NoeudFamilles = new TreeNode("Familles");
            TreeNode NoeudMarques = new TreeNode("Marques");

            //On ajoute les noeuds racines au TreeView
            TreeViewParam.Nodes.Add(NoeudTousLesArticles);
            TreeViewParam.Nodes.Add(NoeudFamilles);
            TreeViewParam.Nodes.Add(NoeudMarques);

            //On ajoute les sous-familles
            foreach (Famille FamilleExistante in Famille.GetDictionnaireFamilles())
            {
                TreeNode NoeudFamille = new TreeNode(FamilleExistante.GetNom());
                NoeudFamilles.Nodes.Add(NoeudFamille);

                foreach (SousFamille SousFamilleExistante in SousFamille.GetDictionnaireSousFamilles())
                {
                    TreeNode NoeudSousFamille = new TreeNode(SousFamilleExistante.GetNom());
                    NoeudFamille.Nodes.Add(NoeudSousFamille);
                }
            }

            //On ajoute les marques
            foreach (Marque MarqueExistante in Marque.GetDictionnaireMarques())
            {
                TreeNode NoeudMarque = new TreeNode(MarqueExistante.GetNom());
                NoeudMarques.Nodes.Add(NoeudMarque);
            }
        }

        private void TreeViewParam_AfterSelect(object sender, TreeViewEventArgs e)
        { 
            //On recupere le type de noeud selectionné
            string TypeNoeudSelectionne = e.Node.Text;
            MessageBox.Show(TypeNoeudSelectionne);
            ListViewParam.Items.Clear();

            switch (TypeNoeudSelectionne)
            {
                case "Tous les articles":
               
                    ChargerListViewArticles(ListViewParam, Article.GetListeArticles());
                    break;

                case "Familles":
                    ChargerListViewFamilles(ListViewParam, Famille.GetDictionnaireFamilles());
                    break;

                case "Marques":
                    ChargerListViewMarques(ListViewParam, Marque.GetDictionnaireMarques());
                    break;

                default:
                    ChargerListViewSousFamilles(ListViewParam, SousFamille.GetDictionnaireSousFamilles());
                    break;
            }
        }

        /// <summary>
        /// Methode qui permet de charger le ListView avec les articles
        /// </summary>
        /// <param name="ListViewParam"></param>
        /// <param name="ListeArticles"></param>
        private void ChargerListViewArticles(ListView ListViewParam, List<Article> ListeArticles)
        {
            //On vide le ListView
            ListViewParam.Items.Clear();
            AjouterColonnesListViewArticles();

            //On ajoute les articles
            foreach (Article ArticleExistante in ListeArticles)
            {
                ListViewItem NouvelItem = new ListViewItem(ArticleExistante.GetDescription());
                NouvelItem.SubItems.Add(ArticleExistante.GetPrixHT().ToString());
                NouvelItem.SubItems.Add(ArticleExistante.GetQuantite().ToString());
                NouvelItem.SubItems.Add(ArticleExistante.GetSousFamille().GetFamille().GetNom());
                NouvelItem.SubItems.Add(ArticleExistante.GetSousFamille().GetNom());
                NouvelItem.SubItems.Add(ArticleExistante.GetMarque().GetNom());
                ListViewParam.Items.Add(NouvelItem);
            }
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes pour la lecture des articles avec le ListView 
        /// <summary>
        
        public void AjouterColonnesListViewArticles()
        {
            ListViewParam.Columns.Add("Référence", 100);
            ListViewParam.Columns.Add("Description", 100);
            ListViewParam.Columns.Add("Famille", 100);
            ListViewParam.Columns.Add("Sous-famille", 100);
            ListViewParam.Columns.Add("Marque", 100);
            ListViewParam.Columns.Add("Quantité", 100);
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes pour la lecture des familles avec le ListView
        /// <summary>
        public void AjouterColonnesListViewFamilles()
        {
            ListViewParam.Columns.Add("Référence", 100);
            ListViewParam.Columns.Add("Nom", 100);
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes pour la lecture des marques avec le ListView
        /// <summary>
        
        public void AjouterColonnesListViewMarques()
        {
            ListViewParam.Columns.Add("Référence", 100);
            ListViewParam.Columns.Add("Nom", 100);
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes pour la lecture des sous-familles avec le ListView
        /// <summary>
        
        public void AjouterColonnesListViewSousFamilles()
        {
            ListViewParam.Columns.Add("Référence", 100);
            ListViewParam.Columns.Add("Nom", 100);
        }

        /// Methode qui permet de charger le ListView avec les familles
        /// </summary>
        /// <param name="ListViewParam"></param>
        /// <param name="ListeFamilles"></param>
        private void ChargerListViewFamilles(ListView ListViewParam, List<Famille> ListeFamilles)
        {
            //On vide le ListView
            ListViewParam.Items.Clear();
            AjouterColonnesListViewFamilles();

            //On ajoute les familles
            foreach (Famille FamilleExistante in ListeFamilles)
            {
                ListViewItem NouvelItem = new ListViewItem(FamilleExistante.GetNom());
                ListViewParam.Items.Add(NouvelItem);
            }
        }
        /// <summary>
        /// Methode qui permet de charger le ListView avec les marques
        /// </summary>
        /// <param name="ListViewParam"></param>
        /// <param name="ListeMarques"></param>

        private void ChargerListViewMarques(ListView ListViewParam, List<Marque> ListeMarques)
        {
            //On vide le ListView
            ListViewParam.Items.Clear();
            AjouterColonnesListViewMarques();

            //On ajoute les marques
            foreach (Marque MarqueExistante in ListeMarques)
            {
                ListViewItem NouvelItem = new ListViewItem(MarqueExistante.GetNom());
                ListViewParam.Items.Add(NouvelItem);
            }
        }


        /// <summary>
        /// Methode qui permet de charger le ListView avec les sous-familles
        /// </summary>
        /// <param name="ListViewParam"></param>
        /// <param name="ListeSousFamilles"></param>

        private void ChargerListViewSousFamilles(ListView ListViewParam, List<SousFamille> ListeSousFamilles)
        {
            //On vide le ListView
            ListViewParam.Items.Clear();
            AjouterColonnesListViewSousFamilles();

            //On ajoute les sous-familles
            foreach (SousFamille SousFamilleExistante in ListeSousFamilles)
            {
                ListViewItem NouvelItem = new ListViewItem(SousFamilleExistante.GetNom());
                NouvelItem.SubItems.Add(SousFamilleExistante.GetFamille().GetNom());
                ListViewParam.Items.Add(NouvelItem);
            }
        }

    }
}




