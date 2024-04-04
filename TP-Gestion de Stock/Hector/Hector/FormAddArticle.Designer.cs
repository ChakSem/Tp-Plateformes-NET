
namespace Hector
{
    partial class FormAddArticle
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
            this.BoutonCreer = new System.Windows.Forms.Button();
            this.BoutonAnnulation = new System.Windows.Forms.Button();
            this.MarqueComboBox = new System.Windows.Forms.ComboBox();
            this.SousFamilleComboBox = new System.Windows.Forms.ComboBox();
            this.PrixHTTextBox = new System.Windows.Forms.TextBox();
            this.PrixHTLabel = new System.Windows.Forms.Label();
            this.QuantiteTextBox = new System.Windows.Forms.TextBox();
            this.QuantiteLabel = new System.Windows.Forms.Label();
            this.MarqueLabel = new System.Windows.Forms.Label();
            this.SousFamilleLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.RefArticlesTextBox = new System.Windows.Forms.TextBox();
            this.RefArticlesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BoutonCreer
            // 
            this.BoutonCreer.Location = new System.Drawing.Point(297, 156);
            this.BoutonCreer.Name = "BoutonCreer";
            this.BoutonCreer.Size = new System.Drawing.Size(75, 23);
            this.BoutonCreer.TabIndex = 14;
            this.BoutonCreer.Text = "Créer";
            this.BoutonCreer.UseVisualStyleBackColor = true;
            this.BoutonCreer.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // BoutonAnnulation
            // 
            this.BoutonAnnulation.Location = new System.Drawing.Point(216, 156);
            this.BoutonAnnulation.Name = "BoutonAnnulation";
            this.BoutonAnnulation.Size = new System.Drawing.Size(75, 23);
            this.BoutonAnnulation.TabIndex = 15;
            this.BoutonAnnulation.Text = "Annuler";
            this.BoutonAnnulation.UseVisualStyleBackColor = true;
            this.BoutonAnnulation.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // MarqueComboBox
            // 
            this.MarqueComboBox.FormattingEnabled = true;
            this.MarqueComboBox.Location = new System.Drawing.Point(76, 77);
            this.MarqueComboBox.Name = "MarqueComboBox";
            this.MarqueComboBox.Size = new System.Drawing.Size(121, 21);
            this.MarqueComboBox.TabIndex = 39;
            // 
            // SousFamilleComboBox
            // 
            this.SousFamilleComboBox.FormattingEnabled = true;
            this.SousFamilleComboBox.Location = new System.Drawing.Point(76, 41);
            this.SousFamilleComboBox.Name = "SousFamilleComboBox";
            this.SousFamilleComboBox.Size = new System.Drawing.Size(121, 21);
            this.SousFamilleComboBox.TabIndex = 38;
            // 
            // PrixHTTextBox
            // 
            this.PrixHTTextBox.Location = new System.Drawing.Point(76, 117);
            this.PrixHTTextBox.Name = "PrixHTTextBox";
            this.PrixHTTextBox.Size = new System.Drawing.Size(100, 20);
            this.PrixHTTextBox.TabIndex = 37;
            // 
            // PrixHTLabel
            // 
            this.PrixHTLabel.AutoSize = true;
            this.PrixHTLabel.Location = new System.Drawing.Point(12, 120);
            this.PrixHTLabel.Name = "PrixHTLabel";
            this.PrixHTLabel.Size = new System.Drawing.Size(39, 13);
            this.PrixHTLabel.TabIndex = 36;
            this.PrixHTLabel.Text = "PrixHT";
            // 
            // QuantiteTextBox
            // 
            this.QuantiteTextBox.Location = new System.Drawing.Point(265, 117);
            this.QuantiteTextBox.Name = "QuantiteTextBox";
            this.QuantiteTextBox.Size = new System.Drawing.Size(100, 20);
            this.QuantiteTextBox.TabIndex = 35;
            // 
            // QuantiteLabel
            // 
            this.QuantiteLabel.AutoSize = true;
            this.QuantiteLabel.Location = new System.Drawing.Point(212, 120);
            this.QuantiteLabel.Name = "QuantiteLabel";
            this.QuantiteLabel.Size = new System.Drawing.Size(47, 13);
            this.QuantiteLabel.TabIndex = 34;
            this.QuantiteLabel.Text = "Quantite";
            // 
            // MarqueLabel
            // 
            this.MarqueLabel.AutoSize = true;
            this.MarqueLabel.Location = new System.Drawing.Point(12, 80);
            this.MarqueLabel.Name = "MarqueLabel";
            this.MarqueLabel.Size = new System.Drawing.Size(43, 13);
            this.MarqueLabel.TabIndex = 33;
            this.MarqueLabel.Text = "Marque";
            // 
            // SousFamilleLabel
            // 
            this.SousFamilleLabel.AutoSize = true;
            this.SousFamilleLabel.Location = new System.Drawing.Point(12, 44);
            this.SousFamilleLabel.Name = "SousFamilleLabel";
            this.SousFamilleLabel.Size = new System.Drawing.Size(63, 13);
            this.SousFamilleLabel.TabIndex = 32;
            this.SousFamilleLabel.Text = "SousFamille";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(265, 6);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(115, 92);
            this.DescriptionTextBox.TabIndex = 31;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(199, 9);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 30;
            this.DescriptionLabel.Text = "Description";
            // 
            // RefArticlesTextBox
            // 
            this.RefArticlesTextBox.Location = new System.Drawing.Point(76, 6);
            this.RefArticlesTextBox.Name = "RefArticlesTextBox";
            this.RefArticlesTextBox.Size = new System.Drawing.Size(100, 20);
            this.RefArticlesTextBox.TabIndex = 29;
            // 
            // RefArticlesLabel
            // 
            this.RefArticlesLabel.AutoSize = true;
            this.RefArticlesLabel.Location = new System.Drawing.Point(12, 9);
            this.RefArticlesLabel.Name = "RefArticlesLabel";
            this.RefArticlesLabel.Size = new System.Drawing.Size(58, 13);
            this.RefArticlesLabel.TabIndex = 28;
            this.RefArticlesLabel.Text = "RefArticles";
            // 
            // FormAddArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 185);
            this.Controls.Add(this.MarqueComboBox);
            this.Controls.Add(this.SousFamilleComboBox);
            this.Controls.Add(this.PrixHTTextBox);
            this.Controls.Add(this.PrixHTLabel);
            this.Controls.Add(this.QuantiteTextBox);
            this.Controls.Add(this.QuantiteLabel);
            this.Controls.Add(this.MarqueLabel);
            this.Controls.Add(this.SousFamilleLabel);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.RefArticlesTextBox);
            this.Controls.Add(this.RefArticlesLabel);
            this.Controls.Add(this.BoutonAnnulation);
            this.Controls.Add(this.BoutonCreer);
            this.MaximumSize = new System.Drawing.Size(398, 224);
            this.MinimumSize = new System.Drawing.Size(398, 224);
            this.Name = "FormAddArticle";
            this.Text = "Créer un nouvel Article";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BoutonCreer;
        private System.Windows.Forms.Button BoutonAnnulation;
        private System.Windows.Forms.ComboBox MarqueComboBox;
        private System.Windows.Forms.ComboBox SousFamilleComboBox;
        private System.Windows.Forms.TextBox PrixHTTextBox;
        private System.Windows.Forms.Label PrixHTLabel;
        private System.Windows.Forms.TextBox QuantiteTextBox;
        private System.Windows.Forms.Label QuantiteLabel;
        private System.Windows.Forms.Label MarqueLabel;
        private System.Windows.Forms.Label SousFamilleLabel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox RefArticlesTextBox;
        private System.Windows.Forms.Label RefArticlesLabel;
    }
}