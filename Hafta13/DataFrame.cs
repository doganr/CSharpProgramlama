using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta13
{
    public class DataFrame
    {
        public List<string> Columns;
        public List<int> CWidths;
        public List<List<object>> Rows;

        public DataFrame(List<string> Columns, List<int> CWidths)
        {
            Console.OutputEncoding = Encoding.UTF8;
            this.Columns = Columns;
            this.CWidths = CWidths;
            this.Rows = new List<List<object>>();
        }

        public void addRow(List<object> Row) 
        {
            if(Columns.Count == Row.Count)
                this.Rows.Add(Row);
        }

        private string Fill(string? deger, int genislik)
        {
            StringBuilder bosluk = new StringBuilder(new string(' ', genislik));
            for (int i = 0; i < (deger.Length > genislik ? genislik : deger.Length); i++)
                bosluk[i] = deger[i];
            return bosluk.ToString();
        }

        private string TableTopLine()
        {
            string[] hucreler = new string[CWidths.Count];
            for (int i = 0; i < CWidths.Count; i++)
                hucreler[i] = new string('═', CWidths[i]);

            string ustcizgi = "╔";
            ustcizgi += String.Join('╦', hucreler);
            ustcizgi += "╗";
            return ustcizgi;
        }

        private string TableElement(List<object> Row)
        {
            string[] hucreler = new string[CWidths.Count];
            for (int i = 0; i < CWidths.Count; i++)
                hucreler[i] = Fill(Row[i].ToString(), CWidths[i]);
            string aracizgi = "║";
            aracizgi += String.Join('║', hucreler);
            aracizgi += "║";
            return aracizgi;             
        }

        private string TableMiddleLine()
        {
            string[] hucreler = new string[CWidths.Count];
            for (int i = 0; i < CWidths.Count; i++)
                hucreler[i] = new string('─', CWidths[i]);

            string aracizgi = "╟";
            aracizgi += String.Join('╫', hucreler);
            aracizgi += "╢";
            return aracizgi;
        }

        private string TableBottomLine()
        {
            string[] hucreler = new string[CWidths.Count];
            for (int i = 0; i < CWidths.Count; i++)
                hucreler[i] = new string('═', CWidths[i]);

            string altcizgi = "╚";
            altcizgi += String.Join('╩', hucreler);
            altcizgi += "╝";
            return altcizgi;
        }

        public void PrintTable() 
        {
            Console.WriteLine(TableTopLine());
            List<object> oColumns = new List<object>();
            foreach (string column in Columns)
                oColumns.Add(column);
            Console.WriteLine(TableElement(oColumns));
            Console.WriteLine(TableMiddleLine());
            foreach (List<object> row in Rows)
                Console.WriteLine(TableElement(row));
            Console.WriteLine(TableBottomLine());
        }

        public override string ToString()
        {
            string tablo = "";
            tablo += TableTopLine() + "\n";
            List<object> oColumns = new List<object>();
            foreach (string column in Columns)
                oColumns.Add(column);
            tablo += TableElement(oColumns) + "\n";
            tablo += TableMiddleLine() + "\n";
            foreach (List<object> row in Rows)
                tablo += TableElement(row) + "\n";
            tablo += TableBottomLine() + "\n";
            return tablo;
        }
    }
}
