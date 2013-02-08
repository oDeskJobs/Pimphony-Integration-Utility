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
        public LoginDialog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You won't be able to receive message notification upon exiting\nAre you sure?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
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
            string sql = "select * from staff where scode=@scode";
            OleDbCommand cmd = new OleDbCommand(sql, DataAccess.getInstance().getDataConnection());
            cmd.Parameters.AddWithValue("scode", ((StaffModel) cboUsername.SelectedValue).Value);
            OleDbDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                Program.loginStaff = new StaffModel(rdr.GetInt32(rdr.GetOrdinal("staffno")), rdr.GetString(rdr.GetOrdinal("scode")), rdr.GetString(rdr.GetOrdinal("sname")), "");
            };
            rdr.Close();
            cmd.Dispose();

            //MessageBox.Show("Welcome " + Program.loginStaff.Name);

        }

        
    }
}
