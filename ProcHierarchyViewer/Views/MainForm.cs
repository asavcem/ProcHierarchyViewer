using ProcHierarchyViewer.Models;
using ProcHierarchyViewer.Presenters;
using ProcHierarchyViewer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProcHierarchyViewer
{
    public partial class MainForm : Form, IMainView
    {
        private readonly IMainPresenter _presenter;
        private SplitContainer splitContainer;
        private List<ProcNode> currentRoots = new List<ProcNode>();
        private TreeNode _rightClickedNode;

        public MainForm(IMainPresenter presenter)
        {
            _presenter = presenter;
            InitializeComponent();

            _presenter.OnHierarchyBuilt += DisplayTree;
            _presenter.OnNotFound += DisplayNotFound;

            _presenter.OnFindProcNode += SelectedProcNode;
            _presenter.OnNotProcNode += DisplayNotFoundWord;

            treeView.NodeMouseClick += treeView_MouseClick;
            ctxTree.Click += menuCopyName_Click;
        }

        public void DisplayTree(IEnumerable<ProcNode> roots)
        {
            //Arama işlemi için atama yapılıyor.
            currentRoots = roots.ToList();

            treeView.Nodes.Clear();
            foreach (var node in roots)
            {
                treeView.Nodes.Add(BuildTreeNode(node));

            }
            treeView.CollapseAll();
        }

        public void DisplayNotFound(IEnumerable<string> missing)
        {
            MessageBox.Show("Aşağıdaki SP(ler) bulunamadı:\n" + string.Join("\n", missing),
                            "SP Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void DisplayNotFoundWord(string missing)
        {
            MessageBox.Show("Aşağıdaki SP listede bulunamadı:\n" + string.Join("\n", missing),
                            "SP Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void SelectedProcNode(ProcNode value)
        {
            var found = FindTreeNodeByProc(treeView.Nodes, value);

            treeView.SelectedNode = found;
            found.EnsureVisible();
        }

        // Recursive helper to convert ProcNode to TreeNode
        private TreeNode BuildTreeNode(ProcNode proc)
        {
            var node = new TreeNode(proc.Name) { Tag = proc };
            foreach (var child in proc.Children)
            {
                node.Nodes.Add(BuildTreeNode(child));
            }
            return node;
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            //// TextBox'tan kök SP isimlerini al
            var roots = txtRootProc.Lines
                            .Select(l => l.Trim())
                            .Where(l => !string.IsNullOrEmpty(l));

            //if (false)//Down or Up
            //{
                // Presenter'ın LoadHierarchy metodunu doğrudan çağırıyoruz
                //_presenter.LoadHierarchy_DownStream(roots);
            //}
            //else
            //{
                _presenter.LoadHierarchy_UpStream(roots);
            //}
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string findWord = txtSearch.Text.Trim();
            _presenter.SearchProcNode(currentRoots, findWord);

        }

        private TreeNode FindTreeNodeByProc(TreeNodeCollection nodes, ProcNode target)
        {
            foreach (TreeNode node in nodes)
            {
                // Tag içine ProcNode koyduğumuz için burası referans karşılaştırması
                if (node.Tag == target)
                    return node;

                // Çocuklarda ara
                var foundInChildren = FindTreeNodeByProc(node.Nodes, target);
                if (foundInChildren != null)
                    return foundInChildren;
            }

            return null;
        }

        private void treeView_MouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                treeView.SelectedNode = e.Node;
                _rightClickedNode = e.Node;
                
            }
        }

        private void menuCopyName_Click(object sender, EventArgs e)
        {
            var node = _rightClickedNode ?? treeView.SelectedNode;

            if (node != null && !string.IsNullOrWhiteSpace(node.Text))
            {
                Clipboard.SetText(node.Text);
            }
        }
    }
}
