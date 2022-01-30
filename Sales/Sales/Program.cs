using System;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "DESKTOP-8GO917E";
            builder.InitialCatalog = "Sales";
            builder.IntegratedSecurity = true;
            builder.ConnectTimeout = 30;
            builder.Encrypt = false;
            builder.TrustServerCertificate = false;
            builder.ApplicationIntent = ApplicationIntent.ReadWrite;
            builder.MultiSubnetFailover = false;
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            using (connection)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                SqlCommand command = connection.CreateCommand();
                Console.WriteLine("connection.State: " + connection.State);
                command.CommandText = "select * from Products";
                using (SqlDataReader reader = command.ExecuteReader())
                    ShowTable(reader);

                command.CommandText = "Select Name from Products";
                using (SqlDataReader reader = command.ExecuteReader())
                    ShowTable(reader);

                command.CommandText = "Select Price from Products";
                using (SqlDataReader reader = command.ExecuteReader())
                    ShowTable(reader);

                command.CommandText = "Select max(Price) as 'Max Price' from Products";
                using (SqlDataReader reader = command.ExecuteReader())
                    ShowTable(reader);

                command.CommandText = "Select min(Price) as 'Min Price' from Products";
                using (SqlDataReader reader = command.ExecuteReader())
                    ShowTable(reader);

                command.CommandText = "Select AVG(Price) as 'Average Price' from Products";
                using (SqlDataReader reader = command.ExecuteReader())
                    ShowTable(reader);

                connection.Close();
                Console.WriteLine("connection.State: " + connection.State);
            }
            Console.ReadKey(true);

            
        }
        private static void ShowTable(SqlDataReader reader, bool showTitle = true)
        {
            bool first = showTitle;
            while (reader.Read())
            {
                if (first)
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader.GetName(i) + "\t");
                    }
                    Console.WriteLine();
                    first = false;
                }

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + "\t");
                }
                Console.WriteLine();
            }
            reader.Close();
        }

    }
}