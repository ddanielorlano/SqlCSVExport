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
        private string DataSource { get; set; }
        private string InitialCatalog { get; set; }
        private string UserId { get; set; }
        private string Password { get; set; }
        private string Table { get; set; }

      
       
        SqlConnect(string connectionString,string table)
        {
           ConnectionString = connectionString;
            Table = table;
           
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
                        var columns = Enumerable.Range(0,reader.FieldCount).Select(reader.GetName).ToList(();
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
                Console.ReadKey();

            }
        }
        static void Main(string[] args)
        {
            string dataSource, initialCatalog, id, password, table,connectionString;

            Console.WriteLine("Enter Server name: ");
            dataSource = Console.ReadLine();
            Console.WriteLine("Enter Database name: ");
            initialCatalog = Console.ReadLine();
            Console.WriteLine("Enter UserId: ");
            id = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            password = Console.ReadLine();
            Console.WriteLine("Enter Table name: ");
            table = Console.ReadLine();
            connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};user id={id};password={password}";
            var reader = new SqlConnect(connectionString,table);
        }
    }
}
