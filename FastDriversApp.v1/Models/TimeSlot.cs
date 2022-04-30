using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    public class TimeSlot : INotifyPropertyChanged
    {
        private int _timeSlotId;
        private string _startTime;
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public int TimeSlotId
        {
            get { return _timeSlotId; }
            set
            {
                _timeSlotId = value;
                OnPropertyChanged("TimeSlotId");
            }
        }

        public string StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }
        public TimeSlot()
        {
            _db = new SQLHelper();
        }
        public TimeSlot(DataRow dr)
        {
            this.TimeSlotId = Convert.ToInt32(dr["timeSlotId"].ToString());
            this.StartTime = dr["startTime"].ToString();
            _db = new SQLHelper();
        }
    }
}