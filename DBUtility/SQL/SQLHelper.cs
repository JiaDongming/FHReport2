using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DBUtility
{
   public  class SQLHelper
    {
        //private static string connString = ConfigurationManager.ConnectionStrings["DevSuiteConnection"].ToString();
         private static string connString = ConfigurationManager.ConnectionStrings["InternalConnection"].ToString();
        //增删改
        public static int Update(string sql,SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connString))//定义连接对象
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(param);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }

        
        }

        //singleresult单集合查
        public static object GetSingleResult(string sql, SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connString))//定义连接对象
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(param);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        //sqldatareader查询

        public static SqlDataReader GetResultByReader(string sql,SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(param);
                    conn.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

          
        }


        public static SqlDataReader GetResultByReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
             
                    conn.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
            }
            catch (Exception ex)
            {
               
                throw ex;
            }


        }

        //datatable查询
        public static DataTable GetDataTable(string sql, params SqlParameter[] ps)
        {
            DataTable dt = null;
            DataSet ds = new DataSet();
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, connString))
            {
                sda.SelectCommand.Parameters.AddRange(ps);
                sda.Fill(ds);
            }
            dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

    }
}
