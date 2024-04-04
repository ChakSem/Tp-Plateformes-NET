
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
            this.CheminLabel = new System.Windows.Forms.Label();
            this.ObjetSaveFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // SelectionFichier
            // 
            this.SelectionFichier.Location = new System.Drawing.Point(15, 6);
            this.SelectionFichier.Name = "SelectionFichier";
            this.SelectionFichier.Size = new System.Drawing.Size(173, 23);
            this.SelectionFichier.TabIndex = 9;
            this.SelectionFichier.Text = "Sauvgarder dans un fichier .csv";
            this.SelectionFichier.UseVisualStyleBackColor = true;
            this.SelectionFichier.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // BoutonExtraire
            // 
            this.BoutonExtraire.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BoutonExtraire.Location = new System.Drawing.Point(0, 86);
            this.BoutonExtraire.Name = "BoutonExtraire";
            this.BoutonExtraire.Size = new System.Drawing.Size(382, 23);
            this.BoutonExtraire.TabIndex = 14;
            this.BoutonExtraire.Text = "Extraire";
            this.BoutonExtraire.UseVisualStyleBackColor = true;
            // 
            // CheminLabel
            // 
            this.CheminLabel.AutoSize = true;
            this.CheminLabel.Location = new System.Drawing.Point(22, 49);
            this.CheminLabel.Name = "CheminLabel";
            this.CheminLabel.Size = new System.Drawing.Size(15, 13);
            this.CheminLabel.TabIndex = 10;
            this.CheminLabel.Text = "./";
            // 
            // ObjetSaveFileDialog
            // 
            this.ObjetSaveFileDialog.FileName = "openFileDialog1";
            // 
            // FormExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 109);
            this.Controls.Add(this.SelectionFichier);
            this.Controls.Add(this.BoutonExtraire);
            this.Controls.Add(this.CheminLabel);
            this.Name = "FormExport";
            this.Text = "Extraire";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectionFichier;
        private System.Windows.Forms.Button BoutonExtraire;
        private System.Windows.Forms.Label CheminLabel;
        private System.Windows.Forms.OpenFileDialog ObjetSaveFileDialog;
    }
}