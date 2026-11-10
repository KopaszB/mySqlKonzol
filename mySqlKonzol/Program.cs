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
                    conn.Close();
                    //helyett
                    /*
                     * using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["nev"],-20} - {reader["eletkor"],-4} éves - {reader["osztaly"]}");
                            }
                        }
                     */

                    //conn.Open();
                    //Adatok hozzáadása az adatbázishoz
                    //Console.WriteLine("Új diák felvétele:");

                    //Console.Write("Név: ");
                    //string nev = Console.ReadLine();

                    //Console.Write("Életkor: ");
                    //int kor = int.Parse(Console.ReadLine());

                    //Console.Write("Osztály: ");
                    //string osztaly = Console.ReadLine();

                    //string insertSql = $"INSERT INTO diakok(nev,eletkor,osztaly) VALUES (@nev,@kor,@osztaly);";

                    ////sql injection támadás
                    ////string insertSql = $"INSERT INTO diakok(nev,eletkor,osztaly) VALUES ('{nev}',{kor},''); DROP DATABASE diak_gyak;'--);";

                    //MySqlCommand insertCmd = new MySqlCommand(insertSql, conn);
                    //insertCmd.Parameters.AddWithValue("@nev", nev);
                    //insertCmd.Parameters.AddWithValue("@kor", kor);
                    //insertCmd.Parameters.AddWithValue("@osztaly", osztaly);
                    //insertCmd.ExecuteNonQuery();
                    //Console.WriteLine("Új diák hozzáadva!");
                    //conn.Close();
                    //Frissítjük az adatokat
                    conn.Open();
                    string updateSql = "UPDATE diakok SET eletkor=30 WHERE nev = 'Kiss Anna'";
                    MySqlCommand updateCmd = new MySqlCommand(updateSql, conn);
                    updateCmd.ExecuteNonQuery();
                    Console.WriteLine("Adatok frissítve!");
                    conn.Close();
                    //Adatok törlése
                    conn.Open();
                    string deleteSql = "DELETE FROM diakok WHERE nev = 'Kiss Anna'";
                    MySqlCommand deleteCmd = new MySqlCommand(deleteSql, conn);
                    deleteCmd.ExecuteNonQuery();
                    Console.WriteLine("Adatok törölve!");
                    conn.Close();

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
