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
    public partial class FormAddArticle : Form
    {
        public FormAddArticle()
        {
            InitializeComponent();

            foreach(SousFamille SousFamilleExistante in SousFamille.GetDictionnaireSousFamilles())
            {
                SousFamilleComboBox.Items.Add(SousFamilleExistante.GetNom());
            }
            SousFamilleComboBox.SelectedIndex = 0;

            foreach (Marque MarqueExistante in Marque.GetDictionnaireMarques())
            {
                MarqueComboBox.Items.Add(MarqueExistante.GetNom());
            }
            MarqueComboBox.SelectedIndex = 0;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                /*On vérifie que les champs obligatoires sont remplis */
                if (RefArticlesTextBox.Text != "" && SousFamilleComboBox.Items.Count > 0 && MarqueComboBox.Items.Count > 0 && DescriptionTextBox.Text != ""
                    && QuantiteTextBox.Text != "" && PrixHTTextBox.Text != "")
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

                    Console.WriteLine(RefArticlesTextBox.Text);

                    Article NouvelArticle = Article.CreerArticle(DescriptionTextBox.Text, RefArticlesTextBox.Text, MarqueSelectionne, SousFamilleSelectionnee,
                        PrixHT, Quantite);

                    if (NouvelArticle != null)
                    {
                        MessageBox.Show("Creer avec succes", "Tout bon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    if (RefArticlesTextBox.Text == "")
                    {
                        MessageBox.Show("Le champ RefArticle est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (SousFamilleComboBox.Items.Count <= 0)
                    {
                        MessageBox.Show("Le champ SousFamille est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (MarqueComboBox.Items.Count <= 0)
                    {
                        MessageBox.Show("Le champ Marque est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (DescriptionTextBox.Text == "")
                    {
                        MessageBox.Show("Le champ Description est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (QuantiteTextBox.Text == "")
                    {
                        MessageBox.Show("Le champ Quantite est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (PrixHTTextBox.Text == "")
                    {
                        MessageBox.Show("Le champ PrixHT est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
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
