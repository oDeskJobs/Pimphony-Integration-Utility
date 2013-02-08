using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesktopNotifier.Models
{
    class BulletinModel
    {
        private int _seqno;
        private int _staffNo;
        private DateTime _bdate;
        private string _notes;
        private bool _complete;
        private DateTime _startDate;
        private int _sender;
        private bool _important;
        public bool _read;

        public BulletinModel(int _seqno, int _staffNo, DateTime _bdate, string _notes, bool _complete, DateTime _startDate, int _sender, bool _important, bool _read)
        {
            this._seqno = _seqno;
            this._staffNo = _staffNo;
            this._bdate = _bdate;
            this._notes = _notes;
            this._complete = _complete;
            this._startDate = _startDate;
            this._sender = _sender;
            this._important = _important;
            this._read = _read;
        }

        public int assignedTo
        {
            get { return _staffNo; }
            set { _staffNo = value; }
        }

        public int seqNo
        {
            get { return _seqno; }
            set { _seqno = value; }
        }

        public bool read
        {
            get { return _read; }
            set { _read = value; }
        }


        public bool important
        {
            get { return _important; }
            set { _important = value; }
        }

        public int senderId
        {
            get { return _sender; }
            set { _sender = value; }
        }
        public DateTime startDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime date
        {
            get { return _bdate; }
            set { _bdate = value; }
        }

        public string note
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public bool complete
        {
            get { return _complete; }
            set { _complete = value; }
        }
    }
}
