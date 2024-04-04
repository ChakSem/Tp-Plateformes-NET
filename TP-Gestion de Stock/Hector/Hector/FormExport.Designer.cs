﻿
namespace Hector
{
    partial class FormExport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectionFichier = new System.Windows.Forms.Button();
            this.BoutonExtraire = new System.Windows.Forms.Button();
            this.ObjetSaveFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.CheminLabel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SelectionFichier
            // 
            this.SelectionFichier.Location = new System.Drawing.Point(12, 9);
            this.SelectionFichier.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SelectionFichier.Name = "SelectionFichier";
            this.SelectionFichier.Size = new System.Drawing.Size(548, 43);
            this.SelectionFichier.TabIndex = 9;
            this.SelectionFichier.Text = "Sauvgarder dans un fichier .csv";
            this.SelectionFichier.UseVisualStyleBackColor = true;
            this.SelectionFichier.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // BoutonExtraire
            // 
            this.BoutonExtraire.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BoutonExtraire.Location = new System.Drawing.Point(0, 109);
            this.BoutonExtraire.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BoutonExtraire.Name = "BoutonExtraire";
            this.BoutonExtraire.Size = new System.Drawing.Size(573, 59);
            this.BoutonExtraire.TabIndex = 14;
            this.BoutonExtraire.Text = "Extraire";
            this.BoutonExtraire.UseVisualStyleBackColor = true;
            this.BoutonExtraire.Click += new System.EventHandler(this.BoutonExtraire_Click);
            // 
            // ObjetSaveFileDialog
            // 
            this.ObjetSaveFileDialog.FileName = "openFileDialog1";
            // 
            // CheminLabel
            // 
            this.CheminLabel.Location = new System.Drawing.Point(12, 75);
            this.CheminLabel.Name = "CheminLabel";
            this.CheminLabel.ReadOnly = true;
            this.CheminLabel.Size = new System.Drawing.Size(549, 26);
            this.CheminLabel.TabIndex = 15;
            this.CheminLabel.Text = "./";
            // 
            // FormExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 168);
            this.Controls.Add(this.SelectionFichier);
            this.Controls.Add(this.BoutonExtraire);
            this.Controls.Add(this.CheminLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormExport";
            this.Text = "Extraire";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectionFichier;
        private System.Windows.Forms.Button BoutonExtraire;
        private System.Windows.Forms.OpenFileDialog ObjetSaveFileDialog;
        private System.Windows.Forms.TextBox CheminLabel;
    }
}