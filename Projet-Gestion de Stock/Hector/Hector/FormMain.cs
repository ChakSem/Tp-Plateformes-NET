using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;
using System.Windows;


namespace Hector
{
    public partial class FormMain : Form
    {
        private string TypeDonneesAffichees;
        private TreeNode NoeudSelectionne;

        private int IndiceColonne;

        private string Filtre;
        private string TypeFiltre;

        private int NombreFamilles;
        private int NombreSousFamilles;
        private int NombreMarques;
        private int NombreArticles;

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

            IndiceColonne = -1; // On initlaise l'indice de la colonne selectionnée

            // On initlaise les attributs de filtre
            Filtre = "";
            TypeFiltre = "";
        }

        /// <summary>
        /// Méthode permettant d'actualiser le nombre de familles affichées dans le StatusStrip
        /// </summary>
        /// <param name="NombreParam"> Nouveau nombre de familles </param>
        public void SetNombreFamilles(int NombreParam)
        {
            NombreFamilles = NombreParam;
            FamillesToolStripStatusLabel.Text = NombreFamilles.ToString();
        }

        /// <summary>
        /// Méthode permettant d'actualiser le nombre de sous-familles affichées dans le StatusStrip
        /// </summary>
        /// <param name="NombreParam"> Nouveau nombre de sous-familles </param>
        public void SetNombreSousFamilles(int NombreParam)
        {
            NombreSousFamilles = NombreParam;
            SousFamillesLabelToolStripStatusLabel.Text = NombreSousFamilles.ToString();
        }

        /// <summary>
        /// Méthode permettant d'actualiser le nombre de marques affichées dans le StatusStrip
        /// </summary>
        /// <param name="NombreParam"> Nouveau nombre de marques </param>
        public void SetNombreMarques(int NombreParam)
        {
            NombreMarques = NombreParam;
            MarquesToolStripStatusLabel.Text = NombreMarques.ToString();
        }

        /// <summary>
        /// Méthode permettant d'actualiser le nombre d'articles affichées dans le StatusStrip
        /// </summary>
        /// <param name="NombreParam"> Nouveau nombre d'articles </param>
        public void SetNombreArticles(int NombreParam)
        {
            NombreArticles = NombreParam;
            ArticlesToolStripStatusLabel.Text = NombreArticles.ToString();
        }

        /// <summary>
        /// Permet de mettre à jour les données depuis les données déjà présente dans le fichier .SQLite
        /// </summary>
        public void ImporterDonneesFichierSQLite()
        {
            BaseDeDonnees BDD = BaseDeDonnees.GetInstance();

            BDD.LireMarquesBdd();
            BDD.LireFamillesBdd();
            BDD.LireSousFamillesBdd();
            BDD.LireArticlesBdd();

            SetNombreFamilles(Famille.GetListeFamilles().Count);
            SetNombreSousFamilles(SousFamille.GetListeSousFamilles().Count);
            SetNombreMarques(Marque.GetListeMarques().Count);
            SetNombreArticles(Article.GetListeArticles().Count);
        }

