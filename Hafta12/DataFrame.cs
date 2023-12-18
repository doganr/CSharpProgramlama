using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta12
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

        private void TableTopLine()
        {
            string[] hucreler = new string[CWidths.Count];
            for (int i = 0; i < CWidths.Count; i++)
                hucreler[i] = new string('═', CWidths[i]);

            string ustcizgi = "╔";
            ustcizgi += String.Join('╦', hucreler);
            ustcizgi += "╗";
            Console.WriteLine(ustcizgi);
        }

        private void TableElement(List<object> Row)
        {
            string[] hucreler = new string[CWidths.Count];
            for (int i = 0; i < CWidths.Count; i++)
                hucreler[i] = Fill(Row[i].ToString(), CWidths[i]);
            string aracizgi = "║";
            aracizgi += String.Join('║', hucreler);
            aracizgi += "║";
            Console.WriteLine(aracizgi);             
        }

        private void TableMiddleLine()
        {
            string[] hucreler = new string[CWidths.Count];
            for (int i = 0; i < CWidths.Count; i++)
                hucreler[i] = new string('─', CWidths[i]);

            string aracizgi = "╟";
            aracizgi += String.Join('╫', hucreler);
            aracizgi += "╢";
            Console.WriteLine(aracizgi);
        }

        private void TableBottomLine()
        {
            string[] hucreler = new string[CWidths.Count];
            for (int i = 0; i < CWidths.Count; i++)
                hucreler[i] = new string('═', CWidths[i]);

            string altcizgi = "╚";
            altcizgi += String.Join('╩', hucreler);
            altcizgi += "╝";
            Console.WriteLine(altcizgi);
        }

        public void PrintTable() 
        {
            TableTopLine();
            List<object> oColumns = new List<object>();
            foreach (string column in Columns)
                oColumns.Add(column);
            TableElement(oColumns);
            TableMiddleLine();
            foreach (List<object> row in Rows)
                TableElement(row);
            TableBottomLine();
        }
    }
}
