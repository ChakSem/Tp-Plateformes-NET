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

 
            TreeView1.Nodes.Clear();
            //On ajoute les noeuds racines
            TreeNode NoeudTousLesArticles = new TreeNode("Tous les articles");
            TreeNode NoeudFamilles = new TreeNode("Familles");
            TreeNode NoeudMarques = new TreeNode("Marques");

            //On ajoute les noeuds racines au TreeView
            TreeView1.Nodes.Add(NoeudTousLesArticles);
            TreeView1.Nodes.Add(NoeudFamilles);
            TreeView1.Nodes.Add(NoeudMarques);

            //On ajoute les sous-familles
            foreach (Famille FamilleExistante in Famille.GetDictionnaireFamilles())
            {
                TreeNode NoeudFamille = new TreeNode(FamilleExistante.GetNom());
                NoeudFamilles.Nodes.Add(NoeudFamille);

                foreach (SousFamille SousFamilleExistante in SousFamille.GetDictionnaireSousFamilles())
                {
                    if (SousFamilleExistante.GetFamille().GetNom() == FamilleExistante.GetNom())
                    {
                        TreeNode NoeudSousFamille = new TreeNode(SousFamilleExistante.GetNom());
                        NoeudFamille.Nodes.Add(NoeudSousFamille);
                    }
                }
            }

            //On ajoute les marques
            foreach (Marque MarqueExistante in Marque.GetDictionnaireMarques())
            {
                TreeNode NoeudMarque = new TreeNode(MarqueExistante.GetNom());
                NoeudMarques.Nodes.Add(NoeudMarque);
            }
        }

        private void TreeViewParam_AfterSelect(object sender, TreeViewEventArgs Event)
        { 
            //On recupere le type de noeud selectionné
            string TypeNoeudSelectionne = Event.Node.Text;
            
            ListView1.Items.Clear();

            TreeNode NoeudParent = Event.Node.Parent;

            switch (TypeNoeudSelectionne)
            {
                case "Tous les articles":
               
                    ChargerListViewArticles(Article.GetListeArticles());
                    break;

                case "Familles":
                    ChargerListViewFamilles(Famille.GetDictionnaireFamilles());
                    break;

                case "Marques":
                    ChargerListViewMarques(Marque.GetDictionnaireMarques());
                    break;

                default :
                    if (NoeudParent.Text == "Familles")
                    {
                        // Famille selectionnee
                        List<Article> ListeArticles = new List<Article>();

                        foreach(Article ArticleExistant in Article.GetListeArticles())
                        {
                            if(ArticleExistant.GetSousFamille().GetFamille().GetNom() == TypeNoeudSelectionne)
                            {
                                ListeArticles.Add(ArticleExistant);
                            }
                        }

                        ChargerListViewArticles(ListeArticles);
                    }
                    else
                    {
                        if (NoeudParent.Text == "Marques")
                        {
                            // Marque selectionnee
                            List<Article> ListeArticles = new List<Article>();

                            foreach (Article ArticleExistant in Article.GetListeArticles())
                            {
                                if (ArticleExistant.GetMarque().GetNom() == TypeNoeudSelectionne)
                                {
                                    ListeArticles.Add(ArticleExistant);
                                }
                            }

                            ChargerListViewArticles(ListeArticles);
                        }
                        else
                        {
                            // SousFamille selectionnee
                            List<Article> ListeArticles = new List<Article>();

                            foreach (Article ArticleExistant in Article.GetListeArticles())
                            {
                                if (ArticleExistant.GetSousFamille().GetNom() == TypeNoeudSelectionne)
                                {
                                    ListeArticles.Add(ArticleExistant);
                                }
                            }

                            ChargerListViewArticles(ListeArticles);
                        }
                    }
                    break;

            }
        }

        /// <summary>
        /// Methode qui permet de charger le ListView avec les articles
        /// </summary>
        /// <param name="ListViewParam"></param>
        /// <param name="ListeArticles"></param>
        private void ChargerListViewArticles(List<Article> ListeArticles)
        {
            //On vide le ListView
            ListView1.Items.Clear();
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
                ListView1.Items.Add(NouvelItem);
            }
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes pour la lecture des articles avec le ListView 
        /// <summary>
        
        public void AjouterColonnesListViewArticles()
        {
            ListView1.Columns.Add("Référence", 100);
            ListView1.Columns.Add("Description", 100);
            ListView1.Columns.Add("Famille", 100);
            ListView1.Columns.Add("Sous-famille", 100);
            ListView1.Columns.Add("Marque", 100);
            ListView1.Columns.Add("Quantité", 100);
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes pour la lecture des familles avec le ListView
        /// <summary>
        public void AjouterColonnesListViewFamilles()
        {
            ListView1.Columns.Add("Référence", 100);
            ListView1.Columns.Add("Nom", 100);
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes pour la lecture des marques avec le ListView
        /// <summary>
        
        public void AjouterColonnesListViewMarques()
        {
            ListView1.Columns.Add("Référence", 100);
            ListView1.Columns.Add("Nom", 100);
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes pour la lecture des sous-familles avec le ListView
        /// <summary>
        
        public void AjouterColonnesListViewSousFamilles()
        {
            ListView1.Columns.Add("Référence", 100);
            ListView1.Columns.Add("Nom", 100);
        }

        /// Methode qui permet de charger le ListView avec les familles
        /// </summary>
        /// <param name="ListViewParam"></param>
        /// <param name="ListeFamilles"></param>
        private void ChargerListViewFamilles(List<Famille> ListeFamilles)
        {
            //On vide le ListView
            ListView1.Items.Clear();
            AjouterColonnesListViewFamilles();

            //On ajoute les familles
            foreach (Famille FamilleExistante in ListeFamilles)
            {
                ListViewItem NouvelItem = new ListViewItem(FamilleExistante.GetNom());
                ListView1.Items.Add(NouvelItem);
            }
        }
        /// <summary>
        /// Methode qui permet de charger le ListView avec les marques
        /// </summary>
        /// <param name="ListViewParam"></param>
        /// <param name="ListeMarques"></param>

        private void ChargerListViewMarques(List<Marque> ListeMarques)
        {
            //On vide le ListView
            ListView1.Items.Clear();
            AjouterColonnesListViewMarques();

            //On ajoute les marques
            foreach (Marque MarqueExistante in ListeMarques)
            {
                ListViewItem NouvelItem = new ListViewItem(MarqueExistante.GetNom());
                ListView1.Items.Add(NouvelItem);
            }
        }


        /// <summary>
        /// Methode qui permet de charger le ListView avec les sous-familles
        /// </summary>
        /// <param name="ListViewParam"></param>
        /// <param name="ListeSousFamilles"></param>

        private void ChargerListViewSousFamilles(List<SousFamille> ListeSousFamilles)
        {
            //On vide le ListView
            ListView1.Items.Clear();
            AjouterColonnesListViewSousFamilles();

            //On ajoute les sous-familles
            foreach (SousFamille SousFamilleExistante in ListeSousFamilles)
            {
                ListViewItem NouvelItem = new ListViewItem(SousFamilleExistante.GetNom());
                NouvelItem.SubItems.Add(SousFamilleExistante.GetFamille().GetNom());
                ListView1.Items.Add(NouvelItem);
            }
        }

    }
}




