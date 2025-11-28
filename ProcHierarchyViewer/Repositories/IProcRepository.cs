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
        /// DB'den DataTable formatında prosedür hiyerarşi verisini getirir. (DownStream)
        /// </summary>
        DataTable GetHierarchyTable_DownStream(string rootProc);

        /// <summary>
        /// DB'den DataTable formatında prosedür hiyerarşi verisini getirir. (UpStream)
        /// </summary>
        DataTable GetHierarchyTable_UpStream(string rootProc);
    }
}
