using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUD_data
{
    class DeleteData
    {
        public string kodeterpilih;
        
        public void HapusData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source = DESKTOP-JF6PA4C; database = PendopoLawas; integrated security = TRUE");
                con.Open();

                Console.Write("Masukkan kode barang yang akan dihapus = ");
                kodeterpilih = Console.ReadLine();

                string sqldelete = "delete from Detail_Transaksi where Kode_Barang = '" + kodeterpilih + "'" +
                    "\ndelete from Barang where Kode_Barang = '" + kodeterpilih + "'";

                SqlCommand cmd = new SqlCommand(sqldelete, con);

                Console.WriteLine("Apakah anda yakin menghapus data ini?");
                Console.Write("Tekan (Y/Apa saja): ");
                if (!Console.ReadLine().Equals("y", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("\nData tidak dihapus");
                    Console.WriteLine("[Press Enter]");
                    return;
                }
                else
                {
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("\nSukses Menghapus Data");
                    Console.WriteLine("[Press Enter]");
                    Console.ReadKey();
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("\nGagal :(");
                Console.WriteLine("[Press Enter]");
                Console.ReadKey();

            }

            //tutup koneksi
            finally
            {
                con.Close();
            }
        }
    }
}
