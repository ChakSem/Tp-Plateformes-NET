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
        TreeNode NoeudSelectionne;

        string Filtre;



        string TypeFiltre;

        /// <summary>
        /// Constructeur de la classe FormMain
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            ImporterDonneesFichierSQLite();

            NoeudSelectionne = null;
            ChargerTreeView();
            Actualiser(false);
            this.KeyPreview = true;

        }

        /// <summary>
        /// Permet de mettre à jour les données depuis les données déjà présente dans le fichier .sqlite
        /// </summary>
        public void ImporterDonneesFichierSQLite()
        {
            BaseDeDonnees BDD = BaseDeDonnees.GetInstance();

            BDD.LireMarquesBdd();
            BDD.LireFamillesBdd();
            BDD.LireSousFamillesBdd();
            BDD.LireArticlesBdd();
        }

        /// <summary>
        /// Methode qui permet de chager le TreeView
        /// </summary>
        private void ChargerTreeView()
        {
            TreeView1.Nodes.Clear();

            // On crée les noeuds racines
            TreeNode NoeudTousLesArticles = new TreeNode("Tous les articles");
            TreeNode NoeudFamilles = new TreeNode("Familles");
            TreeNode NoeudMarques = new TreeNode("Marques");

            // On ajoute les noeuds racines au TreeView
            TreeView1.Nodes.Add(NoeudTousLesArticles);
            TreeView1.Nodes.Add(NoeudFamilles);
            TreeView1.Nodes.Add(NoeudMarques);

            // On ajoute les noeuds familles
            foreach (Famille FamilleExistante in Famille.GetListeFamilles())
            {
                TreeNode NoeudFamille = new TreeNode(FamilleExistante.GetNom());
                NoeudFamilles.Nodes.Add(NoeudFamille);

                // On ajoute les noeuds sous-familles
                foreach (SousFamille SousFamilleExistante in SousFamille.GetListeSousFamilles())
                {
                    if (SousFamilleExistante.GetFamille().GetNom() == FamilleExistante.GetNom())
                    {
                        TreeNode NoeudSousFamille = new TreeNode(SousFamilleExistante.GetNom());
                        NoeudFamille.Nodes.Add(NoeudSousFamille);
                    }
                }
            }

            // On ajoute les noeuds marques
            foreach (Marque MarqueExistante in Marque.GetListeMarques())
            {
                TreeNode NoeudMarque = new TreeNode(MarqueExistante.GetNom());
                NoeudMarques.Nodes.Add(NoeudMarque);
            }
        }

        /// <summary>
        /// Evenement lorsque qu'un noeud du treeview est cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Event"></param>
        private void TreeViewParam_AfterSelect(object sender, TreeViewEventArgs Event)
        {
            // On récupere le type de noeud selectionné
            NoeudSelectionne = Event.Node;
            string TypeNoeudSelectionne = NoeudSelectionne.Text;
            TreeNode NoeudParent = NoeudSelectionne.Parent;

            switch (TypeNoeudSelectionne)
            {
                case "Tous les articles":
                    // On réinitalise les filtres
                    Filtre = "";
                    TypeFiltre = "";

                    ListView1.Columns.Clear();
                    ChargerListViewArticles(Article.GetListeArticles());

                    break;

                case "Familles":
                    // On réinitalise les filtres
                    Filtre = "";
                    TypeFiltre = "";

                    ListView1.Columns.Clear();
                    ChargerListViewFamilles(Famille.GetListeFamilles());

                    break;

                case "Marques":
                    // On réinitalise les filtres
                    Filtre = "";
                    TypeFiltre = "";

                    ListView1.Columns.Clear();
                    ChargerListViewMarques(Marque.GetListeMarques());

                    break;

                default:
                    ListView1.Columns.Clear();
                    if (NoeudParent.Text == "Familles")
                    {
                        // On fixe les filtres sur la Famille cliquée
                        Filtre = NoeudSelectionne.Text;
                        TypeFiltre = "Famille";

                        // Famille selectionnee
                        ChargerListSousFamilles();
                    }
                    else
                    {
                        ListView1.Columns.Clear();
                        if (NoeudParent.Text == "Marques")
                        {
                            // On fixe les filtres sur la Marque cliquée
                            Filtre = NoeudSelectionne.Text;
                            TypeFiltre = "Marque";

                            // Marque selectionnee
                            ChargerListViewArticlesPourUneMarque();
                        }
                        else
                        {
                            // On fixe les filtres sur la Sous-Famille cliquée
                            Filtre = NoeudSelectionne.Text;
                            TypeFiltre = "SousFamille";

                            // SousFamille selectionnee
                            ChargerListViewArticlesPourUneSousFamille();
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Methode qui permet de charger des articles dans le ListView, pour la SousFamille dont le Nom est stockée dans Filtre
        /// </summary>
        private void ChargerListViewArticlesPourUneSousFamille()
        {
            List<Article> ListeArticles = new List<Article>();

            foreach (Article ArticleExistant in Article.GetListeArticles())
            {
                // On récupère les Articles appartenant 
                if (ArticleExistant.GetSousFamille().GetNom() == Filtre)
                {
                    ListeArticles.Add(ArticleExistant);
                }
            }

            ChargerListViewArticles(ListeArticles);
        }

        /// <summary>
        /// Methode qui permet de charger des articles dans le ListView, pour la Famille dont le Nom est stockée dans Filtre
        /// </summary>
        private void ChargerListViewArticlesPourUneFamille()
        {
            List<Article> ListeArticles = new List<Article>();

            foreach (Article ArticleExistant in Article.GetListeArticles())
            {
                if (ArticleExistant.GetSousFamille().GetFamille().GetNom() == Filtre)
                {
                    ListeArticles.Add(ArticleExistant);
                }
            }

            ChargerListViewArticles(ListeArticles);
        }


        /// <summary>
        /// Methode qui permet de charger des articles dans le ListView, pour la Marque dont le Nom est stockée dans Filtre
        /// </summary>
        private void ChargerListViewArticlesPourUneMarque()
        {
            List<Article> ListeArticles = new List<Article>();

            foreach (Article ArticleExistant in Article.GetListeArticles())
            {
                if (ArticleExistant.GetMarque().GetNom() == Filtre)
                {
                    ListeArticles.Add(ArticleExistant);
                }
            }

            ChargerListViewArticles(ListeArticles);
        }

        /// <summary>
        /// Methode qui permet de charger des sous-familles dans le ListView, pour la Famille dont le Nom est stockée dans Filtre
        /// </summary>
        private void ChargerListSousFamilles()
        {
            //On vide le ListView
            ListView1.Columns.Clear();
            ListView1.Items.Clear();
            AjouterColonnesListViewSousFamilles();

            List<SousFamille> ListeSousFamilles = SousFamille.GetListeSousFamilles();

            foreach (SousFamille SousFamilleExistante in ListeSousFamilles)
            {
                if (SousFamilleExistante.GetFamille().GetNom() == Filtre)
                {
                    ListViewItem NouvelItem = new ListViewItem(SousFamilleExistante.GetNom());
                    ListView1.Items.Add(NouvelItem);
                }
            }
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes à l'affichage d'articles
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
        /// Methode qui permet d'ajouter les colonnes correspondantes à l'affichage de sous-familles
        /// <summary>
        public void AjouterColonnesListViewSousFamilles()
        {
            ListView1.ListViewItemSorter = null;
            TypeDonneesAffichees = "SousFamilles";

            ListView1.Columns.Add("Description", 150);
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes à l'affichage de familles
        /// <summary>
        public void AjouterColonnesListViewFamilles()
        {
            ListView1.ListViewItemSorter = null;
            TypeDonneesAffichees = "Familles";

            ListView1.Columns.Add("Description", 150);
        }


        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes à l'affichage de marques
        /// <summary>
        public void AjouterColonnesListViewMarques()
        {
            ListView1.ListViewItemSorter = null;
            TypeDonneesAffichees = "Marques";

            ListView1.Columns.Add("Description", 150);
        }

        /// <summary>
        /// Methode qui permet de charger les articles passés en paramètre
        /// </summary>
        /// <param name="ListeArticles"></param>
        private void ChargerListViewArticles(List<Article> ListeArticles)
        {
            // On vide le ListView
            ListView1.Columns.Clear();
            ListView1.Items.Clear();

            // On met à jour les colonnes
            AjouterColonnesListViewArticles();

            // On ajoute les articles un par un
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
        /// Methode qui permet de charger les familles passées en paramètre
        /// </summary>
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
        /// Methode qui permet de charger les marques passées en paramètre
        /// </summary>
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

        /// <summary>
        /// Appelée lorsqu'un objet du list view est cliqué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView1_ItemActivate(object sender, EventArgs e)
        {
            if (ListView1.SelectedItems.Count == 1) // On vérifie qu'un seul élement est selectionné
            {
                ListViewItem Item = ListView1.SelectedItems[0];

                Filtre = Item.SubItems[0].Text;
                if (TypeDonneesAffichees == "SousFamilles")
                {
                    TypeFiltre = "SousFamille";
                    ChargerListViewArticlesPourUneSousFamille(); // On affiche les articles correspondant à la sous-famille selectionnée
                }
                if (TypeDonneesAffichees == "Familles")
                {
                    TypeFiltre = "Famille";
                    ChargerListViewArticlesPourUneFamille(); // On affiche les articles correspondant à la famille selectionnée
                }
                if (TypeDonneesAffichees == "Marques")
                {
                    TypeFiltre = "Marque";
                    ChargerListViewArticlesPourUneMarque(); // On affiche les articles correspondant à la marque selectionnée
                }
            }
        }

        /// <summary>
        /// Permets de trier la liste view en groupes selon la première lettre de la description de l'article.
        /// </summary>
        public void CreerGroupesPourUneDescription(int IndiceColonne)
        {
            // Nettoyer les groupes existants
            ListView1.Groups.Clear();

            // Dictionnaire pour stocker les groupes
            Dictionary<char, int> IndicesGroupe = new Dictionary<char, int>();

            // Créer les groupes pour chaque lettre de l'alphabet
            ListViewGroup Groupe;
            for (char Lettre = 'A'; Lettre <= 'Z'; Lettre++)
            {
                // On crée le groupe correspondant à la lettre.
                Groupe = new ListViewGroup(Convert.ToString(Lettre).ToUpper(), HorizontalAlignment.Left);
                int IdLettre = ListView1.Groups.Add(Groupe);
                IndicesGroupe.Add(Lettre, IdLettre);
            }

            foreach (ListViewItem Ligne in ListView1.Items)
            {
                char PremiereLettre = ExtractionPremierCaractere(Ligne.SubItems[IndiceColonne].Text);
                Ligne.Group = ListView1.Groups[IndicesGroupe[PremiereLettre]];
            }
        }

        /// <summary>
        /// Permets d'obtenir la première alphabétique d'un string.
        /// </summary>
        /// <param name="Chaine"> Chaine de caractère où l'on veut chercher la première lettre alphabétique. </param>
        /// <returns> char, la première lettre de la chaine de caractère. </returns>
        public char ExtractionPremierCaractere(string Chaine)
        {
            try
            {
                if (string.IsNullOrEmpty(Chaine))
                {
                    throw new Exception(Exception.ERREUR_CHAINE_VIDE);
                }
                else
                {
                    foreach (char Caractere in Chaine)
                    {
                        // Vérifier si le caractère est une lettre et que ce n'est pas le x de "6x Marqueurs - Velleda - 1781bis"
                        if (char.IsLetter(Caractere) && Convert.ToString(Caractere) != "x" || Convert.ToString(Caractere) == "x" || Convert.ToString(Caractere) == "X")
                        {
                            char PremierCaractere = char.ToUpper(Caractere);
                            return PremierCaractere;
                        }
                    }
                }
            }
            catch (Exception Exception)
            {
                Exception.AfficherMessageErreur();
            }
            return ' ';
        }

        /// <summary>
        /// Evenement lors du clique sur une colonne du tree view, pour le tri et les groupe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Event"></param>
        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs Event)
        {
            ListView1.ListViewItemSorter = new ListViewItemComparer(Event.Column);
            ListView1.Groups.Clear(); // On réinitialise les groupes

            // Cas où les données affichées sont des articles
            if (TypeDonneesAffichees == "Articles")
            {
                string NomColonne = ListView1.Columns[Event.Column].Text;
                // Si on clique sur la colonne Familles 
                if (NomColonne == "Familles")
                {
                    Dictionary<string, int> IndicesGroupe = new Dictionary<string, int>(); // On crée un dictionnaire qui attribura un id à chaque famille pour pouvoir les grouper

                    foreach (Famille FamilleExistante in Famille.GetListeFamilles())
                    {
                        int IdFamille = ListView1.Groups.Add(new ListViewGroup(FamilleExistante.GetNom(), HorizontalAlignment.Left));
                        IndicesGroupe.Add(FamilleExistante.GetNom(), IdFamille);
                    }

                    foreach (ListViewItem Ligne in ListView1.Items)
                    {
                        Ligne.Group = ListView1.Groups[IndicesGroupe[Ligne.SubItems[2].Text]];
                    }
                }
                // Si on clique sur la colonne Sous-familles
                if (NomColonne == "Sous-familles")
                {
                    Dictionary<string, int> IndicesGroupe = new Dictionary<string, int>();

                    foreach (SousFamille SousFamilleExistante in SousFamille.GetListeSousFamilles())
                    {
                        int IdFamille = ListView1.Groups.Add(new ListViewGroup(SousFamilleExistante.GetNom(), HorizontalAlignment.Left));
                        IndicesGroupe.Add(SousFamilleExistante.GetNom(), IdFamille);
                    }

                    foreach (ListViewItem Ligne in ListView1.Items)
                    {
                        Ligne.Group = ListView1.Groups[IndicesGroupe[Ligne.SubItems[3].Text]];
                    }
                }
                // Si on clique sur la colonne Marques
                if (NomColonne == "Marques")
                {
                    Dictionary<string, int> IndicesGroupe = new Dictionary<string, int>();

                    foreach (Marque MarqueExistante in Marque.GetListeMarques())
                    {
                        int IdFamille = ListView1.Groups.Add(new ListViewGroup(MarqueExistante.GetNom(), HorizontalAlignment.Left));
                        IndicesGroupe.Add(MarqueExistante.GetNom(), IdFamille);
                    }

                    foreach (ListViewItem Ligne in ListView1.Items)
                    {
                        Ligne.Group = ListView1.Groups[IndicesGroupe[Ligne.SubItems[4].Text]];
                    }
                }

                // Si on clique sur la colonne Marques
                if (NomColonne == "Description")
                {
                    CreerGroupesPourUneDescription(1);
                }
            }
            else
            {
                CreerGroupesPourUneDescription(0);
            }
        }


        /// <summary>
        /// Permets d'actualiser l'application à partir de la BDD.
        /// </summary>
        public void Actualiser(bool Afficher_MessageBox)
        {
            //private void ListView1_ColumnClick(object sender, ColumnClickEventArgs Event)
            ImporterDonneesFichierSQLite();
            ChargerTreeView();
            //on recupere le dernier noeud selectionné
            TreeNode NoeudSelectionne = TreeView1.SelectedNode;
            if (NoeudSelectionne != null)
            {

                ListView1_ColumnClick(TreeView1, new ColumnClickEventArgs(0));
            }
            else
            {
                ChargerListViewArticles(Article.GetListeArticles());
            }
            if (Afficher_MessageBox)
            {
                MessageBox.Show("Actualisation effectuée avec succès.", "Actualisation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Permets de supprimer un élément ( article, famille, sous-famille ou marque ).
        /// </summary>
        public void SupprimerElement()
        {
            if (ListView1.SelectedItems.Count == 1) // Si un seul élément est selectionne dans le ListView
            {
                ListViewItem Item = ListView1.SelectedItems[0];

                if (TypeDonneesAffichees == "Articles")
                {
                    SupprimerArticle(Item);

                    ListView1.Items.Remove(Item);
                }
                try
                {
                    if (TypeDonneesAffichees == "Familles")
                    {
                        Famille FamilleASupprimer = Famille.GetFamilleExistante(Item.SubItems[0].Text);

                        if (FamilleASupprimer.FamilleUtilisee() == false)
                        {
                            SupprimerFamille(FamilleASupprimer);

                            ListView1.Items.Remove(Item);
                        }
                        else
                        {
                            throw new Exception(Exception.ERREUR_OBJET_UTILISEE);
                        }
                    }
                    if (TypeDonneesAffichees == "SousFamilles")
                    {
                        SousFamille SousFamilleASupprimer = SousFamille.GetSousFamilleExistante(Item.SubItems[0].Text);

                        if (SousFamilleASupprimer.SousFamilleUtilisee() == false)
                        {
                            SupprimerSousFamille(SousFamilleASupprimer);

                            ListView1.Items.Remove(Item);
                        }
                        else
                        {
                            throw new Exception(Exception.ERREUR_OBJET_UTILISEE);
                        }
                    }
                    if (TypeDonneesAffichees == "Marques")
                    {
                        Marque MarqueASupprimer = Marque.GetMarqueExistante(Item.SubItems[0].Text);

                        if (MarqueASupprimer.MarqueUtilisee() == false)
                        {
                            SupprimerMarque(MarqueASupprimer);

                            ListView1.Items.Remove(Item);
                        }
                        else
                        {
                            throw new Exception(Exception.ERREUR_OBJET_UTILISEE);
                        }
                    }
                }
                catch (Exception ExceptionAttrapee)
                {
                    ExceptionAttrapee.AfficherMessageErreur();
                }
            }
        }

        /// <summary>
        /// Permet de modifier la ligne selectionnee dans le list view
        /// </summary>
        public void ModifierElement()
        {
            if (ListView1.SelectedItems.Count == 1) // Si un seul élément est selectionne dans le ListView, on ouvre l'interface de modification de cet objet
            {
                ListViewItem Item = ListView1.SelectedItems[0];
                // Si on modifie un article
                if (TypeDonneesAffichees == "Articles")
                {
                    Article ArticleSelectionnee = Article.GetArticleExistant(Item.SubItems[0].Text);

                    // On ouvre la fenêtre de modification de l'article
                    if (ArticleSelectionnee != null)
                    {
                        string NomSousFamilleAvantModification = ArticleSelectionnee.GetSousFamille().GetNom();
                        string NomMarqueAvantModification = ArticleSelectionnee.GetMarque().GetNom();

                        FormModifyArticle NouveauForm = new FormModifyArticle(ArticleSelectionnee);
                        NouveauForm.ShowDialog();

                        string NomNouvelleSousFamille = ArticleSelectionnee.GetSousFamille().GetNom();
                        string NomNouvelleMarque = ArticleSelectionnee.GetMarque().GetNom();

                        if (TypeFiltre == "" || // Si aucun filtre n'est actif, tout les articles sont affichés
                            (TypeFiltre == "Marque" && NomMarqueAvantModification == NomNouvelleMarque) || // Si ce sont les Articles d'une Marque qui sont affichés et que la Marque n'a pas changée
                            (TypeFiltre == "SousFamille" && NomSousFamilleAvantModification == NomNouvelleSousFamille)) // Si ce sont les Articles d'une SousFamille qui sont affichés et que celle-ci n'a pas changée
                        {
                            // Alors, on met à jour la ligne
                            Item.SubItems[0].Text = ArticleSelectionnee.GetReference();
                            Item.SubItems[1].Text = ArticleSelectionnee.GetDescription();
                            Item.SubItems[2].Text = ArticleSelectionnee.GetSousFamille().GetFamille().GetNom();
                            Item.SubItems[3].Text = ArticleSelectionnee.GetSousFamille().GetNom();
                            Item.SubItems[4].Text = ArticleSelectionnee.GetMarque().GetNom();
                        }
                        else
                        {
                            // Sinon on la supprime la ligne
                            ListView1.Items.Remove(Item);
                        }
                    }
                }
                // Si on modifie une famille
                if (TypeDonneesAffichees == "Familles")
                {
                    Famille FamilleSelectionnee = Famille.GetFamilleExistante(Item.SubItems[0].Text);
                    if (FamilleSelectionnee != null)
                    {
                        TreeNode NoeudAMettreAJour = TrouverNoeudParTexte(TreeView1.Nodes[1], FamilleSelectionnee.GetNom());

                        FormModifyFamille NouveauForm = new FormModifyFamille(FamilleSelectionnee);
                        NouveauForm.ShowDialog();

                        string NouveauNom = FamilleSelectionnee.GetNom();

                        Item.SubItems[0].Text = NouveauNom;
                        NoeudAMettreAJour.Text = NouveauNom;
                    }
                }
                // Si on modifie une marque
                if (TypeDonneesAffichees == "Marques")
                {
                    Marque MarqueSelectionnee = Marque.GetMarqueExistante(Item.SubItems[0].Text);
                    if (MarqueSelectionnee != null)
                    {
                        TreeNode NoeudAMettreAJour = TrouverNoeudParTexte(TreeView1.Nodes[2], MarqueSelectionnee.GetNom());

                        FormModifyMarque NouveauForm = new FormModifyMarque(MarqueSelectionnee);
                        NouveauForm.ShowDialog();

                        string NouveauNom = MarqueSelectionnee.GetNom();

                        Item.SubItems[0].Text = NouveauNom;
                        NoeudAMettreAJour.Text = NouveauNom;
                    }
                }
                // Si on modifie une sous-famille
                if (TypeDonneesAffichees == "SousFamilles")
                {
                    SousFamille SousFamilleSelectionnee = SousFamille.GetSousFamilleExistante(Item.SubItems[0].Text);
                    if (SousFamilleSelectionnee != null)
                    {
                        Famille FamilleParente = SousFamilleSelectionnee.GetFamille();

                        TreeNode NoeudFamille = TrouverNoeudParTexte(TreeView1.Nodes[1], FamilleParente.GetNom());
                        TreeNode NoeudAMettreAJour = TrouverNoeudParTexte(NoeudFamille, SousFamilleSelectionnee.GetNom());

                        string NomFamilleAvantModification = FamilleParente.GetNom();

                        FormModifySousFamille NouveauForm = new FormModifySousFamille(SousFamilleSelectionnee);
                        NouveauForm.ShowDialog();

                        /* On vérifie que la famille n'a pas été modifié */
                        string NomNouvelleFamille = SousFamilleSelectionnee.GetNom();
                        if (NomFamilleAvantModification == NomNouvelleFamille)
                        {
                            Item.SubItems[0].Text = SousFamilleSelectionnee.GetNom(); // Si non, on met à jour le nom
                        }
                        else
                        {
                            ListView1.Items.Remove(Item); // Si oui, on supprime la ligne
                                                          // TODO : mise a jour dans le treeview
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Méthode qui permets de supprimer un article.
        /// </summary>
        /// <param name="Item"></param>
        public void SupprimerArticle(ListViewItem Item)
        {
            DialogResult Resultat = MessageBox.Show("Voulez-vous vraiment supprimer cet article ?", "Confirmation suppression article", MessageBoxButtons.YesNo);

            if (Resultat == DialogResult.Yes)
            {
                string ReferenceArticle = Item.SubItems[0].Text;
                Article.GetArticleExistant(ReferenceArticle).SupprimerArticle();
            }
        }

        /// <summary>
        /// Méthode qui permet de supprimer une sous-famille
        /// </summary>
        /// <param name="SousFamilleASupprimer"> SousFamille à supprimer </param>
        public void SupprimerSousFamille(SousFamille SousFamilleASupprimer)
        {
            DialogResult Resultat = MessageBox.Show("Voulez-vous vraiment supprimer cette sous-famille ?", "Confirmation suppression sous-famille", MessageBoxButtons.YesNo);

            if (Resultat == DialogResult.Yes)
            {
                SousFamilleASupprimer.SupprimerSousFamille();
            }

            /* On cherche le noeud du tree view qui correspond à la sous-famille supprimée */
            foreach (TreeNode node in NoeudSelectionne.Nodes)
            {
                if (node.Text == SousFamilleASupprimer.GetNom())
                {
                    TreeView1.Nodes.Remove(node);
                    break;
                }
            }
        }

        /// <summary>
        /// Permets de supprimer une famille
        /// </summary>
        /// <param name="FamilleASupprimer"> Famille à supprimer </param>
        public void SupprimerFamille(Famille FamilleASupprimer)
        {
            DialogResult Resultat = MessageBox.Show("Voulez-vous vraiment supprimer cette famille ?", "Confirmation suppression famille", MessageBoxButtons.YesNo);

            if (Resultat == DialogResult.Yes)
            {
                FamilleASupprimer.SupprimerFamille();
            }

            /* On cherche le noeud du tree view qui correspond à la famille supprimée */
            foreach (TreeNode node in NoeudSelectionne.Nodes)
            {
                if (node.Text == FamilleASupprimer.GetNom())
                {
                    TreeView1.Nodes["Familles"].Nodes.Remove(node); // PROBLEME ICI
                    break;
                }
            }
        }

        /// <summary>
        /// Permets de supprimer une marque
        /// </summary>
        /// <param name="MarqueASupprimer"> Marque à supprimer </param>
        public void SupprimerMarque(Marque MarqueASupprimer)
        {
            DialogResult Resultat = MessageBox.Show("Voulez-vous vraiment supprimer cette marque ?", "Confirmation suppression marque", MessageBoxButtons.YesNo);

            if (Resultat == DialogResult.Yes)
            {
                MarqueASupprimer.SupprimerMarque();
            }

            /* On cherche le noeud du tree view qui correspond à la marque supprimée */
            foreach (TreeNode node in NoeudSelectionne.Nodes)
            {
                if (node.Text == MarqueASupprimer.GetNom())
                {
                    TreeView1.Nodes.Remove(node);
                    break;
                }
            }
        }

        /// <summary>
        /// Quand on appuie sur actualiser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Actualiser(false);
        }

        /// <summary>
        /// Evenement lié à l'import de données du fichier .csv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport FormImport = new FormImport();
            FormImport.ShowDialog();

            Actualiser(false);
        }

        /// <summary>
        /// Evenement lié à l'export de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExport FormExport = new FormExport();
            FormExport.ShowDialog();
        }


        /// <summary>
        /// Evenements pour les raccourcis suppression (activé par Suppr) et modification (activé par Espace ou Entrée)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Event"></param>
        private void ListView1_KeyDown(object sender, KeyEventArgs Event)
        {
            if (Event.KeyCode == Keys.Delete)
            {
                SupprimerElement();
            }
            if (Event.KeyCode == Keys.Space || Event.KeyCode == Keys.Enter)
            {
                ModifierElement();
            }
        }

        /// <summary>
        /// Evenements pour le raccourci actualisation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Event"></param>
        private void FormMain_KeyDown(object sender, KeyEventArgs Event)
        {
            if (Event.KeyCode == Keys.F5)
            {
                Actualiser(true);
            }
        }

        /// <summary>
        /// Evenement à l'ouverture du menu contextuel du clic droit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            /* Si un objet dans le list view est selctionné, on affiche la modification et la suppression */
            if (ListView1.SelectedItems.Count == 1)
            {
                contextMenuStrip1.Items[1].Enabled = true;
                contextMenuStrip1.Items[2].Enabled = true;
            }
            /* Sinon on les cache*/
            else
            {
                contextMenuStrip1.Items[1].Enabled = false;
                contextMenuStrip1.Items[2].Enabled = false;
            }
        }

        /// <summary>
        /// Evenement lorsque la souris sort du list view, déselectionne les elements du list view (pour que contextMenuStrip1_Opening fonctionne correctement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView1_Leave(object sender, EventArgs e)
        {
            ListView1.SelectedItems.Clear();
        }

        /// <summary>
        /// Ajout d'un article depuis le menu contextuel du clique droit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void articleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddArticle NouveauFormAddArticle = new FormAddArticle();
            NouveauFormAddArticle.ShowDialog();
        }

        /// <summary>
        /// Ajout d'une famille depuis le menu contextuel du clique droit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void familleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddFamille NouveauFormAddFamille = new FormAddFamille();
            NouveauFormAddFamille.ShowDialog();
        }

        /// <summary>
        /// Ajout d'une sous-famille depuis le menu contextuel du clique droit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sousFamilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddSousFamille NouveauFormAddSousFamille = new FormAddSousFamille();
            NouveauFormAddSousFamille.ShowDialog();
        }

        /// <summary>
        /// Ajout d'une marque depuis le menu contextuel du clique droit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void marqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddMarque NouveauFormAddMarque = new FormAddMarque();
            NouveauFormAddMarque.ShowDialog();
        }

        /// <summary>
        /// Modification d'un element du list view depuis le menu contextuel du clique droit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifierUnObjetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierElement();
        }

        /// <summary>
        /// Suppression d'un element du list view depuis le menu contextuel du clique droit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supprimerLobjetSelectionneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupprimerElement();
        }

        class ListViewItemComparer : IComparer
        {
            private int NumeroColomne;
            public ListViewItemComparer()
            {
                NumeroColomne = 0;
            }
            public ListViewItemComparer(int column)
            {
                NumeroColomne = column;
            }
            /// <summary
            /// </summary>
            /// <param name="ObjetParam1"></param>
            /// <param name="ObjetParam2"></param> 
            /// <returns></returns>
            public int Compare(object ObjetParam1, object ObjetParam2)
            {
                return String.Compare(((ListViewItem)ObjetParam1).SubItems[NumeroColomne].Text, ((ListViewItem)ObjetParam2).SubItems[NumeroColomne].Text);
            }
        }
        /// <summary>
        /// Methode qui permet de trouver un noeud par son texte
        /// </summary>
        /// <param name="NoeudParent"></param>
        /// <param name="TexteDuNoeud"></param>
        /// <returns> - TreeNode : le noeud trouvé </returns>
        /// <returns> - null : si le noeud n'a pas été trouvé </returns>
        private TreeNode TrouverNoeudParTexte(TreeNode NoeudParent, string TexteDuNoeud)
        {
            if (NoeudParent.Text == TexteDuNoeud)
            {
                return NoeudParent;
            }

            foreach (TreeNode Noeud in NoeudParent.Nodes)
            {
                TreeNode NoeudTrouve = TrouverNoeudParTexte(Noeud, TexteDuNoeud);
                if (NoeudTrouve != null)
                {
                    return NoeudTrouve;
                }
            }

            return null;
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // On regarde si c'est un clic droit.
            if (e.Button == MouseButtons.Left)
            {
                ModifierElement();
            }
        }

    }
}
