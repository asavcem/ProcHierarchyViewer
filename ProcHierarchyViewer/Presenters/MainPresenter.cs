using ProcHierarchyViewer.Models;
using ProcHierarchyViewer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcHierarchyViewer.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        private readonly IProcHierarchyService _service;

        public event Action<List<ProcNode>> OnHierarchyBuilt;
        public event Action<IEnumerable<string>> OnNotFound;

        public MainPresenter(IProcHierarchyService service)
        {
            _service = service;
        }


        public void LoadHierarchy(IEnumerable<string> roots)
        {
            // OnHierarchyBuilt ve OnNotFound, Presenter ile View arasındaki iletişim kanallarıdır.
            // "?.Invoke" kullanımı, event'e kayıtlı handler varsa çalıştırır, yoksa hiçbir işlem yapmaz.
            var notFound = new List<string>();
            var result = new List<ProcNode>();

            foreach (var root in roots)
            {
                try
                {
                    var subtree = _service.BuildTree(root);
                    result.AddRange(subtree);
                }
                catch
                {
                    notFound.Add(root);
                }
            }

            OnHierarchyBuilt?.Invoke(result);
            if (notFound.Count > 0)
                OnNotFound?.Invoke(notFound);
        }
    }
}
