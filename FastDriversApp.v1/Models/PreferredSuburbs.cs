using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
   public class PreferredSuburbs : List<PreferredSuburb>
    {
        public PreferredSuburbs(int instructorId)
        {
            SQLHelper db = new SQLHelper();
            string sql = "SELECT suburb FROM preferredSuburb" +
                " WHERE instructorId = @InstructorId ";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@InstructorId", DbType.Int32);
            objParams[0].Value = instructorId;
            DataTable suburbs = db.ExecuteSQL(sql, objParams);
            foreach (DataRow dr in suburbs.Rows)
            {
                PreferredSuburb suburb = new PreferredSuburb(dr);
                this.Add(suburb);
            }            
        }

        public PreferredSuburbs()
        {
            SQLHelper db = new SQLHelper();
            string sql = "SELECT DISTINCT suburb FROM preferredSuburb";
            DataTable suburbs = db.ExecuteSQL(sql);
            foreach(DataRow dr in suburbs.Rows)
            {
                PreferredSuburb suburb = new PreferredSuburb(dr);
                this.Add(suburb);
            }

        }
    }
}
