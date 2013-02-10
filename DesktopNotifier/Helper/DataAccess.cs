using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DesktopNotifier
{
    class DataAccess
    {
        private static DataAccess instance;
        OleDbConnection dataConnection = null;
        string myConnectionString;

        public static DataAccess getInstance()
        {
            if (instance == null)
            {
                instance = new DataAccess();
            }
            return instance;
        }

        private DataAccess()
        {
            myConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + RegistrySettings.dbFilename;
        }

        public OleDbConnection getDataConnection()
        {
            if (dataConnection == null)
            {
                dataConnection = new OleDbConnection();
                dataConnection.ConnectionString = myConnectionString;
            }
            if (dataConnection.State == System.Data.ConnectionState.Closed)
            {
                dataConnection.Open();
            }
            return dataConnection;
        }
        public bool startup()
        {
            if (!System.IO.File.Exists(RegistrySettings.dbFilename))
            {
                MessageBox.Show("Database not exist\nPlease run the Integration Settings to set the location of the database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
    }
}
