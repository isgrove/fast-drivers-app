using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    public class BookingStatuses : List<BookingStatus>
    {
        public BookingStatuses()
        {
            SQLHelper helper = new SQLHelper();
            string sql = "SELECT bookingStatusId, bookingStatus FROM BookingStatus";
            DataTable types = new DataTable();
            types = helper.ExecuteSQL(sql);
            foreach (DataRow dr in types.Rows)
            {
                BookingStatus status = new BookingStatus(dr);
                this.Add(status);
            }
        }
    }
}
