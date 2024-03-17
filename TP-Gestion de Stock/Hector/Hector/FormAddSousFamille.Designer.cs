
namespace Hector
{
    partial class FormAddSousFamille
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
            this.RefFamilleComboBox = new System.Windows.Forms.ComboBox();
            this.RefFamilleLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.RefArticlesTextBox = new System.Windows.Forms.TextBox();
            this.RefArticlesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RefFamilleComboBox
            // 
            this.RefFamilleComboBox.FormattingEnabled = true;
            this.RefFamilleComboBox.Location = new System.Drawing.Point(76, 37);
            this.RefFamilleComboBox.Name = "RefFamilleComboBox";
            this.RefFamilleComboBox.Size = new System.Drawing.Size(121, 21);
            this.RefFamilleComboBox.TabIndex = 37;
            // 
            // RefFamilleLabel
            // 
            this.RefFamilleLabel.AutoSize = true;
            this.RefFamilleLabel.Location = new System.Drawing.Point(12, 40);
            this.RefFamilleLabel.Name = "RefFamilleLabel";
            this.RefFamilleLabel.Size = new System.Drawing.Size(56, 13);
            this.RefFamilleLabel.TabIndex = 36;
            this.RefFamilleLabel.Text = "RefFamille";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(76, 76);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 35;
            this.CancelButton.Text = "Annuler";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(157, 76);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 34;
            this.CreateButton.Text = "Créer";
            this.CreateButton.UseVisualStyleBackColor = true;
            // 
            // RefArticlesTextBox
            // 
            this.RefArticlesTextBox.Location = new System.Drawing.Point(76, 6);
            this.RefArticlesTextBox.Name = "RefArticlesTextBox";
            this.RefArticlesTextBox.Size = new System.Drawing.Size(100, 20);
            this.RefArticlesTextBox.TabIndex = 33;
            // 
            // RefArticlesLabel
            // 
            this.RefArticlesLabel.AutoSize = true;
            this.RefArticlesLabel.Location = new System.Drawing.Point(12, 9);
            this.RefArticlesLabel.Name = "RefArticlesLabel";
            this.RefArticlesLabel.Size = new System.Drawing.Size(29, 13);
            this.RefArticlesLabel.TabIndex = 32;
            this.RefArticlesLabel.Text = "Nom";
            // 
            // FormAddSousFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 111);
            this.Controls.Add(this.RefFamilleComboBox);
            this.Controls.Add(this.RefFamilleLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.RefArticlesTextBox);
            this.Controls.Add(this.RefArticlesLabel);
            this.MaximumSize = new System.Drawing.Size(250, 150);
            this.MinimumSize = new System.Drawing.Size(250, 150);
            this.Name = "FormAddSousFamille";
            this.Text = "Créer une nouvelle Sous-Famille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox RefFamilleComboBox;
        private System.Windows.Forms.Label RefFamilleLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.TextBox RefArticlesTextBox;
        private System.Windows.Forms.Label RefArticlesLabel;
    }
}