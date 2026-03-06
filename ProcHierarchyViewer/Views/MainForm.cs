using ProcHierarchyViewer.Models;
using ProcHierarchyViewer.Models.Enums;
using ProcHierarchyViewer.Presenters;
using ProcHierarchyViewer.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProcHierarchyViewer
{
    public partial class MainForm : Form, IMainView
    {
        private readonly IMainPresenter _presenter;
        private SplitContainer splitContainer;
        private List<ProcNode> currentRoots = new List<ProcNode>();
        private TreeNode _rightClickedNode;
        private Label _modeHeaderLabel;

        public MainForm(IMainPresenter presenter)
        {
            _presenter = presenter;
            InitializeComponent();
            InitializeModeHeader();

            _presenter.OnHierarchyBuilt += DisplayTree;
            _presenter.OnNotFound += DisplayNotFound;
            _presenter.OnFindProcNode += SelectedProcNode;
            _presenter.OnNotProcNode += DisplayNotFoundWord;
            _presenter.OnModeHeaderChanged += DisplayModeHeader;

            treeView.NodeMouseClick += treeView_MouseClick;
            ctxTree.Click += menuCopyName_Click;
            comboBox_Direction.SelectedIndexChanged += comboBox_Direction_SelectedIndexChanged;
        }

        public void DisplayTree(IEnumerable<ProcNode> roots)
        {
            //Arama iþlemi için atama yapýlýyor.
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
            MessageBox.Show("Aþaðýdaki SP(ler) bulunamadý:\n" + string.Join("\n", missing),
                            "SP Bulunamadý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void DisplayNotFoundWord(string missing)
        {
            MessageBox.Show("Aþaðýdaki SP listede bulunamadý:\n" + string.Join("\n", missing),
                            "SP Bulunamadý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void SelectedProcNode(ProcNode value)
        {
            var found = FindTreeNodeByProc(treeView.Nodes, value);
            if (found == null)
            {
                return;
            }

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

            var direction = GetSelectedDirection();
            if (direction == DirectionType_Stream.DownStream)
            {
                _presenter.LoadHierarchy_DownStream(roots);
            }
            else
            {
                _presenter.LoadHierarchy_UpStream(roots);
            }
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
                // Tag içine ProcNode koyduðumuz için burasý referans karþýlaþtýrmasý
                if (node.Tag == target)
                {
                    return node;
                }

                // Çocuklarda ara
                var foundInChildren = FindTreeNodeByProc(node.Nodes, target);
                if (foundInChildren != null)
                {
                    return foundInChildren;
                }
            }

            return null;
        }

        private void treeView_MouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            Fill_comboBox_Direction();
        }

        private void Fill_comboBox_Direction()
        {
            var items = new[]
            {
                new { Text = "Down Stream", Value = DirectionType_Stream.DownStream },
                new { Text = "Up Stream", Value = DirectionType_Stream.UpStream }
            };

            comboBox_Direction.DisplayMember = "Text";
            comboBox_Direction.ValueMember = "Value";
            comboBox_Direction.DataSource = items;

            _presenter.ChangeDirection(GetSelectedDirection());
        }

        private void InitializeModeHeader()
        {
            _modeHeaderLabel = new Label
            {
                Dock = DockStyle.Fill,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White
            };

            var treeLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2
            };
            treeLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            treeLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            treeLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            splitContainer.Panel1.Controls.Remove(treeView);
            treeView.Dock = DockStyle.Fill;

            treeLayout.Controls.Add(_modeHeaderLabel, 0, 0);
            treeLayout.Controls.Add(treeView, 0, 1);
            splitContainer.Panel1.Controls.Add(treeLayout);
        }

        private void comboBox_Direction_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.ChangeDirection(GetSelectedDirection());
        }

        private DirectionType_Stream GetSelectedDirection()
        {
            if (comboBox_Direction.SelectedValue is DirectionType_Stream direction)
            {
                return direction;
            }

            return DirectionType_Stream.DownStream;
        }

        private void DisplayModeHeader(string headerText, DirectionType_Stream mode)
        {
            _modeHeaderLabel.Text = headerText;
            _modeHeaderLabel.BackColor = mode == DirectionType_Stream.DownStream
                ? Color.SteelBlue
                : Color.Firebrick;
        }
    }
}
