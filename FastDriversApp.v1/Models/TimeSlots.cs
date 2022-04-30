using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    public class TimeSlots : List<TimeSlot>
    {
        public TimeSlots()
        {
            SQLHelper helper = new SQLHelper();
            string sql = "SELECT timeSlotId, startTime FROM TimeSlot";
            DataTable types = new DataTable();
            types = helper.ExecuteSQL(sql);
            foreach (DataRow dr in types.Rows)
            {
                TimeSlot slots = new TimeSlot(dr);
                this.Add(slots);
            }
        }
    }
}
