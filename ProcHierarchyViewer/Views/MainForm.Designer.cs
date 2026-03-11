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
        /// <param name="disposing">true if disposing true, otherwise false.</param>
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
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panelObjectExplorer = new System.Windows.Forms.Panel();
            this.treeViewObjectExplorer = new System.Windows.Forms.TreeView();
            this.panelObjectExplorerFilterHost = new System.Windows.Forms.Panel();
            this.txtObjectExplorerFilter = new System.Windows.Forms.TextBox();
            this.lblObjectExplorerHeader = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.ctxTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ismiKopyalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop = new System.Windows.Forms.Panel();
            this.topControlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox_Direction = new System.Windows.Forms.ComboBox();
            this.label_Direction = new System.Windows.Forms.Label();
            this.lblRoot = new System.Windows.Forms.Label();
            this.txtRootProc = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.panelObjectExplorer.SuspendLayout();
            this.panelObjectExplorerFilterHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.ctxTree.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.topControlLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 92);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.mainSplitContainer.Panel1.Controls.Add(this.panelObjectExplorer);
            this.mainSplitContainer.Panel1MinSize = 230;
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.splitContainer);
            this.mainSplitContainer.Size = new System.Drawing.Size(862, 469);
            this.mainSplitContainer.SplitterDistance = 235;
            this.mainSplitContainer.SplitterWidth = 1;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // panelObjectExplorer
            // 
            this.panelObjectExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panelObjectExplorer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelObjectExplorer.Controls.Add(this.treeViewObjectExplorer);
            this.panelObjectExplorer.Controls.Add(this.panelObjectExplorerFilterHost);
            this.panelObjectExplorer.Controls.Add(this.lblObjectExplorerHeader);
            this.panelObjectExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelObjectExplorer.Location = new System.Drawing.Point(0, 0);
            this.panelObjectExplorer.Name = "panelObjectExplorer";
            this.panelObjectExplorer.Padding = new System.Windows.Forms.Padding(12);
            this.panelObjectExplorer.Size = new System.Drawing.Size(235, 469);
            this.panelObjectExplorer.TabIndex = 0;
            // 
            // treeViewObjectExplorer
            // 
            this.treeViewObjectExplorer.BackColor = System.Drawing.Color.White;
            this.treeViewObjectExplorer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewObjectExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewObjectExplorer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.treeViewObjectExplorer.FullRowSelect = true;
            this.treeViewObjectExplorer.HideSelection = false;
            this.treeViewObjectExplorer.Location = new System.Drawing.Point(12, 52);
            this.treeViewObjectExplorer.Name = "treeViewObjectExplorer";
            this.treeViewObjectExplorer.Size = new System.Drawing.Size(209, 365);
            this.treeViewObjectExplorer.TabIndex = 1;
            // 
            // panelObjectExplorerFilterHost
            // 
            this.panelObjectExplorerFilterHost.Controls.Add(this.txtObjectExplorerFilter);
            this.panelObjectExplorerFilterHost.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelObjectExplorerFilterHost.Location = new System.Drawing.Point(12, 417);
            this.panelObjectExplorerFilterHost.Name = "panelObjectExplorerFilterHost";
            this.panelObjectExplorerFilterHost.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panelObjectExplorerFilterHost.Size = new System.Drawing.Size(209, 29);
            this.panelObjectExplorerFilterHost.TabIndex = 2;
            // 
            // txtObjectExplorerFilter
            // 
            this.txtObjectExplorerFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObjectExplorerFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObjectExplorerFilter.Location = new System.Drawing.Point(0, 6);
            this.txtObjectExplorerFilter.Name = "txtObjectExplorerFilter";
            this.txtObjectExplorerFilter.Size = new System.Drawing.Size(209, 23);
            this.txtObjectExplorerFilter.TabIndex = 0;
            // 
            // lblObjectExplorerHeader
            // 
            this.lblObjectExplorerHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblObjectExplorerHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblObjectExplorerHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblObjectExplorerHeader.Location = new System.Drawing.Point(12, 12);
            this.lblObjectExplorerHeader.Name = "lblObjectExplorerHeader";
            this.lblObjectExplorerHeader.Padding = new System.Windows.Forms.Padding(2, 0, 0, 10);
            this.lblObjectExplorerHeader.Size = new System.Drawing.Size(209, 40);
            this.lblObjectExplorerHeader.TabIndex = 0;
            this.lblObjectExplorerHeader.Text = "Object Explorer";
            this.lblObjectExplorerHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            this.splitContainer.Panel2Collapsed = true;
            this.splitContainer.Size = new System.Drawing.Size(626, 469);
            this.splitContainer.SplitterDistance = 121;
            this.splitContainer.TabIndex = 1;
            // 
            // treeView
            // 
            this.treeView.ContextMenuStrip = this.ctxTree;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.FullRowSelect = true;
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(626, 469);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_MouseClick);
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
            this.ismiKopyalaToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.ismiKopyalaToolStripMenuItem.Text = "İsmi Kopyala";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.Control;
            this.panelTop.Controls.Add(this.topControlLayout);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(8);
            this.panelTop.Size = new System.Drawing.Size(862, 92);
            this.panelTop.TabIndex = 1;
            // 
            // topControlLayout
            // 
            this.topControlLayout.ColumnCount = 7;
            this.topControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.topControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.topControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.topControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.topControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.topControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.topControlLayout.Controls.Add(this.comboBox_Direction, 5, 1);
            this.topControlLayout.Controls.Add(this.label_Direction, 4, 1);
            this.topControlLayout.Controls.Add(this.lblRoot, 0, 0);
            this.topControlLayout.Controls.Add(this.txtRootProc, 1, 0);
            this.topControlLayout.Controls.Add(this.btnLoad, 2, 0);
            this.topControlLayout.Controls.Add(this.lblSearch, 4, 0);
            this.topControlLayout.Controls.Add(this.txtSearch, 5, 0);
            this.topControlLayout.Controls.Add(this.btnSearch, 6, 0);
            this.topControlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topControlLayout.Location = new System.Drawing.Point(8, 8);
            this.topControlLayout.Name = "topControlLayout";
            this.topControlLayout.RowCount = 2;
            this.topControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.topControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.topControlLayout.Size = new System.Drawing.Size(846, 76);
            this.topControlLayout.TabIndex = 0;
            // 
            // comboBox_Direction
            // 
            this.comboBox_Direction.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox_Direction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Direction.FormattingEnabled = true;
            this.comboBox_Direction.Location = new System.Drawing.Point(559, 41);
            this.comboBox_Direction.Name = "comboBox_Direction";
            this.comboBox_Direction.Size = new System.Drawing.Size(160, 23);
            this.comboBox_Direction.TabIndex = 7;
            // 
            // label_Direction
            // 
            this.label_Direction.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_Direction.AutoSize = true;
            this.label_Direction.Location = new System.Drawing.Point(489, 45);
            this.label_Direction.Name = "label_Direction";
            this.label_Direction.Size = new System.Drawing.Size(60, 15);
            this.label_Direction.TabIndex = 6;
            this.label_Direction.Text = "Direction:";
            // 
            // lblRoot
            // 
            this.lblRoot.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRoot.AutoSize = true;
            this.lblRoot.Location = new System.Drawing.Point(3, 7);
            this.lblRoot.Name = "lblRoot";
            this.lblRoot.Size = new System.Drawing.Size(52, 15);
            this.lblRoot.TabIndex = 0;
            this.lblRoot.Text = "Root SP:";
            // 
            // txtRootProc
            // 
            this.txtRootProc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRootProc.Location = new System.Drawing.Point(63, 3);
            this.txtRootProc.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.txtRootProc.Multiline = true;
            this.txtRootProc.Name = "txtRootProc";
            this.topControlLayout.SetRowSpan(this.txtRootProc, 2);
            this.txtRootProc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRootProc.Size = new System.Drawing.Size(330, 54);
            this.txtRootProc.TabIndex = 1;
            this.txtRootProc.Text = "dbo.up_winbank_gns_krreeskont";
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLoad.Location = new System.Drawing.Point(404, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(64, 24);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(489, 7);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 15);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSearch.Location = new System.Drawing.Point(559, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(210, 23);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.Text = "dbo.sel_yilsonutarihleri";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSearch.Location = new System.Drawing.Point(779, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 24);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Find";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(862, 561);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stored Procedure Hierarchy Viewer v2.0.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.panelObjectExplorer.ResumeLayout(false);
            this.panelObjectExplorerFilterHost.ResumeLayout(false);
            this.panelObjectExplorerFilterHost.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ctxTree.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.topControlLayout.ResumeLayout(false);
            this.topControlLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblRoot;
        private Label lblSearch;
        private ContextMenuStrip ctxTree;
        private ToolStripMenuItem ismiKopyalaToolStripMenuItem;
        private ComboBox comboBox_Direction;
        private Label label_Direction;
        private SplitContainer mainSplitContainer;
        private Panel panelObjectExplorer;
        private TreeView treeViewObjectExplorer;
        private Panel panelObjectExplorerFilterHost;
        private TextBox txtObjectExplorerFilter;
        private Label lblObjectExplorerHeader;
        private TableLayoutPanel topControlLayout;
    }
}