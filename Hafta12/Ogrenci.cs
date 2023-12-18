using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta12
{
    public enum GecmeKalma{ Gecti, SartliGecti, Kaldi}
    public class Ogrenci
    {
        private string _numara;
        private string _ad;
        private string _soyad;
        private int _yas;
        private Cinsiyet _cinsiyet;
        private double _vize;
        private double _final;

        public string Numara
        {
            get { return _numara; }
        }

        public string Ad
        {
            get { return _ad; }
        }

        public string Soyad 
        {
            get { return _soyad; }
        }  

        public int Yas 
        {
            get { return _yas; }
            set { _yas = value<0 ? 0 : value; }
        }

        public Cinsiyet Cinsiyet 
        {
            get { return _cinsiyet; }
            set { _cinsiyet = value;}
        }

        public double Vize 
        {
            get { return _vize; }
            set 
            { 
                if (value<0)
                    _vize = 0;
                else if(value>100)
                    _vize = 100;
                else
                    _vize = value;            
            }
        }

        public double Final
        {
            get { return _final; }
            set
            {
                if (value < 0)
                    _final = 0;
                else if (value > 100)
                    _final = 100;
                else
                    _final = value;
            }
        }

        public double Ortalama 
        {
            get 
            {
                double ortalama = _vize * 0.4 + _final * 0.6;
                return ortalama; 
            }
        }

        public GecmeKalma GecmeDurumu 
        {
            get 
            {
                if (_final < 45)
                    return GecmeKalma.Kaldi;
                else if (Ortalama >= 45 && Ortalama < 50)
                    return GecmeKalma.SartliGecti;
                else
                    return GecmeKalma.Gecti;
            }
        }

        public string HarfNotu 
        {
            get 
            {
                if (GecmeDurumu == GecmeKalma.Kaldi)
                    return "FF";
                else 
                {
                    if (Ortalama <= 100 && Ortalama >= 80.5)
                        return "AA";
                    else if (Ortalama < 80.5 && Ortalama >= 75.5)
                        return "BA";
                    else if (Ortalama < 75.5 && Ortalama >= 69.5)
                        return "BB";
                    else if (Ortalama < 69.5 && Ortalama >= 59.5)
                        return "CB";
                    else if (Ortalama < 59.5 && Ortalama >= 49.5)
                        return "CC";
                    else if (Ortalama < 49.5 && Ortalama >= 44.5)
                        return "DC";
                    else if (Ortalama < 44.5 && Ortalama >= 39.5)
                        return "DD";
                    else if (Ortalama < 39.5 && Ortalama >= 29.5)
                        return "FD";
                    else
                        return "FF";
                }                
            }
        }        

        public Ogrenci(string numara, string ad, string soyad) 
        {
            this._numara = numara;
            this._ad = ad;
            this._soyad = soyad;
        }

        public List<object> DataRow 
        {
            get{
                return new List<object>() { this.Numara,
                                        this.Ad,
                                        this.Soyad,
                                        this.Yas,
                                        this.Cinsiyet,
                                        this.Vize,
                                        this.Final,
                                        this.Ortalama,
                                        this.HarfNotu,
                                        this.GecmeDurumu};
            }
        }
    }
}
