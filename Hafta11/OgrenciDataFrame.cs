using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta11
{
    public class OgrenciDataFrame : DataFrame
    {
        private static List<string> sutunlar = new List<string>() { "Numara", "Ad", "Soyad", "Yaş", "Cinsiyet", "Vize", "Final" };
        private static List<int> genislikler = new List<int>() { 10, 20, 20, 4, 10, 5, 5 };

        public OgrenciDataFrame() : base (sutunlar, genislikler)
        {
        
        }
    }
}
