using System.Text;

namespace Hafta10
{
    public class Program
    {      
        enum Cinsiyet {Erkek, Kadın}

        static void Main()
        {
            List<string> sutunlar = new List<string>() {"","Ad","Soyad","Yaş", "Cinsiyet" };
            List<int> genislikler = new List<int>() {3, 30,20, 10, 10 };

            DataFrame tablo = new DataFrame(sutunlar, genislikler);
            tablo.addRow(new List<object>() {1, "Ramazan", "Doğan", 36, Cinsiyet.Erkek });
            tablo.addRow(new List<object>() {2, "Sinan", "Turan", 19, Cinsiyet.Erkek });
            tablo.addRow(new List<object>() {3, "Selim", "Demir", 22, Cinsiyet.Erkek });
            tablo.addRow(new List<object>() {4, "Habibe", "Karagöz", 20, Cinsiyet.Kadın });

            tablo.PrintTable();
        }
    }
}