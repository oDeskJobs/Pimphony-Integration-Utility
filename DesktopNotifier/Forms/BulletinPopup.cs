using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DesktopNotifier.Forms
{
    public partial class BulletinPopup : UserControl
    {
        private int iPosMessage;
        private bool toggleBlink = true;

        public BulletinPopup()
        {
            InitializeComponent();
        }

        public BulletinPopup(int iPosMessage)
        {
            InitializeComponent();
            this.iPosMessage = iPosMessage;
            txtFrom.Text = Program.listBulletin[iPosMessage].senderExplained;
            txtMessage.Text = Program.listBulletin[iPosMessage].note;
            if (Program.listBulletin[iPosMessage].important)
            {
                picImportant.Visible = true;
                toggleBlink = true;
                timerFlashImportant.Enabled = true;
                picImportant.Image = global::DesktopNotifier.Properties.Resources.information_2;
            }
            else
            {
                picImportant.Visible = false;
                timerFlashImportant.Enabled = false;
            }
        }

        private void timerFlashImportant_Tick(object sender, EventArgs e)
        {
            if (!toggleBlink)
            {
                toggleBlink = !toggleBlink;
                picImportant.Image = global::DesktopNotifier.Properties.Resources.information_2;
            }
            else
            {
                toggleBlink = !toggleBlink;
                picImportant.Image = global::DesktopNotifier.Properties.Resources.information_4;
            }
         }
    }
}
