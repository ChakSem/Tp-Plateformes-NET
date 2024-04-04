
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
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActualiserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjetStatusStrip = new System.Windows.Forms.StatusStrip();
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
            this.fichierToolStripMenuItem});
            this.ObjetMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.ObjetMenuStrip.Name = "ObjetMenuStrip";
            this.ObjetMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.ObjetMenuStrip.TabIndex = 0;
            this.ObjetMenuStrip.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActualiserToolStripMenuItem,
            this.ImporterToolStripMenuItem,
            this.ExporterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // ActualiserToolStripMenuItem
            // 
            this.ActualiserToolStripMenuItem.Name = "ActualiserToolStripMenuItem";
            this.ActualiserToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ActualiserToolStripMenuItem.Text = "Actualiser";
            this.ActualiserToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // ImporterToolStripMenuItem
            // 
            this.ImporterToolStripMenuItem.Name = "ImporterToolStripMenuItem";
            this.ImporterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ImporterToolStripMenuItem.Text = "Importer";
            this.ImporterToolStripMenuItem.Click += new System.EventHandler(this.importerToolStripMenuItem_Click);
            // 
            // ExporterToolStripMenuItem
            // 
            this.ExporterToolStripMenuItem.Name = "ExporterToolStripMenuItem";
            this.ExporterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExporterToolStripMenuItem.Text = "Exporter";
            this.ExporterToolStripMenuItem.Click += new System.EventHandler(this.exporterToolStripMenuItem_Click);
            // 
            // ObjetStatusStrip
            // 
            this.ObjetStatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ObjetStatusStrip.Location = new System.Drawing.Point(0, 428);
            this.ObjetStatusStrip.Name = "ObjetStatusStrip";
            this.ObjetStatusStrip.Size = new System.Drawing.Size(800, 22);
            this.ObjetStatusStrip.TabIndex = 1;
            this.ObjetStatusStrip.Text = "statusStrip1";
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
            this.ObjetTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewParam_AfterSelect);
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
            this.ObjetListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView1_ColumnClick);
            this.ObjetListView.ItemActivate += new System.EventHandler(this.ListView1_ItemActivate);
            this.ObjetListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListView1_KeyDown);
            this.ObjetListView.Leave += new System.EventHandler(this.ListView1_Leave);
            this.ObjetListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseDoubleClick);
            // 
            // ObjetContextMenuStrip
            // 
            this.ObjetContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ObjetContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreerToolStripMenuItem,
            this.ModifierUnObjetToolStripMenuItem,
            this.SupprimerLobjetSelectionneToolStripMenuItem});
            this.ObjetContextMenuStrip.Name = "contextMenuStrip1";
            this.ObjetContextMenuStrip.Size = new System.Drawing.Size(229, 92);
            this.ObjetContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
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
            this.CreerArticleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CreerArticleToolStripMenuItem.Text = "Article";
            this.CreerArticleToolStripMenuItem.Click += new System.EventHandler(this.articleToolStripMenuItem_Click);
            // 
            // CreerFamilleToolStripMenuItem
            // 
            this.CreerFamilleToolStripMenuItem.Name = "CreerFamilleToolStripMenuItem";
            this.CreerFamilleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CreerFamilleToolStripMenuItem.Text = "Famille";
            this.CreerFamilleToolStripMenuItem.Click += new System.EventHandler(this.familleToolStripMenuItem_Click);
            // 
            // CreerSousFamilleToolStripMenuItem
            // 
            this.CreerSousFamilleToolStripMenuItem.Name = "CreerSousFamilleToolStripMenuItem";
            this.CreerSousFamilleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CreerSousFamilleToolStripMenuItem.Text = "Sous-Famille";
            this.CreerSousFamilleToolStripMenuItem.Click += new System.EventHandler(this.sousFamilleToolStripMenuItem_Click);
            // 
            // CreerMarqueToolStripMenuItem
            // 
            this.CreerMarqueToolStripMenuItem.Name = "CreerMarqueToolStripMenuItem";
            this.CreerMarqueToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CreerMarqueToolStripMenuItem.Text = "Marque";
            this.CreerMarqueToolStripMenuItem.Click += new System.EventHandler(this.marqueToolStripMenuItem_Click);
            // 
            // ModifierUnObjetToolStripMenuItem
            // 
            this.ModifierUnObjetToolStripMenuItem.Name = "ModifierUnObjetToolStripMenuItem";
            this.ModifierUnObjetToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.ModifierUnObjetToolStripMenuItem.Text = "Modifier l\'objet selectionne";
            this.ModifierUnObjetToolStripMenuItem.Click += new System.EventHandler(this.modifierUnObjetToolStripMenuItem_Click);
            // 
            // SupprimerLobjetSelectionneToolStripMenuItem
            // 
            this.SupprimerLobjetSelectionneToolStripMenuItem.Name = "SupprimerLobjetSelectionneToolStripMenuItem";
            this.SupprimerLobjetSelectionneToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.SupprimerLobjetSelectionneToolStripMenuItem.Text = "Supprimer l\'objet selectionne";
            this.SupprimerLobjetSelectionneToolStripMenuItem.Click += new System.EventHandler(this.supprimerLobjetSelectionneToolStripMenuItem_Click);
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
            this.Text = "Outil de Gestion de stock";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.ObjetMenuStrip.ResumeLayout(false);
            this.ObjetMenuStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
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
    }
}

