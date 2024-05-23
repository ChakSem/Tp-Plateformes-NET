
namespace Hector
{
    partial class FormMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ObjetMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActualiserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjetStatusStrip = new System.Windows.Forms.StatusStrip();
            this.LabelFamilleToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FamillesToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SousFamilleLabelToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SousFamillesLabelToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MarqueLabelToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MarquesToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ArticleLabelToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ArticlesToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ObjetTreeView = new System.Windows.Forms.TreeView();
            this.ObjetListView = new System.Windows.Forms.ListView();
            this.ObjetContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CreerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreerArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreerFamilleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreerSousFamilleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreerMarqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifierUnObjetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SupprimerLobjetSelectionneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjetMenuStrip.SuspendLayout();
            this.ObjetStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ObjetContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ObjetMenuStrip
            // 
            this.ObjetMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ObjetMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FichierToolStripMenuItem});
            this.ObjetMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.ObjetMenuStrip.Name = "ObjetMenuStrip";
            this.ObjetMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.ObjetMenuStrip.TabIndex = 0;
            this.ObjetMenuStrip.Text = "menuStrip1";
            // 
            // FichierToolStripMenuItem
            // 
            this.FichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActualiserToolStripMenuItem,
            this.ImporterToolStripMenuItem,
            this.ExporterToolStripMenuItem});
            this.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem";
            this.FichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.FichierToolStripMenuItem.Text = "Fichier";
            // 
            // ActualiserToolStripMenuItem
            // 
            this.ActualiserToolStripMenuItem.Name = "ActualiserToolStripMenuItem";
            this.ActualiserToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ActualiserToolStripMenuItem.Text = "Actualiser";
            this.ActualiserToolStripMenuItem.Click += new System.EventHandler(this.ActualiserToolStripMenuItem_Click);
            // 
            // ImporterToolStripMenuItem
            // 
            this.ImporterToolStripMenuItem.Name = "ImporterToolStripMenuItem";
            this.ImporterToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ImporterToolStripMenuItem.Text = "Importer";
            this.ImporterToolStripMenuItem.Click += new System.EventHandler(this.ImporterToolStripMenuItem_Click);
            // 
            // ExporterToolStripMenuItem
            // 
            this.ExporterToolStripMenuItem.Name = "ExporterToolStripMenuItem";
            this.ExporterToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ExporterToolStripMenuItem.Text = "Exporter";
            this.ExporterToolStripMenuItem.Click += new System.EventHandler(this.ExporterToolStripMenuItem_Click);
            // 
            // ObjetStatusStrip
            // 
            this.ObjetStatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ObjetStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelFamilleToolStripStatusLabel,
            this.FamillesToolStripStatusLabel,
            this.SousFamilleLabelToolStripStatusLabel3,
            this.SousFamillesLabelToolStripStatusLabel,
            this.MarqueLabelToolStripStatusLabel,
            this.MarquesToolStripStatusLabel,
            this.ArticleLabelToolStripStatusLabel,
            this.ArticlesToolStripStatusLabel});
            this.ObjetStatusStrip.Location = new System.Drawing.Point(0, 428);
            this.ObjetStatusStrip.Name = "ObjetStatusStrip";
            this.ObjetStatusStrip.Size = new System.Drawing.Size(800, 22);
            this.ObjetStatusStrip.TabIndex = 1;
            this.ObjetStatusStrip.Text = "statusStrip1";
            // 
            // LabelFamilleToolStripStatusLabel
            // 
            this.LabelFamilleToolStripStatusLabel.Name = "LabelFamilleToolStripStatusLabel";
            this.LabelFamilleToolStripStatusLabel.Size = new System.Drawing.Size(56, 17);
            this.LabelFamilleToolStripStatusLabel.Text = "Familles :";
            // 
            // FamillesToolStripStatusLabel
            // 
            this.FamillesToolStripStatusLabel.Name = "FamillesToolStripStatusLabel";
            this.FamillesToolStripStatusLabel.Size = new System.Drawing.Size(13, 17);
            this.FamillesToolStripStatusLabel.Text = "0";
            // 
            // SousFamilleLabelToolStripStatusLabel3
            // 
            this.SousFamilleLabelToolStripStatusLabel3.Name = "SousFamilleLabelToolStripStatusLabel3";
            this.SousFamilleLabelToolStripStatusLabel3.Size = new System.Drawing.Size(81, 17);
            this.SousFamilleLabelToolStripStatusLabel3.Text = "SousFamilles :";
            // 
            // SousFamillesLabelToolStripStatusLabel
            // 
            this.SousFamillesLabelToolStripStatusLabel.Name = "SousFamillesLabelToolStripStatusLabel";
            this.SousFamillesLabelToolStripStatusLabel.Size = new System.Drawing.Size(13, 17);
            this.SousFamillesLabelToolStripStatusLabel.Text = "0";
            // 
            // MarqueLabelToolStripStatusLabel
            // 
            this.MarqueLabelToolStripStatusLabel.Name = "MarqueLabelToolStripStatusLabel";
            this.MarqueLabelToolStripStatusLabel.Size = new System.Drawing.Size(59, 17);
            this.MarqueLabelToolStripStatusLabel.Text = "Marques :";
            // 
            // MarquesToolStripStatusLabel
            // 
            this.MarquesToolStripStatusLabel.Name = "MarquesToolStripStatusLabel";
            this.MarquesToolStripStatusLabel.Size = new System.Drawing.Size(13, 17);
            this.MarquesToolStripStatusLabel.Text = "0";
            // 
            // ArticleLabelToolStripStatusLabel
            // 
            this.ArticleLabelToolStripStatusLabel.Name = "ArticleLabelToolStripStatusLabel";
            this.ArticleLabelToolStripStatusLabel.Size = new System.Drawing.Size(52, 17);
            this.ArticleLabelToolStripStatusLabel.Text = "Articles :";
            // 
            // ArticlesToolStripStatusLabel
            // 
            this.ArticlesToolStripStatusLabel.Name = "ArticlesToolStripStatusLabel";
            this.ArticlesToolStripStatusLabel.Size = new System.Drawing.Size(13, 17);
            this.ArticlesToolStripStatusLabel.Text = "0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ObjetTreeView);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ObjetListView);
            this.splitContainer1.Size = new System.Drawing.Size(800, 404);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 2;
            // 
            // ObjetTreeView
            // 
            this.ObjetTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjetTreeView.Location = new System.Drawing.Point(0, 0);
            this.ObjetTreeView.Name = "ObjetTreeView";
            this.ObjetTreeView.Size = new System.Drawing.Size(264, 404);
            this.ObjetTreeView.TabIndex = 0;
            this.ObjetTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ObjetTreeView_AfterSelect);
            // 
            // ObjetListView
            // 
            this.ObjetListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjetListView.FullRowSelect = true;
            this.ObjetListView.HideSelection = false;
            this.ObjetListView.Location = new System.Drawing.Point(0, 0);
            this.ObjetListView.MultiSelect = false;
            this.ObjetListView.Name = "ObjetListView";
            this.ObjetListView.Size = new System.Drawing.Size(532, 404);
            this.ObjetListView.TabIndex = 0;
            this.ObjetListView.UseCompatibleStateImageBehavior = false;
            this.ObjetListView.View = System.Windows.Forms.View.Details;
            this.ObjetListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ObjetListView_ColumnClick);
            this.ObjetListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ObjetListView_KeyDown);
            this.ObjetListView.Leave += new System.EventHandler(this.ObjetListView_Leave);
            this.ObjetListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ObjetListView_MouseDoubleClick);
            // 
            // ObjetContextMenuStrip
            // 
            this.ObjetContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ObjetContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreerToolStripMenuItem,
            this.ModifierUnObjetToolStripMenuItem,
            this.SupprimerLobjetSelectionneToolStripMenuItem});
            this.ObjetContextMenuStrip.Name = "contextMenuStrip1";
            this.ObjetContextMenuStrip.Size = new System.Drawing.Size(229, 70);
            this.ObjetContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ObjetContextMenuStrip_Opening);
            // 
            // CreerToolStripMenuItem
            // 
            this.CreerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreerArticleToolStripMenuItem,
            this.CreerFamilleToolStripMenuItem,
            this.CreerSousFamilleToolStripMenuItem,
            this.CreerMarqueToolStripMenuItem});
            this.CreerToolStripMenuItem.Name = "CreerToolStripMenuItem";
            this.CreerToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.CreerToolStripMenuItem.Text = "Créer un nouvel individu";
            // 
            // CreerArticleToolStripMenuItem
            // 
            this.CreerArticleToolStripMenuItem.Name = "CreerArticleToolStripMenuItem";
            this.CreerArticleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.CreerArticleToolStripMenuItem.Text = "Article";
            this.CreerArticleToolStripMenuItem.Click += new System.EventHandler(this.CreerArticleToolStripMenuItem_Click);
            // 
            // CreerFamilleToolStripMenuItem
            // 
            this.CreerFamilleToolStripMenuItem.Name = "CreerFamilleToolStripMenuItem";
            this.CreerFamilleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.CreerFamilleToolStripMenuItem.Text = "Famille";
            this.CreerFamilleToolStripMenuItem.Click += new System.EventHandler(this.CreerFamilleToolStripMenuItem_Click);
            // 
            // CreerSousFamilleToolStripMenuItem
            // 
            this.CreerSousFamilleToolStripMenuItem.Name = "CreerSousFamilleToolStripMenuItem";
            this.CreerSousFamilleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.CreerSousFamilleToolStripMenuItem.Text = "Sous-Famille";
            this.CreerSousFamilleToolStripMenuItem.Click += new System.EventHandler(this.CreerSousFamilleToolStripMenuItem_Click);
            // 
            // CreerMarqueToolStripMenuItem
            // 
            this.CreerMarqueToolStripMenuItem.Name = "CreerMarqueToolStripMenuItem";
            this.CreerMarqueToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.CreerMarqueToolStripMenuItem.Text = "Marque";
            this.CreerMarqueToolStripMenuItem.Click += new System.EventHandler(this.CreerMarqueToolStripMenuItem_Click);
            // 
            // ModifierUnObjetToolStripMenuItem
            // 
            this.ModifierUnObjetToolStripMenuItem.Name = "ModifierUnObjetToolStripMenuItem";
            this.ModifierUnObjetToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.ModifierUnObjetToolStripMenuItem.Text = "Modifier l\'objet selectionne";
            this.ModifierUnObjetToolStripMenuItem.Click += new System.EventHandler(this.ModifierUnObjetToolStripMenuItem_Click);
            // 
            // SupprimerLobjetSelectionneToolStripMenuItem
            // 
            this.SupprimerLobjetSelectionneToolStripMenuItem.Name = "SupprimerLobjetSelectionneToolStripMenuItem";
            this.SupprimerLobjetSelectionneToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.SupprimerLobjetSelectionneToolStripMenuItem.Text = "Supprimer l\'objet selectionne";
            this.SupprimerLobjetSelectionneToolStripMenuItem.Click += new System.EventHandler(this.SupprimerLobjetSelectionneToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ContextMenuStrip = this.ObjetContextMenuStrip;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ObjetStatusStrip);
            this.Controls.Add(this.ObjetMenuStrip);
            this.MainMenuStrip = this.ObjetMenuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outil de Gestion de stock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.ObjetMenuStrip.ResumeLayout(false);
            this.ObjetMenuStrip.PerformLayout();
            this.ObjetStatusStrip.ResumeLayout(false);
            this.ObjetStatusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ObjetContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ObjetMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ActualiserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImporterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExporterToolStripMenuItem;
        private System.Windows.Forms.StatusStrip ObjetStatusStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView ObjetTreeView;
        private System.Windows.Forms.ListView ObjetListView;
        private System.Windows.Forms.ContextMenuStrip ObjetContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CreerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreerArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreerFamilleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreerSousFamilleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreerMarqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModifierUnObjetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SupprimerLobjetSelectionneToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel LabelFamilleToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel FamillesToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel SousFamilleLabelToolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel SousFamillesLabelToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel MarqueLabelToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel MarquesToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ArticleLabelToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ArticlesToolStripStatusLabel;
    }
}

