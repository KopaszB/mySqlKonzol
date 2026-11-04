using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace mySqlKonzol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;user=root;password=;database=diak_gyak;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("A kapcsolódás sikeres!");

                    string sqlCommad = "SELECT * FROM diakok;";
                    MySqlCommand cmd = new MySqlCommand(sqlCommad, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) 
                    {
                        Console.WriteLine($"{reader["nev"],-20} - {reader["eletkor"],-4} éves - {reader["osztaly"]}");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Hiba! {e.Message}");
                }

            }



            Console.ReadKey();
        }
    }
}
