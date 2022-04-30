using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    public class TransmissionTypes : List<TransmissionType>
    {
        public TransmissionTypes()
        {
            SQLHelper helper = new SQLHelper();
            string sql = "SELECT transmissionTypeId, typeName FROM TransmissionType";
            DataTable types = new DataTable();
            types = helper.ExecuteSQL(sql);
            foreach (DataRow dr in types.Rows)
            {
                TransmissionType type = new TransmissionType(dr);
                this.Add(type);
            }
        }
    }
}
