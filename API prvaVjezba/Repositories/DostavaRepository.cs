using API_prvaVjezba.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace API_prvaVjezba.Repositories
{
    public class DostavaRepository
    {
        public static bool AddToDatabase(Narudzba narudzba)
        {
            MySqlConnection connection = new MySqlConnection("Database=dostava;Data Source=localhost;User Id=root;Password= ");
            var query = "INSERT INTO dostava(dostavaIme,dostavaAdresa,dostavaTelefon,dostavaPostanskiBroj) VALUES ('@IME','@ADRESA','@TELEFON','@POSTBROJ')";

            query = query.Replace("@IME", narudzba.dostavaIme).Replace("@ADRESA", narudzba.dostavaAdresa).Replace("@TELEFON", narudzba.dostavaTelefon).Replace("@POSTBROJ", narudzba.dostavaPostanskiBroj);


           

            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();

                return true;
            }
            catch (Exception)
            {

                //throw;
                return false;
            }


        }

        public static DataTable ReturnFromDB()
        {
            MySqlConnection connection = new MySqlConnection("Database=dostava;Data Source=localhost;User Id=root;Password= ");

            var query = "SELECT * FROM dostava";


            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                DataTable table = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                da.Fill(table);
                connection.Close();
                return table;

            }
            catch (Exception)
            {

                //throw;
                DataTable empty=new DataTable();
                return empty; 

            }
        }

        public static DataTable ReturnFromDB(int id)
        {
            MySqlConnection connection = new MySqlConnection("Database=dostava;Data Source=localhost;User Id=root;Password= ");

            var query = "SELECT * FROM dostava WHERE dostavaID=" + id;

            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                DataTable table = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                da.Fill(table);
                connection.Close();
                return table;
            }
            catch (Exception)
            {

                DataTable empty = new DataTable();
                return empty;
            }

        }

        public static bool DeleteRecord(int id)
        {
            MySqlConnection connection = new MySqlConnection("Database=dostava;Data Source=localhost;User Id=root;Password= ");

            var query = "DELETE FROM dostava WHERE dostavaID=" + id;

            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();

                return true;

            }
            catch (Exception)
            {

                //throw;
                return false;
            }
        }

        public static bool UpdateRecord(int id,Narudzba narudzba)
        {
            MySqlConnection connection = new MySqlConnection("Database=dostava;Data Source=localhost;User Id=root;Password= ");
            var query = "UPDATE dostava SET dostavaIme='" + narudzba.dostavaIme + "', dostavaAdresa='" + narudzba.dostavaAdresa + "',dostavaTelefon='" + narudzba.dostavaTelefon + "',dostavaPostanskiBroj='" + narudzba.dostavaPostanskiBroj + "' WHERE dostavaID=" + id;

            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();

                return true;


            }
            catch (Exception)
            {

                //throw;
                return false;
            }

        }
    }
}