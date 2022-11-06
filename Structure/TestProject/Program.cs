using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Mid;
using TestProject.Presentation;

namespace TestProject
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


            string errorMessage = DataBaseExecutor.Initialize();
            if (string.IsNullOrEmpty(errorMessage))
            {
                Application.Run(new MainForm());

            }
            else
            {
                Application.Run(new ErrorMessageForm());
            }
        }
    }
}
