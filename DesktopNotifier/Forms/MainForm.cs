using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            


            timer1.Enabled = true;
            
        }
    }
}
