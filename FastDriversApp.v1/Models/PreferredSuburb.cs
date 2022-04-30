using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    public class PreferredSuburb :INotifyPropertyChanged
    {
        private string _suburb;
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public string Suburb
        {
            get { return _suburb; }
            set { _suburb = value;
                OnPropertyChanged("Suburb");
            }
        }
        public PreferredSuburb()
        {
            _db = new SQLHelper();
        }
        public PreferredSuburb(DataRow dr)
        {
            this.Suburb = dr["suburb"].ToString();
            _db = new SQLHelper();
        }
        public int InsertSuburb(int instructorId)
        {
            int returnValue = 0;
            string sql = "INSERT INTO PreferredSuburb(InstructorId, Suburb)" +
                "VALUES(@InstructorId, @Suburb)";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@InstructorId", DbType.Int32);
            objParams[0].Value = instructorId;
            objParams[1] = new SqlParameter("@Suburb", DbType.Int32);
            objParams[1].Value = this.Suburb;
            returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;
        }
        public int DeleteSuburb(int instructorId)
        {
            int returnValue = 0;
            string sql = "DELETE FROM PreferredSuburb " +
                "WHERE InstructorId = @InstructorId " +
                "AND Suburb = @Suburb";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@InstructorId", DbType.Int32);
            objParams[0].Value = instructorId;
            objParams[1] = new SqlParameter("@Suburb", DbType.Int32);
            objParams[1].Value = this.Suburb;
            returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;
        }
    }
}
