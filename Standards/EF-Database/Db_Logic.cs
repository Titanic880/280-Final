using Microsoft.Data.SqlClient;
using Standards.User;
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

        public static User_Data Login(User_Data user_)
        {
            if (Sql_Functions.Connected)
            {
                if (Sql_Functions.Check_Table("USERS"))
                {
                    //Tests the Table for Data
                    string Q = "SELECT * FROM USERS WHERE UserName = '@U_NAME' and Password = '@PASS'";
                    SqlCommand cmdTest = new SqlCommand(Q, Sql_Functions.Sql);
                    cmdTest.Parameters.AddWithValue("@U_NAME", user_.UserName);
                    cmdTest.Parameters.AddWithValue("@PASS", user_.Password);
                    DataTable o = Sql_Functions.Query(cmdTest.CommandText);
                    if (o != null)
                    {
                        User_Data ret = new User_Data
                        {
                            Id = (int)o.Rows[0].ItemArray[0],
                            UserName = o.Rows[0].ItemArray[1].ToString(),
                            F_Name = o.Rows[0].ItemArray[2].ToString(),
                            Password = o.Rows[0].ItemArray[3].ToString()
                        };
                        return ret;
                    }
                }
            }
            return default;
            
        }

        public static bool Register(User_Data user_)
        {
            if (Sql_Functions.Connected)
            {
                if (Sql_Functions.Check_Table("USERS"))
                {
                    //Tests the Table for Data
                    string Q = "SELECT * FROM USERS WHERE UserName = '@U_NAME' and Password = '@PASS'";
                    SqlCommand cmdTest = new SqlCommand(Q, Sql_Functions.Sql);
                    cmdTest.Parameters.AddWithValue("@U_NAME", user_.UserName);
                    cmdTest.Parameters.AddWithValue("@PASS", user_.Password);

                    //Checks to see if anything is returned
                    if (Sql_Functions.RunScalar(cmdTest) == null)
                    {
                        //Inserts the user
                        string Query = "INSERT INTO [USERS] (UserName, F_Name, Password) VALUES (@U_Name, @FNAME, @PASS)";
                        SqlCommand cmd = new SqlCommand(Query, Sql_Functions.Sql);
                        cmd.Parameters.AddWithValue("@U_Name", user_.UserName);
                        cmd.Parameters.AddWithValue("@U_Name", user_.F_Name);
                        cmd.Parameters.AddWithValue("@U_Name", user_.Password);
                        Sql_Functions.RunNonQuery(cmd);
                        return true;
                    }
                }
            }
            return false;
        }
    }

    /// <summary>
    /// This is from an Internal resource of mine (Hasn't been pulled out this semester!)
    /// </summary>
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
            string Query = $"Select * From {TableName}";

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

