using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    public class AvailableSession
    {
        private string _instructorFirstName;
        private string _instructorLastName;
        private string _startTime;
        private int _availabilityId;
        SQLHelper _db;

        public string InstructorFirstName
        {
            get { return _instructorFirstName; }
            set { _instructorFirstName = value; }
        }
        public string InstructorLastName
        {
            get { return _instructorLastName; }
            set { _instructorLastName = value; }
        }
        public string StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        public int AvailabilityId
        {
            get { return _availabilityId; }
            set { _availabilityId = value; }
        }
        
        public AvailableSession()
        {
            _db = new SQLHelper();
        }
        public AvailableSession(DataRow dr)
        {
            this.InstructorFirstName = dr["firstName"].ToString();
            this.InstructorLastName = dr["lastName"].ToString();
            this.StartTime = dr["startTime"].ToString();
            this.AvailabilityId = Convert.ToInt32(dr["availabilityId"].ToString());
            _db = new SQLHelper();
        }
    }
}