        /// <summary>
        /// Methode qui permet de chager le TreeView
        /// </summary>
        private void ChargerTreeView()
        {
            ObjetTreeView.Nodes.Clear();

            // On crée les noeuds racines
            TreeNode NoeudTousLesArticles = new TreeNode("Tous les articles");
            TreeNode NoeudFamilles = new TreeNode("Familles");
            TreeNode NoeudMarques = new TreeNode("Marques");

            // On ajoute les noeuds racines au TreeView
            ObjetTreeView.Nodes.Add(NoeudTousLesArticles);
            ObjetTreeView.Nodes.Add(NoeudFamilles);
            ObjetTreeView.Nodes.Add(NoeudMarques);

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
        private void ObjetTreeView_AfterSelect(object sender, TreeViewEventArgs Event)
        {
            // On récupere le type de noeud selectionné
            NoeudSelectionne = Event.Node;
            string TypeNoeudSelectionne = NoeudSelectionne.Text;
            TreeNode NoeudParent = NoeudSelectionne.Parent;

            IndiceColonne = -1; // On réinitlaise l'indice de la colonne selectionnée
            ObjetListView.Groups.Clear(); // On réinitialises les groupes

            switch (TypeNoeudSelectionne)
            {
                case "Tous les articles":
                    // On réinitalise les filtres
                    Filtre = "";
                    TypeFiltre = "";

                    ObjetListView.Columns.Clear();
                    ChargerListViewArticles(Article.GetListeArticles());

                    break;

                case "Familles":
                    // On réinitalise les filtres
                    Filtre = "";
                    TypeFiltre = "";

                    ObjetListView.Columns.Clear();
                    ChargerListViewFamilles(Famille.GetListeFamilles());

                    break;

                case "Marques":
                    // On réinitalise les filtres
                    Filtre = "";
                    TypeFiltre = "";

                    ObjetListView.Columns.Clear();
                    ChargerListViewMarques(Marque.GetListeMarques());

                    break;

                default:
                    ObjetListView.Columns.Clear();
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
                        ObjetListView.Columns.Clear();
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
            ObjetListView.Columns.Clear();
            ObjetListView.Items.Clear();
            AjouterColonnesListViewSousFamilles();

            List<SousFamille> ListeSousFamilles = SousFamille.GetListeSousFamilles();

            foreach (SousFamille SousFamilleExistante in ListeSousFamilles)
            {
                if (SousFamilleExistante.GetFamille().GetNom() == Filtre)
                {
                    ListViewItem NouvelItem = new ListViewItem(SousFamilleExistante.GetNom());
                    ObjetListView.Items.Add(NouvelItem);
                }
            }
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes à l'affichage d'articles
        /// <summary
        public void AjouterColonnesListViewArticles()
        {
            ObjetListView.ListViewItemSorter = null;
            TypeDonneesAffichees = "Articles";

            ObjetListView.Columns.Add("RefArticle", 60);
            ObjetListView.Columns.Add("Description", 200);
            ObjetListView.Columns.Add("Familles", 100);
            ObjetListView.Columns.Add("Sous-familles", 100);
            ObjetListView.Columns.Add("Marques", 90);
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes à l'affichage de sous-familles
        /// <summary>
        public void AjouterColonnesListViewSousFamilles()
        {
            ObjetListView.ListViewItemSorter = null;
            TypeDonneesAffichees = "SousFamilles";

            ObjetListView.Columns.Add("Description", 150);
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes à l'affichage de familles
        /// <summary>
        public void AjouterColonnesListViewFamilles()
        {
            ObjetListView.ListViewItemSorter = null;
            TypeDonneesAffichees = "Familles";

            ObjetListView.Columns.Add("Description", 150);
        }

        /// <summary>
        /// Methode qui permet d'ajouter les colonnes correspondantes à l'affichage de marques
        /// <summary>
        public void AjouterColonnesListViewMarques()
        {
            ObjetListView.ListViewItemSorter = null;
            TypeDonneesAffichees = "Marques";

            ObjetListView.Columns.Add("Description", 150);
        }

        /// <summary>
        /// Methode qui permet de charger les articles passés en paramètre
        /// </summary>
        /// <param name="ListeArticles"></param>
        private void ChargerListViewArticles(List<Article> ListeArticles)
        {
            // On vide le ListView
            ObjetListView.Columns.Clear();
            ObjetListView.Items.Clear();

            // On met à jour les colonnes
            AjouterColonnesListViewArticles();

            // On ajoute les articles un par un
            foreach (Article ArticleExistant in ListeArticles)
            {
                ListViewItem NouvelItem = new ListViewItem(ArticleExistant.GetReference());
                NouvelItem.SubItems.Add(ArticleExistant.GetDescription().ToString());
                NouvelItem.SubItems.Add(ArticleExistant.GetSousFamille().GetFamille().GetNom());
                NouvelItem.SubItems.Add(ArticleExistant.GetSousFamille().GetNom());
                NouvelItem.SubItems.Add(ArticleExistant.GetMarque().GetNom());
                ObjetListView.Items.Add(NouvelItem);
            }
        }

        /// <summary>
        /// Methode qui permet de charger les familles passées en paramètre
        /// </summary>
        /// <param name="ListeFamilles"></param>
        private void ChargerListViewFamilles(List<Famille> ListeFamilles)
        {
            //On vide le ListView
            ObjetListView.Columns.Clear();
            ObjetListView.Items.Clear();
            AjouterColonnesListViewFamilles();

            //On ajoute les familles
            foreach (Famille FamilleExistante in ListeFamilles)
            {
                ListViewItem NouvelItem = new ListViewItem(FamilleExistante.GetNom());
                ObjetListView.Items.Add(NouvelItem);
            }
        }

        /// <summary>
        /// Methode qui permet de charger les marques passées en paramètre
        /// </summary>
        /// <param name="ListeMarques"></param>
        private void ChargerListViewMarques(List<Marque> ListeMarques)
        {
            // On vide le ListView
            ObjetListView.Columns.Clear();
            ObjetListView.Items.Clear();
            AjouterColonnesListViewMarques();

            // On ajoute les marques
            foreach (Marque MarqueExistante in ListeMarques)
            {
                ListViewItem NouvelItem = new ListViewItem(MarqueExistante.GetNom());
                ObjetListView.Items.Add(NouvelItem);
            }
        }
        
        /// <summary>
        /// Permets de trier la liste view en groupes selon la première lettre de la description de l'article.
        /// </summary>
        public void CreerGroupesPourUneDescription()
        {
            // Dictionnaire pour stocker les groupes
            Dictionary<char, int> IndicesGroupe = new Dictionary<char, int>();

            // Créer les groupes pour chaque lettre de l'alphabet
            ListViewGroup Groupe;
            for (char Lettre = 'A'; Lettre <= 'Z'; Lettre++)
            {
                // On crée le groupe correspondant à la lettre.
                Groupe = new ListViewGroup(Convert.ToString(Lettre).ToUpper(), HorizontalAlignment.Left);
                int IdLettre = ObjetListView.Groups.Add(Groupe);
                IndicesGroupe.Add(Lettre, IdLettre);
            }

            foreach (ListViewItem Ligne in ObjetListView.Items)
            {
                char PremiereLettre = ExtractionPremierCaractere(Ligne.SubItems[IndiceColonne].Text);
                Console.WriteLine(PremiereLettre);
                Ligne.Group = ObjetListView.Groups[IndicesGroupe[PremiereLettre]];
            }
        }

        /// <summary>
        /// Permets d'obtenir la première lettre d'une description, en tenant pas en compte les quantités
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
                    string ChaineNormalisee = Chaine.Normalize(NormalizationForm.FormD); // On normalise pour retirer les accents
                    bool ChiffreDetecte = false;

                    foreach (char Caractere in ChaineNormalisee)
                    {
                        if (char.IsDigit(Caractere))
                        {
                            ChiffreDetecte = true;
                            continue; // On passe au caractère suivant
                        }

                        // On vérifie que  le caractere lu est une lettre et qu'il ne correspond pas à un x de quantité (par ex : "6x Marqueurs - Velleda - 1781bis")
                        if (char.IsLetter(Caractere) && !(Caractere == 'x' && ChiffreDetecte))
                        {
                            char PremierCaractere = char.ToUpper(Caractere);
                            return PremierCaractere;
                        } 
                        // Si le caractère x n'a pas été choisi, alors cela veut dire qu'il était précédé par un chiffre, on réinitialise donc le booléen
                        if (Caractere == 'x')
                        {
                            ChiffreDetecte = false;
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
        private void ObjetListView_ColumnClick(object sender, ColumnClickEventArgs Event)
        {
            ObjetListView.ListViewItemSorter = new ListViewItemComparer(Event.Column);

            IndiceColonne = Event.Column; // On sauvegarde l'indice de la colonne cliquée
            ObjetListView.Groups.Clear(); // On réinitialise les groupes

            // Cas où les données affichées sont des articles
            if (TypeDonneesAffichees == "Articles")
            {
                string NomColonne = ObjetListView.Columns[Event.Column].Text;
                // Si on clique sur la colonne Familles 
                if (NomColonne == "Familles")
                {
                    Dictionary<string, int> IndicesGroupe = new Dictionary<string, int>(); // On crée un dictionnaire qui attribura un id à chaque famille pour pouvoir les grouper

                    // On ajoute chaque famille une à une au dictionnaire
                    foreach (Famille FamilleExistante in Famille.GetListeFamilles())
                    {
                        int IdFamille = ObjetListView.Groups.Add(new ListViewGroup(FamilleExistante.GetNom(), HorizontalAlignment.Left));
                        IndicesGroupe.Add(FamilleExistante.GetNom(), IdFamille);
                    }

                    // Pour chaque article affiché, on l'ajoute au groupe crée pour sa famille
                    foreach (ListViewItem Ligne in ObjetListView.Items)
                    {
                        Ligne.Group = ObjetListView.Groups[IndicesGroupe[Ligne.SubItems[IndiceColonne].Text]];
                    }
                }
                // Si on clique sur la colonne Sous-familles
                if (NomColonne == "Sous-familles")
                {
                    Dictionary<string, int> IndicesGroupe = new Dictionary<string, int>(); // On crée un dictionnaire qui attribura un id à chaque sous-famille pour pouvoir grouper les articles en fonction

                    // On ajoute chaque sous-famille une à une au dictionnaire
                    foreach (SousFamille SousFamilleExistante in SousFamille.GetListeSousFamilles())
                    {
                        int IdFamille = ObjetListView.Groups.Add(new ListViewGroup(SousFamilleExistante.GetNom(), HorizontalAlignment.Left));
                        IndicesGroupe.Add(SousFamilleExistante.GetNom(), IdFamille);
                    }

                    // Pour chaque article affiché, on l'ajoute au groupe crée pour sa sous-famille
                    foreach (ListViewItem Ligne in ObjetListView.Items)
                    {
                        Ligne.Group = ObjetListView.Groups[IndicesGroupe[Ligne.SubItems[IndiceColonne].Text]];
                    }
                }
                // Si on clique sur la colonne Marques
                if (NomColonne == "Marques")
                {
                    Dictionary<string, int> IndicesGroupe = new Dictionary<string, int>(); // On crée un dictionnaire qui attribura un id à chaque marque pour pouvoir grouper les articles en fonction

                    // On ajoute chaque marque une à une au dictionnaire
                    foreach (Marque MarqueExistante in Marque.GetListeMarques())
                    {
                        int IdFamille = ObjetListView.Groups.Add(new ListViewGroup(MarqueExistante.GetNom(), HorizontalAlignment.Left));
                        IndicesGroupe.Add(MarqueExistante.GetNom(), IdFamille);
                    }

                    // Pour chaque  article affiché, on l'ajoute au groupe crée pour sa marque
                    foreach (ListViewItem Ligne in ObjetListView.Items)
                    {
                        Ligne.Group = ObjetListView.Groups[IndicesGroupe[Ligne.SubItems[IndiceColonne].Text]];
                    }
                }

                // Si on clique sur la colonne Marques
                if (NomColonne == "Description")
                {
                    CreerGroupesPourUneDescription();
                }
            }
            else
            {
                CreerGroupesPourUneDescription();
            }
        }

        /// <summary>
        /// Permets d'actualiser l'application à partir de la BDD.
        /// </summary>
        public void Actualiser(bool Afficher_MessageBox)
        {
            String IdItem = null; // On stocke la ref (ou la description) de la ligne selectionne avant l'actualisation
            int IndiceColonneAvantActualisation = IndiceColonne;

            if (ObjetListView.SelectedItems.Count > 0)
            {
                IdItem = ObjetListView.SelectedItems[0].Text;
            }

            ImporterDonneesFichierSQLite();
            ChargerTreeView(); // On met à jour le treeview

            // On refait la dernière selection qui a été faites
            if (NoeudSelectionne != null)
            {
                ObjetTreeView_AfterSelect(ObjetTreeView, new TreeViewEventArgs(NoeudSelectionne, TreeViewAction.ByMouse));
            }

            // On remet la selection sur l'élément qui été selectionnée dans le listView avant l'actualisation (s'il existe toujours)
            if (IdItem != null)
            {
                foreach (ListViewItem item in ObjetListView.Items)
                {
                    if (item.Text == IdItem)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }

            // On refait le tri / groupement qui était fait avant l'actualisation
            if (IndiceColonneAvantActualisation > -1)
            {
                ObjetListView_ColumnClick(ObjetListView, new ColumnClickEventArgs(IndiceColonneAvantActualisation));
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
            if (ObjetListView.SelectedItems.Count == 1) // Si un seul élément est selectionne dans le ListView
            {
                ListViewItem Item = ObjetListView.SelectedItems[0];

                if (TypeDonneesAffichees == "Articles")
                {
                    if (SupprimerArticle(Item) == Exception.RETOUR_NORMAL)
                    {
                        SetNombreArticles(NombreArticles - 1); // On met à jour le nombre d'articles
                        ObjetListView.Items.Remove(Item); // On efface la ligne si l'élement a pu être correctement supprimé
                    }
                }
                try
                {
                    if (TypeDonneesAffichees == "Familles")
                    {
                        Famille FamilleASupprimer = Famille.GetFamilleExistante(Item.SubItems[0].Text);

                        if (FamilleASupprimer.FamilleUtilisee() == false)
                        {
                            if (SupprimerFamille(FamilleASupprimer) == Exception.RETOUR_NORMAL)
                            {
                                SetNombreFamilles(NombreFamilles - 1); // On met à jour le nombre de familles
                                ObjetListView.Items.Remove(Item);
                            }
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
                            if (SupprimerSousFamille(SousFamilleASupprimer) == Exception.RETOUR_NORMAL)
                            {
                                SetNombreSousFamilles(NombreSousFamilles - 1); // On met à jour le nombre de sous-familles
                                ObjetListView.Items.Remove(Item);
                            }
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
                            if (SupprimerMarque(MarqueASupprimer) == Exception.RETOUR_NORMAL)
                            {
                                SetNombreMarques(NombreMarques - 1); // On met à jour le nombre de marques
                                ObjetListView.Items.Remove(Item);
                            }
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
            if (ObjetListView.SelectedItems.Count == 1) // Si un seul élément est selectionne dans le ListView, on ouvre l'interface de modification de cet objet
            {
                ListViewItem Item = ObjetListView.SelectedItems[0];
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
                            ObjetListView.Items.Remove(Item);
                        }
                    }
                }
                // Si on modifie une famille
                if (TypeDonneesAffichees == "Familles")
                {
                    Famille FamilleSelectionnee = Famille.GetFamilleExistante(Item.SubItems[0].Text);
                    if (FamilleSelectionnee != null)
                    {
                        TreeNode NoeudAMettreAJour = TrouverNoeudParTexte(ObjetTreeView.Nodes[1], FamilleSelectionnee.GetNom());

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
                        TreeNode NoeudAMettreAJour = TrouverNoeudParTexte(ObjetTreeView.Nodes[2], MarqueSelectionnee.GetNom());

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

                        TreeNode NoeudFamille = TrouverNoeudParTexte(ObjetTreeView.Nodes[1], FamilleParente.GetNom());
                        TreeNode NoeudAMettreAJour = TrouverNoeudParTexte(NoeudFamille, SousFamilleSelectionnee.GetNom());

                        string NomFamilleAvantModification = FamilleParente.GetNom();

                        FormModifySousFamille NouveauForm = new FormModifySousFamille(SousFamilleSelectionnee);
                        NouveauForm.ShowDialog();

                        // On vérifie que la famille n'a pas été modifié
                        string NomNouvelleFamille = SousFamilleSelectionnee.GetNom();
                        if (NomFamilleAvantModification == NomNouvelleFamille)
                        {
                            Item.SubItems[0].Text = SousFamilleSelectionnee.GetNom(); // Si non, on met à jour le nom
                        }
                        else
                        {
                            ObjetListView.Items.Remove(Item); // Si oui, on supprime la ligne
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Méthode qui permets de supprimer un article.
        /// </summary>
        /// <param name="Item"></param>
        /// <returns> Une valeur indiquant si la suppression a réussie </returns>
        public uint SupprimerArticle(ListViewItem Item)
        {
            DialogResult Resultat = MessageBox.Show("Voulez-vous vraiment supprimer cet article ?", "Confirmation suppression article", MessageBoxButtons.YesNo);

            if (Resultat == DialogResult.Yes)
            {
                string ReferenceArticle = Item.SubItems[0].Text;
                return Article.GetArticleExistant(ReferenceArticle).SupprimerArticle();
            }

            return Exception.RETOUR_ERREUR; // On renvoie RETOUR_ERREUR pour indiquer que la suppression n'a pas été effectuée (que ce soit dû à une erreur ou non)
        }

        /// <summary>
        /// Méthode qui permet de supprimer une sous-famille
        /// </summary>
        /// <param name="SousFamilleASupprimer"> SousFamille à supprimer </param>
        /// <returns> Une valeur indiquant si la suppression a réussie </returns>
        public uint SupprimerSousFamille(SousFamille SousFamilleASupprimer)
        {
            DialogResult Resultat = MessageBox.Show("Voulez-vous vraiment supprimer cette sous-famille ?", "Confirmation suppression sous-famille", MessageBoxButtons.YesNo);

            if (Resultat == DialogResult.Yes)
            {
                if (SousFamilleASupprimer.SupprimerSousFamille() == Exception.RETOUR_NORMAL)
                {
                    // On cherche le noeud du tree view qui correspond à la sous-famille supprimée
                    foreach (TreeNode node in NoeudSelectionne.Nodes)
                    {
                        if (node.Text == SousFamilleASupprimer.GetNom())
                        {
                            ObjetTreeView.Nodes.Remove(node);
                            return Exception.RETOUR_NORMAL;
                        }
                    }
                }
            }

            return Exception.RETOUR_ERREUR; // On renvoie RETOUR_ERREUR pour indiquer que la suppression n'a pas été effectuée (que ce soit dû à une erreur ou non)
        }

        /// <summary>
        /// Permets de supprimer une famille
        /// </summary>
        /// <param name="FamilleASupprimer"> Famille à supprimer </param>
        /// <returns> Une valeur indiquant si la suppression a réussie </returns>
        public uint SupprimerFamille(Famille FamilleASupprimer)
        {
            DialogResult Resultat = MessageBox.Show("Voulez-vous vraiment supprimer cette famille ?", "Confirmation suppression famille", MessageBoxButtons.YesNo);

            if (Resultat == DialogResult.Yes)
            {
                if (FamilleASupprimer.SupprimerFamille() == Exception.RETOUR_NORMAL)
                {
                    // On cherche le noeud du tree view qui correspond à la famille supprimée
                    foreach (TreeNode node in NoeudSelectionne.Nodes)
                    {
                        if (node.Text == FamilleASupprimer.GetNom())
                        {
                            ObjetTreeView.Nodes.Remove(node);
                            return Exception.RETOUR_NORMAL;
                        }
                    }
                }
            }

            return Exception.RETOUR_ERREUR; // On renvoie RETOUR_ERREUR pour indiquer que la suppression n'a pas été effectuée (que ce soit dû à une erreur ou non)
        }

        /// <summary>
        /// Permets de supprimer une marque
        /// </summary>
        /// <param name="MarqueASupprimer"> Marque à supprimer </param>
        /// <returns> Une valeur indiquant si la suppression a réussie </returns>
        public uint SupprimerMarque(Marque MarqueASupprimer)
        {
            DialogResult Resultat = MessageBox.Show("Voulez-vous vraiment supprimer cette marque ?", "Confirmation suppression marque", MessageBoxButtons.YesNo);

            if (Resultat == DialogResult.Yes)
            {
                if (MarqueASupprimer.SupprimerMarque() == Exception.RETOUR_NORMAL)
                {
                    // On cherche le noeud du tree view qui correspond à la marque supprimée
                    foreach (TreeNode node in NoeudSelectionne.Nodes)
                    {
                        if (node.Text == MarqueASupprimer.GetNom())
                        {
                            ObjetTreeView.Nodes.Remove(node);
                            return Exception.RETOUR_NORMAL;
                        }
                    }
                }
            }

            return Exception.RETOUR_ERREUR; // On renvoie RETOUR_ERREUR pour indiquer que la suppression n'a pas été effectuée (que ce soit dû à une erreur ou non)
        }

        /// <summary>
        /// Quand on appuie sur actualiser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualiser(false);
        }

        /// <summary>
        /// Evenement lié à l'import de données du fichier .csv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImporterToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void ExporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExport FormExport = new FormExport();
            FormExport.ShowDialog();
        }

        /// <summary>
        /// Evenements pour les raccourcis suppression (activé par Suppr) et modification (activé par Espace ou Entrée)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Event"></param>
        private void ObjetListView_KeyDown(object sender, KeyEventArgs Event)
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
        /// Evenements pour le raccourci actualisation (F5)
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
        private void ObjetContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // Si un objet dans le list view est selectionné, on affiche les champs modification et suppression du menu contextuel
            if (ObjetListView.SelectedItems.Count == 1)
            {
                ObjetContextMenuStrip.Items[1].Enabled = true;
                ObjetContextMenuStrip.Items[2].Enabled = true;
            }
            // Sinon on les grise
            else
            {
                ObjetContextMenuStrip.Items[1].Enabled = false;
                ObjetContextMenuStrip.Items[2].Enabled = false;
            }
        }

        /// <summary>
        /// Evenement lorsque la souris sort du list view, déselectionne les elements du list view (pour que champs modification et suppression du menu contextuel ne s'affiche pas)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObjetListView_Leave(object sender, EventArgs e)
        {
            ObjetListView.SelectedItems.Clear();
        }

        /// <summary>
        /// Ajout d'un article depuis le menu contextuel du clique droit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreerArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddArticle NouveauFormAddArticle = new FormAddArticle();
            NouveauFormAddArticle.ShowDialog();

            Article NouvelArticle = NouveauFormAddArticle.GetArticle();

            // Si l'article est crée
            if (NouvelArticle != null)
            {
                SetNombreArticles(NombreArticles + 1); // On met à jour le nombre d'articles

                // Si les données affichées sont des articles et l'article crée respecte les filtres, on l'affiche
                if (TypeDonneesAffichees == "Articles" && 
                    (TypeFiltre == ""
                    || (TypeFiltre == "Famille" && Filtre == NouvelArticle.GetSousFamille().GetFamille().GetNom())
                    || (TypeFiltre == "SousFamille" && Filtre == NouvelArticle.GetSousFamille().GetNom())
                    || (TypeFiltre == "Marque" && Filtre == NouvelArticle.GetMarque().GetNom())))
                {
                    ListViewItem NouvelItem = new ListViewItem(NouvelArticle.GetReference());
                    NouvelItem.SubItems.Add(NouvelArticle.GetDescription().ToString());
                    NouvelItem.SubItems.Add(NouvelArticle.GetSousFamille().GetFamille().GetNom());
                    NouvelItem.SubItems.Add(NouvelArticle.GetSousFamille().GetNom());
                    NouvelItem.SubItems.Add(NouvelArticle.GetMarque().GetNom());
                    ObjetListView.Items.Add(NouvelItem);

                    // On refait le tri / groupement pour que le nouvel Article le respecte
                    if (IndiceColonne > -1)
                    {
                        ObjetListView_ColumnClick(ObjetListView, new ColumnClickEventArgs(IndiceColonne));
                    }
                }
            }
        }

        /// <summary>
        /// Ajout d'une famille depuis le menu contextuel du clique droit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreerFamilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddFamille NouveauFormAddFamille = new FormAddFamille();
            NouveauFormAddFamille.ShowDialog();

            Famille NouvelleFamille = NouveauFormAddFamille.GetFamille();

            // Si la famille est crée
            if (NouvelleFamille != null)
            {
                SetNombreFamilles(NombreFamilles + 1); // On met à jour le nombre de familles

                // On ajoute un noeud correspondant au TreeView
                ObjetTreeView.Nodes[1].Nodes.Add(new TreeNode(NouvelleFamille.GetNom()));

                // Si les données affichées sont des familles, on l'affiche
                if (TypeDonneesAffichees == "Familles")
                {
                    ListViewItem NouvelItem = new ListViewItem(NouvelleFamille.GetNom());
                    ObjetListView.Items.Add(NouvelItem);

                    // On refait le tri / groupement pour que la nouvelle famile le respecte
                    if (IndiceColonne > -1)
                    {
                        ObjetListView_ColumnClick(ObjetListView, new ColumnClickEventArgs(IndiceColonne));
                    }
                }
            }
        }

        /// <summary>
        /// Ajout d'une sous-famille depuis le menu contextuel du clique droit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreerSousFamilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddSousFamille NouveauFormAddSousFamille = new FormAddSousFamille();
            NouveauFormAddSousFamille.ShowDialog();

            SousFamille NouvelleSousFamille = NouveauFormAddSousFamille.GetSousFamille();

            // Si la famille est crée, on l'ajoute 
            if (NouvelleSousFamille != null)
            {
                SetNombreSousFamilles(NombreSousFamilles + 1); // On met à jour le nombre de sous-familles

                // On ajoute un noeud correspondant au TreeView
                TreeNode NoeudParent = TrouverNoeudParTexte(ObjetTreeView.Nodes[1], NouvelleSousFamille.GetFamille().GetNom());
                NoeudParent.Nodes.Add(new TreeNode(NouvelleSousFamille.GetNom()));

                // Si les données affichées sont des sous-familles et la sous-familles crée respecte le filtre, on l'affiche
                if (TypeDonneesAffichees == "SousFamilles" 
                    && (TypeFiltre == "" || (TypeFiltre == "Famille" && Filtre == NouvelleSousFamille.GetFamille().GetNom())))
                    {
                    ListViewItem NouvelItem = new ListViewItem(NouvelleSousFamille.GetNom());
                    ObjetListView.Items.Add(NouvelItem);

                    // On refait le tri / groupement pour que la nouvelle sous-famile le respecte
                    if (IndiceColonne > -1)
                    {
                        ObjetListView_ColumnClick(ObjetListView, new ColumnClickEventArgs(IndiceColonne));
                    }
                }
            }
        }

        /// <summary>
        /// Ajout d'une marque depuis le menu contextuel du clique droit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreerMarqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddMarque NouveauFormAddMarque = new FormAddMarque();
            NouveauFormAddMarque.ShowDialog();

            Marque NouvelleMarque = NouveauFormAddMarque.GetMarque();

            // Si la famille est crée
            if (NouvelleMarque != null)
            {
                SetNombreMarques(NombreMarques + 1); // On met à jour le nombre de marques

                // On ajoute un noeud correspondant au TreeView
                ObjetTreeView.Nodes[2].Nodes.Add(new TreeNode(NouvelleMarque.GetNom()));

                // Si les données affichées sont des marques, on l'affiche
                if (TypeDonneesAffichees == "Marques") 
                { 
                    ListViewItem NouvelItem = new ListViewItem(NouvelleMarque.GetNom());
                    ObjetListView.Items.Add(NouvelItem);

                    // On refait le tri / groupement pour que la nouvelle marque le respecte
                    if (IndiceColonne > -1)
                    {
                        ObjetListView_ColumnClick(ObjetListView, new ColumnClickEventArgs(IndiceColonne));
                    }
                }
            }
        }

        /// <summary>
        /// Modification d'un element du list view depuis le menu contextuel du clique droit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifierUnObjetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierElement();
        }

        /// <summary>
        /// Suppression d'un element du list view depuis le menu contextuel du clique droit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupprimerLobjetSelectionneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupprimerElement();
        }

        /// <summary>
        /// Permet de gérer le tri des lignes lors d'un clic sur l'une des colonnes du list view
        /// </summary>
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
        /// <param name="NoeudParent"> Noeud à partir duquel il faut chercher </param>
        /// <param name="TexteDuNoeud"> Texte du Noeud recherché </param>
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

        /// <summary>
        /// Evenements pour le raccourci modification (DoubleClic)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObjetListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // On regarde si c'est un clic droit.
            if (e.Button == MouseButtons.Left)
            {
                ModifierElement();
            }
        }

        /// <summary>
        /// Méthode permettant de gérer la sauvegarde de la taille et de la position de la fenetre à la fermeture de l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Sauvegarde des positions et tailles dans le fichier App.config
            config.AppSettings.Settings["Gauche"].Value = Left.ToString();
            config.AppSettings.Settings["Haut"].Value = Top.ToString();
            config.AppSettings.Settings["Longueur"].Value = Width.ToString();
            config.AppSettings.Settings["Hauteur"].Value = Height.ToString();

            // Sauvegarde de l'état maximisé du form
            config.AppSettings.Settings["EtatMaximise"].Value = this.WindowState == FormWindowState.Maximized ? "True" : "False";

            config.Save(ConfigurationSaveMode.Modified);
        }

        /// <summary>
        /// Méthode permettant de charger la taille et de la position de la fenetre à la dernière session
        /// Appelée à l'ouverture de l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Recuperation des données sauvegardées lors de la dernière session
            int Gauche = int.Parse(config.AppSettings.Settings["Gauche"].Value);
            int Haut = int.Parse(config.AppSettings.Settings["Haut"].Value);
            int Longueur = int.Parse(config.AppSettings.Settings["Longueur"].Value);
            int Hauteur = int.Parse(config.AppSettings.Settings["Hauteur"].Value);
            bool EtatMaximise = bool.Parse(config.AppSettings.Settings["EtatMaximise"].Value);

            if (EtatMaximise)
            {
                // Si la fenetre etait maximisee, on l'ouvre simplement maximisee
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                Rectangle Ecran = Screen.GetWorkingArea(this);

                // Sinon on définit la position et la taille de la fenêtre
                Width = Longueur;
                Height = Hauteur;
                Left = Gauche;
                Top = Haut;

                // On vérifie que la fenetre ne sort pas de l'écran
                if (!Ecran.Contains(this.Bounds))
                {
                    Left = Math.Max(Ecran.Left, Math.Min(Ecran.Right - Longueur, Gauche));
                    Top = Math.Max(Ecran.Top, Math.Min(Ecran.Bottom - Hauteur, Haut));
                }
            }
        }
    }
}
