using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2_PABD
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().CreateTable();

            new Program().InsertData();
        }

        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=LAPTOP-LKP54HAE\\MSSQLSERVER01;database=PABD_Exercise2;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand("create table Pembeli (Id_Pembeli char(5) primary key, Nama_Pembeli varchar(32), Alamat varchar(32), No_Telp char(15))"
                    + "create table Karyawan (Id_Karyawan char(5) primary key, Nama_Karyawan varchar(32), No_Telp char(15))"
                    + "create table Transaksi(Id_Transaksi char(5) primary key, Id_Pembeli char(5) foreign key references Pembeli(Id_Pembeli), Id_Karyawan char(5) foreign key references Karyawan(Id_Karyawan), Tgl_Transaksi date, Kode_Barang char(5), Jumlah_Barang char(20), Total_Harga money)"
                    + "create table Kue (Id_Kue char(5) primary key, Id_Pembeli char(5) foreign key references Pembeli (Id_Pembeli), Nama_Kue varchar(32), Jenis_Kue varchar(32), Harga_Kue money, Stok char(20))", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Tabel sukses dibuat!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, sepertinya ada yang salah. " + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertData()
        {
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=LAPTOP-LKP54HAE\\MSSQLSERVER01;database=PABD_Exercise2;Integrated Security = TRUE");
                    con.Open();

                    SqlCommand cm = new SqlCommand("insert into Pembeli (Id_Pembeli, Nama_Pembeli, Alamat, No_Telp) values ('235', 'Rezka', 'Bengkulu', '08463873749')" +
                        "insert into Pembeli (Id_Pembeli, Nama_Pembeli, Alamat, No_Telp) values ('237', 'Nabila', 'Jawa Tengah', '085329717686')" +
                        "insert into Pembeli (Id_Pembeli, Nama_Pembeli, Alamat, No_Telp) values ('238', 'Syafii', 'Jawa Tengah', '085782920115')" +
                        "insert into Pembeli (Id_Pembeli, Nama_Pembeli, Alamat, No_Telp) values ('239', 'Tika', 'Jakarta', '08544628302')" +
                        "insert into Pembeli (Id_Pembeli, Nama_Pembeli, Alamat, No_Telp) values ('300', 'Rafi', 'Yogyakarta', '085739901234')" +
                        "insert into Karyawan (Id_Karyawan, Nama_Karyawan, No_Telp) values ('001', 'Arif', '081592804277')" +
                        "insert into Karyawan (Id_Karyawan, Nama_Karyawan, No_Telp) values ('002', 'Dita', '085820101334')" +
                        "insert into Karyawan (Id_Karyawan, Nama_Karyawan, No_Telp) values ('003', 'Sari', '085628012435')" +
                        "insert into Karyawan (Id_Karyawan, Nama_Karyawan, No_Telp) values ('004', 'Lulu', '081593510484')" +
                        "insert into Karyawan (Id_Karyawan, Nama_Karyawan, No_Telp) values ('005', 'Dika', '085116892475')" +
                        "insert into Transaksi(Id_Transaksi, Id_Pembeli, Id_Karyawan, Tgl_Transaksi, Kode_Barang, Jumlah_Barang, Total_Harga) values ('5262', '235', '003', '2022-02-21', 'T045', '5', '100000')" +
                        "insert into Transaksi(Id_Transaksi, Id_Pembeli, Id_Karyawan, Tgl_Transaksi, Kode_Barang, Jumlah_Barang, Total_Harga) values ('5256', '237', '001', '2022-02-22', 'L043', '5', '200000')" +
                        "insert into Transaksi(Id_Transaksi, Id_Pembeli, Id_Karyawan, Tgl_Transaksi, Kode_Barang, Jumlah_Barang, Total_Harga) values ('5345', '238', '004', '2022-02-23', 'P023', '2', '100000')" +
                        "insert into Transaksi(Id_Transaksi, Id_Pembeli, Id_Karyawan, Tgl_Transaksi, Kode_Barang, Jumlah_Barang, Total_Harga) values ('6343', '239', '005', '2022-02-23', 'B821', '4', '120000')" +
                        "insert into Transaksi(Id_Transaksi, Id_Pembeli, Id_Karyawan, Tgl_Transaksi, Kode_Barang, Jumlah_Barang, Total_Harga) values ('6345', '300', '002', '2022-02-24', 'C992', '1', '25000')" +
                        "insert into Kue (Id_Kue, Id_Pembeli, Nama_Kue, Jenis_Kue, Harga_Kue, Stok) values ('B782', '235', 'Bolu Pisang', 'Bolu', '50000', '5')" +
                        "insert into Kue (Id_Kue, Id_Pembeli, Nama_Kue, Jenis_Kue, Harga_Kue, Stok) values ('K752', '237', 'Kue Nastar', 'Kue Kering', '40000', '10')" +
                        "insert into Kue (Id_Kue, Id_Pembeli, Nama_Kue, Jenis_Kue, Harga_Kue, Stok) values ('C734', '238', 'Blackforest', 'Cake', '50000', '6')" +
                        "insert into Kue (Id_Kue, Id_Pembeli, Nama_Kue, Jenis_Kue, Harga_Kue, Stok) values ('C882', '239', 'Chifon', 'Cake', '30000', '5')" +
                        "insert into Kue (Id_Kue, Id_Pembeli, Nama_Kue, Jenis_Kue, Harga_Kue, Stok) values ('C921', '300', 'Cup cake', 'Cake', '25000', '20')", con);
                    cm.ExecuteNonQuery();

                    Console.WriteLine("Insert sukses dibuat!");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oops, sepertinya ada yang salah. " + e);
                    Console.ReadKey();
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
} 
