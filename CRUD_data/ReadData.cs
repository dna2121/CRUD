using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CRUD_data
{
    class ReadData
    {        
        public void Baca()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source = DESKTOP-JF6PA4C; database = PendopoLawas; integrated security = TRUE");
                con.Open();
                
                SqlCommand cmd = new SqlCommand("select * from Barang", con);
                SqlDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                    Console.WriteLine("");
                    Console.WriteLine(String.Format("{0}\nNama Makanan/Minuman: {1}\nHarga: Rp.{2}",reader[0],reader[1],reader[2]));
               }                
            }
            catch
            {
                Console.WriteLine("Gagal membaca data");
                Console.WriteLine("");
            }
            finally
            {
                con.Close();                
            }
        }
    }
}
