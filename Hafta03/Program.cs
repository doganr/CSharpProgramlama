using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta03
{
    internal class Program
    {
        static void Main()
        {
            List<string> isimler = new List<string>();
            List<string> soyisimler = new List<string>();
            List<int> yaslar = new List<int>();

            bool yeniKisiVarmi = true;
            int sayac = 0;
            while (yeniKisiVarmi) 
            {
                Console.WriteLine($"{sayac + 1}. Kişinin");
                Console.Write("Adını Giriniz:");
                isimler.Add(Console.ReadLine());
                Console.Write("Soyadını Giriniz:");
                soyisimler.Add(Console.ReadLine());
                Console.Write("Yaşını Giriniz:");
                yaslar.Add(Convert.ToInt32(Console.ReadLine()));
                Console.Write('\n' );
                Console.Write("Başka kişi eklenecek mi? (y/n):");
                if(Console.ReadLine()!="y")
                    yeniKisiVarmi = false;
                sayac++;
            }

            TextInfo ti = new CultureInfo("tr-TR", false).TextInfo;
            Console.WriteLine($"|{"",5}|{"İSİM",-20}|{"SOYİSİM",-10}|{"YAS",5}|");
            Console.WriteLine($"----------------------------------------------");
            for (int i = 0; i < isimler.Count; i++)
                Console.WriteLine($"|{1,5}|{ti.ToTitleCase(isimler[i]),-20}|{ti.ToTitleCase(soyisimler[i]),-10}|{yaslar[i],5}|");


            //Console.Write("Kaç adet kişi bilgisi gireceksiniz:");
            //int kisiSayisi = Convert.ToInt32(Console.ReadLine());

            //string[] isimler = new string[kisiSayisi];
            //string[] soyisimler = new string[kisiSayisi];
            //int[] yaslar = new int[kisiSayisi];

            //for (int i = 0; i < kisiSayisi; i++) 
            //{
            //    Console.WriteLine($"{i + 1}. Kişinin");
            //    Console.Write("Adını Giriniz:");
            //    isimler[i] = Console.ReadLine();
            //    Console.Write("Soyadını Giriniz:");
            //    soyisimler[i] = Console.ReadLine();
            //    Console.Write("Yaşını Giriniz:");
            //    yaslar[i] = Convert.ToInt32(Console.ReadLine());
            //    Console.Write('\n' );
            //}
            //TextInfo ti = new CultureInfo("tr-TR", false).TextInfo;
            //Console.WriteLine($"|{"",5}|{"İSİM",-20}|{"SOYİSİM",-10}|{"YAS",5}|");
            //Console.WriteLine($"----------------------------------------------");
            //for ( int i = 0;i<isimler.Length;i++ ) 
            //    Console.WriteLine($"|{1,5}|{ti.ToTitleCase(isimler[i]),-20}|{ti.ToTitleCase(soyisimler[i]),-10}|{yaslar[i],5}|");



            //string[] isimler = { "Ramazan" , "Hülya" , "Yiğit Kağan", "Haydar Uraz", "Efe"};
            //string[] soyisimler = { "DOĞAN", "DOĞAN", "DOĞAN", "DOĞAN", "HANÇER" };
            //int[] yaslar = { 35, 34, 8, 3, 19};

            //Console.WriteLine($"|{"",5}|{"İSİM",-20}|{"SOYİSİM",-10}|{"YAS",5}|");
            //Console.WriteLine($"----------------------------------------------");
            //for ( int i = 0;i<isimler.Length;i++ ) 
            //    Console.WriteLine($"|{1,5}|{isimler[i],-20}|{soyisimler[i],-10}|{yaslar[i],5}|");


            //Console.WriteLine($"|{"",5}|{"İSİM",-20}|{"SOYİSİM",-10}|{"YAS",5}|");
            //Console.WriteLine($"----------------------------------------------");
            //Console.WriteLine($"|{1,5}|{isimler[0],-20}|{soyisimler[0],-10}|{yaslar[0],5}|");
            //Console.WriteLine($"|{2,5}|{isimler[1],-20}|{soyisimler[1],-10}|{yaslar[1],5}|");
            //Console.WriteLine($"|{3,5}|{isimler[2],-20}|{soyisimler[2],-10}|{yaslar[2],5}|");

            //string isim1 = "Ramazan";
            //string soyisim1 = "DOĞAN";
            //int yas1 = 35;

            //string isim2 = "Hülya";
            //string soyisim2 = "DOĞAN";
            //int yas2 = 34;

            //string isim3 = "Yiğit Kağan";
            //string soyisim3 = "DOĞAN";
            //int yas3 = 8;

            //Console.WriteLine($"|{"",5}|{"İSİM",-20}|{"SOYİSİM",-10}|{"YAS",5}|");
            //Console.WriteLine($"----------------------------------------------");
            //Console.WriteLine($"|{1,5}|{isim1,-20}|{soyisim1,-10}|{yas1,5}|");
            //Console.WriteLine($"|{2,5}|{isim2,-20}|{soyisim2,-10}|{yas2,5}|");
            //Console.WriteLine($"|{3,5}|{isim3,-20}|{soyisim3,-10}|{yas3,5}|");

            //Console.WriteLine($"{isim1,20} {soyisim1,10} {yas1,5}");
            //Console.WriteLine($"{isim2,20} {soyisim2,10} {yas2,5}");
            //Console.WriteLine($"{isim3,20} {soyisim3,10} {yas3,5}");

            //Console.WriteLine($"{isim1} {soyisim1} {yas1}");
            //Console.WriteLine($"{isim2} {soyisim2} {yas2}");
            //Console.WriteLine($"{isim3} {soyisim3} {yas3}");
            //Ramazan DOĞAN 35
            //Hülya DOĞAN 34
            //Yiğit Kağan DOĞAN 8

            //Console.WriteLine(isim1 + " " + soyisim1 + " " + yas1);
            //Console.WriteLine(isim2 + " " + soyisim2 + " " + yas2);
            //Console.WriteLine(isim3 + " " + soyisim3 + " " + yas3);
            //Ramazan DOĞAN 35
            //Hülya DOĞAN 34
            //Yiğit Kağan DOĞAN 8
        }
    }
}






//örnek 1
//Console.Write("İsiminizi Giriniz:");
//string isim = Console.ReadLine();

//Console.Write("Soyisminizi Girini:");
//string soyisim = Console.ReadLine();

//Console.Write("Yaşınızı Giriniz:");
//int yas = Convert.ToInt32(Console.ReadLine());

////Console.Write("Yaşınızı Giriniz:");
////string syas = Console.ReadLine();
////int yas = Convert.ToInt32(syas);

//Console.WriteLine($"Merhaba sayın {isim} {soyisim}, nasılsınız.");
//Console.WriteLine($"Yaşınızın {yas} olduğunu görüyorum.");

