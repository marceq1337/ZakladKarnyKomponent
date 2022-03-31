using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ZakladKarnyKomponent
{
    public class ObslugaOsadzonych
    {
       
       MySqlConnection cnn;

        public ObslugaOsadzonych(string serwer, string baza,string login, string haslo) {
            string connetionString = @"Server="+serwer+";Database="+baza+";User ID="+login+";Password="+haslo;
            cnn = new MySqlConnection(connetionString);
             
        }

        public DataTable SprawdzOsobe(int nr_osadzonego, String tabela) 
        {
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `"+tabela+"` WHERE nr="+nr_osadzonego, cnn);
            MySqlDataAdapter adapter;
            DataTable wynik = new DataTable();
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(wynik);
            cnn.Close();
            return wynik;
        }

        public DataTable SprawdzOsoby(String tabela)
        {
            cnn.Open();
            string query = "SELECT * FROM " + tabela;
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataAdapter adapter;
            DataTable wynik = new DataTable();
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(wynik);
            cnn.Close();
            return wynik;
        }

        public void WprowadzOsobe(string imie, string nazwisko, string nr_wieznia, string tabela)
        {
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO `{tabela}` (`id`, `imie`, `nazwisko`, `nr`) VALUES (NULL, '{imie}', '{nazwisko}', '{nr_wieznia}');", cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }


    }
}
