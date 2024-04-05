
namespace Hector
{
    partial class FormAddFamille
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
            this.NomFamilleTextBox = new System.Windows.Forms.TextBox();
            this.NomFamilleLabel = new System.Windows.Forms.Label();
            this.BoutonAnnulation = new System.Windows.Forms.Button();
            this.BoutonCreer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NomFamilleTextBox
            // 
            this.NomFamilleTextBox.Location = new System.Drawing.Point(76, 6);
            this.NomFamilleTextBox.Name = "NomFamilleTextBox";
            this.NomFamilleTextBox.Size = new System.Drawing.Size(100, 20);
            this.NomFamilleTextBox.TabIndex = 19;
            // 
            // NomFamilleLabel
            // 
            this.NomFamilleLabel.AutoSize = true;
            this.NomFamilleLabel.Location = new System.Drawing.Point(12, 9);
            this.NomFamilleLabel.Name = "NomFamilleLabel";
            this.NomFamilleLabel.Size = new System.Drawing.Size(29, 13);
            this.NomFamilleLabel.TabIndex = 18;
            this.NomFamilleLabel.Text = "Nom";
            // 
            // BoutonAnnulation
            // 
            this.BoutonAnnulation.Location = new System.Drawing.Point(76, 56);
            this.BoutonAnnulation.Name = "BoutonAnnulation";
            this.BoutonAnnulation.Size = new System.Drawing.Size(75, 23);
            this.BoutonAnnulation.TabIndex = 21;
            this.BoutonAnnulation.Text = "Annuler";
            this.BoutonAnnulation.UseVisualStyleBackColor = true;
            this.BoutonAnnulation.Click += new System.EventHandler(this.BoutonAnnulation_Click);
            // 
            // BoutonCreer
            // 
            this.BoutonCreer.Location = new System.Drawing.Point(157, 56);
            this.BoutonCreer.Name = "BoutonCreer";
            this.BoutonCreer.Size = new System.Drawing.Size(75, 23);
            this.BoutonCreer.TabIndex = 20;
            this.BoutonCreer.Text = "Créer";
            this.BoutonCreer.UseVisualStyleBackColor = true;
            this.BoutonCreer.Click += new System.EventHandler(this.BoutonCreer_Click);
            // 
            // FormAddFamille
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 91);
            this.Controls.Add(this.BoutonAnnulation);
            this.Controls.Add(this.BoutonCreer);
            this.Controls.Add(this.NomFamilleTextBox);
            this.Controls.Add(this.NomFamilleLabel);
            this.MaximumSize = new System.Drawing.Size(250, 130);
            this.MinimumSize = new System.Drawing.Size(250, 130);
            this.Name = "FormAddFamille";
            this.Text = "Créer une nouvelle Famille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NomFamilleTextBox;
        private System.Windows.Forms.Label NomFamilleLabel;
        private System.Windows.Forms.Button BoutonAnnulation;
        private System.Windows.Forms.Button BoutonCreer;
    }
}