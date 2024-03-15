
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
            this.selectButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.checkBoxAjout = new System.Windows.Forms.CheckBox();
            this.checkBoxEcrasement = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(16, 12);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(96, 23);
            this.selectButton.TabIndex = 0;
            this.selectButton.Text = "Open .csv file";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Location = new System.Drawing.Point(23, 55);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(15, 13);
            this.filePathLabel.TabIndex = 4;
            this.filePathLabel.Text = "./";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 168);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(384, 23);
            this.progressBar.TabIndex = 5;
            // 
            // checkBoxAjout
            // 
            this.checkBoxAjout.AutoSize = true;
            this.checkBoxAjout.Location = new System.Drawing.Point(35, 136);
            this.checkBoxAjout.Name = "checkBoxAjout";
            this.checkBoxAjout.Size = new System.Drawing.Size(96, 17);
            this.checkBoxAjout.TabIndex = 6;
            this.checkBoxAjout.Text = "Ouvrir en Ajout";
            this.checkBoxAjout.UseVisualStyleBackColor = true;
            this.checkBoxAjout.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxEcrasement
            // 
            this.checkBoxEcrasement.AutoSize = true;
            this.checkBoxEcrasement.Location = new System.Drawing.Point(224, 136);
            this.checkBoxEcrasement.Name = "checkBoxEcrasement";
            this.checkBoxEcrasement.Size = new System.Drawing.Size(128, 17);
            this.checkBoxEcrasement.TabIndex = 7;
            this.checkBoxEcrasement.Text = "Ouvrir en Ecrasement";
            this.checkBoxEcrasement.UseVisualStyleBackColor = true;
            // 
            // FormImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 191);
            this.Controls.Add(this.checkBoxEcrasement);
            this.Controls.Add(this.checkBoxAjout);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.selectButton);
            this.Name = "FormImport";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox checkBoxAjout;
        private System.Windows.Forms.CheckBox checkBoxEcrasement;
    }
}