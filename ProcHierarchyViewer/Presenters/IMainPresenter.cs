using ProcHierarchyViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcHierarchyViewer.Presenters
{
    public interface IMainPresenter
    {
        /// <summary>View'den kullanıcı girdilerini alır.</summary>
        void LoadHierarchy(IEnumerable<string> roots);

        /// <summary>TreeView için oluşturulan ProcNode listesini döner.</summary>
        event Action<List<ProcNode>> OnHierarchyBuilt;

        /// <summary>Bulunamayan SP isimlerini döner.</summary>
        event Action<IEnumerable<string>> OnNotFound;
    }
}
