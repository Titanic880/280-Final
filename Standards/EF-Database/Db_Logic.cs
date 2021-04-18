using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standards.EF_Database
{
    public class Db_Logic
    {
        public static bool Connect(string Connection_String)
        {
            return Sql_Functions.SetConn(Connection_String);
        }

        public static bool Login(string UserName, string Password)
        {
            if (Sql_Functions.Connected)
            {
                Sql_Functions.RunScalar($"SELECT * FROM USERS WHERE UserName = '{UserName}' and Password = '{Password}'");
            }

            throw new NotImplementedException();
        }

        public static void Register(string UserName, string Password)
        {
            if (Sql_Functions.Connected)
            {

            }
        }
    }

    internal static class Sql_Functions
    {
        /// <summary>
        /// Primary Sql Connection - must be set prior to use
        /// </summary>
        internal static SqlConnection Sql { get; private set; }
        public static bool Connected { get; private set; }

        #region Startup
        /// <summary>
        /// Used to set the Connection
        /// </summary>
        /// <param name="Conn"></param>
        /// <returns></returns>
        public static bool SetConn(string ConnString)
        {
            Sql = new SqlConnection(ConnString);
            Connected = Test_Conn();
            return Connected;
        }
        public static bool SetConn(SqlConnection Conn)
        {
            Sql = Conn;
            Connected = Test_Conn();
            return Connected;
        }

        /// <summary>
        /// Tests the Sql Connection
        /// </summary>
        public static bool Test_Conn()
        {
            string Table_Loggging = "Create Table Test_conn (" +
                 "ID int not null Primary key Identity(0,1)," +
                 "LogLevel int not null," +
                 "Error_Desc varchar(50)," +
                 "Time_Of_Error DateTime not null" +
                 ");";
            string check_tbl = "Select * from Test_conn";

            bool test = true;

            try
            {
                Sql.Open();

                //Tests to see if the table exists, if it doesn't the runs the Table create
                try
                {
                    SqlCommand comm = new SqlCommand(check_tbl, Sql);
                    comm.ExecuteScalar();
                }
                catch
                {
                    test = false;
                }
                if (!test)
                {
                    SqlCommand cmd = new SqlCommand(Table_Loggging, Sql);
                    cmd.ExecuteScalar();
                }
                SqlCommand drop = new SqlCommand("Drop Table Test_conn;", Sql);
                drop.ExecuteScalar();
                test = true;
            }
            catch //(Exception ex)
            {
                test = false;
            }
            finally
            {
                if (Sql.State != ConnectionState.Closed)
                    Sql.Close();
            }

            return test;
        }

        /// <summary>
        /// Checks to see if the table exists in the database
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static bool Check_Table(string TableName)
        {
            string Query = "Select * From " + TableName;

            try
            {
                Sql.Open();
                SqlCommand cmd = new SqlCommand(Query, Sql);
                cmd.ExecuteScalar();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (Sql.State != ConnectionState.Closed)
                    Sql.Close();
            }
        }
        #endregion Startup

        #region Execution
        /// <summary>
        /// Runs the Scalar method and returns the result, or the error log : check for error by substring(0,2)
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public static object RunScalar(string Query)
        {
            try
            {
                Sql.Open();
                SqlCommand cmd = new SqlCommand(Query, Sql);
                object o = cmd.ExecuteScalar();
                return o;
            }
            catch (Exception ex)
            {
                return "--" + ex.Message;
            }
            finally
            {
                if (Sql.State != ConnectionState.Closed)
                    Sql.Close();
            }
        }
        /// <summary>
        /// Takes command and runs it
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public static object RunScalar(SqlCommand Query)
        {
            try
            {
                Sql.Open();
                Query.Connection = Sql;
                return Query.ExecuteScalar();
            }
            catch (Exception ex)
            {
                return "--" + ex.Message;
            }
            finally
            {
                if (Sql.State != ConnectionState.Closed)
                    Sql.Close();
            }
        }

        /// <summary>
        /// Fills a DataTable and returns it
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public static DataTable Query(string Query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(Query, Sql);
            adapter.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Executes a Query returns if it is successful or not
        /// </summary>
        /// <param name="Query"></param>
        public static bool RunNonQuery(string Query)
        {
            try
            {
                Sql.Open();
                SqlCommand cmd = new SqlCommand(Query, Sql);
                cmd.ExecuteNonQuery().ToString();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (Sql.State != ConnectionState.Closed)
                    Sql.Close();
            }
        }
        /// <summary>
        /// Executes a Query returns if it is successful or not
        /// </summary>
        /// <param name="Query"></param>s
        public static bool RunNonQuery(SqlCommand Query)
        {
            try
            {
                Sql.Open();
                Query.Connection = Sql;
                Query.ExecuteNonQuery().ToString();
                return true;
            }
            catch //(Exception ex)
            {
                return false;
            }
            finally
            {
                if (Sql.State != ConnectionState.Closed)
                    Sql.Close();
            }
        }
        #endregion Execution
    }
}

