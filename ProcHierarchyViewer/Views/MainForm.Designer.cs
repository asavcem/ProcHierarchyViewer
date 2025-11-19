
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
            this.Text = "Stored Procedure Hierarchy Viewer";
            this.Width = 900;
            this.Height = 600;

            // SplitContainer for Tree
            splitContainer = new SplitContainer();
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Orientation = Orientation.Vertical;
            splitContainer.SplitterDistance = 300;
            splitContainer.Panel2Collapsed = true; // hide right panel
            this.Controls.Add(splitContainer);

            // Top panel for inputs
            panelTop = new Panel();
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 80;
            this.Controls.Add(panelTop);

            Label lblRoot = new Label();
            lblRoot.Text = "Root SP:";
            lblRoot.Left = 5;
            lblRoot.Top = 15;
            lblRoot.AutoSize = true;
            panelTop.Controls.Add(lblRoot);

            txtRootProc = new TextBox();
            txtRootProc.Left = 70;
            txtRootProc.Top = 12;
            txtRootProc.Width = 350;
            txtRootProc.Height = 60;
            txtRootProc.Multiline = true;
            txtRootProc.ScrollBars = ScrollBars.Vertical;
            txtRootProc.Text = "dbo.";
            panelTop.Controls.Add(txtRootProc);

            btnLoad = new Button();
            btnLoad.Text = "Load";
            btnLoad.Left = txtRootProc.Right + 10;
            btnLoad.Top = 11;
            btnLoad.Width = 60;
            btnLoad.Click += new EventHandler(btnLoad_Click);
            panelTop.Controls.Add(btnLoad);

            Label lblSearch = new Label();
            lblSearch.Text = "Search:";
            lblSearch.Left = btnLoad.Right + 20;
            lblSearch.Top = 15;
            lblSearch.AutoSize = true;
            panelTop.Controls.Add(lblSearch);

            txtSearch = new TextBox();
            txtSearch.Left = lblSearch.Right + 5;
            txtSearch.Top = 12;
            txtSearch.Width = 200;
            panelTop.Controls.Add(txtSearch);

            btnSearch = new Button();
            btnSearch.Text = "Find";
            btnSearch.Left = txtSearch.Right + 10;
            btnSearch.Top = 11;
            btnSearch.Width = 60;
            btnSearch.Click += new EventHandler(btnSearch_Click);
            panelTop.Controls.Add(btnSearch);

            // TreeView in left panel
            treeView = new TreeView();
            treeView.Dock = DockStyle.Fill;
            treeView.HideSelection = false;
            treeView.FullRowSelect = true;
            treeView.ContextMenuStrip = new ContextMenuStrip();
            //treeView.ContextMenuStrip.Items.Add("Copy", null, new EventHandler(copyMenu_Click));
            //treeView.KeyDown += new KeyEventHandler(treeView_KeyDown);
            splitContainer.Panel1.Controls.Add(treeView);

            //this.Load += new EventHandler(MainForm_Load);

        }

        #endregion
    }
}

