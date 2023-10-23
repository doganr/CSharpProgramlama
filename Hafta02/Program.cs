using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.Write("Araba");
            Console.Write(" hareket ediyor.");
            Console.WriteLine("Merhaba.");
            Console.Write("deneme");

            Console.ReadLine();*/

            // 0000 0000 -> 2^0*0 + 2^1*0 + 2^2*0+ ... + 2^7*0 = 0
            // 1111 1111 -> 2^0*1 + 2^1*1 + 2^2*1+ ... + 2^7*1 = 255

            //byte ilkSayi = 62;
            ////byte ikinciSayi = 200;
            ////byte ucuncuSayi = (byte)(ilkSayi + ikinciSayi);

            //short sSayi1 = 75;

            //// short sSayi2 = (short) (sSayi1 + ilkSayi);

            //Console.WriteLine(" merhaba " + ilkSayi + sSayi1);
            //Console.WriteLine(" merhaba 62" + sSayi1);
            //Console.WriteLine(" merhaba 6275");


            //int yas = 35;
            //int kilo = 80;
            //string isim = "Ali";
            //string soyisim = "DOĞAN";

            //Console.WriteLine($"Merahaba sayın {isim} {soyisim}. Nasılsınız?");
            //Console.WriteLine($"Yaşınız:{yas}");
            //Console.WriteLine($"Kilonuz:{kilo} kg");

            //Console.WriteLine("Merahaba sayın " + isim + " " + soyisim + ". Nasılsınız?");
            //Console.WriteLine("Yaşınız:"+yas);
            //Console.WriteLine("Kilonuz:" + kilo + " kg");

            //char harf = 'a';
            //char harf2 = '\'';

            //Console.WriteLine(harf2);

            //Console.WriteLine("Erkek\\Kadın");
            //Console.WriteLine("Atürkün Meşur lafı.\"Ne mutlu Türküm Diyene\"");

            //Console.WriteLine(@"Merahaba\v\n\tDün\fya:");


            //Console.WriteLine($"Yaşınız:{yas:D4}");
            //Console.WriteLine($"Kilonuz:{kilo} kg");
            //Console.WriteLine($"Maaşınız:{maas:C1}");
            //Console.WriteLine($"Bilimsel Sayı:{dsayi:P0}");

            int yas = 35;
            int kilo = 80;
            double dsayi = 0.25;
            double maas = 2000.75;
            string isim = "Ali";
            string soyisim = "DOĞAN";

            string mesaj = String.Format("Merahaba sayın {0} {1}. Nasılsınız?", isim, soyisim);
            string mesaj2 = $"Merahaba sayın {isim} {soyisim}. Nasılsınız?";

            Console.WriteLine($"Merahaba sayın {isim} {soyisim}. Nasılsınız?");
            Console.WriteLine(String.Format("Merahaba sayın {0} {1}. Nasılsınız?",isim,soyisim));
            Console.WriteLine(mesaj);
            Console.WriteLine(mesaj2);
        }
    }
}

