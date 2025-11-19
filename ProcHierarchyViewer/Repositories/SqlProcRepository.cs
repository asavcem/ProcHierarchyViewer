using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcHierarchyViewer.Repositories
{
    public class SqlProcRepository : IProcRepository
    {
        private readonly string _connectionString;
        public SqlProcRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetHierarchyTable(string rootProc)
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "dbo.kr_SP_HierarchyView";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RootProc", rootProc);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                conn.Close();
            }

            return dt;
        }
    }
}
