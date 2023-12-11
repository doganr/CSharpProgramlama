using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta11
{
    public class Ogrenci
    {
        public string numara;
        public string ad;
        public string soyad;
        public int yas;
        public Cinsiyet cinsiyet;
        public double vize;
        public double final;

        public Ogrenci() { }

        public Ogrenci(string numara, string ad, string soyad) 
        {
            this.numara = numara;
            this.ad = ad;
            this.soyad = soyad;
        }

        public List<object> DataRow 
        {
            get{
                return new List<object>() { this.numara,
                                        this.ad,
                                        this.soyad,
                                        this.yas,
                                        this.cinsiyet,
                                        this.vize,
                                        this.final };
            }
        }
    }
}
