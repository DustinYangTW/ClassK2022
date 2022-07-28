using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _07ADonet_Send_differentdb.Models
{
    public class GetData
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["aaa"].ConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter("", conn);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public DataTable querySql(string sql)
        {
            adapter.SelectCommand.CommandText = sql;
            adapter.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }      
        public DataTable querySqlBySP(string sqName)
        {
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.CommandText = sqName;
            adapter.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }


    }
}