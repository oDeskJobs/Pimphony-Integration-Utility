using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility.ModifyRegistry;

namespace DesktopNotifier
{
    public class RegistrySettings
    {
        private static RegistrySettings instance = null;
        private static ModifyRegistry reg = new ModifyRegistry();

        public static string dbFilename;
        public static int checkInterval;
        public static bool playNotificationSound;

        private RegistrySettings()
        {
            loadValues();
        }

        public static RegistrySettings getInstance()
        {
            if (instance == null)
            {
                instance = new RegistrySettings();
            }
            return instance;

        }

        public static void loadValues()
        {
            dbFilename = (string)reg.Read("DB Filename", "");
            checkInterval = (int)reg.Read("Check Interval", 1);
            playNotificationSound = Convert.ToBoolean((int) reg.Read("playNotificationSound", 1));
        }

        public static void writeValues()
        {
            reg.Write("DB Filename", dbFilename);
            reg.Write("Check Interval", checkInterval);
            reg.Write("playNotificationSound", Convert.ToInt32(playNotificationSound));
        }

        
    }
}
