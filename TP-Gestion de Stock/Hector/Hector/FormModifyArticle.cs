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
        public FormModifyArticle(Article ArticleSelectionnee)
        {
            InitializeComponent();

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
        }
    }
}
