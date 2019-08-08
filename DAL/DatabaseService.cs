﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class DatabaseService
    {
        public string connectionString = "SERVER = LAPTOP-PESL1UJR;database = QLPT ; uid = sa; pwd= 11081999";
        public SqlConnection connection;
        public SqlCommand command;
        public DatabaseService()
        {
            connection = new SqlConnection(connectionString);
        }
        public void OpenConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public SqlDataReader ReadData(string sql)
        {
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;
            command.Connection = connection;
            OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        public SqlDataReader ReadDataPars(string sql, SqlParameter[] pars)
        {
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;
            command.Connection = connection;
            OpenConnection();
            command.Parameters.AddRange(pars);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        public bool WriteData(string sql, SqlParameter[] pars)
        {
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;
            command.Connection = connection;
            OpenConnection();
            command.Parameters.AddRange(pars);
            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }
        public string ToiUuChuoi(string s)
        {
            s = s.ToLower();
            s = s.Trim();
            string[] arr = s.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            s = "";
            for (int i = 0; i < arr.Length; i++)
            {
                string word = arr[i];
                word = word.ToLower();
                char[] arrWord = word.ToCharArray();
                arrWord[0] = char.ToUpper(arrWord[0]);
                string newWord = new string(arrWord);
                s += newWord + " ";
            }
            s=s.Trim();
            return s;
        }
    }
}
