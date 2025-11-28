
using System;
using System.Windows.Forms;

namespace ProcHierarchyViewer
{
    partial class MainForm
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

        // Tasarım kontrolleri
        private Panel panelTop;
        private Panel panelBottom;
        private TextBox txtRootProc;
        private Button btnLoad;
        private TextBox txtSearch;
        private Button btnSearch;
        private TreeView treeView;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblRoot = new System.Windows.Forms.Label();
            this.txtRootProc = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ctxTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ismiKopyalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.ctxTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 80);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            this.splitContainer.Panel2Collapsed = true;
            this.splitContainer.Size = new System.Drawing.Size(884, 481);
            this.splitContainer.SplitterDistance = 121;
            this.splitContainer.TabIndex = 0;
            // 
            // treeView
            // 
            this.treeView.ContextMenuStrip = this.ctxTree;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.FullRowSelect = true;
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(884, 481);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_MouseClick);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblRoot);
            this.panelTop.Controls.Add(this.txtRootProc);
            this.panelTop.Controls.Add(this.btnLoad);
            this.panelTop.Controls.Add(this.lblSearch);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(884, 80);
            this.panelTop.TabIndex = 1;
            // 
            // lblRoot
            // 
            this.lblRoot.AutoSize = true;
            this.lblRoot.Location = new System.Drawing.Point(5, 15);
            this.lblRoot.Name = "lblRoot";
            this.lblRoot.Size = new System.Drawing.Size(50, 13);
            this.lblRoot.TabIndex = 0;
            this.lblRoot.Text = "Root SP:";
            // 
            // txtRootProc
            // 
            this.txtRootProc.Location = new System.Drawing.Point(70, 12);
            this.txtRootProc.Multiline = true;
            this.txtRootProc.Name = "txtRootProc";
            this.txtRootProc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRootProc.Size = new System.Drawing.Size(350, 60);
            this.txtRootProc.TabIndex = 1;
            this.txtRootProc.Text = "dbo.up_winbank_gns_krreeskont";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(420, 11);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(60, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(480, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(524, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.Text = "dbo.sel_yilsonutarihleri";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(724, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Find";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ctxTree
            // 
            this.ctxTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ismiKopyalaToolStripMenuItem});
            this.ctxTree.Name = "ctxTree";
            this.ctxTree.Size = new System.Drawing.Size(142, 26);
            // 
            // ismiKopyalaToolStripMenuItem
            // 
            this.ismiKopyalaToolStripMenuItem.Name = "ismiKopyalaToolStripMenuItem";
            this.ismiKopyalaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ismiKopyalaToolStripMenuItem.Text = "İsmi Kopyala";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelTop);
            this.Name = "MainForm";
            this.Text = "Stored Procedure Hierarchy Viewer";
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ctxTree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblRoot;
        private Label lblSearch;
        private ContextMenuStrip ctxTree;
        private ToolStripMenuItem ismiKopyalaToolStripMenuItem;
    }
}

