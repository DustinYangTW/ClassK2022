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

        /// <summary>
        /// 傳入table，或者是有沒有預存程序CommandType.text
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmt"></param>
        /// <returns></returns>
        public DataTable querySql(string sql, CommandType cmt)
        {
            adapter.SelectCommand.CommandType = cmt;
            adapter.SelectCommand.CommandText = sql;
            adapter.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }   
        public DataTable querySql(string sql, CommandType cmt,string id,string name)
        {
            adapter.SelectCommand.Parameters.AddWithValue("@id", id);
            adapter.SelectCommand.Parameters.AddWithValue("@name", name);

            adapter.SelectCommand.CommandType = cmt;
            adapter.SelectCommand.CommandText = sql;
            adapter.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }


        public DataTable querySql(string sql, CommandType cmt,string dtName)
        {
            adapter.SelectCommand.CommandType = cmt;
            adapter.SelectCommand.CommandText = sql;
            adapter.Fill(ds, dtName);
            dt = ds.Tables[dtName];
            return dt;
        }



        public DataTable querySql(string sql, CommandType cmt, List<SqlParameter> para)
        {
            foreach (SqlParameter p in para)
            {
                adapter.SelectCommand.Parameters.Add(p);
            }
            adapter.SelectCommand.CommandType = cmt;
            adapter.SelectCommand.CommandText = sql;
            adapter.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }
    }
}