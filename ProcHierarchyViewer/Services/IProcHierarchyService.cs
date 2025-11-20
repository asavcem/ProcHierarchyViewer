using ProcHierarchyViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcHierarchyViewer.Services
{
    public interface IProcHierarchyService
    {
        /// <summary>
        /// DataTable'dan ProcNode ağacı örüntüsü oluşturur.
        /// </summary>
        List<ProcNode> BuildTree(string rootProc);

        ProcNode FindProcNode(IEnumerable<ProcNode> nodes, string term);
    }
}
