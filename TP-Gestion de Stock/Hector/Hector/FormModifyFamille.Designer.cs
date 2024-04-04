
namespace Hector
{
    partial class FormModifyFamille
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
            this.NomFamilleTextBox = new System.Windows.Forms.TextBox();
            this.NomFamilleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BoutonAnnulation
            // 
            this.BoutonAnnulation.Location = new System.Drawing.Point(76, 56);
            this.BoutonAnnulation.Name = "BoutonAnnulation";
            this.BoutonAnnulation.Size = new System.Drawing.Size(75, 23);
            this.BoutonAnnulation.TabIndex = 25;
            this.BoutonAnnulation.Text = "Annuler";
            this.BoutonAnnulation.UseVisualStyleBackColor = true;
            this.BoutonAnnulation.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BoutonModifier
            // 
            this.BoutonModifier.Location = new System.Drawing.Point(157, 56);
            this.BoutonModifier.Name = "BoutonModifier";
            this.BoutonModifier.Size = new System.Drawing.Size(75, 23);
            this.BoutonModifier.TabIndex = 24;
            this.BoutonModifier.Text = "Modifier";
            this.BoutonModifier.UseVisualStyleBackColor = true;
            this.BoutonModifier.Click += new System.EventHandler(this.ModifyButton_Click);
            // 
            // NomFamilleTextBox
            // 
            this.NomFamilleTextBox.Location = new System.Drawing.Point(76, 12);
            this.NomFamilleTextBox.Name = "NomFamilleTextBox";
            this.NomFamilleTextBox.Size = new System.Drawing.Size(100, 20);
            this.NomFamilleTextBox.TabIndex = 27;
            // 
            // NomFamilleLabel
            // 
            this.NomFamilleLabel.AutoSize = true;
            this.NomFamilleLabel.Location = new System.Drawing.Point(12, 15);
            this.NomFamilleLabel.Name = "NomFamilleLabel";
            this.NomFamilleLabel.Size = new System.Drawing.Size(29, 13);
            this.NomFamilleLabel.TabIndex = 26;
            this.NomFamilleLabel.Text = "Nom";
            // 
            // FormModifyFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 91);
            this.Controls.Add(this.NomFamilleTextBox);
            this.Controls.Add(this.NomFamilleLabel);
            this.Controls.Add(this.BoutonAnnulation);
            this.Controls.Add(this.BoutonModifier);
            this.MaximumSize = new System.Drawing.Size(250, 130);
            this.MinimumSize = new System.Drawing.Size(250, 130);
            this.Name = "FormModifyFamille";
            this.Text = "Modifier une Famille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BoutonAnnulation;
        private System.Windows.Forms.Button BoutonModifier;
        private System.Windows.Forms.TextBox NomFamilleTextBox;
        private System.Windows.Forms.Label NomFamilleLabel;
    }
}