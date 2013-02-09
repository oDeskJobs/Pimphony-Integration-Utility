using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DesktopNotifier.Models;

namespace DesktopNotifier
{
    static class Program
    {
        //Constants
        public const int AW_SLIDE = 0X40000;
        public const int AW_HOR_POSITIVE = 0X1;
        public const int AW_HOR_NEGATIVE = 0X2;
        public const int AW_BLEND = 0X80000;

        [DllImport("user32")]
        public static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);

        //Global static object
        public static StaffModel loginStaff = null;
        public static List<BulletinModel> listBulletin;
        public static MainForm mainForm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RegistrySettings.loadValues();
            mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}
