
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
            this.CreateButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.RefMarqueComboBox = new System.Windows.Forms.ComboBox();
            this.RefSousFamilleComboBox = new System.Windows.Forms.ComboBox();
            this.PrixHTTextBox = new System.Windows.Forms.TextBox();
            this.PrixHTLabel = new System.Windows.Forms.Label();
            this.QuantiteTextBox = new System.Windows.Forms.TextBox();
            this.QuantiteLabel = new System.Windows.Forms.Label();
            this.RefMarqueLabel = new System.Windows.Forms.Label();
            this.RefSousFamilleLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.RefArticlesTextBox = new System.Windows.Forms.TextBox();
            this.RefArticlesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(446, 240);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(112, 35);
            this.CreateButton.TabIndex = 14;
            this.CreateButton.Text = "Créer";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(324, 240);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(112, 35);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "Annuler";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // RefMarqueComboBox
            // 
            this.RefMarqueComboBox.FormattingEnabled = true;
            this.RefMarqueComboBox.Location = new System.Drawing.Point(140, 118);
            this.RefMarqueComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RefMarqueComboBox.Name = "RefMarqueComboBox";
            this.RefMarqueComboBox.Size = new System.Drawing.Size(180, 28);
            this.RefMarqueComboBox.TabIndex = 39;
            // 
            // RefSousFamilleComboBox
            // 
            this.RefSousFamilleComboBox.FormattingEnabled = true;
            this.RefSousFamilleComboBox.Location = new System.Drawing.Point(140, 63);
            this.RefSousFamilleComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RefSousFamilleComboBox.Name = "RefSousFamilleComboBox";
            this.RefSousFamilleComboBox.Size = new System.Drawing.Size(180, 28);
            this.RefSousFamilleComboBox.TabIndex = 38;
            this.RefSousFamilleComboBox.SelectedIndexChanged += new System.EventHandler(this.RefSousFamilleComboBox_SelectedIndexChanged);
            // 
            // PrixHTTextBox
            // 
            this.PrixHTTextBox.Location = new System.Drawing.Point(140, 180);
            this.PrixHTTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PrixHTTextBox.Name = "PrixHTTextBox";
            this.PrixHTTextBox.Size = new System.Drawing.Size(148, 26);
            this.PrixHTTextBox.TabIndex = 37;
            // 
            // PrixHTLabel
            // 
            this.PrixHTLabel.AutoSize = true;
            this.PrixHTLabel.Location = new System.Drawing.Point(18, 185);
            this.PrixHTLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PrixHTLabel.Name = "PrixHTLabel";
            this.PrixHTLabel.Size = new System.Drawing.Size(55, 20);
            this.PrixHTLabel.TabIndex = 36;
            this.PrixHTLabel.Text = "PrixHT";
            // 
            // QuantiteTextBox
            // 
            this.QuantiteTextBox.Location = new System.Drawing.Point(398, 180);
            this.QuantiteTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.QuantiteTextBox.Name = "QuantiteTextBox";
            this.QuantiteTextBox.Size = new System.Drawing.Size(148, 26);
            this.QuantiteTextBox.TabIndex = 35;
            // 
            // QuantiteLabel
            // 
            this.QuantiteLabel.AutoSize = true;
            this.QuantiteLabel.Location = new System.Drawing.Point(318, 185);
            this.QuantiteLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.QuantiteLabel.Name = "QuantiteLabel";
            this.QuantiteLabel.Size = new System.Drawing.Size(70, 20);
            this.QuantiteLabel.TabIndex = 34;
            this.QuantiteLabel.Text = "Quantite";
            // 
            // RefMarqueLabel
            // 
            this.RefMarqueLabel.AutoSize = true;
            this.RefMarqueLabel.Location = new System.Drawing.Point(18, 123);
            this.RefMarqueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RefMarqueLabel.Name = "RefMarqueLabel";
            this.RefMarqueLabel.Size = new System.Drawing.Size(89, 20);
            this.RefMarqueLabel.TabIndex = 33;
            this.RefMarqueLabel.Text = "RefMarque";
            // 
            // RefSousFamilleLabel
            // 
            this.RefSousFamilleLabel.AutoSize = true;
            this.RefSousFamilleLabel.Location = new System.Drawing.Point(18, 68);
            this.RefSousFamilleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RefSousFamilleLabel.Name = "RefSousFamilleLabel";
            this.RefSousFamilleLabel.Size = new System.Drawing.Size(122, 20);
            this.RefSousFamilleLabel.TabIndex = 32;
            this.RefSousFamilleLabel.Text = "RefSousFamille";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(398, 9);
            this.DescriptionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(170, 139);
            this.DescriptionTextBox.TabIndex = 31;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(298, 14);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(89, 20);
            this.DescriptionLabel.TabIndex = 30;
            this.DescriptionLabel.Text = "Description";
            // 
            // RefArticlesTextBox
            // 
            this.RefArticlesTextBox.Location = new System.Drawing.Point(140, 9);
            this.RefArticlesTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RefArticlesTextBox.Name = "RefArticlesTextBox";
            this.RefArticlesTextBox.Size = new System.Drawing.Size(148, 26);
            this.RefArticlesTextBox.TabIndex = 29;
            // 
            // RefArticlesLabel
            // 
            this.RefArticlesLabel.AutoSize = true;
            this.RefArticlesLabel.Location = new System.Drawing.Point(18, 14);
            this.RefArticlesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RefArticlesLabel.Name = "RefArticlesLabel";
            this.RefArticlesLabel.Size = new System.Drawing.Size(87, 20);
            this.RefArticlesLabel.TabIndex = 28;
            this.RefArticlesLabel.Text = "RefArticles";
            // 
            // FormAddArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 268);
            this.Controls.Add(this.RefMarqueComboBox);
            this.Controls.Add(this.RefSousFamilleComboBox);
            this.Controls.Add(this.PrixHTTextBox);
            this.Controls.Add(this.PrixHTLabel);
            this.Controls.Add(this.QuantiteTextBox);
            this.Controls.Add(this.QuantiteLabel);
            this.Controls.Add(this.RefMarqueLabel);
            this.Controls.Add(this.RefSousFamilleLabel);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.RefArticlesTextBox);
            this.Controls.Add(this.RefArticlesLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(589, 324);
            this.MinimumSize = new System.Drawing.Size(589, 324);
            this.Name = "FormAddArticle";
            this.Text = "Créer un nouvel Article";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ComboBox RefMarqueComboBox;
        private System.Windows.Forms.ComboBox RefSousFamilleComboBox;
        private System.Windows.Forms.TextBox PrixHTTextBox;
        private System.Windows.Forms.Label PrixHTLabel;
        private System.Windows.Forms.TextBox QuantiteTextBox;
        private System.Windows.Forms.Label QuantiteLabel;
        private System.Windows.Forms.Label RefMarqueLabel;
        private System.Windows.Forms.Label RefSousFamilleLabel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox RefArticlesTextBox;
        private System.Windows.Forms.Label RefArticlesLabel;
    }
}