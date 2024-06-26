﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hector
{
    public partial class FormAddSousFamille : Form
    {
        private SousFamille NouvelleSousFamillee;

        /// <summary>
        /// Accesseur en lecture de la SousFamille crée
        /// </summary>
        /// <returns> NouvelleSousFamillee </returns>
        public SousFamille GetSousFamille()
        {
            return NouvelleSousFamillee;
        }

        /// <summary>
        /// Constructeur de la classe FormAddSousFamille
        /// </summary>
        public FormAddSousFamille()
        {
            InitializeComponent();
            NouvelleSousFamillee = null;

            foreach (Famille FamilleExistante in Famille.GetListeFamilles())
            {
                FamilleComboBox.Items.Add(FamilleExistante.GetNom());
            }

            FamilleComboBox.SelectedIndex = 0;
        }
        
        /// <summary>
        /// Méthode permettant de créer une sous-famille
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonCreer_Click(object sender, EventArgs e)
        {
            if (NomSousFamilleTextBox.Text != "" && FamilleComboBox.Items.Count > 0)
            {
                Famille FamilleSelectionnee = Famille.GetFamilleExistante(FamilleComboBox.Text);
                NouvelleSousFamillee = SousFamille.CreerSousFamille(NomSousFamilleTextBox.Text, FamilleSelectionnee);

                if (NouvelleSousFamillee != null)
                {
                    MessageBox.Show("Creer avec succes", "Tout bon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                if (NomSousFamilleTextBox.Text == "")
                    MessageBox.Show("Le champ Nom est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                    MessageBox.Show("Aucune Famille n'est selectionne", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Méthode permettant de fermer la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonAnnulation_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
