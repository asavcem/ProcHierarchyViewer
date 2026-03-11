using ProcHierarchyViewer.Models;
using ProcHierarchyViewer.Models.Enums;
using System;
using System.Collections.Generic;

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

        /// <summary>Dönen SP listesi içinde arama yapar.</summary>
        void SearchProcNode(IEnumerable<ProcNode> procNode, string term);

        /// <summary>Liste içerisinde olan SP bilgileri.</summary>
        event Action<ProcNode> OnFindProcNode;

        /// <summary>Liste içerisinde bulunamayan SP bilgisi.</summary>
        event Action<string> OnNotProcNode;

        /// <summary>Aktif yön değişimini Presenter katmanında ele alır.</summary>
        void ChangeDirection(DirectionType_Stream direction);

        /// <summary>Object Explorer için stored procedure listesini yükler.</summary>
        void LoadStoredProcedures();

        /// <summary>Yüklenen stored procedure isimlerini döner.</summary>
        event Action<IEnumerable<string>> OnStoredProceduresLoaded;

        /// <summary>Stored procedure listesi yüklenirken oluşan hatayı döner.</summary>
        event Action<string> OnStoredProceduresLoadFailed;

        /// <summary>View'de gösterilecek mod başlığı bilgisini döner.</summary>
        event Action<string, DirectionType_Stream> OnModeHeaderChanged;
    }
}