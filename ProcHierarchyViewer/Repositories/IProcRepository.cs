using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcHierarchyViewer.Repositories
{
    public interface IProcRepository
    {
        /// <summary>
        /// DB'den DataTable formatında prosedür hiyerarşi verisini getirir.
        /// </summary>
        DataTable GetHierarchyTable(string rootProc);
    }
}
