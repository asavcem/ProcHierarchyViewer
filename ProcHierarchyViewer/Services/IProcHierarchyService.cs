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
        /// DataTable'dan ProcNode ağacı örüntüsü oluşturur. (DownStream)
        /// </summary>
        List<ProcNode> BuildTree_DownStream(string rootProc);

        /// <summary>
        /// DataTable'dan ProcNode ağacı örüntüsü oluşturur. (UpStream)
        /// </summary>
        List<ProcNode> BuildTree_UpStream(string rootProc);

        /// <summary>
        /// Listenen SP'ler arasında arama yapma işlemi
        /// </summary>
        ProcNode FindProcNode(IEnumerable<ProcNode> nodes, string term);
    }
}
