using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_data
{
    class Program
    {
        void Menu()
        {
            double pilih;
            while (true)
            {
                try
                {
                    Console.WriteLine("`````````````````````````````````````````````````````");                                       
                    Console.WriteLine("\nMENU ");
                    Console.WriteLine("1. Tambah Data");
                    Console.WriteLine("2. Ubah Data");
                    Console.WriteLine("3. Mencari Data");
                    Console.WriteLine("4. Hapus Data");
                    Console.WriteLine("5. Tampil Data");
                    Console.WriteLine("6. Exit");
                    Console.Write("Pilih (1/2/3/4/5/6): ");
                    pilih = double.Parse(Console.ReadLine());
                    Console.WriteLine("");
                    switch (pilih)
                    {
                        case 1:
                            InsertData add = new InsertData();
                            add.TambahData();
                            break;
                        case 2:
                            UpdateData upd = new UpdateData();
                            upd.UbahData();
                            break;
                        case 3:
                            SearchData cari = new SearchData();
                            cari.Cari();
                            break;
                        case 4:
                            DeleteData del = new DeleteData();
                            del.HapusData();
                            break;
                        case 5:
                            ReadData rd = new ReadData();
                            rd.Baca();
                            break;
                        case 6:
                            Environment.Exit(0); //untuk keluar dari program
                            break;
                        default:
                            Console.WriteLine("Pilihan tidak tersedia\n");
                            break;
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("\nInput Sesuai Pilihan.\n");
                }

            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Menu();
        }
    }
}
