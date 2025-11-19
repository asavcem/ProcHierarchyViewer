using ProcHierarchyViewer.Models;
using ProcHierarchyViewer.Presenters;
using ProcHierarchyViewer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcHierarchyViewer
{
    public partial class MainForm : Form, IMainView
    {
        private readonly IMainPresenter _presenter;


        private SplitContainer splitContainer;

        public MainForm(IMainPresenter presenter)
        {
            _presenter = presenter;
            InitializeComponent();

            _presenter.OnHierarchyBuilt += DisplayTree;
            _presenter.OnNotFound += DisplayNotFound;
        }

        public void DisplayTree(IEnumerable<ProcNode> roots)
        {
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

        // Recursive helper to convert ProcNode to TreeNode
        private TreeNode BuildTreeNode(ProcNode proc)
        {
            var node = new TreeNode(proc.Name) { Tag = proc.Id };
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

            // Presenter'ın LoadHierarchy metodunu doğrudan çağırıyoruz
            _presenter.LoadHierarchy(roots);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchNode();
        }


        private void SearchNode()
        {
            var term = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(term))
                return;

            TreeNode found = null;
            void Traverse(TreeNodeCollection nodes)
            {
                foreach (TreeNode n in nodes)
                {
                    if (found != null)
                        return;
                    if (n.Text.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        found = n;
                        return;
                    }
                    Traverse(n.Nodes);
                }
            }

            Traverse(treeView.Nodes);
            if (found != null)
            {
                treeView.SelectedNode = found;
                found.EnsureVisible();
            }
            else
            {
                MessageBox.Show($"\"{term}\" bulunamadı.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
