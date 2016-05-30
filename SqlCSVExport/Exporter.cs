using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SqlExport
{
    public class Exporter
    {
        private string ConnectionString { get; set; }
        private string DataSource { get; set; }
        private string InitialCatalog { get; set; }
        private string UserId { get; set; }
        private string Password { get; set; }
        private string Table { get; set; }
        private string SavePath { get; set; }

        public Exporter(string connectionString, string table, string savePath)
        {
            ConnectionString = connectionString;
            Table = table;
            SavePath = savePath;
        }
        //Create new Exporter
        //Call Connection
        /// <summary>
        /// CAll Read, pass in the connecton
        /// 
        /// </summary>
        /// <returns></returns>
        public SqlConnection Connect()
        {
            return new SqlConnection(ConnectionString);
        }
        //Get the stringbuilder read from db
        private StringBuilder ReadFromDb(SqlConnection connection)
        {

            using (connection)
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = $"select * from {Table}";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var columns = Enumerable
                            .Range(0, reader.FieldCount)
                            .Select(reader.GetName)
                            .ToArray();

                        var sBuilder = new StringBuilder();

                        while (reader.Read())
                        {
                            for (int i = 0; i < columns.Count(); i++)
                            {
                                sBuilder.Append($"{reader[columns[i]]},");
                            }
                        }
                        return sBuilder;
                    }
                }
            }
        }
        public bool WriteToFile(StringBuilder sBuilder)
        {
            try
            {
                File.WriteAllText(SavePath, sBuilder.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}