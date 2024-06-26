﻿
namespace Hector
{
    partial class FormImport
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
            this.ObjetBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.BarreDeProgression = new System.Windows.Forms.ProgressBar();
            this.CheckBoxAjout = new System.Windows.Forms.CheckBox();
            this.CheckBoxEcrasement = new System.Windows.Forms.CheckBox();
            this.BoutonImporter = new System.Windows.Forms.Button();
            this.ObjetOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.CheminTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SelectionFichier
            // 
            this.SelectionFichier.Location = new System.Drawing.Point(8, 9);
            this.SelectionFichier.Name = "SelectionFichier";
            this.SelectionFichier.Size = new System.Drawing.Size(358, 38);
            this.SelectionFichier.TabIndex = 0;
            this.SelectionFichier.Text = "Ouvrir le fichier .csv";
            this.SelectionFichier.UseVisualStyleBackColor = true;
            this.SelectionFichier.Click += new System.EventHandler(this.SelectionFichier_Click);
            // 
            // ObjetBackgroundWorker
            // 
            this.ObjetBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ObjetBackgroundWorker_DoWork);
            this.ObjetBackgroundWorker.ProgressChanged += ObjetBackgroundWorker_ProgressChanged;
            // 
            // BarreDeProgression
            // 
            this.BarreDeProgression.Location = new System.Drawing.Point(0, 124);
            this.BarreDeProgression.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.BarreDeProgression.Name = "BarreDeProgression";
            this.BarreDeProgression.Size = new System.Drawing.Size(374, 36);
            this.BarreDeProgression.TabIndex = 5;
            // 
            // CheckBoxAjout
            // 
            this.CheckBoxAjout.AutoSize = true;
            this.CheckBoxAjout.Checked = true;
            this.CheckBoxAjout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxAjout.Location = new System.Drawing.Point(24, 101);
            this.CheckBoxAjout.Name = "CheckBoxAjout";
            this.CheckBoxAjout.Size = new System.Drawing.Size(96, 17);
            this.CheckBoxAjout.TabIndex = 6;
            this.CheckBoxAjout.Text = "Ouvrir en Ajout";
            this.CheckBoxAjout.UseVisualStyleBackColor = true;
            this.CheckBoxAjout.CheckedChanged += new System.EventHandler(this.CheckBoxAjout_CheckedChanged);
            // 
            // CheckBoxEcrasement
            // 
            this.CheckBoxEcrasement.AutoSize = true;
            this.CheckBoxEcrasement.Location = new System.Drawing.Point(223, 101);
            this.CheckBoxEcrasement.Name = "CheckBoxEcrasement";
            this.CheckBoxEcrasement.Size = new System.Drawing.Size(128, 17);
            this.CheckBoxEcrasement.TabIndex = 7;
            this.CheckBoxEcrasement.Text = "Ouvrir en Ecrasement";
            this.CheckBoxEcrasement.UseVisualStyleBackColor = true;
            this.CheckBoxEcrasement.CheckedChanged += new System.EventHandler(this.CheckBoxEcrasement_CheckedChanged);
            // 
            // BoutonImporter
            // 
            this.BoutonImporter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BoutonImporter.Location = new System.Drawing.Point(0, 150);
            this.BoutonImporter.Name = "BoutonImporter";
            this.BoutonImporter.Size = new System.Drawing.Size(378, 23);
            this.BoutonImporter.TabIndex = 8;
            this.BoutonImporter.Text = "Démarrer l\'importation";
            this.BoutonImporter.UseVisualStyleBackColor = true;
            this.BoutonImporter.Click += new System.EventHandler(this.BoutonImporter_Click);
            // 
            // ObjetOpenFileDialog
            // 
            this.ObjetOpenFileDialog.FileName = "openFileDialog1";
            // 
            // CheminTextBox
            // 
            this.CheminTextBox.Location = new System.Drawing.Point(24, 61);
            this.CheminTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheminTextBox.Name = "CheminTextBox";
            this.CheminTextBox.ReadOnly = true;
            this.CheminTextBox.Size = new System.Drawing.Size(327, 20);
            this.CheminTextBox.TabIndex = 30;
            this.CheminTextBox.Text = "./";
            // 
            // FormImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 173);
            this.Controls.Add(this.CheminTextBox);
            this.Controls.Add(this.BoutonImporter);
            this.Controls.Add(this.CheckBoxEcrasement);
            this.Controls.Add(this.CheckBoxAjout);
            this.Controls.Add(this.BarreDeProgression);
            this.Controls.Add(this.SelectionFichier);
            this.MaximumSize = new System.Drawing.Size(394, 212);
            this.MinimumSize = new System.Drawing.Size(394, 212);
            this.Name = "FormImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Importer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectionFichier;
        private System.ComponentModel.BackgroundWorker ObjetBackgroundWorker;
        private System.Windows.Forms.ProgressBar BarreDeProgression;
        private System.Windows.Forms.CheckBox CheckBoxAjout;
        private System.Windows.Forms.CheckBox CheckBoxEcrasement;
        private System.Windows.Forms.Button BoutonImporter;
        private System.Windows.Forms.OpenFileDialog ObjetOpenFileDialog;
        private System.Windows.Forms.TextBox CheminTextBox;
    }
}