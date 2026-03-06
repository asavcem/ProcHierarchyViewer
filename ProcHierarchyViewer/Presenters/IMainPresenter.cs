using ProcHierarchyViewer.Models;
using ProcHierarchyViewer.Models.Enums;
using System;
using System.Collections.Generic;

namespace ProcHierarchyViewer.Presenters
{
    public interface IMainPresenter
    {
        /// <summary>View'den kullanýcý girdilerini alýr. (DownStream)</summary>
        void LoadHierarchy_DownStream(IEnumerable<string> roots);

        /// <summary>View'den kullanýcý girdilerini alýr. (UpStream)</summary>
        void LoadHierarchy_UpStream(IEnumerable<string> roots);

        /// <summary>TreeView için oluþturulan ProcNode listesini döner.</summary>
        event Action<List<ProcNode>> OnHierarchyBuilt;

        /// <summary>Bulunamayan SP isimlerini döner.</summary>
        event Action<IEnumerable<string>> OnNotFound;

        /// <summary>Dönen SP listesi içinde arama yapar.</summary>
        void SearchProcNode(IEnumerable<ProcNode> procNode, string term);

        /// <summary>Liste içerisinde olan SP bilgileri.</summary>
        event Action<ProcNode> OnFindProcNode;

        /// <summary>Liste içerisinde bulunamayan SP bilgisi.</summary>
        event Action<string> OnNotProcNode;

        /// <summary>Aktif yön deðiþimini Presenter katmanýnda ele alýr.</summary>
        void ChangeDirection(DirectionType_Stream direction);

        /// <summary>View'de gösterilecek mod baþlýðý bilgisini döner.</summary>
        event Action<string, DirectionType_Stream> OnModeHeaderChanged;
    }
}
