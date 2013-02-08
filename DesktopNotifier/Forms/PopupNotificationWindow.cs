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
    public partial class PopupNotificationWindow : Form
    {
        public PopupNotificationWindow()
        {
            InitializeComponent();
        }

        private void PopupNotificationWindow_Load(object sender, EventArgs e)
        {
            //Load the Form At Position of Main Form
            int LocationMainX = Screen.GetWorkingArea(this).Width - this.Width - 10;
            int locationMainy = Screen.GetWorkingArea(this).Height - this.Height;

            //Set the Location
            this.Location = new Point(LocationMainX, locationMainy);
            Program.AnimateWindow(this.Handle, 250, Program.AW_SLIDE | 0X8);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PopupNotificationWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Program.AnimateWindow(this.Handle, 250, Program.AW_SLIDE | Program.AW_HOR_NEGATIVE);
        }
    }
}
