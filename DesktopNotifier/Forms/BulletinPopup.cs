using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

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

        private void chkComplete_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "update bulletin set [complete]=true where [seqno]=@seqno";
            OleDbCommand cmd = new OleDbCommand(sql, DataAccess.getInstance().getDataConnection());
            cmd.Parameters.AddWithValue("seqno", Program.listBulletin[iPosMessage].seqNo);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            //check it
            sql = "select [complete] from bulletin where seqno=@seqno";
            cmd = new OleDbCommand(sql, DataAccess.getInstance().getDataConnection());
            cmd.Parameters.AddWithValue("seqno", Program.listBulletin[iPosMessage].seqNo);
            OleDbDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                if (rdr.GetBoolean(rdr.GetOrdinal("complete")))
                {
                    chkComplete.Checked = true;
                    Program.listBulletin[iPosMessage].complete = true;
                }
                else
                {
                    MessageBox.Show("Unable to mark this task as complete! Please consult your system administration", Application.ProductName);
                }
            }
            rdr.Close();
            cmd.Dispose();

            

        }
    }
}
