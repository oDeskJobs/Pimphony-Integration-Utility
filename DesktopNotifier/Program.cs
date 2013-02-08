using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DesktopNotifier
{
    static class Program
    {
        public static StaffModel loginStaff = null;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RegistrySettings.loadValues();
            Application.Run(new MainForm());
        }
    }
}
