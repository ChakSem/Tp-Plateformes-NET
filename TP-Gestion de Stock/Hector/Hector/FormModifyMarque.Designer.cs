
namespace Hector
{
    partial class FormModifyMarque
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
            this.NomMarqueTextBox = new System.Windows.Forms.TextBox();
            this.NomMarqueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BoutonAnnulation
            // 
            this.BoutonAnnulation.Location = new System.Drawing.Point(76, 56);
            this.BoutonAnnulation.Name = "BoutonAnnulation";
            this.BoutonAnnulation.Size = new System.Drawing.Size(75, 23);
            this.BoutonAnnulation.TabIndex = 29;
            this.BoutonAnnulation.Text = "Annuler";
            this.BoutonAnnulation.UseVisualStyleBackColor = true;
            this.BoutonAnnulation.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BoutonModifier
            // 
            this.BoutonModifier.Location = new System.Drawing.Point(157, 56);
            this.BoutonModifier.Name = "BoutonModifier";
            this.BoutonModifier.Size = new System.Drawing.Size(75, 23);
            this.BoutonModifier.TabIndex = 28;
            this.BoutonModifier.Text = "Modifier";
            this.BoutonModifier.UseVisualStyleBackColor = true;
            this.BoutonModifier.Click += new System.EventHandler(this.BouttonModifier_Click);
            // 
            // NomMarqueTextBox
            // 
            this.NomMarqueTextBox.Location = new System.Drawing.Point(76, 12);
            this.NomMarqueTextBox.Name = "NomMarqueTextBox";
            this.NomMarqueTextBox.Size = new System.Drawing.Size(100, 20);
            this.NomMarqueTextBox.TabIndex = 31;
            // 
            // NomMarqueLabel
            // 
            this.NomMarqueLabel.AutoSize = true;
            this.NomMarqueLabel.Location = new System.Drawing.Point(12, 15);
            this.NomMarqueLabel.Name = "NomMarqueLabel";
            this.NomMarqueLabel.Size = new System.Drawing.Size(29, 13);
            this.NomMarqueLabel.TabIndex = 30;
            this.NomMarqueLabel.Text = "Nom";
            // 
            // FormModifyMarque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 91);
            this.Controls.Add(this.NomMarqueTextBox);
            this.Controls.Add(this.NomMarqueLabel);
            this.Controls.Add(this.BoutonAnnulation);
            this.Controls.Add(this.BoutonModifier);
            this.MaximumSize = new System.Drawing.Size(250, 130);
            this.MinimumSize = new System.Drawing.Size(250, 130);
            this.Name = "FormModifyMarque";
            this.Text = "Modifier une Marque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BoutonAnnulation;
        private System.Windows.Forms.Button BoutonModifier;
        private System.Windows.Forms.TextBox NomMarqueTextBox;
        private System.Windows.Forms.Label NomMarqueLabel;
    }
}