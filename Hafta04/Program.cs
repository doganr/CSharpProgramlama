using System.Globalization;

namespace Hafta04
{
    internal class Program
    {
        struct Kisi 
        {
            public string isim;
            public string soyisim;
            public int yas;
            public Cinsiyet cinsiyet;

            public void BilgileriYazdir(int index) 
            {
                TextInfo ti = new CultureInfo("tr-TR", false).TextInfo;
                Console.WriteLine($"|{index+1,5}|{ti.ToTitleCase(isim),-20}|{ti.ToTitleCase(soyisim),-10}|{yas,5}|{cinsiyet,10}|");
            }
        }

        enum Cinsiyet 
        {            
            Kadin,
            Erkek
        }

        static string SDegerAl(string mesaj) 
        {
            Console.Write(mesaj);
            string deger = Console.ReadLine();
            return deger;
        }

        static int IDegerAl(string mesaj)
        {
            Console.Write(mesaj);
            string deger = Console.ReadLine();
            return Convert.ToInt32(deger);
        }

        static void KisileriYazdir(Kisi[] kisiler) 
        {
            TextInfo ti = new CultureInfo("tr-TR", false).TextInfo;
            Console.WriteLine($"|{"",5}|{"İSİM",-20}|{"SOYİSİM",-10}|{"YAS",5}|{"CİNSİYET",10}|");
            Console.WriteLine($"-----------------------------------------------------");
            for (int i = 0; i < kisiler.Length; i++)
                kisiler[i].BilgileriYazdir(i);
        }


        static void Main()
        {
            int kisiSayisi = IDegerAl("Kaç adet kişi bilgisi gireceksiniz:");

            Kisi[] kisiler = new Kisi[kisiSayisi];

            for (int i = 0; i < kisiSayisi; i++) 
            {
                Console.WriteLine($"{i + 1}. Kişinin");
                kisiler[i].isim = SDegerAl("Adını Giriniz:");
                kisiler[i].soyisim = SDegerAl("Soyadını Giriniz:");
                kisiler[i].yas = IDegerAl("Yaşını Giriniz:");
                Console.Write("Cinsiyeti Giriniz (Kadın:0/Erkek:1):");
                kisiler[i].cinsiyet = Console.ReadLine() == "0" ? Cinsiyet.Kadin : Cinsiyet.Erkek;
                Console.Write('\n');
            }

            KisileriYazdir(kisiler);
        }

        //struct Kisi
        //{
        //    public string isim;
        //    public string soyisim;
        //    public int yas;
        //    public Cinsiyet cinsiyet;
        //}

        //enum Cinsiyet
        //{
        //    Kadin,
        //    Erkek
        //}

        //static void Main()
        //{

        //    Console.Write("Kaç adet kişi bilgisi gireceksiniz:");
        //    int kisiSayisi = Convert.ToInt32(Console.ReadLine());

        //    int a = 5;
        //    string isim = "Ramazan";
        //    string[] isimler = new string[kisiSayisi];
        //    List<string> isimler2 = new List<string>();
        //    Kisi[] kisiler = new Kisi[kisiSayisi];

        //    for (int i = 0; i < kisiSayisi; i++)
        //    {
        //        Console.WriteLine($"{i + 1}. Kişinin");
        //        Console.Write("Adını Giriniz:");
        //        kisiler[i].isim = Console.ReadLine();
        //        Console.Write("Soyadını Giriniz:");
        //        kisiler[i].soyisim = Console.ReadLine();
        //        Console.Write("Yaşını Giriniz:");
        //        kisiler[i].yas = Convert.ToInt32(Console.ReadLine());
        //        Console.Write("Cinsiyeti Giriniz (Kadın:0/Erkek:1):");
        //        kisiler[i].cinsiyet = Console.ReadLine() == "0" ? Cinsiyet.Kadin : Cinsiyet.Erkek;
        //        Console.Write('\n');
        //    }

        //    TextInfo ti = new CultureInfo("tr-TR", false).TextInfo;
        //    Console.WriteLine($"|{"",5}|{"İSİM",-20}|{"SOYİSİM",-10}|{"YAS",5}|");
        //    Console.WriteLine($"----------------------------------------------");
        //    for (int i = 0; i < kisiler.Length; i++)
        //        Console.WriteLine($"|{i+1,5}|{ti.ToTitleCase(kisiler[i].isim),-20}|{ti.ToTitleCase(kisiler[i].soyisim),-10}|{kisiler[i].yas,5}|");

        //}
    }
}