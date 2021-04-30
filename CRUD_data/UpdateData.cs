using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUD_data
{
    class UpdateData
    {
        public string nama, kodeterpilih;
        public double harga,qty,subtotal;
        public void UbahData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source = DESKTOP-JF6PA4C; database = PendopoLawas; integrated security = TRUE");
                con.Open();

                Console.Write("Masukkan kode barang yang akan diubah = ");
                kodeterpilih = Console.ReadLine();
                Console.Write("Masukkan nama makanan/minuman yang baru = ");
                nama = Console.ReadLine();
                Console.Write("Masukkan harga makanan/minuman = ");
                harga = Convert.ToDouble(Console.ReadLine());
                Console.Write("Masukkan QTY = ");
                qty = Convert.ToDouble(Console.ReadLine());                

                subtotal = qty * harga;

                string sqlupd = "update Barang set Nama_makanan = '" + nama + "', Harga = " + harga + " where Kode_Barang = '" + kodeterpilih + "'" +
                    "\nupdate Detail_Transaksi set Qty = " + qty + ", Sub_Total = " + subtotal + " where Kode_Barang = '" + kodeterpilih + "'";

                SqlCommand cmd = new SqlCommand(sqlupd, con);

                Console.WriteLine("Apakah anda yakin mengubah data ini?");
                Console.Write("Tekan (Y/Apa saja): ");
                if (!Console.ReadLine().Equals("y", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("\nData tidak diubah");
                    Console.WriteLine("[Press Enter]");
                    return;
                }
                else
                {
                    
                    cmd.ExecuteNonQuery();


                    Console.WriteLine("\nSukses Mengubah Data");
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