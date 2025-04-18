using System;
using System.Windows.Forms;
using ims.UI.Pages;
using ims.Utils;

namespace ims
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Set mock session (until login is implemented)
            CacheManager.SetSession("mock-org-id", "mock-user-id", "Admin");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
