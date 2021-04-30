using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.SqlServer.Server;

namespace CRUD_data
{
    class SearchData
    {
        public string namaterpilih;
        public void Cari()
        {
            SqlConnection con = null;


            try
            {
                con = new SqlConnection("data source = DESKTOP-JF6PA4C; database = PendopoLawas; integrated security = TRUE");
                con.Open();

                Console.Write("Masukkan nama makanan/minuman yang akan dicari = ");
                namaterpilih = Console.ReadLine();                

                string sqlsearch = "select Barang.Kode_Barang, Barang.Nama_Makanan, Barang.Harga, Detail_Transaksi.Qty, Detail_Transaksi.Sub_Total " +
                    "from [dbo].[Barang] " +
                    "join [dbo].[Detail_Transaksi] " +
                    "on [dbo].[Barang].Kode_Barang = [dbo].[Detail_Transaksi].Kode_Barang " +
                    "where Nama_Makanan like '%" + namaterpilih + "%'";                

                SqlCommand cmd = new SqlCommand(sqlsearch, con);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("\nKode: {0}\nNama: {1}\nHarga: Rp.{2}" +
                        "\nQTY: {3}\nSubtotal: Rp.{4}", reader[0], reader[1], reader[2], reader[3], reader[4]);
                }
              
            }
            catch (Exception e)
            {
                Console.WriteLine("\nData tidak tersedia :(");
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
