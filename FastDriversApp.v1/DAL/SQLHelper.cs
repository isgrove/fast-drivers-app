﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.DAL
{
    public class SQLHelper
    {
        private string _conn;
        public SQLHelper()
        {
            _conn = ConfigurationManager.ConnectionStrings["FD"].ConnectionString;
        }

        public DataTable ExecuteSQL(string sql, SqlParameter[] parameters = null, bool storedProcedure = false)
        {
            DataTable dataTable = new DataTable();
            SqlConnection dbConnection = new SqlConnection(_conn);
            SqlCommand dbCommand = new SqlCommand(sql, dbConnection);//Fire the query
                                                                     // written in queryString using the connection object
            dbConnection.Open();
            if (storedProcedure == true)
            {
                dbCommand.CommandType = CommandType.StoredProcedure;
            }
            if (parameters != null)
            {
                AddParameters(dbCommand, parameters);
            }
            //Try the statement first and then if try is unsuccessful then handle it
            //C#.Net  - Exception as a class and acts as a base class to many different types of special Exceptions
            //Example - Class SqlException that handles Sql related Exceptions
            try
            {
                SqlDataReader drResults = dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                dataTable.Load(drResults);
                dbConnection.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dataTable;
        }

        public void AddParameters(SqlCommand objCommand, SqlParameter[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                objCommand.Parameters.Add(parameters[i]);
            }
        }

        public int ExecuteNonQuery(string sql, SqlParameter[] parameters = null, bool storedProcedure = false)
        {
            int returnValue = -1;
            SqlConnection dbConnection = new SqlConnection(_conn);
            SqlCommand dbCommand = new SqlCommand(sql, dbConnection);//Fire the query
                                                                     //written in queryString using the connection object
            if (storedProcedure == true)
            {
                dbCommand.CommandType = CommandType.StoredProcedure;
            }
            if (parameters != null)
            {
                AddParameters(dbCommand, parameters);
            }
            try
            {
                dbConnection.Open();
                returnValue = dbCommand.ExecuteNonQuery();
                dbConnection.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return returnValue;
        }
    }
}
