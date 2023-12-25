using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta13
{
    public class OgrenciDataFrame : DataFrame
    {
        private static List<string> sutunlar = new List<string>() { "Numara", "Ad", "Soyad", "Yaş", "Cinsiyet", "Vize", "Final", "Ort.", "H.N.", "Geçme/Kalma" };
        private static List<int> genislikler = new List<int>() { 10, 20, 20, 4, 10, 5, 5, 5, 5, 15 };

        public OgrenciDataFrame() : base (sutunlar, genislikler)
        {
        
        }
    }
}
