
namespace Hector
{
    partial class FormModifySousFamille
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
            this.BoutonAnnulation = new System.Windows.Forms.Button();
            this.BoutonModifier = new System.Windows.Forms.Button();
            this.FamilleComboBox = new System.Windows.Forms.ComboBox();
            this.FamilleLabel = new System.Windows.Forms.Label();
            this.NomSousFamilleTextBox = new System.Windows.Forms.TextBox();
            this.NomSousFamilleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BoutonAnnulation
            // 
            this.BoutonAnnulation.Location = new System.Drawing.Point(76, 76);
            this.BoutonAnnulation.Name = "BoutonAnnulation";
            this.BoutonAnnulation.Size = new System.Drawing.Size(75, 23);
            this.BoutonAnnulation.TabIndex = 29;
            this.BoutonAnnulation.Text = "Annuler";
            this.BoutonAnnulation.UseVisualStyleBackColor = true;
            this.BoutonAnnulation.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BoutonModifier
            // 
            this.BoutonModifier.Location = new System.Drawing.Point(157, 76);
            this.BoutonModifier.Name = "BoutonModifier";
            this.BoutonModifier.Size = new System.Drawing.Size(75, 23);
            this.BoutonModifier.TabIndex = 28;
            this.BoutonModifier.Text = "Modifier";
            this.BoutonModifier.UseVisualStyleBackColor = true;
            this.BoutonModifier.Click += new System.EventHandler(this.ModifyButton_Click);
            // 
            // FamilleComboBox
            // 
            this.FamilleComboBox.FormattingEnabled = true;
            this.FamilleComboBox.Location = new System.Drawing.Point(76, 39);
            this.FamilleComboBox.Name = "FamilleComboBox";
            this.FamilleComboBox.Size = new System.Drawing.Size(121, 21);
            this.FamilleComboBox.TabIndex = 41;
            // 
            // FamilleLabel
            // 
            this.FamilleLabel.AutoSize = true;
            this.FamilleLabel.Location = new System.Drawing.Point(12, 42);
            this.FamilleLabel.Name = "FamilleLabel";
            this.FamilleLabel.Size = new System.Drawing.Size(39, 13);
            this.FamilleLabel.TabIndex = 40;
            this.FamilleLabel.Text = "Famille";
            // 
            // NomSousFamilleTextBox
            // 
            this.NomSousFamilleTextBox.Location = new System.Drawing.Point(76, 8);
            this.NomSousFamilleTextBox.Name = "NomSousFamilleTextBox";
            this.NomSousFamilleTextBox.Size = new System.Drawing.Size(100, 20);
            this.NomSousFamilleTextBox.TabIndex = 39;
            // 
            // NomSousFamilleLabel
            // 
            this.NomSousFamilleLabel.AutoSize = true;
            this.NomSousFamilleLabel.Location = new System.Drawing.Point(12, 11);
            this.NomSousFamilleLabel.Name = "NomSousFamilleLabel";
            this.NomSousFamilleLabel.Size = new System.Drawing.Size(29, 13);
            this.NomSousFamilleLabel.TabIndex = 38;
            this.NomSousFamilleLabel.Text = "Nom";
            // 
            // FormModifySousFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 111);
            this.Controls.Add(this.FamilleComboBox);
            this.Controls.Add(this.FamilleLabel);
            this.Controls.Add(this.NomSousFamilleTextBox);
            this.Controls.Add(this.NomSousFamilleLabel);
            this.Controls.Add(this.BoutonAnnulation);
            this.Controls.Add(this.BoutonModifier);
            this.MaximumSize = new System.Drawing.Size(250, 150);
            this.MinimumSize = new System.Drawing.Size(250, 150);
            this.Name = "FormModifySousFamille";
            this.Text = "Modifier une Sous-Famille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BoutonAnnulation;
        private System.Windows.Forms.Button BoutonModifier;
        private System.Windows.Forms.ComboBox FamilleComboBox;
        private System.Windows.Forms.Label FamilleLabel;
        private System.Windows.Forms.TextBox NomSousFamilleTextBox;
        private System.Windows.Forms.Label NomSousFamilleLabel;
    }
}