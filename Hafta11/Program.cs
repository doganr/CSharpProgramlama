namespace Hafta11
{
    public enum Cinsiyet { Kadin, Erkek }

    public class Program
    {
        static void Main()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();

            ogrenciler.Add(new Ogrenci("2207231061", "Sinan", "Turan") {yas=19, cinsiyet=Cinsiyet.Erkek });
            ogrenciler.Add(new Ogrenci("2207231032", "Ahmet", "Yavuz") { yas = 20, cinsiyet = Cinsiyet.Erkek });
            ogrenciler.Add(new Ogrenci("2207231055", "Burçin", "Lale") { yas = 21, cinsiyet = Cinsiyet.Kadin });

            //List<string> sutunlar = new List<string>() { "Numara", "Ad", "Soyad", "Yaş", "Cinsiyet", "Vize", "Final" };
            //List<int> genislikler = new List<int>() { 10, 20, 20, 4, 10, 5, 5 };
            //DataFrame tablo = new DataFrame(sutunlar, genislikler);

            OgrenciDataFrame tablo = new OgrenciDataFrame();

            
            foreach (Ogrenci ogr in ogrenciler)
            {
                tablo.addRow(ogr.DataRow);
            }
            tablo.PrintTable();





            //foreach (Ogrenci ogr in ogrenciler)
            //{                
            //    tablo.addRow(new List<object>() {ogr.numara, ogr.ad, ogr.soyad, ogr.yas, ogr.cinsiyet, ogr.vize, ogr.final });
            //}
            //tablo.PrintTable();


                //Ogrenci ogr1 = new Ogrenci("2207231062", "Sinan", "Turan");
                //ogr1.yas = 19;
                //ogr1.cinsiyet = Cinsiyet.Erkek;

            //Ogrenci ogr2 = new Ogrenci() { numara= "2207231032",
            //                               ad= "Ahmet",
            //                               soyad = "Yavuz",
            //                               cinsiyet = Cinsiyet.Erkek,
            //                               yas = 19};

            //Ogrenci ogr3 = new Ogrenci("2207231055", "Burçin", "Turan") { cinsiyet = Cinsiyet.Kadin,
            //                                                              yas = 21};

            //List<string> sutunlar = new List<string>() { "", "Ad", "Soyad", "Yaş", "Cinsiyet", "Vize" };
            //List<int> genislikler = new List<int>() { 3, 30, 20, 10, 10, 5 };

            //DataFrame tablo = new DataFrame(sutunlar, genislikler);
            //tablo.addRow(new List<object>() { 1, "Ramazan", "Doğan", 36, Cinsiyet.Erkek, 65 });
            //tablo.addRow(new List<object>() { 2, "Sinan", "Turan", 19, Cinsiyet.Erkek, 40 });
            //tablo.addRow(new List<object>() { 3, "Selim", "Demir", 22, Cinsiyet.Erkek, 0 });
            //tablo.addRow(new List<object>() { 4, "Habibe", "Karagöz", 20, Cinsiyet.Kadın, 100 });

            //tablo.PrintTable();
            }
    }
}