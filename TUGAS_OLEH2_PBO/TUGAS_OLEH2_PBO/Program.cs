using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUGAS_OLEH2_PBO
{
    // a. Kelas Item
    class Item
    {
        public string Judul { get; set; }
        public int Tahun { get; set; }

        public Item(string judul, int tahun)
        {
            Judul = judul;
            Tahun = tahun;
        }

        public virtual string Deskripsi()
        {
            return ($"Item ini berupa: {Judul} dengan tahun terbit tercatat pada {Tahun}");
        }
        public void InfoItem()
        {
            Console.WriteLine($"Judul: {Judul}, tahun terbit {Tahun}");
        }
    }

    // b. Kelas Buku
    class Buku : Item
    {
        public string Penulis { get; set; }

        public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
        {
            Penulis = penulis;
        }
        public override string Deskripsi()
        { 
            return ($"Buku ini berjudul: {Judul}, terbit pada tahun: {Tahun}, dan ditulis oleh {Penulis}");
        }

        public void CekPenulis()
        {
            Console.WriteLine($"Penulis buku '{Judul}': {Penulis}");
        }
    }

    // c. Kelas Majalah
    class Majalah : Item
    {
        public int Edisi { get; set; }

        public Majalah(string judul, int tahun, int edisi) : base(judul, tahun)
        {
            Edisi = edisi;
        }
        public override string Deskripsi()
        {
            return ($"Majalah ini berjudul: {Judul}, terbit pada tahun: {Tahun}, edisi majalah: {Edisi}");
        }
        public void InfoEdisi()
        {
            Console.WriteLine($"Majalah '{Judul}' - Edisi: {Edisi}");
        }
    }

    // d. Kelas Novel
    class Novel : Buku
    {
        public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

        public override string Deskripsi()
        {
            return ($"Buku ini berjudul: {Judul}, terbit pada tahun: {Tahun}, ditulis oleh {Penulis}, bergenre Novel");
        }
        public void BacaSinopsis()
        {
            Console.WriteLine($"Membaca sinopsis novel '{Judul}' oleh {Penulis}...");
        }
    }

    // d. Kelas Komik
    class Komik : Buku
    {
        public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

        public override string Deskripsi()
        {
            return ($"Buku ini berjudul: {Judul}, terbit pada tahun: {Tahun}, ditulis oleh {Penulis}, bergenre Komik");
        }
        public void TampilkanIlustrasi()
        {
            Console.WriteLine($"Menampilkan ilustrasi komik '{Judul}' oleh {Penulis}...");
        }
    }

    // e. Kelas MajalahAnak
    class MajalahAnak : Majalah
    {
        public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

        public override string Deskripsi()
        {
            return ($"Majalah ini berjudul: {Judul}, terbit pada tahun: {Tahun}, edisi majalah: {Edisi}, kategori Anak-Anak");
        }

        public void KategoriAnak()
        {
            Console.WriteLine($"'{Judul}' adalah majalah kategori anak-anak.");
        }
    }

    // e. Kelas MajalahTeknologi
    class MajalahTeknologi : Majalah
    {
        public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

        public override string Deskripsi()
        {
            return ($"Majalah ini berjudul: {Judul}, terbit pada tahun: {Tahun}, edisi majalah: {Edisi}, kategori Teknologi");
        }
        public void TopikTeknologi()
        {
            Console.WriteLine($"'{Judul}' membahas topik-topik teknologi terkini.");
        }
    }

    // f. Kelas Perpustakaan
    class Perpustakaan
    {
        private List<Item> Koleksi = new List<Item>();

        public void TambahItem(params Item[] items)
        {
            foreach (var item in items)
            {
                Koleksi.Add(item);
                Console.WriteLine($"'{item.Judul}' ditambahkan ke perpustakaan.");
            }
        }

        public void DaftarItem()
        {
            Console.WriteLine("\n=== Koleksi Perpustakaan ===");
            foreach (var item in Koleksi)
            {
                Console.WriteLine($"Judul {item.Judul} \t\t | Tahun: {item.Tahun} \t | Deskripsi : {item.Deskripsi()}"); //Deskripsi ovveride y kak.
            }
                
        }
    }

    // Main Program
    internal class Program
    {
        static void Main(string[] args)
        {
            Perpustakaan perpus = new Perpustakaan();
            Novel novel1 = new Novel("Eighty Six", 2025, "curangtau");
            Komik manga1 = new Komik("Jujutsu Kaizen", 2014, "sikayaknya");
            MajalahAnak majalah_anak1 = new MajalahAnak("Aku suka tanaman", 2030, 1);
            MajalahTeknologi majalah_teknologi1 = new MajalahTeknologi("Mekanisme Satelit", 1980, 2);

            perpus.TambahItem(novel1, manga1, majalah_anak1);
            //mweheheheheheh....
            perpus.DaftarItem();

            Console.WriteLine($"\nMethod Khsus Deskripsi: {novel1.Deskripsi()}");
            Console.WriteLine($"\nMethod Khsus Deskripsi: {majalah_anak1.Deskripsi()}");
            novel1.BacaSinopsis();
        }
    }
}
