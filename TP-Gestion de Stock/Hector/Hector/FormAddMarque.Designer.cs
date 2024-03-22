
namespace Hector
{
    partial class FormAddMarque
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.RefArticlesTextBox = new System.Windows.Forms.TextBox();
            this.RefArticlesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(114, 86);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(112, 35);
            this.CancelButton.TabIndex = 25;
            this.CancelButton.Text = "Annuler";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(236, 86);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(112, 35);
            this.CreateButton.TabIndex = 24;
            this.CreateButton.Text = "Créer";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // RefArticlesTextBox
            // 
            this.RefArticlesTextBox.Location = new System.Drawing.Point(114, 9);
            this.RefArticlesTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RefArticlesTextBox.Name = "RefArticlesTextBox";
            this.RefArticlesTextBox.Size = new System.Drawing.Size(148, 26);
            this.RefArticlesTextBox.TabIndex = 23;
            // 
            // RefArticlesLabel
            // 
            this.RefArticlesLabel.AutoSize = true;
            this.RefArticlesLabel.Location = new System.Drawing.Point(18, 14);
            this.RefArticlesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RefArticlesLabel.Name = "RefArticlesLabel";
            this.RefArticlesLabel.Size = new System.Drawing.Size(42, 20);
            this.RefArticlesLabel.TabIndex = 22;
            this.RefArticlesLabel.Text = "Nom";
            // 
            // FormAddMarque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 114);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.RefArticlesTextBox);
            this.Controls.Add(this.RefArticlesLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(364, 170);
            this.MinimumSize = new System.Drawing.Size(364, 170);
            this.Name = "FormAddMarque";
            this.Text = "Créer une nouvelle Marque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.TextBox RefArticlesTextBox;
        private System.Windows.Forms.Label RefArticlesLabel;
    }
}