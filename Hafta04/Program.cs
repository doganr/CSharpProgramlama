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
        }

        static void Main(string[] args)
        {

            Console.Write("Kaç adet kişi bilgisi gireceksiniz:");
            int kisiSayisi = Convert.ToInt32(Console.ReadLine());

            int a = 5;
            string isim = "Ramazan";
            string[] isimler = new string[kisiSayisi];
            List<string> isimler2 = new List<string>();
            Kisi[] kisiler = new Kisi[kisiSayisi];

            for (int i = 0; i < kisiSayisi; i++) 
            {
                Console.WriteLine($"{i + 1}. Kişinin");
                Console.Write("Adını Giriniz:");
                kisiler[i].isim = Console.ReadLine();
                Console.Write("Soyadını Giriniz:");
                kisiler[i].soyisim = Console.ReadLine();
                Console.Write("Yaşını Giriniz:");
                kisiler[i].yas = Convert.ToInt32(Console.ReadLine());
                Console.Write('\n');
            }

            TextInfo ti = new CultureInfo("tr-TR", false).TextInfo;
            Console.WriteLine($"|{"",5}|{"İSİM",-20}|{"SOYİSİM",-10}|{"YAS",5}|");
            Console.WriteLine($"----------------------------------------------");
            for (int i = 0; i < kisiler.Length; i++)
                Console.WriteLine($"|{1,5}|{ti.ToTitleCase(kisiler[i].isim),-20}|{ti.ToTitleCase(kisiler[i].soyisim),-10}|{kisiler[i].yas,5}|");

        }
    }
}