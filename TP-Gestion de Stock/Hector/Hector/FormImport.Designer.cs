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
            this.SelectFile = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.CheckBoxAjout = new System.Windows.Forms.CheckBox();
            this.CheckBoxEcrasement = new System.Windows.Forms.CheckBox();
            this.FinishButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // SelectFile
            // 
            this.SelectFile.Location = new System.Drawing.Point(24, 18);
            this.SelectFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(177, 35);
            this.SelectFile.TabIndex = 0;
            this.SelectFile.Text = "Ouvrir le fichier .csv";
            this.SelectFile.UseVisualStyleBackColor = true;
            this.SelectFile.Click += new System.EventHandler(this.ImportButton);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.AutoSize = true;
            this.FilePathLabel.Location = new System.Drawing.Point(34, 85);
            this.FilePathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(17, 20);
            this.FilePathLabel.TabIndex = 4;
            this.FilePathLabel.Text = "./";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(0, 220);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 6);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(576, 43);
            this.ProgressBar.TabIndex = 5;
            // 
            // CheckBoxAjout
            // 
            this.CheckBoxAjout.AutoSize = true;
            this.CheckBoxAjout.Checked = true;
            this.CheckBoxAjout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxAjout.Location = new System.Drawing.Point(39, 169);
            this.CheckBoxAjout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CheckBoxAjout.Name = "CheckBoxAjout";
            this.CheckBoxAjout.Size = new System.Drawing.Size(139, 24);
            this.CheckBoxAjout.TabIndex = 6;
            this.CheckBoxAjout.Text = "Ouvrir en Ajout";
            this.CheckBoxAjout.UseVisualStyleBackColor = true;
            this.CheckBoxAjout.CheckedChanged += new System.EventHandler(this.CheckBoxAjout_CheckedChanged);
            // 
            // CheckBoxEcrasement
            // 
            this.CheckBoxEcrasement.AutoSize = true;
            this.CheckBoxEcrasement.Location = new System.Drawing.Point(338, 169);
            this.CheckBoxEcrasement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CheckBoxEcrasement.Name = "CheckBoxEcrasement";
            this.CheckBoxEcrasement.Size = new System.Drawing.Size(188, 24);
            this.CheckBoxEcrasement.TabIndex = 7;
            this.CheckBoxEcrasement.Text = "Ouvrir en Ecrasement";
            this.CheckBoxEcrasement.UseVisualStyleBackColor = true;
            this.CheckBoxEcrasement.CheckedChanged += new System.EventHandler(this.CheckBoxEcrasement_CheckedChanged);
            // 
            // FinishButton
            // 
            this.FinishButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FinishButton.Location = new System.Drawing.Point(0, 223);
            this.FinishButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(564, 35);
            this.FinishButton.TabIndex = 8;
            this.FinishButton.Text = "Finir";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 108);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(502, 53);
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // FormImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 258);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.CheckBoxEcrasement);
            this.Controls.Add(this.CheckBoxAjout);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.FilePathLabel);
            this.Controls.Add(this.SelectFile);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(586, 314);
            this.MinimumSize = new System.Drawing.Size(586, 314);
            this.Name = "FormImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Importer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectFile;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.CheckBox CheckBoxAjout;
        private System.Windows.Forms.CheckBox CheckBoxEcrasement;
        private System.Windows.Forms.Button FinishButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
    }
}