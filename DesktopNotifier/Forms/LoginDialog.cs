using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DesktopNotifier
{
    public partial class LoginDialog : Form
    {
        List<StaffModel> listStaff;
        bool graceClose = false;
        public LoginDialog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            graceClose = false;
            Close();
        }

        private void LoginDialog_Load(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("select staffno, scode,sname from staff order by sname", DataAccess.getInstance().getDataConnection());
            OleDbDataReader rdr = cmd.ExecuteReader();
          
            listStaff = new List<StaffModel>();

            while (rdr.Read())
            {
                listStaff.Add(new StaffModel(rdr.GetInt32(rdr.GetOrdinal("staffno")), rdr.GetString(rdr.GetOrdinal("scode")), rdr.GetString(rdr.GetOrdinal("sname")), ""));
            }
            cboUsername.Items.Clear();
            cboUsername.DisplayMember = "Name";
            cboUsername.DataSource = listStaff;
            rdr.Close();
            cmd.Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string sql = "select * from [staff] where [scode]=@scode and [password]=@password";
            OleDbCommand cmd = new OleDbCommand(sql, DataAccess.getInstance().getDataConnection());
            cmd.Parameters.AddWithValue("scode", ((StaffModel) cboUsername.SelectedValue).Value);
            cmd.Parameters.AddWithValue("password", txtPassword.Text);
            OleDbDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                if(!rdr.GetBoolean(rdr.GetOrdinal("isactive")))
                {
                    MessageBox.Show("Your account has been deactivated. Please consult your administration regarding this");
                    rdr.Close();
                    cmd.Dispose();
                    return;
                }
                Program.loginStaff = new StaffModel(rdr.GetInt32(rdr.GetOrdinal("staffno")), rdr.GetString(rdr.GetOrdinal("scode")), rdr.GetString(rdr.GetOrdinal("sname")), "");
                rdr.Close();
                cmd.Dispose();
                graceClose = true;
                Close();
            }
            else
            {
                MessageBox.Show("You have supply a wrong credential", Application.ProductName);
                return;
            }
        }

        private void LoginDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (graceClose) return;
            if (MessageBox.Show("You won't be able to receive message notification upon exiting\nAre you sure?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                graceClose = true;
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        
    }
}
