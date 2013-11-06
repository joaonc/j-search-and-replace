using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSearchAndReplace
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool registryProcessed = SetRegistry.CheckCommandLineArgs(args);  // If specified in the args, updates the registry

            if (!registryProcessed)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormJSearchAndReplace());
            }
        }
    }
}
