using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Testing is a process that proves the presence of an error - Destructive activity
//But cannot prove the absence of an error

namespace FastDriversApp.v1.Models
{
    public class Instructors : List<Instructor>
    {
        public Instructors()
        {
            SQLHelper db = new SQLHelper();
            string sql = "SELECT i.instructorId, i.firstName, i.lastName, i.phone, i.email, i.street, i.suburb, " +
                " i.state, i. postcode, i.dob, i.licenceNumber, t.typeName as transmissionType" +
                " FROM Instructor i, TransmissionType t " +
                " WHERE i.TransmissionTypeId = t.TransmissionTypeId ";
            DataTable instructorTable = db.ExecuteSQL(sql);
            foreach(DataRow dr in instructorTable.Rows)
            {
                Instructor newInstructor = new Instructor(dr);
                this.Add(newInstructor);
            }    
        }
    }
}
