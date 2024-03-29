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
    public partial class FormModifyArticle : Form
    {
        Article ArticleSelectionnee;
        public FormModifyArticle(Article ArticleParam)
        {
            InitializeComponent();
            ArticleSelectionnee = ArticleParam;

            string NomSousFamilleArticleSelectionnee = ArticleSelectionnee.GetSousFamille().GetNom();
            foreach (SousFamille SousFamilleExistante in SousFamille.GetDictionnaireSousFamilles())
            {
                string Nom = SousFamilleExistante.GetNom();
                if (Nom != NomSousFamilleArticleSelectionnee)
                    SousFamilleComboBox.Items.Add(Nom);
            }
            SousFamilleComboBox.Items.Add(NomSousFamilleArticleSelectionnee);
            SousFamilleComboBox.SelectedIndex = 0;


            string NomMarqueArticleSelectionnee = ArticleSelectionnee.GetMarque().GetNom();
            foreach (Marque MarqueExistante in Marque.GetDictionnaireMarques())
            {
                string Nom = MarqueExistante.GetNom();
                if (Nom != NomSousFamilleArticleSelectionnee)
                    MarqueComboBox.Items.Add(MarqueExistante.GetNom());
            }
            MarqueComboBox.Items.Add(NomMarqueArticleSelectionnee);
            MarqueComboBox.SelectedIndex = 0;

            RefArticlesTextBox.Text = ArticleSelectionnee.GetReference();
            DescriptionTextBox.Text = ArticleSelectionnee.GetDescription();
            PrixHTTextBox.Text = ArticleSelectionnee.GetPrixHT().ToString();
            QuantiteTextBox.Text = ArticleSelectionnee.GetQuantite().ToString();
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                SousFamille SousFamilleSelectionnee = SousFamille.GetSousFamilleExistante(SousFamilleComboBox.Text);
                Marque MarqueSelectionne = Marque.GetMarqueExistante(MarqueComboBox.Text);

                double PrixHT;
                if (!double.TryParse(PrixHTTextBox.Text, out PrixHT))
                {
                    throw new Exception(Exception.ERREUR_PARSING_DOUBLE);
                }

                uint Quantite;
                if (!uint.TryParse(QuantiteTextBox.Text, out Quantite))
                {
                    throw new Exception(Exception.ERREUR_PARSING_UINT);
                }

                if (ArticleSelectionnee.SetReference(RefArticlesTextBox.Text) == Exception.RETOUR_ERREUR)
                {
                    return;
                }

                ArticleSelectionnee.SetDescription(DescriptionTextBox.Text);
                ArticleSelectionnee.SetMarque(MarqueSelectionne);
                ArticleSelectionnee.SetSousFamille(SousFamilleSelectionnee);
                ArticleSelectionnee.SetPrixHT(PrixHT);
                ArticleSelectionnee.SetQuantite(Quantite);

                MessageBox.Show("Creer avec succes", "Tout bon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                
            } catch (Exception ExceptionAttrapee)
            {
                ExceptionAttrapee.AfficherMessageErreur();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
