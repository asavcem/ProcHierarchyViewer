using System;
using System.Windows.Forms;
using ProcHierarchyViewer.Repositories;
using ProcHierarchyViewer.Services;
using ProcHierarchyViewer.Presenters;
using ProcHierarchyViewer.Views;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace ProcHierarchyViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainDbConnection = ConfigurationManager.ConnectionStrings["MainDb"];
            if (mainDbConnection == null || string.IsNullOrWhiteSpace(mainDbConnection.ConnectionString))
            {
                MessageBox.Show(
                    "App.config içinde 'MainDb' connection string tanýmlý deðil veya boþ.",
                    "Yapýlandýrma Hatasý",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string connStr = mainDbConnection.ConnectionString;

            // Manuel baðýmlýlýk oluþturma
            var repository = new SqlProcRepository(connStr);
            var service = new ProcHierarchyService(repository);
            var presenter = new MainPresenter(service);
            var mainForm = new MainForm(presenter);

            Application.Run(mainForm);
        }
    }
}
