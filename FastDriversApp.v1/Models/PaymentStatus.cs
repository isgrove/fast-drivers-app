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
    public class PaymentStatus : INotifyPropertyChanged
    {
        private int _paymentStatusId;
        private string _paymentStatus;
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public int PaymentStatusId
        {
            get { return _paymentStatusId; }
            set
            {
                _paymentStatusId = value;
                OnPropertyChanged("PaymentStatusId");
            }
        }

        public string Status
        {
            get { return _paymentStatus; }
            set
            {
                _paymentStatus = value;
                OnPropertyChanged("Status");
            }
        }
        public PaymentStatus()
        {
            _db = new SQLHelper();
        }
        public PaymentStatus(DataRow dr)
        {
            this.PaymentStatusId = Convert.ToInt32(dr["paymentStatusId"].ToString());
            this.Status = dr["paymentStatus"].ToString();
            _db = new SQLHelper();
        }
    }
}
