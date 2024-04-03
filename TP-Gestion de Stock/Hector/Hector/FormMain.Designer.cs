
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.importerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TreeView1 = new System.Windows.Forms.TreeView();
            this.ListView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.créerUnNouvelIndividuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.familleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sousFamilleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierUnObjetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerLobjetSelectionneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1200, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.importerToolStripMenuItem,
            this.exporterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 30);
            this.toolStripMenuItem2.Text = "Actualiser";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // importerToolStripMenuItem
            // 
            this.importerToolStripMenuItem.Name = "importerToolStripMenuItem";
            this.importerToolStripMenuItem.Size = new System.Drawing.Size(172, 30);
            this.importerToolStripMenuItem.Text = "Importer";
            this.importerToolStripMenuItem.Click += new System.EventHandler(this.importerToolStripMenuItem_Click);
            // 
            // exporterToolStripMenuItem
            // 
            this.exporterToolStripMenuItem.Name = "exporterToolStripMenuItem";
            this.exporterToolStripMenuItem.Size = new System.Drawing.Size(172, 30);
            this.exporterToolStripMenuItem.Text = "Exporter";
            this.exporterToolStripMenuItem.Click += new System.EventHandler(this.exporterToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 670);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TreeView1);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ListView1);
            this.splitContainer1.Size = new System.Drawing.Size(1200, 635);
            this.splitContainer1.SplitterDistance = 396;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 2;
            // 
            // TreeView1
            // 
            this.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView1.Location = new System.Drawing.Point(0, 0);
            this.TreeView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TreeView1.Name = "TreeView1";
            this.TreeView1.Size = new System.Drawing.Size(396, 635);
            this.TreeView1.TabIndex = 0;
            this.TreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewParam_AfterSelect);
            // 
            // ListView1
            // 
            this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView1.FullRowSelect = true;
            this.ListView1.HideSelection = false;
            this.ListView1.Location = new System.Drawing.Point(0, 0);
            this.ListView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListView1.MultiSelect = false;
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(798, 635);
            this.ListView1.TabIndex = 0;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.Details;
            this.ListView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView1_ColumnClick);
            this.ListView1.ItemActivate += new System.EventHandler(this.ListView1_ItemActivate);
            this.ListView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListView1_KeyDown);
            this.ListView1.Leave += new System.EventHandler(this.ListView1_Leave);
            this.ListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.créerUnNouvelIndividuToolStripMenuItem,
            this.modifierUnObjetToolStripMenuItem,
            this.supprimerLobjetSelectionneToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(315, 94);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // créerUnNouvelIndividuToolStripMenuItem
            // 
            this.créerUnNouvelIndividuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articleToolStripMenuItem,
            this.familleToolStripMenuItem,
            this.sousFamilleToolStripMenuItem,
            this.marqueToolStripMenuItem});
            this.créerUnNouvelIndividuToolStripMenuItem.Name = "créerUnNouvelIndividuToolStripMenuItem";
            this.créerUnNouvelIndividuToolStripMenuItem.Size = new System.Drawing.Size(314, 30);
            this.créerUnNouvelIndividuToolStripMenuItem.Text = "Créer un nouvel individu";
            // 
            // articleToolStripMenuItem
            // 
            this.articleToolStripMenuItem.Name = "articleToolStripMenuItem";
            this.articleToolStripMenuItem.Size = new System.Drawing.Size(196, 30);
            this.articleToolStripMenuItem.Text = "Article";
            this.articleToolStripMenuItem.Click += new System.EventHandler(this.articleToolStripMenuItem_Click);
            // 
            // familleToolStripMenuItem
            // 
            this.familleToolStripMenuItem.Name = "familleToolStripMenuItem";
            this.familleToolStripMenuItem.Size = new System.Drawing.Size(196, 30);
            this.familleToolStripMenuItem.Text = "Famille";
            this.familleToolStripMenuItem.Click += new System.EventHandler(this.familleToolStripMenuItem_Click);
            // 
            // sousFamilleToolStripMenuItem
            // 
            this.sousFamilleToolStripMenuItem.Name = "sousFamilleToolStripMenuItem";
            this.sousFamilleToolStripMenuItem.Size = new System.Drawing.Size(196, 30);
            this.sousFamilleToolStripMenuItem.Text = "Sous-Famille";
            this.sousFamilleToolStripMenuItem.Click += new System.EventHandler(this.sousFamilleToolStripMenuItem_Click);
            // 
            // marqueToolStripMenuItem
            // 
            this.marqueToolStripMenuItem.Name = "marqueToolStripMenuItem";
            this.marqueToolStripMenuItem.Size = new System.Drawing.Size(196, 30);
            this.marqueToolStripMenuItem.Text = "Marque";
            this.marqueToolStripMenuItem.Click += new System.EventHandler(this.marqueToolStripMenuItem_Click);
            // 
            // modifierUnObjetToolStripMenuItem
            // 
            this.modifierUnObjetToolStripMenuItem.Name = "modifierUnObjetToolStripMenuItem";
            this.modifierUnObjetToolStripMenuItem.Size = new System.Drawing.Size(314, 30);
            this.modifierUnObjetToolStripMenuItem.Text = "Modifier l\'objet selectionne";
            this.modifierUnObjetToolStripMenuItem.Click += new System.EventHandler(this.modifierUnObjetToolStripMenuItem_Click);
            // 
            // supprimerLobjetSelectionneToolStripMenuItem
            // 
            this.supprimerLobjetSelectionneToolStripMenuItem.Name = "supprimerLobjetSelectionneToolStripMenuItem";
            this.supprimerLobjetSelectionneToolStripMenuItem.Size = new System.Drawing.Size(314, 30);
            this.supprimerLobjetSelectionneToolStripMenuItem.Text = "Supprimer l\'objet selectionne";
            this.supprimerLobjetSelectionneToolStripMenuItem.Click += new System.EventHandler(this.supprimerLobjetSelectionneToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "Outil de Gestion de stock";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem importerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exporterToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView TreeView1;
        private System.Windows.Forms.ListView ListView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem créerUnNouvelIndividuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem familleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sousFamilleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierUnObjetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerLobjetSelectionneToolStripMenuItem;
    }
}

