using ProcHierarchyViewer.Models;
using ProcHierarchyViewer.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcHierarchyViewer.Services
{
    public class ProcHierarchyService : IProcHierarchyService
    {
        private readonly IProcRepository _repo;
        public ProcHierarchyService(IProcRepository repo)
        {
            _repo = repo;
        }

        public List<ProcNode> BuildTree(string rootProc)
        {
            var table = _repo.GetHierarchyTable(rootProc);


            try
            {
                // 1) ProcNode nesnelerini tekilleştirerek oluştur
                var nodeDict = table.Rows.Cast<DataRow>()
                    .GroupBy(r => (int)r["ObjId"])
                    .ToDictionary(
                        g => g.Key,
                        g => new ProcNode
                        {
                            Id = g.Key,
                            Name = g.First()["FullName"].ToString()
                        }
                    );

                // 2) Parent–child ilişkisini kur
                foreach (DataRow row in table.Rows)
                {
                    if (!row.IsNull("ParentObjId"))
                    {
                        int parentId = (int)row["ParentObjId"];
                        int childId = (int)row["ObjId"];
                        // parent ve child mutlaka nodeDict içinde var
                        nodeDict[parentId].Children.Add(nodeDict[childId]);
                    }
                }

                // 3) Kök düğümleri ayıkla ve döndür
                return nodeDict.Values
                    .Where(n => !table.Rows.Cast<DataRow>()
                        .Any(r2 => !r2.IsNull("ParentObjId") && (int)r2["ObjId"] == n.Id))
                    .ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }

        public ProcNode FindProcNode(IEnumerable<ProcNode> nodes, string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return null;

            foreach (var node in nodes)
            {
                if (node.Name.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
                    return node;

                var found = FindProcNode(node.Children, term);
                if (found != null)
                    return found;
            }

            return null;
        }
    }
}
