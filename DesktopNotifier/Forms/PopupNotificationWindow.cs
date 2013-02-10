using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DesktopNotifier.Forms
{
    public partial class PopupNotificationWindow : Form
    {

        int iPosMessage = -1;
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
            Program.mainForm.fillListBulletin(); //reset list
            Close();
        }

        private void PopupNotificationWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Program.AnimateWindow(this.Handle, 250, Program.AW_SLIDE | Program.AW_HOR_NEGATIVE);
        }

        internal void initPopupDisplay()
        {
            pnlMessage.Controls.Clear();
            if (Program.listBulletin.Count == 0)
            {
                iPosMessage = -1;
                lblMessage.Text = "";
                btnPrev.Enabled = false;
                btnNext.Enabled = false;
                pnlMessage.Controls.Add(lblEmptyMessage);
            }
            else if (Program.listBulletin.Count == 1)
            {
                iPosMessage = 0;
                btnPrev.Enabled = false;
                btnNext.Enabled = false;
                lblMessage.Text = "You have 1 message";
            }
            else
            {
                iPosMessage = 0;
                btnNext.Enabled = true;
                lblMessage.Text = "You have " + Program.listBulletin.Count + " messages";
            }

            displayMessage(iPosMessage);
        }

        private void displayMessage(int iPosMessage)
        {
            pnlMessage.Controls.Clear();
            BulletinPopup popup = new BulletinPopup(iPosMessage);
            popup.Dock = DockStyle.Fill;
            pnlMessage.Controls.Add(popup);
            //mark read
            string sql = "update [bulletin] set [read]=true where [seqno]=@seqno";
            OleDbCommand cmd = new OleDbCommand(sql, DataAccess.getInstance().getDataConnection());
            cmd.Parameters.AddWithValue("seqno", Program.listBulletin[iPosMessage].seqNo);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int oldPos = iPosMessage;
            if (iPosMessage < Program.listBulletin.Count-1)
            {
                iPosMessage++;
            }
            if(oldPos!=iPosMessage) displayMessage(iPosMessage);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            int oldPos = iPosMessage;
            if (iPosMessage > 0)
            {
                iPosMessage--;
            }
            if (oldPos != iPosMessage) displayMessage(iPosMessage);
        }
    }
}
