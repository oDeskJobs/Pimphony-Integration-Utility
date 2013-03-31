using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopNotifier.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            RegistrySettings.loadValues();
            numCheckInterval.Value = RegistrySettings.checkInterval;

            //check for autostart entry
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (key.GetValue("Aquasol Desktop Notifier") == null)
            {
                chkRuntAtStartup.Checked = false;
            }
            else
            {
                chkRuntAtStartup.Checked = true;
            }
            key.Close();

            //check for notif config
            chkPlayNotificationSound.Checked = RegistrySettings.playNotificationSound;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            RegistrySettings.checkInterval = (int) numCheckInterval.Value;
            RegistrySettings.playNotificationSound = chkPlayNotificationSound.Checked;
            Program.mainForm.resetTimer();
            RegistrySettings.writeValues();

            //register for autostart entry
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (chkRuntAtStartup.Checked)
            {
                key.SetValue("Aquasol Desktop Notifier", "\"" + Application.ExecutablePath + "\"");
            }
            else
            {
                key.DeleteValue("Aquasol Desktop Notifier");
            }
            key.Close();

            
            Close();
        }

        private void btnUpdateLocalRepository_Click(object sender, EventArgs e)
        {
            AdminAccess adminAccess = new AdminAccess();
            DialogResult dr = adminAccess.ShowDialog();
            if (dr == DialogResult.OK && adminAccess.password.Equals("aqua101"))
            {
                
            }
        }
    }
}
