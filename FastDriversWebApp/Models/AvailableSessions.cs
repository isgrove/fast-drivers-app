using FastDriversWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FastDriversWebApp.Models
{
    public class AvailableSessions
    {
        public DataTable GetAllAvailableSessions(DateTime date, string time, string suburb)
        {
            string sql = "SELECT t.startTime, a.availabilityId, i.firstName, i.lastName " +
                " FROM TimeSlot t, Availability a, Instructor i, PreferredSuburb ps" +
                " WHERE t.timeSlotId = a.timeSlotId " +
                " AND i.instructorId = a.instructorId " +
                " AND i.instructorId = ps.instructorId " +
                " AND a.availableDate = '" + date.ToString("yyyy-MM-dd") + "'" +
                " AND t.startTime = '" + time + "' " +
                " AND ps.suburb = '" + suburb + "' AND status = 'Available'";
            SQLHelper helper = new SQLHelper();
            return helper.ExecuteSQL(sql);

        }
    }
}