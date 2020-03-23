using System;
using System.Data.SqlClient;

namespace Zjazd_nr1_semIV
{

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;
                    Integrated Security=True;Connect Timeout=30;Encrypt=False;
                    TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string Polecenie_SQL = "SELECT * FROM Customers";
            SqlCommand polecenie = new SqlCommand(Polecenie_SQL, connection);
            SqlDataReader reader = polecenie.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["CompanyName"]);
            }
            reader.Close();

            CRUD test = new CRUD();
            Console.WriteLine("-------------------------");
            test.Create(13, "slask", connection);
            test.Update(13, "inny_slask", connection);
            test.Delete(13, connection);
            connection.Close();
        }
    }
}
