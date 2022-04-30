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
    public class TransmissionType : INotifyPropertyChanged
    {
        private char _transmissionTypeId;
        private string _transmissionTypeName;
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public char TransmissionTypeId
        {
            get { return _transmissionTypeId; }
            set { _transmissionTypeId = value; }
        }
        public string TransmissionTypeName
        {
            get { return _transmissionTypeName; }
            set
            {
                _transmissionTypeName = value;
                OnPropertyChanged("TransmissionType");
            }
        }
        public TransmissionType()
        {
            _db = new SQLHelper();
        }
        public TransmissionType(DataRow dr)
        {
            this.TransmissionTypeId = Convert.ToChar(dr["transmissionTypeId"].ToString());
            this.TransmissionTypeName = dr["typeName"].ToString();
            _db = new SQLHelper();
        }
    }
}
