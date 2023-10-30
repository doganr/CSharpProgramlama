using System.Globalization;
using System.Text;

namespace Hafta05
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
                Console.WriteLine($"|{index + 1,5}|{ti.ToTitleCase(isim),-20}|{ti.ToTitleCase(soyisim),-10}|{yas,5}|{cinsiyet,10}|");
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
            Console.WriteLine($"--------------------------------------------------------");
            for (int i = 0; i < kisiler.Length; i++)
                kisiler[i].BilgileriYazdir(i);
        }

        static void KisileriDosyayaYazdir(Kisi[] kisiler) 
        {
            string[] satirlar = new string[kisiler.Length+2];
            satirlar[0] = $"|{"",5}|{"İSİM",-20}|{"SOYİSİM",-10}|{"YAS",5}|{"CİNSİYET",10}|";
            satirlar[1] = "--------------------------------------------------------";
            for (int i = 0;i < kisiler.Length;i++) 
                satirlar[i+2] = String.Format("|{4,5}|{0,-20}|{1,-10}|{2,5}|{3,10}|",
                                                kisiler[i].isim, 
                                                kisiler[i].soyisim, 
                                                kisiler[i].yas,
                                                kisiler[i].cinsiyet,
                                                (i+1));

            File.WriteAllLines("kisiler.txt", satirlar, Encoding.UTF8);
            //string yazilacaklar = "";
            //for(int i = 0; i < kisiler.Length; i++) 
            //{
            //    //yazilacaklar = yazilacaklar + "klgsdfhskfdh";
            //    //yazilacaklar += "klgsdfhskfdh";
            //    yazilacaklar += String.Format("İsim:{0} Soyisim:{1} Yaş:{2} Cinsiyet:{3}\n", 
            //                                    kisiler[i].isim, 
            //                                    kisiler[i].soyisim, 
            //                                    kisiler[i].yas,
            //                                    kisiler[i].cinsiyet);
            //}
            //File.WriteAllText("kisiler.txt",yazilacaklar,Encoding.UTF8);
        }

        static Kisi[] KisileriDosyadanOku() 
        {
            string icerik = File.ReadAllText("kisiler.txt", Encoding.UTF8);
            string[] satirlar = icerik.Trim().Split("\r\n");
            //string[] satirlar = File.ReadAllLines("kisiler.txt", Encoding.UTF8);

            Kisi[] kisiler = new Kisi[satirlar.Length - 2];
            for (int i = 0; i < kisiler.Length; i++)
            {
                string[] bilgiler = satirlar[i + 2].Split("|");
                kisiler[i].isim = bilgiler[2].Trim();
                kisiler[i].soyisim = bilgiler[3].Trim();
                kisiler[i].yas = Convert.ToInt32(bilgiler[4].Trim());
                kisiler[i].cinsiyet = bilgiler[5].Trim() == "Kadin" ? Cinsiyet.Kadin : Cinsiyet.Erkek;
            }

            return kisiler;
        }

        static void Main()
        {
            Kisi[] kisiler = KisileriDosyadanOku();                       

            KisileriYazdir(kisiler);            
        }


        //File --> Dosya
        //Directory --> Klasör
        //File.WriteAllText("C:\\deneme\\dosya.txt", "C# Programlama Dersi");
        //File.WriteAllText(@"C:\deneme\dosya.txt", "C# Programlama Dersi");
        //File.WriteAllText("dosya.txt", "C# Programlama Dersi");
        //File.WriteAllText(@"..\veriler\dosya.txt", "C# Programlama Dersi");
        //string[] satirlar = { "Satır1: deneme", "Satır2: aaa", "Ramazan Özgür DOĞAN" };
        //File.WriteAllText("dosya.txt", "C#\tProgramlama\tDersi \nnasılsınız, iyi şanslar...", Encoding.UTF8);
        //File.WriteAllLines("dosya.txt", satirlar, Encoding.UTF8);

        //int kisiSayisi = IDegerAl("Kaç adet kişi bilgisi gireceksiniz:");

        //Kisi[] kisiler = new Kisi[kisiSayisi];

        //for (int i = 0; i < kisiSayisi; i++)
        //{
        //    Console.WriteLine($"{i + 1}. Kişinin");
        //    kisiler[i].isim = SDegerAl("Adını Giriniz:");
        //    kisiler[i].soyisim = SDegerAl("Soyadını Giriniz:");
        //    kisiler[i].yas = IDegerAl("Yaşını Giriniz:");
        //    Console.Write("Cinsiyeti Giriniz (Kadın:0/Erkek:1):");
        //    kisiler[i].cinsiyet = Console.ReadLine() == "0" ? Cinsiyet.Kadin : Cinsiyet.Erkek;
        //    Console.Write('\n');
        //}

        //KisileriYazdir(kisiler);
        //KisileriDosyayaYazdir(kisiler);
    }
}