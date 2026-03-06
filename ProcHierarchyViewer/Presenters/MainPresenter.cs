using ProcHierarchyViewer.Models;
using ProcHierarchyViewer.Models.Enums;
using ProcHierarchyViewer.Services;
using System;
using System.Collections.Generic;

namespace ProcHierarchyViewer.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        private readonly IProcHierarchyService _service;

        public event Action<List<ProcNode>> OnHierarchyBuilt;
        public event Action<IEnumerable<string>> OnNotFound;

        public event Action<ProcNode> OnFindProcNode;
        public event Action<string> OnNotProcNode;
        public event Action<string, DirectionType_Stream> OnModeHeaderChanged;

        public MainPresenter(IProcHierarchyService service)
        {
            _service = service;
        }

        public void LoadHierarchy_DownStream(IEnumerable<string> roots)
        {
            // OnHierarchyBuilt ve OnNotFound, Presenter ile View arasýndaki iletiþim kanallarýdýr.
            // "?.Invoke" kullanýmý, event'e kayýtlý handler varsa çalýþtýrýr, yoksa hiçbir iþlem yapmaz.
            var notFound = new List<string>();
            var result = new List<ProcNode>();

            foreach (var root in roots)
            {
                try
                {
                    var subtree = _service.BuildTree_DownStream(root);
                    result.AddRange(subtree);
                }
                catch
                {
                    notFound.Add(root);
                }
            }

            OnHierarchyBuilt?.Invoke(result);
            if (notFound.Count > 0 || result.Count < 1)
            {
                OnNotFound?.Invoke(notFound);
            }
        }

        public void LoadHierarchy_UpStream(IEnumerable<string> roots)
        {
            var notFound = new List<string>();
            var result = new List<ProcNode>();

            foreach (var root in roots)
            {
                try
                {
                    var subtree = _service.BuildTree_UpStream(root);
                    result.AddRange(subtree);
                }
                catch
                {
                    notFound.Add(root);
                }
            }

            OnHierarchyBuilt?.Invoke(result);
            if (notFound.Count > 0 || result.Count < 1)
            {
                OnNotFound?.Invoke(notFound);
            }
        }

        public void SearchProcNode(IEnumerable<ProcNode> procNode, string term)
        {
            var result = _service.FindProcNode(procNode, term);

            if (result != null)
            {
                OnFindProcNode?.Invoke(result);
            }
            else
            {
                OnNotProcNode?.Invoke(term);
            }
        }

        public void ChangeDirection(DirectionType_Stream direction)
        {
            var headerText = direction == DirectionType_Stream.DownStream
                ? "[ \u2193 DOWNSTREAM MODE ]"
                : "[ \u2191 UPSTREAM MODE ]";

            OnModeHeaderChanged?.Invoke(headerText, direction);
        }
    }
}
