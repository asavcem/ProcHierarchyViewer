using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcHierarchyViewer.Models
{
    public class ProcNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProcNode> Children { get; } = new List<ProcNode>();


        //Yardımcı: TreeView için otomatik ToString()
        public override string ToString() => Name;

    }
}
