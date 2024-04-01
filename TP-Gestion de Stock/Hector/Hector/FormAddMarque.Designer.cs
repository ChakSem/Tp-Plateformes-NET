
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
            this.BoutonAnnulation = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.NomMarqueTextBox = new System.Windows.Forms.TextBox();
            this.NomMarqueLabel = new System.Windows.Forms.Label();
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
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(157, 56);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 24;
            this.CreateButton.Text = "Créer";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // NomMarqueTextBox
            // 
            this.NomMarqueTextBox.Location = new System.Drawing.Point(76, 6);
            this.NomMarqueTextBox.Name = "NomMarqueTextBox";
            this.NomMarqueTextBox.Size = new System.Drawing.Size(100, 20);
            this.NomMarqueTextBox.TabIndex = 23;
            // 
            // NomMarqueLabel
            // 
            this.NomMarqueLabel.AutoSize = true;
            this.NomMarqueLabel.Location = new System.Drawing.Point(12, 9);
            this.NomMarqueLabel.Name = "NomMarqueLabel";
            this.NomMarqueLabel.Size = new System.Drawing.Size(29, 13);
            this.NomMarqueLabel.TabIndex = 22;
            this.NomMarqueLabel.Text = "Nom";
            // 
            // FormAddMarque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 85);
            this.Controls.Add(this.BoutonAnnulation);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.NomMarqueTextBox);
            this.Controls.Add(this.NomMarqueLabel);
            this.MaximumSize = new System.Drawing.Size(248, 124);
            this.MinimumSize = new System.Drawing.Size(248, 124);
            this.Name = "FormAddMarque";
            this.Text = "Créer une nouvelle Marque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BoutonAnnulation;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.TextBox NomMarqueTextBox;
        private System.Windows.Forms.Label NomMarqueLabel;
    }
}