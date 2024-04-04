
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
            this.FamilleComboBox = new System.Windows.Forms.ComboBox();
            this.FamilleLabel = new System.Windows.Forms.Label();
            this.BoutonAnnulation = new System.Windows.Forms.Button();
            this.BoutonCreer = new System.Windows.Forms.Button();
            this.NomSousFamilleTextBox = new System.Windows.Forms.TextBox();
            this.NomSousFamilleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FamilleComboBox
            // 
            this.FamilleComboBox.FormattingEnabled = true;
            this.FamilleComboBox.Location = new System.Drawing.Point(76, 37);
            this.FamilleComboBox.Name = "FamilleComboBox";
            this.FamilleComboBox.Size = new System.Drawing.Size(121, 21);
            this.FamilleComboBox.TabIndex = 37;
            // 
            // FamilleLabel
            // 
            this.FamilleLabel.AutoSize = true;
            this.FamilleLabel.Location = new System.Drawing.Point(12, 40);
            this.FamilleLabel.Name = "FamilleLabel";
            this.FamilleLabel.Size = new System.Drawing.Size(39, 13);
            this.FamilleLabel.TabIndex = 36;
            this.FamilleLabel.Text = "Famille";
            // 
            // BoutonAnnulation
            // 
            this.BoutonAnnulation.Location = new System.Drawing.Point(76, 76);
            this.BoutonAnnulation.Name = "BoutonAnnulation";
            this.BoutonAnnulation.Size = new System.Drawing.Size(75, 23);
            this.BoutonAnnulation.TabIndex = 35;
            this.BoutonAnnulation.Text = "Annuler";
            this.BoutonAnnulation.UseVisualStyleBackColor = true;
            this.BoutonAnnulation.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BoutonCreer
            // 
            this.BoutonCreer.Location = new System.Drawing.Point(157, 76);
            this.BoutonCreer.Name = "BoutonCreer";
            this.BoutonCreer.Size = new System.Drawing.Size(75, 23);
            this.BoutonCreer.TabIndex = 34;
            this.BoutonCreer.Text = "Créer";
            this.BoutonCreer.UseVisualStyleBackColor = true;
            this.BoutonCreer.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // NomSousFamilleTextBox
            // 
            this.NomSousFamilleTextBox.Location = new System.Drawing.Point(76, 6);
            this.NomSousFamilleTextBox.Name = "NomSousFamilleTextBox";
            this.NomSousFamilleTextBox.Size = new System.Drawing.Size(100, 20);
            this.NomSousFamilleTextBox.TabIndex = 33;
            // 
            // NomSousFamilleLabel
            // 
            this.NomSousFamilleLabel.AutoSize = true;
            this.NomSousFamilleLabel.Location = new System.Drawing.Point(12, 9);
            this.NomSousFamilleLabel.Name = "NomSousFamilleLabel";
            this.NomSousFamilleLabel.Size = new System.Drawing.Size(29, 13);
            this.NomSousFamilleLabel.TabIndex = 32;
            this.NomSousFamilleLabel.Text = "Nom";
            // 
            // FormAddSousFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 105);
            this.Controls.Add(this.FamilleComboBox);
            this.Controls.Add(this.FamilleLabel);
            this.Controls.Add(this.BoutonAnnulation);
            this.Controls.Add(this.BoutonCreer);
            this.Controls.Add(this.NomSousFamilleTextBox);
            this.Controls.Add(this.NomSousFamilleLabel);
            this.MaximumSize = new System.Drawing.Size(248, 144);
            this.MinimumSize = new System.Drawing.Size(248, 144);
            this.Name = "FormAddSousFamille";
            this.Text = "Créer une nouvelle Sous-Famille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FamilleComboBox;
        private System.Windows.Forms.Label FamilleLabel;
        private System.Windows.Forms.Button BoutonAnnulation;
        private System.Windows.Forms.Button BoutonCreer;
        private System.Windows.Forms.TextBox NomSousFamilleTextBox;
        private System.Windows.Forms.Label NomSousFamilleLabel;
    }
}