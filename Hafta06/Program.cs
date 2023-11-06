using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace Hafta06
{
    public class Program
    {
        struct Ogrenci
        {
            public string numara;
            public string isim;
            public string soyisim;
            public int yas;
            public double? vize_notu;
            public double? final_notu;
        }

        static string StringDegerAl(string mesaj)
        {
            Console.Write(mesaj);
            string deger = Console.ReadLine();
            return deger;
        }

        static int IntegerDegerAl(string mesaj)
        {
            Console.Write(mesaj);
            string deger = Console.ReadLine();
            return Convert.ToInt32(deger);
        }
        static void TabloUstCizgi() 
        {
            Console.WriteLine(String.Format("╔{0}╦{1}╦{2}╗", new string('═', 5)
                                                           , new string('═', 70)
                                                           , new string('═', 21)));
        }
        
        static void TabloEleman(int? index, string aciklama, string komut) 
        {
            Console.WriteLine(String.Format("║{0,5}║{1,-70}║{2,-21}║", index == null ? "ID": index
                                                                      , aciklama
                                                                      , komut));
        }

        static void TabloAraCizgi() 
        {
            Console.WriteLine(String.Format("╟{0}╫{1}╫{2}╢", new string('─', 5)
                                                           , new string('─', 70)
                                                           , new string('─', 21)));
        }

        static void TabloAltCizgi() 
        {
            Console.WriteLine(String.Format("╚{0}╩{1}╩{2}╝", new string('═', 5)
                                                           , new string('═', 70)
                                                           , new string('═', 21)));
        }

        static void KomutlariYazdir() 
        {
            TabloUstCizgi();
            TabloEleman(null, "Açıklama", "Komut");
            TabloAraCizgi();
            TabloEleman(1, "Uygulamayı sonlandırır.", "kapat");
            TabloAraCizgi();
            TabloEleman(2, "Değişiklikleri kaydet.", "kaydet");
            TabloAraCizgi();
            TabloEleman(3, "Sisteme yeni öğrenci ekler.", "ogrenci_ekle");
            TabloAltCizgi();
        }

        static void BilinmeyenKomut() 
        {
            Console.Clear();
            Console.WriteLine("Bilinmeyen bir komut girdiniz!\n\n");
            Console.Write("Devam etmek için Enter tuşuna basınız...");
            Console.ReadLine();
            Console.Clear();
        }

        static void DegisiklikleriKaydet(List<Ogrenci> ogrenciler) 
        {
            Console.Clear();

            List<string> satirlar = new List<string>();

            for (int i = 0; i < ogrenciler.Count; i++)
            {
                satirlar.Add(String.Format("|{5,5}|{0,-20}|{1,-10}|{2,5}|{3,5}|{4,5}|",
                                                ogrenciler[i].isim,
                                                ogrenciler[i].soyisim,
                                                ogrenciler[i].yas,
                                                ogrenciler[i].vize_notu,
                                                ogrenciler[i].final_notu,
                                                (i + 1)));
            }

            File.WriteAllLines("ogrenciler.txt", satirlar, Encoding.UTF8);

            Console.WriteLine("\n\nDeğişiklikler kaydedildi!");
            Console.Write("Devam etmek için Enter tuşuna basınız...");
            Console.ReadLine();
            Console.Clear();
        }

        static Ogrenci OgrenciEkle() 
        {
            Console.Clear();
            Ogrenci ogrenci = new Ogrenci();

            Console.WriteLine("Öğrenci Bilgileri:");
            Console.WriteLine(new string('─', 100));

            ogrenci.isim = StringDegerAl("İsmi giriniz:");
            ogrenci.soyisim = StringDegerAl("Soyismi giriniz:");
            ogrenci.yas = IntegerDegerAl("Yaşı giriniz:");

            Console.WriteLine("\n\nÖğrenci sisteme eklendi!");
            Console.Write("Devam etmek için Enter tuşuna basınız...");
            Console.ReadLine();
            Console.Clear();

            return ogrenci;
        }
        
        static void Main()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();

            Console.OutputEncoding = Encoding.UTF8;
            bool devam = true;
            do
            {
                KomutlariYazdir();                
                string komut = StringDegerAl("Komutu Giriniz:");

                switch (komut)
                {
                    case "kapat":
                        devam = false;
                        break;
                    case "kaydet":
                        DegisiklikleriKaydet(ogrenciler);
                        break;
                    case "ogrenci_ekle":
                        ogrenciler.Add(OgrenciEkle());
                        break;
                    default:
                        BilinmeyenKomut();
                        break;
                }

            } while (devam);
        }
    }
}