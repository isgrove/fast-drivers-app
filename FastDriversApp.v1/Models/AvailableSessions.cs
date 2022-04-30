using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    class AvailableSessions : List<AvailableSession>
    {
        public AvailableSessions(DateTime date, string time, string suburb)
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
            DataTable sessionsTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in sessionsTable.Rows)
            {
                AvailableSession session = new AvailableSession(dr);
                this.Add(session);
            }
        }
    }
}
