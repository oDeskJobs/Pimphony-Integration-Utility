using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using DesktopNotifier.Models;
using DesktopNotifier.Forms;

namespace DesktopNotifier
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;

            //prepare data connection
            DataAccess.getInstance().startup();
            
            //Login
            (new LoginDialog()).ShowDialog();

            //timer
            timer1.Interval = RegistrySettings.checkInterval * 1000 * 60;
            timer1.Enabled = true;
            timer1_Tick(sender, e); //first call
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You won't be able to receive message notification upon exiting\nAre you sure?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            try
            {

                //fill listBulleting
                string sql = "select [seqno],[staff].[staffno],[staff].[sname],[bdate],[notes],[complete],[startdate],[sender],[important],[read] from [bulletin],staff where [bulletin].[staffno]=@staffno and [read]=false and [bulletin].[sender]=[staff].[staffno]";
                OleDbCommand cmd = new OleDbCommand(sql, DataAccess.getInstance().getDataConnection());
                cmd.Parameters.AddWithValue("staffno", Program.loginStaff.staffNo);
                OleDbDataReader rdr = cmd.ExecuteReader();
                Program.listBulletin = new List<BulletinModel>();
                while (rdr.Read())
                {
                    Program.listBulletin.Add(new
                        BulletinModel(rdr.GetInt32(rdr.GetOrdinal("seqno")),
                        rdr.GetInt32(rdr.GetOrdinal("staffno")),
                        rdr.GetDateTime(rdr.GetOrdinal("bdate")),
                        rdr.GetString(rdr.GetOrdinal("notes")),
                        rdr.GetBoolean(rdr.GetOrdinal("complete")),
                        rdr.GetDateTime(rdr.GetOrdinal("startdate")),
                        rdr.GetInt32(rdr.GetOrdinal("sender")),
                        rdr.GetBoolean(rdr.GetOrdinal("important")),
                        rdr.GetBoolean(rdr.GetOrdinal("read")),
                        rdr.GetString(rdr.GetOrdinal("sname"))));
                }
                rdr.Close();
                cmd.Dispose();

                //store and display in a nice sliding notification window
                string tip;
                if (Program.listBulletin.Count == 0)
                {
                    tip = "You don't have new messages";
                }else{
                    tip = "You have " + Program.listBulletin.Count + " message(s) waiting\nClick here to display it";
                    popupMessage();
                }
                notifyIcon1.Text = tip;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                timer1.Enabled = true;

        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Program.listBulletin == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                popupMessage();
            }
        }

        private static void popupMessage()
        {
            PopupNotificationWindow popup = new PopupNotificationWindow();
            popup.initPopupDisplay();
            popup.Show();
        }
    }
}
