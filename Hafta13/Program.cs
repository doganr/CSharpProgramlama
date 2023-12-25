using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;

namespace Hafta13
{
    public enum Cinsiyet { Kadin, Erkek }

    public class Program
    {
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

        static void KomutlariYazdir()
        {
            DataFrame komutlar = new DataFrame(new List<string>() { "", "Açıklama", "Komut" },
                                               new List<int>() { 3, 80, 25 });
            int i = 1;
            komutlar.addRow(new List<object>() { i++, "Uygulamayı sonlandırır.", " kapat " });
            komutlar.addRow(new List<object>() { i++, "Değişiklikleri kaydet.", " kaydet " });
            komutlar.addRow(new List<object>() { i++, "Sisteme yeni öğrenci ekler.", " ogrenci_ekle " });
            komutlar.addRow(new List<object>() { i++, "Sistemeden öğrenci siler.", " ogrenci_sil " });
            komutlar.addRow(new List<object>() { i++, "Sistemdeki öğrencileri listeler.", " ogrenci_listele " });
            komutlar.addRow(new List<object>() { i++, "Seçili öğrencinin vize notu bilgilerini günceller.", " vizenotu_guncelle " });
            komutlar.addRow(new List<object>() { i++, "Seçili öğrencinin final notu bilgilerini günceller.", " finalnotu_guncelle " });

            komutlar.PrintTable();
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

            string data = JsonSerializer.Serialize<Dictionary<string, Ogrenci>>(ogrenciler);
            File.WriteAllText("ogrenciler.json", data, Encoding.UTF8);

            Console.WriteLine("\n\nDeğişiklikler kaydedildi!");
            Console.Write("Devam etmek için Enter tuşuna basınız...");
            Console.ReadLine();
            Console.Clear();
        }

        static Dictionary<string, Ogrenci> OgrencileriDosyadanOku()
        {
            Dictionary<string, Ogrenci> ogrenciler;
            if (File.Exists("ogrenciler.json"))
            {
                string okunan = File.ReadAllText("ogrenciler.json", Encoding.UTF8);
                ogrenciler = JsonSerializer.Deserialize<Dictionary<string, Ogrenci>>(okunan);
                
            }
            else 
            {
                ogrenciler = new Dictionary<string, Ogrenci>();
            }                
            return ogrenciler;
        }

        static void OgrenciEkle(Dictionary<string, Ogrenci> ogrenciler)
        {
            Console.Clear();            

            Console.WriteLine("Öğrenci Bilgileri:");
            Console.WriteLine(new string('─', 100));

            string numara = StringDegerAl("Numara giriniz:");
            string isim = StringDegerAl("İsmi giriniz:");
            string soyisim = StringDegerAl("Soyismi giriniz:");

            Ogrenci ogrenci = new Ogrenci(numara,isim, soyisim);

            int yas = IntegerDegerAl("Yaşı giriniz:");
            ogrenci.Yas = yas;

            int cinsiyet = IntegerDegerAl("Cinsiyet giriniz (Kadın:0, Erkek:1):");
            ogrenci.Cinsiyet = cinsiyet == 0 ? Cinsiyet.Kadin : Cinsiyet.Erkek;

            ogrenciler.Add(ogrenci.Numara, ogrenci);

            Console.WriteLine("\n\nÖğrenci sisteme eklendi!");
            Console.Write("Devam etmek için Enter tuşuna basınız...");
            Console.ReadLine();
            Console.Clear();            

            DegisiklikleriKaydet(ogrenciler);
        }

        static void OgrenciSil(Dictionary<string, Ogrenci> ogrenciler)
        {
            Console.Clear();
            Console.WriteLine(OgrencileriDondur(ogrenciler));
            Console.WriteLine(new string('─', 100));
            string numara = StringDegerAl("Öğrenci numarası giriniz:");

            ogrenciler.Remove(numara);
            Console.Clear();

            Console.WriteLine("\n\nÖğrenci sistemden silindi!");
            Console.Write("Devam etmek için Enter tuşuna basınız...");
            Console.ReadLine();
            Console.Clear();

            DegisiklikleriKaydet(ogrenciler);
        }

        static void OgrencileriListele(Dictionary<string, Ogrenci> ogrenciler)
        {            
            Console.Clear();

            OgrenciDataFrame ogrencidf = new OgrenciDataFrame();
            foreach (var ogrenci in ogrenciler)
            {
                ogrencidf.addRow(ogrenci.Value.DataRow);
            }
            ogrencidf.PrintTable();

            Console.WriteLine("\n\nSisteme kayıtlı öğrenciler yukarıdaki gibidir!");
            Console.Write("Devam etmek için Enter tuşuna basınız...");
            Console.ReadLine();
            Console.Clear();
        }

        static string OgrencileriDondur(Dictionary<string, Ogrenci> ogrenciler)
        {
            OgrenciDataFrame ogrencidf = new OgrenciDataFrame();
            foreach (var ogrenci in ogrenciler)
            {
                ogrencidf.addRow(ogrenci.Value.DataRow);
            }
            return ogrencidf.ToString();
        }

        static void OgrenciVizeNotuEkle(Dictionary<string, Ogrenci> ogrenciler)
        {
            Console.Clear();
            Console.WriteLine(OgrencileriDondur(ogrenciler));
            Console.WriteLine(new string('─', 100));
            string numara = StringDegerAl("Öğrenci numarası giriniz:");
            Console.Clear();

            if (ogrenciler.Keys.Contains(numara))
            {
                ogrenciler[numara].Vize = IntegerDegerAl("Güncel vize notunu giriniz:");

                DegisiklikleriKaydet(ogrenciler);

                Console.Clear();
                Console.WriteLine(OgrencileriDondur(ogrenciler));
                Console.WriteLine(new string('─', 100));

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
            Console.WriteLine(OgrencileriDondur(ogrenciler));
            Console.WriteLine(new string('─', 100));
            string numara = StringDegerAl("Öğrenci numarası giriniz:");
            Console.Clear();

            if (ogrenciler.Keys.Contains(numara))
            { 
                ogrenciler[numara].Final = IntegerDegerAl("Güncel final notunu giriniz:");

                DegisiklikleriKaydet(ogrenciler);

                Console.Clear();
                Console.WriteLine(OgrencileriDondur(ogrenciler));
                Console.WriteLine(new string('─', 100));

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
                    case "ogrenci_sil":
                        OgrenciSil(ogrenciler);
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