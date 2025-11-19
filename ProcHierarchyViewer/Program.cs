using System;
using System.Windows.Forms;
using ProcHierarchyViewer.Repositories;
using ProcHierarchyViewer.Services;
using ProcHierarchyViewer.Presenters;
using ProcHierarchyViewer.Views;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcHierarchyViewer
{
    static class Program
    {
        private const string ConnectionString = "(value)";  

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Manuel bağımlılık oluşturma

            var repository = new SqlProcRepository(ConnectionString);
            var service = new ProcHierarchyService(repository);
            var presenter = new MainPresenter(service);
            var mainForm = new MainForm(presenter);

            Application.Run(mainForm);

        }
    }
}
