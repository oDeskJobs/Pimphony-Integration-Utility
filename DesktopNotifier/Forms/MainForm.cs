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
using System.Media;

namespace DesktopNotifier
{
    public partial class MainForm : Form
    {
        private static PopupNotificationWindow popup = new PopupNotificationWindow();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //prepare tray 
            notifyIcon1.Visible = true;
            notifyIcon1.ContextMenuStrip = null;

            //prepare data connection
            if (!DataAccess.getInstance().startup())
            {
                Application.Exit();
                return;
            }
            
            //Login
            (new LoginDialog()).ShowDialog();
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;

            //timer
            resetTimer();
            timer1_Tick(null, null); //first call
        }

        public void resetTimer()
        {
            timer1.Enabled = false;
            timer1.Interval = RegistrySettings.checkInterval * 1000 * 60;
            timer1.Enabled = true;
            
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
            if (!popup.IsDisposed && popup.Visible) return;//SIMPLE, not checking it
            timer1.Enabled = false;
            try
            {
                fillListBulletin(true);
                if (Program.listBulletin.Count> 0)
                {
                    popupMessage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                timer1.Enabled = true;

        }

        public void fillListBulletin(bool playSound)
        {
            //fill listBulleting
            string sql = "select [seqno],[staff].[staffno],[staff].[sname],[bdate],[notes],[complete],[startdate],[sender],[important],[read] from [bulletin],staff where ([bulletin].[staffno]=@staffno) and ([complete]=false or [read]=false) and ([bulletin].[sender]=[staff].[staffno])";
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
            }
            else
            {
                //let's play sound!
                if(playSound && RegistrySettings.playNotificationSound && !popup.Visible) (new SoundPlayer(Application.StartupPath + "\\Media\\newmail.wav")).Play();
                tip = "You have " + Program.listBulletin.Count + " message(s) waiting\nClick here to display it";
                //popupMessage();
            }
            notifyIcon1.Text = tip;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (notifyIcon1.ContextMenuStrip == null) return;
            fillListBulletin(false);
            if (e.Button==MouseButtons.Left && Program.listBulletin.Count == 0)
            {
                notifyIcon1.ShowBalloonTip(1000,"",notifyIcon1.Text,ToolTipIcon.Info);
                return;
            }
             
            if (e.Button == MouseButtons.Left)
            {
                popupMessage();
            }
        }

        private static void popupMessage()
        {
            if (popup.IsDisposed) popup = new PopupNotificationWindow();
            popup.initPopupDisplay();
            popup.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void checkUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoupdateEngine.automaticUpdate = false;
            checkLatestSoftwareUpdate();
        }

        private void checkLatestSoftwareUpdate()
        {
            AutoupdateEngine.CheckForUpdates(new NAppUpdate.Framework.Sources.UncSource(string.Format("{0}\\{1}", Program.updateLocation, "piu.xml"), Program.updateLocation + "\\piu.xml"));
        }

        public void startTimerCheckLatestSoftwareUpdate()
        {
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            AutoupdateEngine.automaticUpdate = true;
            checkLatestSoftwareUpdate();            
        }
    }
}
