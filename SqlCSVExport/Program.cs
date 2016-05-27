using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SqlCSVExport
{
   public class SqlConnect
    {
        private string ConnectionString { get; set; }
        private string DataSource { get; set; }
        private string InitialCatalog { get; set; }
        private string UserId { get; set; }
        private string Password { get; set; }
        private string Table { get; set; }

       public SqlConnect(string connectionString,string table)
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
                        var columns = Enumerable.Range(0,reader.FieldCount).Select(reader.GetName).ToArray();
                        int count=0;
                        using(StreamWriter writer = new StreamWriter(path)){
                            var sBuilder = new StringBuilder();
                        while(reader.Read())
                        {
                            for(int i=0;i<columns.Count();i++){
                                sBuilder.Append($"{reader[columns[i]]},");
                            }
                            sBuilder.Append(count);
                            count++;
                            writer.WriteLine(sBuilder.ToString());
                            sBuilder.Clear();
                            
                            //reader.NextResult()
                        }
                        }
                        Process.Start(path);
                    }
                    Console.WriteLine($"success files saved {DateTime.UtcNow - now}");
                     
                }
               
            }  
        }
        static void Main(string[] args)
        {
            string dataSource, initialCatalog, id, password, table,connectionString;

            Console.WriteLine("Use defualt connection string? Y/N");
            var useDefault = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(useDefault)&& string.Equals(useDefault,"N",StringComparison.OrdinalIgnoreCase)){
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
            }else{
               connectionString = "Data Source=nyphrmdb;Initial Catalog=appdb;user id=website;password=ws&1701&ut";
                var reader = new SqlConnect(connectionString,"dbo.dashboardErrors");
            }
            Console.ReadKey();

        }
    }
}
