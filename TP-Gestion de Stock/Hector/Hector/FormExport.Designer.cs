
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
            this.CheminTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SelectionFichier
            // 
            this.SelectionFichier.Location = new System.Drawing.Point(8, 6);
            this.SelectionFichier.Name = "SelectionFichier";
            this.SelectionFichier.Size = new System.Drawing.Size(185, 28);
            this.SelectionFichier.TabIndex = 9;
            this.SelectionFichier.Text = "Sauvgarder dans un fichier .csv";
            this.SelectionFichier.UseVisualStyleBackColor = true;
            this.SelectionFichier.Click += new System.EventHandler(this.SelectionFichier_Click);
            // 
            // BoutonExtraire
            // 
            this.BoutonExtraire.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BoutonExtraire.Location = new System.Drawing.Point(0, 88);
            this.BoutonExtraire.Name = "BoutonExtraire";
            this.BoutonExtraire.Size = new System.Drawing.Size(414, 38);
            this.BoutonExtraire.TabIndex = 14;
            this.BoutonExtraire.Text = "Extraire";
            this.BoutonExtraire.UseVisualStyleBackColor = true;
            this.BoutonExtraire.Click += new System.EventHandler(this.BoutonExtraire_Click);
            // 
            // ObjetSaveFileDialog
            // 
            this.ObjetSaveFileDialog.FileName = "openFileDialog1";
            // 
            // CheminTextBox
            // 
            this.CheminTextBox.Location = new System.Drawing.Point(11, 49);
            this.CheminTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheminTextBox.Name = "CheminTextBox";
            this.CheminTextBox.ReadOnly = true;
            this.CheminTextBox.Size = new System.Drawing.Size(392, 20);
            this.CheminTextBox.TabIndex = 31;
            this.CheminTextBox.Text = "./";
            // 
            // FormExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 126);
            this.Controls.Add(this.CheminTextBox);
            this.Controls.Add(this.SelectionFichier);
            this.Controls.Add(this.BoutonExtraire);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormExport";
            this.Text = "Extraire";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectionFichier;
        private System.Windows.Forms.Button BoutonExtraire;
        private System.Windows.Forms.OpenFileDialog ObjetSaveFileDialog;
        private System.Windows.Forms.TextBox CheminTextBox;
    }
}