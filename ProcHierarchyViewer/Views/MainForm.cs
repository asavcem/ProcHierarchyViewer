using ProcHierarchyViewer.Models;
using ProcHierarchyViewer.Models.Enums;
using ProcHierarchyViewer.Presenters;
using ProcHierarchyViewer.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProcHierarchyViewer
{
    public partial class MainForm : Form, IMainView
    {
        private const string ObjectExplorerStoredProcedureNodeTag = "StoredProcedure";
        private const int EM_SETCUEBANNER = 0x1501;

        private readonly IMainPresenter _presenter;
        private readonly List<string> _allStoredProcedures = new List<string>();
        private SplitContainer splitContainer;
        private List<ProcNode> currentRoots = new List<ProcNode>();
        private TreeNode _rightClickedNode;
        private TreeNode _storedProceduresExplorerNode;
        private Label _modeHeaderLabel;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        public MainForm(IMainPresenter presenter)
        {
            _presenter = presenter;
            InitializeComponent();
            InitializeModeHeader();
            WirePresenterEvents();
            WireControlEvents();
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
            if (found == null)
            {
                return;
            }

            treeView.SelectedNode = found;
            found.EnsureVisible();
        }

        private void WirePresenterEvents()
        {
            _presenter.OnHierarchyBuilt += DisplayTree;
            _presenter.OnNotFound += DisplayNotFound;
            _presenter.OnFindProcNode += SelectedProcNode;
            _presenter.OnNotProcNode += DisplayNotFoundWord;
            _presenter.OnModeHeaderChanged += UpdateModeHeader;
            _presenter.OnStoredProceduresLoaded += LoadStoredProceduresIntoExplorer;
            _presenter.OnStoredProceduresLoadFailed += DisplayStoredProceduresLoadError;
        }

        private void WireControlEvents()
        {
            treeView.NodeMouseClick += treeView_MouseClick;
            treeViewObjectExplorer.AfterSelect += treeViewObjectExplorer_AfterSelect;
            treeViewObjectExplorer.NodeMouseDoubleClick += treeViewObjectExplorer_NodeMouseDoubleClick;
            txtObjectExplorerFilter.TextChanged += txtObjectExplorerFilter_TextChanged;
            ctxTree.Click += menuCopyName_Click;
            comboBox_Direction.SelectedIndexChanged += comboBox_Direction_SelectedIndexChanged;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeExplorer();
            Fill_comboBox_Direction();
        }

        private void InitializeExplorer()
        {
            BuildObjectExplorerTree();
            SetObjectExplorerFilterPlaceholder();
            RequestStoredProcedures();
        }

        private void RequestStoredProcedures()
        {
            _presenter.LoadStoredProcedures();
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

        private TreeNode FindTreeNodeByProc(TreeNodeCollection nodes, ProcNode target)
        {
            foreach (TreeNode node in nodes)
            {
                // Tag içine ProcNode koyduğumuz için burası referans karşılaştırması
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadHierarchy();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string findWord = txtSearch.Text.Trim();
            _presenter.SearchProcNode(currentRoots, findWord);
        }

        private void treeView_MouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView.SelectedNode = e.Node;
                _rightClickedNode = e.Node;
            }
        }

        private void treeViewObjectExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectExplorerStoredProcedure(e.Node);
        }

        private void treeViewObjectExplorer_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!SelectExplorerStoredProcedure(e.Node))
            {
                return;
            }

            LoadHierarchy();
        }

        private void txtObjectExplorerFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyStoredProcedureFilter();
        }

        private bool SelectExplorerStoredProcedure(TreeNode node)
        {
            if (!IsStoredProcedureExplorerNode(node))
            {
                return false;
            }

            txtRootProc.Text = node.Text;
            return true;
        }

        private bool IsStoredProcedureExplorerNode(TreeNode node)
        {
            return node != null
                && node.Tag is string nodeTag
                && nodeTag == ObjectExplorerStoredProcedureNodeTag;
        }

        private void LoadHierarchy()
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

        private void menuCopyName_Click(object sender, EventArgs e)
        {
            var node = _rightClickedNode ?? treeView.SelectedNode;

            if (node != null && !string.IsNullOrWhiteSpace(node.Text))
            {
                Clipboard.SetText(node.Text);
            }
        }

        private void BuildObjectExplorerTree()
        {
            treeViewObjectExplorer.BeginUpdate();
            treeViewObjectExplorer.Nodes.Clear();

            var databaseNode = new TreeNode("Database");
            var dbBankingNode = new TreeNode("dbbanking");
            _storedProceduresExplorerNode = new TreeNode("Stored Procedures");

            dbBankingNode.Nodes.Add(_storedProceduresExplorerNode);
            databaseNode.Nodes.Add(dbBankingNode);
            treeViewObjectExplorer.Nodes.Add(databaseNode);

            databaseNode.Expand();
            dbBankingNode.Expand();
            _storedProceduresExplorerNode.Expand();
            treeViewObjectExplorer.EndUpdate();
        }

        private void SetObjectExplorerFilterPlaceholder()
        {
            SendMessage(txtObjectExplorerFilter.Handle, EM_SETCUEBANNER, (IntPtr)1, "Filter SP...");
        }

        private void LoadStoredProceduresIntoExplorer(IEnumerable<string> storedProcedures)
        {
            CacheStoredProcedures(storedProcedures);
            ApplyStoredProcedureFilter();
        }

        private void CacheStoredProcedures(IEnumerable<string> storedProcedures)
        {
            _allStoredProcedures.Clear();
            _allStoredProcedures.AddRange(storedProcedures);
        }

        private void ApplyStoredProcedureFilter()
        {
            if (_storedProceduresExplorerNode == null)
            {
                return;
            }

            PopulateStoredProcedureNodes(GetFilteredStoredProcedures());
        }

        private IEnumerable<string> GetFilteredStoredProcedures()
        {
            var filterText = txtObjectExplorerFilter.Text.Trim();
            if (string.IsNullOrWhiteSpace(filterText))
            {
                return _allStoredProcedures;
            }

            return _allStoredProcedures
                .Where(name => name.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        private void PopulateStoredProcedureNodes(IEnumerable<string> storedProcedures)
        {
            treeViewObjectExplorer.BeginUpdate();
            _storedProceduresExplorerNode.Nodes.Clear();

            foreach (var storedProcedure in storedProcedures)
            {
                _storedProceduresExplorerNode.Nodes.Add(CreateStoredProcedureNode(storedProcedure));
            }

            _storedProceduresExplorerNode.Expand();
            treeViewObjectExplorer.EndUpdate();
        }

        private TreeNode CreateStoredProcedureNode(string storedProcedure)
        {
            return new TreeNode(storedProcedure)
            {
                Tag = ObjectExplorerStoredProcedureNodeTag
            };
        }

        private void DisplayStoredProceduresLoadError(string errorMessage)
        {
            MessageBox.Show("Stored Procedures listesi yüklenemedi:\n" + errorMessage,
                            "Object Explorer",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
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
            _modeHeaderLabel = CreateModeHeaderLabel();

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

        private Label CreateModeHeaderLabel()
        {
            return new Label
            {
                Dock = DockStyle.Fill,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White
            };
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

        private void UpdateModeHeader(string headerText, DirectionType_Stream mode)
        {
            _modeHeaderLabel.Text = headerText;
            _modeHeaderLabel.BackColor = GetModeHeaderBackColor(mode);
        }

        private Color GetModeHeaderBackColor(DirectionType_Stream mode)
        {
            return mode == DirectionType_Stream.DownStream
                ? Color.SteelBlue
                : Color.Firebrick;
        }
    }
}