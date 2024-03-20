
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
            this.SelectFile = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.FinishButton = new System.Windows.Forms.Button();
            this.CheckBoxEcrasement = new System.Windows.Forms.CheckBox();
            this.CheckBoxAjout = new System.Windows.Forms.CheckBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // SelectFile
            // 
            this.SelectFile.Location = new System.Drawing.Point(22, 9);
            this.SelectFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(260, 35);
            this.SelectFile.TabIndex = 9;
            this.SelectFile.Text = "Sauvgarder dans un fichier .csv";
            this.SelectFile.UseVisualStyleBackColor = true;
            this.SelectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // FinishButton
            // 
            this.FinishButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FinishButton.Location = new System.Drawing.Point(0, 250);
            this.FinishButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(573, 35);
            this.FinishButton.TabIndex = 14;
            this.FinishButton.Text = "Extraire";
            this.FinishButton.UseVisualStyleBackColor = true;
            // 
            // CheckBoxEcrasement
            // 
            this.CheckBoxEcrasement.AutoSize = true;
            this.CheckBoxEcrasement.Location = new System.Drawing.Point(298, 160);
            this.CheckBoxEcrasement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CheckBoxEcrasement.Name = "CheckBoxEcrasement";
            this.CheckBoxEcrasement.Size = new System.Drawing.Size(238, 24);
            this.CheckBoxEcrasement.TabIndex = 13;
            this.CheckBoxEcrasement.Text = "Sauvegarder en Ecrasement";
            this.CheckBoxEcrasement.UseVisualStyleBackColor = true;
            this.CheckBoxEcrasement.CheckedChanged += new System.EventHandler(this.CheckBoxEcrasement_CheckedChanged);
            // 
            // CheckBoxAjout
            // 
            this.CheckBoxAjout.AutoSize = true;
            this.CheckBoxAjout.Checked = true;
            this.CheckBoxAjout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxAjout.Location = new System.Drawing.Point(38, 160);
            this.CheckBoxAjout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CheckBoxAjout.Name = "CheckBoxAjout";
            this.CheckBoxAjout.Size = new System.Drawing.Size(189, 24);
            this.CheckBoxAjout.TabIndex = 12;
            this.CheckBoxAjout.Text = "Sauvegarder en Ajout";
            this.CheckBoxAjout.UseVisualStyleBackColor = true;
            this.CheckBoxAjout.CheckedChanged += new System.EventHandler(this.CheckBoxAjout_CheckedChanged);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(-2, 211);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 6);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(576, 43);
            this.ProgressBar.TabIndex = 11;
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.AutoSize = true;
            this.FilePathLabel.Location = new System.Drawing.Point(33, 75);
            this.FilePathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(17, 20);
            this.FilePathLabel.TabIndex = 10;
            this.FilePathLabel.Text = "./";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 285);
            this.Controls.Add(this.SelectFile);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.CheckBoxEcrasement);
            this.Controls.Add(this.CheckBoxAjout);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.FilePathLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormExport";
            this.Text = "FormExport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectFile;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button FinishButton;
        private System.Windows.Forms.CheckBox CheckBoxEcrasement;
        private System.Windows.Forms.CheckBox CheckBoxAjout;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}