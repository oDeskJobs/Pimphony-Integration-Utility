using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DesktopNotifier.Models;
using System.Xml;
using System.Net;
using NAppUpdate.Framework;
using NAppUpdate.Framework.Common;
using NAppUpdate.Framework.Sources;

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
        public static List<BulletinModel> listBulletin = new List<BulletinModel>();
        public static MainForm mainForm;

        


        [STAThread]
        static void Main(string[] args)
        {   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            for (int i = 0; i < args.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        password = args[i];
                        break;                    
                }
            }
            RegistrySettings.loadValues();
            mainForm = new MainForm();
            Application.Run(mainForm);
        }
    
        public static string password { get; set; }
        public static string updateLocation = "\\\\AQSBS\\aquasol\\aquasolpublic\\Aquanet\\AQuanet Updater";
        //public static string updateLocation = "\\\\COREI3\\Aquanet Updater";
    }
}