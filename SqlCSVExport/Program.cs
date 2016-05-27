using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCSVExport
{
   class SqlConnect
    {
        private string ConnectionString { get; set; }
        private string Server { get; set; }
        private string Database { get; set; }
        private string UserId { get; set; }
        private string Password { get; set; }
        private string Table { get; set; }

        SqlConnect(string server="nyphrmdb", string database="ultipro_cambridge", string userId="website", string password ="ws&1701&ut",string table=" ",string connectionString=" ")
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                ConnectionString = connectionString;

            }
            else
            {
                Server = server;
                Database = database;
                UserId = userId;
                Password = password;
                Table = table;

                ConnectionString = $"{Server}{Database}{UserId}{Password}";
            }

            var connection = new SqlConnection(ConnectionString);
            Read(connection);

        }
        private void Read(SqlConnection connection)
        {
            

            using (connection)
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = $"select * from {Table}";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;
                    Console.WriteLine($"Executing command {cmd.CommandText}");
                    var now = DateTime.UtcNow;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Records read..");
                        Console.WriteLine("Enter save path:");
                        var path = Console.ReadLine();
                        using (StreamWriter writer = new StreamWriter(path))
                        {
                            while (reader.Read())
                            {
                                foreach(var row in reader)
                                {
                                    Console.WriteLine($"{row.ToString()}");
                                }
                            }

                        }
                    }
                    Console.WriteLine($"success files saved {DateTime.UtcNow - now}");
                }

            }
        }
        static void Main(string[] args)
        {
            string server, db, id, password, table,connectionString;

            Console.WriteLine("Enter Server name: ");
            server = Console.ReadLine();
            Console.WriteLine("Enter Database name: ");
            db = Console.ReadLine();
            Console.WriteLine("Enter UserId: ");
            id = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            password = Console.ReadLine();
            Console.WriteLine("Enter Table name: ");
            table = Console.ReadLine();
            connectionString = $"server,db,id,password,table";
            var reader = new SqlConnect(connectionString);
        }
    }
}
