using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    public class PaymentStatuses : List<PaymentStatus>
    {
        public PaymentStatuses()
        {
            SQLHelper helper = new SQLHelper();
            string sql = "SELECT paymentStatusId, paymentStatus FROM PaymentStatus";
            DataTable types = new DataTable();
            types = helper.ExecuteSQL(sql);
            foreach (DataRow dr in types.Rows)
            {
                PaymentStatus status = new PaymentStatus(dr);
                this.Add(status);
            }
        }
    }
}
