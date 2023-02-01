using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppArchi.Base;
using MySql.Data.MySqlClient;

namespace AppArchi.Networking
{
    public class DatabaseMgr : AutoSingletonMono<DatabaseMgr>
    {
        //entity
        public static MySqlConnection sqlConnection;    
        //Host
        string host;
        public string Host{get{return host;}set{host=value;}}   
        //User
        string user;
        public string User{get{return user;}set{user=value;}}
        //Password
        string pwd;
        public string Pwd{get{return pwd;}set{pwd=value;}}
        //Database
        string database;
        public string Database{get{return database;}set{database=value;}}

        public void ConnectDataBase()
        {
            try
            {
                string sql = string.Format("Database={0};Data Source={1};User Id={2};Password={3};", database, host, user, pwd, "3306");
                sqlConnection = new MySqlConnection(sql);
                sqlConnection.Open();
                Debug.Log("Database have connected!");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public bool CheckAccount(string user,string pwd)
        {
            if (sqlConnection==null)
            {
                ConnectDataBase();
            }
            
            try
            {
                string name = string.Format("'{0}'",user);
                string cmd = "select password from account whre user ="+name;
                MySqlCommand read = new MySqlCommand(cmd,sqlConnection);
                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    //Wait if no result
                }
                string realPwd = reader[0].ToString();
                return pwd == realPwd;

            }
            catch (System.Exception)
            {            
                throw;
            }
        }
    }

}
