

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace Hector
{
    public partial class FormMain : Form
    {
        string TypeDonneesAffichees;

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

                default:
                    if (NoeudParent.Text == "Familles")
                    {
                        // Famille selectionnee
                        ChargerListViewArticlesPourUneFamille(TypeNoeudSelectionne);
                    }
                    else
                    {
                        if (NoeudParent.Text == "Marques")
                        {
                            // Marque selectionnee
                            ChargerListViewArticlesPourUneMarque(TypeNoeudSelectionne);
                        }
                        else
                        {
                            // SousFamille selectionnee
                            ChargerListViewArticlesPourUneSousFamille(TypeNoeudSelectionne);
                        }
                    }
                    break;

            }
        }

        /// <summary>
        /// Methode qui permet de charger le ListView avec les articles
        /// </summary>
        /// <param name="NomMarque"></param>
        private void ChargerListViewArticlesPourUneMarque(string NomMarque)
        {
            List<Article> ListeArticles = new List<Article>();

            foreach (Article ArticleExistant in Article.GetListeArticles())
            {
                if (ArticleExistant.GetMarque().GetNom() == NomMarque)
                {
                    ListeArticles.Add(ArticleExistant);
                }
            }

            ChargerListViewArticles(ListeArticles);
        }

        /// <summary>
        /// Methode qui permet de charger le ListView avec les articles
        /// </summary>
        /// <param name="NomFamille"></param>
        private void ChargerListViewArticlesPourUneFamille(string NomFamille)
        {
            List<Article> ListeArticles = new List<Article>();

            foreach (Article ArticleExistant in Article.GetListeArticles())
            {
                if (ArticleExistant.GetSousFamille().GetFamille().GetNom() == NomFamille)
                {
                    ListeArticles.Add(ArticleExistant);
                }
            }

            ChargerListViewArticles(ListeArticles);
        }

        /// <summary>
        /// Methode qui permet de charger le ListView avec les articles
        /// </summary>
        /// <param name="NomSousFamille"></param>
        private void ChargerListViewArticlesPourUneSousFamille(string NomSousFamille)
        {
            List<Article> ListeArticles = new List<Article>();

            foreach (Article ArticleExistant in Article.GetListeArticles())
            {
                if (ArticleExistant.GetSousFamille().GetNom() == NomSousFamille)
                {
                    ListeArticles.Add(ArticleExistant);
                }
            }

            ChargerListViewArticles(ListeArticles);
        }

        /// <summary>
        /// Methode qui permet de charger le ListView avec les articles
        /// </summary>
        /// <param name="ListViewParam"></param>
        /// <param name="ListeArticles"></param>
        private void ChargerListViewArticles(List<Article> ListeArticles)
        {
            //On vide le ListView
            ListView1.Columns.Clear();
            ListView1.Items.Clear();
            AjouterColonnesListViewArticles();

            //On ajoute les articles
            foreach (Article ArticleExistante in ListeArticles)
            {
                ListViewItem NouvelItem = new ListViewItem(ArticleExistante.GetReference());
                NouvelItem.SubItems.Add(ArticleExistante.GetDescription().ToString());
                NouvelItem.SubItems.Add(ArticleExistante.GetSousFamille().GetFamille().GetNom());
                NouvelItem.SubItems.Add(ArticleExistante.GetSousFamille().GetNom());
                NouvelItem.SubItems.Add(ArticleExistante.GetMarque().GetNom());
                ListView1.Items.Add(NouvelItem);
            }
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes pour la lecture des articles avec le ListView 
        /// <summary
        public void AjouterColonnesListViewArticles()
        {
            ListView1.ListViewItemSorter = null;
            TypeDonneesAffichees = "Articles";

            ListView1.Columns.Add("RefArticle", 60);
            ListView1.Columns.Add("Description", 200);
            ListView1.Columns.Add("Familles", 100);
            ListView1.Columns.Add("Sous-familles", 100);
            ListView1.Columns.Add("Marques", 90);
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes pour la lecture des familles avec le ListView
        /// <summary>
        public void AjouterColonnesListViewFamilles()
        { 
            ListView1.ListViewItemSorter = null;
            TypeDonneesAffichees = "Familles";

            ListView1.Columns.Add("Description", 150);
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes pour la lecture des marques avec le ListView
        /// <summary>
        public void AjouterColonnesListViewMarques()
        {
            ListView1.ListViewItemSorter = null;
            TypeDonneesAffichees = "Marques";

            ListView1.Columns.Add("Description", 150);
        }

        /// Methode qui permet de charger le ListView avec les familles
        /// </summary>
        /// <param name="ListViewParam"></param>
        /// <param name="ListeFamilles"></param>
        private void ChargerListViewFamilles(List<Famille> ListeFamilles)
        {
            //On vide le ListView
            ListView1.Columns.Clear();
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
            ListView1.Columns.Clear();
            ListView1.Items.Clear();
            AjouterColonnesListViewMarques();

            //On ajoute les marques
            foreach (Marque MarqueExistante in ListeMarques)
            {
                ListViewItem NouvelItem = new ListViewItem(MarqueExistante.GetNom());
                ListView1.Items.Add(NouvelItem);
            }
        }


        private void ListView1_ItemActivate(object sender, EventArgs e)
        {
            if (ListView1.SelectedItems.Count == 1)
            {
                ListViewItem Item = ListView1.SelectedItems[0];

                if (TypeDonneesAffichees == "Familles")
                {
                    ChargerListViewArticlesPourUneFamille(Item.SubItems[0].Text);
                    
                } else
                {
                    if (TypeDonneesAffichees == "Marques")
                    {
                        ChargerListViewArticlesPourUneMarque(Item.SubItems[0].Text);
                    }
                }
            }
        }

        private void articleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddArticle NouveauFormAddArticle = new FormAddArticle();
            NouveauFormAddArticle.ShowDialog();
        }

        private void familleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddFamille NouveauFormAddFamille = new FormAddFamille();
            NouveauFormAddFamille.ShowDialog();
        }

        private void sousFamilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddSousFamille NouveauFormAddSousFamille = new FormAddSousFamille();
            NouveauFormAddSousFamille.ShowDialog();
        }

        private void marqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddMarque NouveauFormAddMarque = new FormAddMarque();
            NouveauFormAddMarque.ShowDialog();
        }

        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs Event)
        {
            ListView1.ListViewItemSorter = new ListViewItemComparer(Event.Column);

            if (TypeDonneesAffichees == "Articles") { 
                ListView1.Groups.Clear();

                string NomColonne = ListView1.Columns[Event.Column].Text;

                if (NomColonne == "Familles")
                {
                    Dictionary<string, int> IndicesGroupe = new Dictionary<string, int>();

                    foreach (Famille FamilleExistante in Famille.GetDictionnaireFamilles())
                    {
                        int IdFamille = ListView1.Groups.Add(new ListViewGroup(FamilleExistante.GetNom(), HorizontalAlignment.Left));
                        IndicesGroupe.Add(FamilleExistante.GetNom(), IdFamille);
                    }

                    foreach (ListViewItem Ligne in ListView1.Items)
                    {
                        Console.WriteLine(Ligne.SubItems[3].Text);
                        Ligne.Group = ListView1.Groups[IndicesGroupe[Ligne.SubItems[2].Text]];
                    }
                }

                if (NomColonne == "Sous-familles")
                {
                    Dictionary<string, int> IndicesGroupe = new Dictionary<string, int>();

                    foreach (SousFamille SousFamilleExistante in SousFamille.GetDictionnaireSousFamilles())
                    {
                        int IdFamille = ListView1.Groups.Add(new ListViewGroup(SousFamilleExistante.GetNom(), HorizontalAlignment.Left));
                        IndicesGroupe.Add(SousFamilleExistante.GetNom(), IdFamille);
                    }

                    foreach (ListViewItem Ligne in ListView1.Items)
                    {
                        Ligne.Group = ListView1.Groups[IndicesGroupe[Ligne.SubItems[3].Text]];
                    }
                }

                if (NomColonne == "Marques")
                {
                    Dictionary<string, int> IndicesGroupe = new Dictionary<string, int>();

                    foreach (Marque MarqueExistante in Marque.GetDictionnaireMarques())
                    {
                        int IdFamille = ListView1.Groups.Add(new ListViewGroup(MarqueExistante.GetNom(), HorizontalAlignment.Left));
                        IndicesGroupe.Add(MarqueExistante.GetNom(), IdFamille);
                    }

                    foreach (ListViewItem Ligne in ListView1.Items)
                    {
                        Ligne.Group = ListView1.Groups[IndicesGroupe[Ligne.SubItems[4].Text]];
                    }
                }
            }
        }

        class ListViewItemComparer : IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs Event)
        {
            if (Event.Button == MouseButtons.Right)
            {
                var focusedItem = ListView1.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(Event.Location))
                {
                    // TODO
                }
            }
        }

        // /// <summary>
        // /// Permets de supprimer un élément ( article, famille, sous-famille ou marque ).
        // /// </summary>
        // private void ListView1_KeyDown(object sender, KeyEventArgs e)
        // {
        //     if (e.KeyCode == Keys.F5)
        //     {
        //         ImporterDonneesFichierSQLite();
        //         ChargerTreeView();
        //         DialogResult Resultat = MessageBox.Show("Voulez-vous vraiment supprimer cette marque ?", "Confirmation suppression marque", MessageBoxButtons.YesNo);

        //     }
        //     else
        //     {
        //         if (e.KeyCode == Keys.Delete)
        //         {
        //             DialogResult Resultat = MessageBox.Show("Voulez-vous vraiment supprimer cette marque ?", "Confirmation suppression marque", MessageBoxButtons.YesNo)
        //             SupprimerElement();
        //         }
            
        //     }
        // }
        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {
           // Utiliser KeyPreview pour que le formulaire recoive les touches

            if (e.KeyChar == (char)Keys.F5)
            {
                ImporterDonneesFichierSQLite();
                ChargerTreeView();
            }
            if (e.KeyChar == (char)Keys.Delete)
            {
                SupprimerElement();
            }
        }

        /// <summary>
        /// Permets de supprimer un élément ( article, famille, sous-famille ou marque ).
        /// </summary>
        public void SupprimerElement()
        {
            if (ListView1.SelectedItems.Count == 1)
            {
                ListViewItem Item = ListView1.SelectedItems[0];

                if (TypeDonneesAffichees == "Articles")
                {
                    SupprimerArticle(Item);
                }
                else
                {
                    if (TypeDonneesAffichees == "Familles")
                    {

                        SupprimerFamille(Item);
                    }
                    else
                    {
                        if (TypeDonneesAffichees == "Marques")
                        {
                            SupprimerMarque(Item);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Permets de supprimer un article.
        /// </summary>
        /// <param name="Item"></param>
        public void SupprimerArticle(ListViewItem Item)
        {
            DialogResult Resultat = MessageBox.Show("Voulez-vous vraiment supprimer cet article ?", "Confirmation suppression article", MessageBoxButtons.YesNo);

            if (Resultat == DialogResult.Yes)
            {
                Article ArticleASupprimer = Article.GetListeArticles().Find(Article => Article.GetReference() == Item.Text);
                string ReferenceArticle = ArticleASupprimer.GetReference();
                Article.SupprimerArticle(ReferenceArticle);
                ChargerTreeView();
            }
        }


        /// <summary>
        /// Permets de supprimer une famille.
        /// </summary>
        /// <param name="Item"></param>
        public void SupprimerFamille(ListViewItem Item)
        {

            DialogResult Resultat = MessageBox.Show("Voulez-vous vraiment supprimer cette famille ?", "Confirmation suppression famille", MessageBoxButtons.YesNo);

            if (Resultat == DialogResult.Yes)
            {
                Famille FamilleASupprimer = Famille.GetDictionnaireFamilles().Find(Famille => Famille.GetNom() == Item.SubItems[1].Text);
                int ReferenceFamille = FamilleASupprimer.GetRefFamille();
                //on verifie si la  famille a une sous famille

                if (Famille.GetDictionnaireFamilles().Exists(Famille => Famille.GetRefFamille() == FamilleASupprimer.GetRefFamille()) == true)
                {
                    MessageBox.Show("Vous ne pouvez pas supprimer cette famille car des articles appartiennent à cette famille.", "Erreur : famille utilisé par un / des article(s).", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Famille.SupprimerFamille(ReferenceFamille);
                    ChargerTreeView();
                }
            }
        }

            /// <summary>
            /// Permets de supprimer une marque.
            /// </summary>
            /// <param name="Item"></param>
            public void SupprimerMarque(ListViewItem Item)
            {
                DialogResult Resultat = MessageBox.Show("Voulez-vous vraiment supprimer cette marque ?", "Confirmation suppression marque", MessageBoxButtons.YesNo);

                // if (Resultat == DialogResult.Yes)
                // {
                //     Marque MarqueASupprimer = Marque.GetDictionnaireMarques().Find(Marque => Marque.GetNom() == Item.SubItems[1].Text);
                //     MarqueASupprimer.Supprimer();
                //     ChargerTreeView();
                // }

            }

    
    }
    }




