using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;

namespace Hafta12
{
    public enum Cinsiyet { Kadin, Erkek }

    public class Program
    {
        static void Main()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();

            ogrenciler.Add(new Ogrenci("2207231061", "Sinan", "Turan") { Yas = 19, Cinsiyet = Cinsiyet.Erkek });
            ogrenciler.Add(new Ogrenci("2207231032", "Ahmet", "Yavuz") { Yas = 20, Cinsiyet = Cinsiyet.Erkek });
            ogrenciler.Add(new Ogrenci("2207231055", "Burçin", "Lale") { Yas = 21, Cinsiyet = Cinsiyet.Kadin });

            ogrenciler[0].Vize = 98;
            ogrenciler[0].Final = 55;



            OgrenciDataFrame tablo = new OgrenciDataFrame();

            foreach (Ogrenci ogr in ogrenciler)
            {
                tablo.addRow(ogr.DataRow);
            }
            tablo.PrintTable();

            string data = JsonSerializer.Serialize<List<Ogrenci>>(ogrenciler);

            File.WriteAllText("ogrenciler.json", data, Encoding.UTF8);

            string okunan = File.ReadAllText("ogrenciler.json", Encoding.UTF8);

            List<Ogrenci> ogrenciler2 = JsonSerializer.Deserialize<List<Ogrenci>>(okunan);
        }
    }
}