using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DBUtility.SQL
{
  public  class SQLHelper2
    {
        //封装数据库连接字符串
        private static string connString = ConfigurationManager.ConnectionStrings["InternalConnection"].ToString();

        #region 1. 封装格式化的sql语句方法

        /// <summary>
        /// 执行增删改通用方法
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(string sql)
        {
            //1. 数据库连接器:连接数据源
            SqlConnection conn = new SqlConnection(connString);

            //2. 用SqlCommand对象执行命令
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();//打开数据库连接
                return cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception($"调用public static int Update(string sql)方法发生错误：{ex.Message}");
            }
            finally
            {
                conn.Close();//关闭数据库连接
            }

        }

        /// <summary>
        /// 执行查询，获取单一结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>返回查询结果</returns>
        public static object GetSingleResult(string sql)
        {
            //1. 数据库连接器连接数据源
            SqlConnection conn = new SqlConnection(connString);

            //2. sqlcommand对数据源执行命令
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                //3. 打开连接
                conn.Open();
                return cmd.ExecuteScalar();//执行查询，返回第一行，第一列

            }
            catch (Exception ex)
            {

                throw new Exception($"调用 public static object GetSingleResult(string sql)方法发生错误{ex.Message}");
            }
            finally
            {
                conn.Close();//4. 关闭连接
            }
        }

        /// <summary>
        /// 获取一个结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>返回一个结果集</returns>
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {

                throw new Exception($"执行查询public static SqlDataReader GetReader(string sql)方法时发生错误{ex.Message}");
            }

        }
        #endregion

        #region 2. 封装带参数的sql语句方法（数据的安全性，避免sql注入）
        /// <summary>
        /// 增删改通用方法，带参数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param">参数数组</param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception($"调用方法public  static int Update(string sql, SqlParameter[] param)报错{ex.Message}");
            }
            finally
            {
                conn.Close();
            }

        }

        /// <summary>
        /// 获取单一结果集的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param">参数数组</param>
        /// <returns>返回单一结果集</returns>
        public static object GetSingleResult(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {

                throw new Exception($"调用方法  public static object GetSingleResult(string sql,SqlParameter[] param)出错{ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取结果集查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param">参数数组</param>
        /// <returns>返回结果集</returns>
        public static SqlDataReader GetReader(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {

                throw new Exception($"调用 public static SqlDataReader GetReader(string sql, SqlParameter[] param)出错{ex.Message}");
            }
        }
        #endregion

        #region 3. 封装调用存储过程的方法
        /// <summary>
        /// 调用存储过程执行增删改的通用方法
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="param">参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int UpdateByProc(string spName, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(spName, conn);
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;//声明当前操作的是存储过程
                cmd.Parameters.AddRange(param);

                return cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception($"调用 public static int UpdateByProc(string spName,SqlParameter[] param)出错{ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 调用存储过程获取单一结果集的查询
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="param"></param>
        /// <returns>返回单一结果集对象</returns>
        public static object GetSingleResultByProc(string spName, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(spName, conn);
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {

                throw new Exception($"调用方法 public static object GetSingleResultByProc(string spName, SqlParameter[] param)出错{ex.Message}");
            }
            finally
            {
                conn.Close();
            }

        }

        public static SqlDataReader GetReaderByProc(string spName, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(spName, conn);
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {

                throw new Exception($"调用public static SqlDataReader GetReaderByProc(string spName,SqlParameter[] param)出错{ex.Message}");
            }
        }

        #endregion

        #region 4. 带事务的增删改方法
        //如果多条语句，需要同时执行，担心中间执行出错，导致部分执行从而影响数据的一致性，可以采用事务

        /// <summary>
        /// 带事务的执行多条增删改的方法
        /// </summary>
        /// <param name="sqls"></param>
        /// <returns>返回受影响的行数</returns>
        public static int UpdateWithTran(List<string> sqls)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tran = conn.BeginTransaction();
                cmd.Transaction = tran;

                try
                {
                    int count = 0;
                    foreach (var sql in sqls)
                    {
                        if (sql.Trim().Length > 0)
                        {
                            cmd.CommandText = sql;
                            count = count + cmd.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                    return count;

                }
                catch
                {

                    tran.Rollback();
                    return 0;
                }

            }
        }


        #endregion

        #region 用泛型和事务实现数据的执行
        /// <summary>
        /// 采用泛型和Func委托实现带事务的通用的数据增删改方法
        /// 调用采用类似  object result2 = SQLHelper.Execute<object>(sql2, (cmd) => { return cmd.ExecuteScalar(); });
        /// </summary>
        /// <typeparam name="T">泛型，指cmd执行后的返回值，可以包括int或者object</typeparam>
        /// <param name="sql">执行语句，可以是一条语句或者多条语句合并成的一个string</param>
        /// <param name="func">委托，输入参数时sqlcommand，输出是泛型T，根据调用时直接指定</param>
        /// <returns>返回sqlcommand执行后的返回值</returns>
        public static T Execute<T>(string sql, Func<SqlCommand, T> func)
        {
            //using实质: 在程序编译阶段，编译器会自动将using语句生成为try-finally语句，并在finally块中调用对象的Dispose方法，来清理资源
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //打开连接
                conn.Open();

                //开启事务
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    //定义sqlcommand
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Transaction = trans;//指定sqlcommand对象的事务
                    T t = func(cmd);//调用外部传入的委托执行command
                    trans.Commit();//提交事务
                    return t;//返回值
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    trans.Rollback();//如果发生异常，执行回滚
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 采用泛型和Func委托实现带事务的通用的数据增删改方法
        /// 调用采用类似  bool result = SQLHelper.Update<int>(sqls, (cmd) => { return cmd.ExecuteNonQuery(); });
        /// 其中sqls参数时List<string>
        /// </summary>
        /// <typeparam name="T">泛型，指cmd执行后的返回值，可以包括int或者object</typeparam>
        /// <param name="sqls">执行语句，List<string> 多条sql语句集合</param>
        /// <param name="func">委托，输入参数时sqlcommand，输出是泛型T，根据调用时直接指定</param>
        /// <returns></returns>
        public static bool Update<T>(List<string> sqls, Func<SqlCommand, T> func)
        {
            //using实质: 在程序编译阶段，编译器会自动将using语句生成为try-finally语句，并在finally块中调用对象的Dispose方法，来清理资源
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                //开启事务
                SqlTransaction trans = conn.BeginTransaction();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;//指定sqlcommand的连接
                cmd.Transaction = trans;//指定sqlcommand对象的事务

                try
                {

                    foreach (var sql in sqls)//遍历sql
                    {

                        cmd.CommandText = sql;//指定当前sqlcommand的执行sql
                        T t = func(cmd);//调用委托方法执行sql
                    }
                    trans.Commit();//遍历完毕后，执行提交事务
                    return true;//返回执行成功标记
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    trans.Rollback();//任一出错，则执行回滚
                    return false;//返回失败提示
                    //throw ex;
                }




            }
        }

        #endregion
    }
}
