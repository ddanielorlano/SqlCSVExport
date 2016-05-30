using Microsoft.SqlServer.Management.Smo;
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
        //$"Data Source={};Initial Catalog={};user id={};password={};" 
        public Exporter(string dataSource, string initialCatalog,string id,string pass ,string table)
        {
            DataSource = dataSource;
            InitialCatalog = initialCatalog;
            UserId = id;
            Password = pass;
            ConnectionString = $"Data Source={DataSource};Initial Catalog={InitialCatalog};user id={UserId};password={Password};";
            Table = table;
        }
        public Exporter(string dataSource, string initialCatalog,string table)
        {
            DataSource = dataSource;
            InitialCatalog = initialCatalog;
            ConnectionString = $"Data Source={DataSource};Initial Catalog={InitialCatalog};Trusted_Connection=True;";
            Table = table;
        }
        public SqlConnection Connect()
        {
            try
            {
                return new SqlConnection(ConnectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Get the stringbuilder read from db
        public StringBuilder ReadFromDb(SqlConnection connection,out int count)
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
                        var counter = 0;
                        while (reader.Read())
                        {
                            for (int i = 0; i < columns.Count(); i++)
                            {
                                sBuilder.Append($"{reader[columns[i]]},");
                            }
                            sBuilder.AppendLine();
                            counter++;
                        }
                        count = counter;
                        return sBuilder;
                    }
                }
            }
        }

        public bool WriteToFile(StringBuilder sBuilder,string path)
        {
            try
            {
                File.WriteAllText(path, sBuilder.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}