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
        }
    }
}
