using ProcHierarchyViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace ProcHierarchyViewer.Presenters
{
    public interface IMainPresenter
    {
        /// <summary>View'den kullanıcı girdilerini alır. (DownStream)</summary>
        void LoadHierarchy_DownStream(IEnumerable<string> roots);

        /// <summary>View'den kullanıcı girdilerini alır. (UpStream)</summary>
        void LoadHierarchy_UpStream(IEnumerable<string> roots);

        /// <summary>TreeView için oluşturulan ProcNode listesini döner.</summary>
        event Action<List<ProcNode>> OnHierarchyBuilt;

        /// <summary>Bulunamayan SP isimlerini döner.</summary>
        event Action<IEnumerable<string>> OnNotFound;

        /// <summary>Dönen SP Listesi içinde arama yapar</summary>
        void SearchProcNode(IEnumerable<ProcNode> procNode, string term);

        /// <summary>Liste içerisinde olan SP bilgileri</summary>
        event Action<ProcNode> OnFindProcNode;

        ///<summary>Liste içerisinde bulanamayan SP bilgisi</summary>
        event Action<string> OnNotProcNode;
    }
}
