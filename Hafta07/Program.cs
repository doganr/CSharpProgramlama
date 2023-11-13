using System.Collections.Generic;
using System.Text;

namespace Hafta07
{
    internal class Program
    {
        struct Ogrenci
        {
            public string numara;
            public string isim;
            public string soyisim;
            public int yas;
            public double? vize_notu;
            public double? final_notu;

            public string Bilgiler() 
            {

                string ifade = String.Format("|{0,-10}|{1,-20}|{2,-10}|{3,5}|{4,5}|{5,5}|{6,5}|",
                                                numara,
                                                isim,
                                                soyisim,
                                                yas,
                                                vize_notu,
                                                final_notu,
                                                gecme_notu());
                return ifade;
            }

            public double? gecme_notu() 
            {
                return final_notu != null && final_notu < 45 ? 0 : vize_notu * 0.4 + final_notu * 0.6;
            }
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
            Console.WriteLine(String.Format("║{0,5}║{1,-70}║{2,-21}║", index == null ? "ID" : index
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
            TabloEleman(1, "Uygulamayı sonlandırır.", " kapat ");
            TabloAraCizgi();
            TabloEleman(2, "Değişiklikleri kaydet.", " kaydet ");
            TabloAraCizgi();
            TabloEleman(3, "Sisteme yeni öğrenci ekler.", " ogrenci_ekle ");
            TabloAraCizgi();
            TabloEleman(4, "Sistemdeki öğrencileri listeler.", " ogrenci_listele ");
            TabloAraCizgi();
            TabloEleman(5, "Seçili öğrencinin vize notu bilgilerini günceller.", " vizenotu_guncelle ");
            TabloAraCizgi();
            TabloEleman(6, "Seçili öğrencinin final notu bilgilerini günceller.", " finalnotu_guncelle ");
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

        static void DegisiklikleriKaydet(Dictionary<string, Ogrenci> ogrenciler)
        {
            Console.Clear();

            List<string> satirlar = new List<string>();

            foreach (var pair in ogrenciler)
            {
                satirlar.Add(String.Format("{0}", pair.Value.Bilgiler()));
            }

            File.WriteAllLines("ogrenciler.txt", satirlar, Encoding.UTF8);

            Console.WriteLine("\n\nDeğişiklikler kaydedildi!");
            Console.Write("Devam etmek için Enter tuşuna basınız...");
            Console.ReadLine();
            Console.Clear();
        }

        static void OgrenciEkle(Dictionary<string, Ogrenci> ogrenciler)
        {
            Console.Clear();
            Ogrenci ogrenci = new Ogrenci();

            Console.WriteLine("Öğrenci Bilgileri:");
            Console.WriteLine(new string('─', 100));
            ogrenci.numara = StringDegerAl("Numara giriniz:");
            ogrenci.isim = StringDegerAl("İsmi giriniz:");
            ogrenci.soyisim = StringDegerAl("Soyismi giriniz:");
            ogrenci.yas = IntegerDegerAl("Yaşı giriniz:");

            Console.WriteLine("\n\nÖğrenci sisteme eklendi!");
            Console.Write("Devam etmek için Enter tuşuna basınız...");
            Console.ReadLine();
            Console.Clear();

            ogrenciler.Add(ogrenci.numara, ogrenci);

            DegisiklikleriKaydet(ogrenciler);
        }

        static Dictionary<string, Ogrenci> OgrencileriDosyadanOku() 
        {
            Dictionary<string, Ogrenci> ogrenciler = new Dictionary<string, Ogrenci>();
            if (File.Exists("ogrenciler.txt"))
            {
                string[] satirlar = File.ReadAllLines("ogrenciler.txt", Encoding.UTF8);
                foreach (string satir in satirlar)
                {
                    string[] degerler = satir.Split('|');

                    Ogrenci ogr = new Ogrenci();
                    ogr.numara = degerler[1].Trim();
                    ogr.isim = degerler[2].Trim();
                    ogr.soyisim = degerler[3].Trim();
                    ogr.yas = Convert.ToInt32(degerler[4].Trim());
                    ogr.vize_notu = degerler[5].Trim() == "" ? null : Convert.ToInt32(degerler[5].Trim());
                    ogr.final_notu = degerler[6].Trim() == "" ? null : Convert.ToInt32(degerler[6].Trim());
                    ogrenciler.Add(ogr.numara,ogr);
                }
            }
            return ogrenciler;
        }

        static string OgrenciListesi(Dictionary<string, Ogrenci> ogrenciler) 
        {
            string liste = "";
            int sayac = 1;
            foreach (var pair in ogrenciler)
            {
                liste += String.Format("|{0,5}{1}\n", sayac++, pair.Value.Bilgiler());
            }
            return liste;
        }

        static void OgrencileriListele(Dictionary<string, Ogrenci> ogrenciler) 
        {
            Console.Clear();

            Console.WriteLine(OgrenciListesi(ogrenciler));

            Console.WriteLine("\n\nSisteme kayıtlı öğrenciler yukarıdaki gibidir!");
            Console.Write("Devam etmek için Enter tuşuna basınız...");
            Console.ReadLine();
            Console.Clear();
        }

        static void OgrenciVizeNotuEkle(Dictionary<string, Ogrenci> ogrenciler) 
        {
            Console.Clear();
            Console.WriteLine(OgrenciListesi(ogrenciler));
            Console.WriteLine(new string('─', 100));
            string numara = StringDegerAl("Öğrenci numarası giriniz:");
            Console.Clear();

            if (ogrenciler.Keys.Contains(numara))
            {
                Ogrenci ogr = ogrenciler[numara];

                Console.WriteLine("Öğrenci Bilgileri:");
                Console.WriteLine(new string('─', 100));
                Console.WriteLine(ogr.Bilgiler());
                Console.WriteLine(new string('─', 100));
                ogr.vize_notu = IntegerDegerAl("Güncel vize notunu giriniz:");
                ogrenciler[numara] = ogr;
                DegisiklikleriKaydet(ogrenciler);
                Console.WriteLine("\n\nÖğrenci vize notu değiştirildi!");
                Console.Write("Devam etmek için Enter tuşuna basınız...");
                Console.ReadLine();
                Console.Clear();
            }
            else 
            {
                Console.WriteLine($"\n\nSisteme kayıtlı {numara} numaralı bir öğrenci yoktur!");
                Console.Write("Devam etmek için Enter tuşuna basınız...");
                Console.ReadLine();
                Console.Clear();
            }           
        }

        static void OgrenciFinalNotuEkle(Dictionary<string, Ogrenci> ogrenciler)
        {
            Console.Clear();
            Console.WriteLine(OgrenciListesi(ogrenciler));
            Console.WriteLine(new string('─', 100));
            string numara = StringDegerAl("Öğrenci numarası giriniz:");
            Console.Clear();

            if (ogrenciler.Keys.Contains(numara))
            {
                Ogrenci ogr = ogrenciler[numara];

                Console.WriteLine("Öğrenci Bilgileri:");
                Console.WriteLine(new string('─', 100));
                Console.WriteLine(ogr.Bilgiler());
                Console.WriteLine(new string('─', 100));
                ogr.final_notu = IntegerDegerAl("Güncel final notunu giriniz:");
                ogrenciler[numara] = ogr;
                DegisiklikleriKaydet(ogrenciler);
                Console.WriteLine("\n\nÖğrenci final notu değiştirildi!");
                Console.Write("Devam etmek için Enter tuşuna basınız...");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"\n\nSisteme kayıtlı {numara} numaralı bir öğrenci yoktur!");
                Console.Write("Devam etmek için Enter tuşuna basınız...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void Main()
        {
            Dictionary<string, Ogrenci> ogrenciler = OgrencileriDosyadanOku();
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
                        OgrenciEkle(ogrenciler);
                        break;
                    case "ogrenci_listele":
                        OgrencileriListele(ogrenciler);
                        break;
                    case "vizenotu_guncelle":
                        OgrenciVizeNotuEkle(ogrenciler);
                        break;
                    case "finalnotu_guncelle":
                        OgrenciFinalNotuEkle(ogrenciler);
                        break;
                    default:
                        BilinmeyenKomut();
                        break;
                }

            } while (devam);
        }
    }
}