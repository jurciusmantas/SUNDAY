using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

namespace SUNDAY.Repository
{
    public static class DbRepository
    {
        private static readonly MySqlConnection _connection;
        static DbRepository()
        {
            try
            {
                var myJsonString = File.ReadAllText("Properties/connectionStrings.json");
                var myJObject = JObject.Parse(myJsonString);

                _connection = new MySqlConnection()
                {
                    ConnectionString = myJObject.SelectToken("connectionStrings").Value<string>(),
                };
                _connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error trying to connect to db! - " + e.Message);
            }
        }

        public static T FetchSingle<T>(MySqlCommand cmd)
        {
            AreWeAlive();

            cmd.Connection = _connection;
            var reader = cmd.ExecuteReader();
            var ds = new DataSet();
            var table = new DataTable();
            ds.Tables.Add(table);
            table.Load(reader);
            reader.Close();

            if (table.Rows != null && table.Rows.Count == 1)
                return table.Rows[0].Field<T>(0);

            else
                return default(T);
        }

        public static T FetchSingleRow<T>(MySqlCommand cmd)
        {
            AreWeAlive();

            cmd.Connection = _connection;
            var reader = cmd.ExecuteReader();
            var ds = new DataSet();
            var table = new DataTable();
            ds.Tables.Add(table);
            table.Load(reader);
            reader.Close();

            if (table.Rows != null && table.Rows.Count == 1)
                return ConvertDataTable<T>(table)[0];

            else
                return default(T);
        }

        public static List<T> FetchList<T>(MySqlCommand cmd)
        {
            AreWeAlive();

            cmd.Connection = _connection;
            var reader = cmd.ExecuteReader();
            var ds = new DataSet();
            var table = new DataTable();
            ds.Tables.Add(table);
            ds.EnforceConstraints = false;
            table.Load(reader);
            reader.Close();

            return ConvertDataTable<T>(table);
        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);

            if (temp != typeof(string))
            {
                T obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name == column.ColumnName)
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        else
                            continue;
                    }
                }

                return obj;
            }
            else
            {
                return (T)dr[0];
            }
        }

        private static void AreWeAlive()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
        }
    }
}
