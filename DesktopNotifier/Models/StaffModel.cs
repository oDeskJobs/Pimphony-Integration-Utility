using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesktopNotifier
{
    class StaffModel
    {
        private string scode;
        private string sname;
        private string password;

        public StaffModel(string scode, string sname, string password)
        {
            this.scode = scode;
            this.sname = sname;
            this.password = password;
        }

        public string Value
        {
            get { return scode; }
            set { scode = value; }
        }
        public string Name
        {
            get { return sname; }
            set { sname = value; }
        }
    }
}
