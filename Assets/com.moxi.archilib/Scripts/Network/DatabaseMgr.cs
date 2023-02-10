using System.Data;
using UnityEngine;
using MySql.Data.MySqlClient;

namespace AppArchi.Networking
{
    public class DatabaseMgr
    {
        //request
        public static MySqlConnection sqlConnection;
        //Host
        string host;
        public string Host { get { return host; } set { host = value; } }
        //User
        string user;
        public string User { get { return user; } set { user = value; } }
        //Password
        string pwd;
        public string Pwd { get { return pwd; } set { pwd = value; } }
        //Database
        string database;
        public string Database { get { return database; } set { database = value; } }
        public void Bind(string host, string user, string pwd, string database)
        {
            this.host = host;
            this.user = user;
            this.pwd = pwd;
            this.database = database;
        }
        public void Connect()
        {
            try
            {
                string sql = string.Format("Database={0};Data Source={1};User Id={2};Password={3};", database, host, user, pwd, "3306");
                sqlConnection = new MySqlConnection(sql);
                sqlConnection.Open();
#if UNITY_EDITOR
                Debug.Log("Database have connected!");
#endif
            }
            catch (System.Exception)
            {
#if UNITY_EDITOR
                Debug.Log("Connect Failed!");
#endif
            }
        }
        public void Close()
        {
            if (IsDatabaseOpen())
            {
                sqlConnection.Close();
#if UNITY_EDITOR
                Debug.Log("Database have closed!");
#endif
            }
        }
        bool IsDatabaseOpen()
        {
            if (sqlConnection == null) return false;
            return sqlConnection.State == ConnectionState.Open;
        }
        public bool Insert<T>(string table, string column, T value)
        {
            if (!IsDatabaseOpen()) Connect();
            try
            {
                string cmd = string.Format("Insert into {0} where {1} = @paral0", table, column);
                using (MySqlCommand insert = new MySqlCommand(cmd, sqlConnection))
                {
                    insert.Parameters.AddWithValue("paral0", value);
                    MySqlDataReader reader = insert.ExecuteReader();
                    if (reader.Read())
                    {
                    }
                }
#if UNITY_EDITOR
                Debug.Log("Insert Succeed!");
#endif
                return true;

            }
            catch (System.Exception)
            {
#if UNITY_EDITOR
                Debug.Log("Insert Failed!");
#endif
                return false;
            }
        }
        public bool Insert<T1, T2>(string table, string column1, T1 value1, string column2, T2 value2)
        {
            if (!IsDatabaseOpen()) Connect();
            try
            {
                string cmd = string.Format("insert into {0} set {1} =@paral0 and {2} =@paral1", table, column1, column2);
                using (MySqlCommand insert = new MySqlCommand(cmd, sqlConnection))
                {
                    insert.Parameters.AddWithValue("paral0", value1);
                    insert.Parameters.AddWithValue("paral1", value2);
                    MySqlDataReader reader = insert.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                }
#if UNITY_EDITOR
                Debug.Log("Insert Succeed!");
#endif
                return true;

            }
            catch (System.Exception)
            {
#if UNITY_EDITOR
                Debug.Log("Insert Failed!");
#endif
                throw;
            }
        }
        public bool Delete<T>(string table, string column, T value)
        {
            if (!IsDatabaseOpen()) Connect();
            try
            {
                string cmd = string.Format("delete from {0} where {1} =@paral0", table, column);
                using (MySqlCommand insert = new MySqlCommand(cmd, sqlConnection))
                {
                    insert.Parameters.AddWithValue("paral0", value);
                    MySqlDataReader reader = insert.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                }

#if UNITY_EDITOR
                Debug.Log("Delete Succeed!");
#endif
                return true;

            }
            catch (System.Exception)
            {
#if UNITY_EDITOR
                Debug.Log("Delete Failed!");
#endif
                return false;
            }
        }
        public bool Delete<T1, T2>(string table, string column1, T1 value1, string column2, T2 value2)
        {
            if (!IsDatabaseOpen()) Connect();
            try
            {
                string cmd = string.Format("delete from {0} where {1} =@paral0 and {2} =@paral1", table, column1, column2);
                using (MySqlCommand insert = new MySqlCommand(cmd, sqlConnection))
                {
                    insert.Parameters.AddWithValue("paral0", value1);
                    insert.Parameters.AddWithValue("paral1", value2);
                    MySqlDataReader reader = insert.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                }

#if UNITY_EDITOR
                Debug.Log("Delete Succeed!");
#endif
                return true;

            }
            catch (System.Exception)
            {
#if UNITY_EDITOR
                Debug.Log("Delete Failed!");
#endif
                return false;
            }
        }
        public string Select<T>(string key, string table, string column, T value)
        {
            if (!IsDatabaseOpen()) Connect();
            try
            {
                string cmd = string.Format("Select {0} from {1} where {2} = @paral0", key, table, column);
                using (MySqlCommand insert = new MySqlCommand(cmd, sqlConnection))
                {
                    insert.Parameters.AddWithValue("paral0", value);
                    MySqlDataReader reader = insert.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                    string str = reader[0].ToString();
                    Close();
                    return str;
                }
            }
            catch (System.Exception)
            {
#if UNITY_EDITOR
                Debug.Log("Search Failed!");
#endif
                return null;
            }
        }
        public string Select<T1, T2>(string key, string table, string column1, T1 value1, string column2, T2 value2)
        {
            if (!IsDatabaseOpen()) Connect();
            try
            {
                string cmd = string.Format("Select {0} from {1} where {2} = @paral0 and {3} =@paral1", key, table, column1, column2);
                using (MySqlCommand insert = new MySqlCommand(cmd, sqlConnection))
                {
                    insert.Parameters.AddWithValue("paral0", value1);
                    insert.Parameters.AddWithValue("paral1", value2);
                    MySqlDataReader reader = insert.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                    string str = reader[0].ToString();
                    Close();
                    return str;
                }
            }
            catch (System.Exception)
            {
#if UNITY_EDITOR
                Debug.Log("Search Failed!");
#endif
                return null;
            }
        }
        public bool Update<T1, T2>(string table, string key, T1 value1, string column, string paraml)
        {
            if (!IsDatabaseOpen()) Connect();
            try
            {
                string cmd = string.Format("Update {0} Set {1} = @paral0 where {2} = @paral1", table, key, column);
                using (MySqlCommand insert = new MySqlCommand(cmd, sqlConnection))
                {
                    insert.Parameters.AddWithValue("paral0", value1);
                    insert.Parameters.AddWithValue("paral1", paraml);
                    MySqlDataReader reader = insert.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                    Close();
                    return true;
                }
            }
            catch (System.Exception)
            {
#if UNITY_EDITOR
                Debug.Log("Update Failed!");
#endif
                return false;
            }
        }
    }

}
