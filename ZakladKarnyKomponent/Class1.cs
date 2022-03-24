using System;
using System.Collections.Generic;
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

        public string SprawdzOsadzonego(int nr_osadzonego) 
        {
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `osadzeni` WHERE nr="+nr_osadzonego, cnn);
            var reader = cmd.ExecuteReader();
            reader.Read();
            string imie = reader.GetString(1);
            string nazwisko = reader.GetString(2);

            return imie+" "+nazwisko;
        }

    }
}
