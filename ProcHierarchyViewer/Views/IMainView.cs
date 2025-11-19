using ProcHierarchyViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcHierarchyViewer.Views
{
    public interface IMainView
    {
        // Presenter'dan alınan veriler UI'a aktarılır
        void DisplayTree(IEnumerable<ProcNode> roots);
        void DisplayNotFound(IEnumerable<string> missing);
    }
}
