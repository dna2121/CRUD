using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http.Headers;

namespace CRUD_data
{
    class InsertData
    {
        public string nama, kode, iddtl;
        public double harga, qty, subtotal;
        public void TambahData()
        {            
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source = DESKTOP-JF6PA4C; database = PendopoLawas; integrated security = TRUE");
                con.Open();

                Console.Write("Masukkan nama makanan/minuman = ");
                nama = Console.ReadLine();
                Console.Write("Masukkan kode barang = ");
                kode = Console.ReadLine();
                Console.Write("Masukkan harga makanan/minuman = ");
                harga = Convert.ToDouble(Console.ReadLine());
                Console.Write("Masukkan QTY = ");
                qty = Convert.ToDouble(Console.ReadLine());
                Console.Write("Masukkan 4 digit untuk idDetail = ");
                iddtl = Console.ReadLine();

                subtotal = qty * harga;
                /*string sqlinsert = "insert into Barang(Kode_Barang, Nama_makanan, Harga) " +
                    "values('" + kode + "','" + nama + "', " + harga + ")";*/

                string sqlinsert = ("insert into Barang (Kode_Barang, Nama_makanan, Harga)" +
                    "values('" + kode + "','" + nama + "','" + harga + "')" +
                    "\ninsert into Detail_Transaksi(Id_Detail, Kode_Struk, Kode_Barang, Qty, Sub_Total)" +
                    "values ('" + iddtl + "'," + "'000000#018012', '" + kode + "'," + qty + ", " + subtotal + ")");

                SqlCommand cmd = new SqlCommand(sqlinsert, con);

                // execute sql query
                cmd.ExecuteNonQuery();

                //menampilkan pesan
                Console.WriteLine("\nHoreee Sukses Menambahkan Data :D");
                Console.WriteLine("[Press Enter]");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("\nOooopppss, Gagal :(");
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
