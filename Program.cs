using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Odev4
{
    class Program
    {

        static void Main(string[] args)
        {
            SortedDictionary<string, SortedDictionary<string, string>> Liste = new SortedDictionary<string, SortedDictionary<string, string>>();
            StreamReader oku = new StreamReader("kisiler.txt");
            using (oku)
            {
                while (true)
                {
                    string satir = oku.ReadLine();
                    if (satir == null)
                        break;
                    string[] ekleme = satir.Split('|');
                    string isim = ekleme[0].Trim();
                    string sehir = ekleme[1].Trim();
                    string tel = ekleme[2].Trim();

                    SortedDictionary<string, string> telDictionary;
                    if (!Liste.TryGetValue(sehir, out telDictionary))
                    {
                        telDictionary = new SortedDictionary<string, string>();
                        Liste.Add(sehir, telDictionary);

                    }
                    telDictionary.Add(isim, tel);
                }
            }

            foreach (string sehir in Liste.Keys)
            {
                Console.WriteLine(sehir + ":");
                SortedDictionary<string, string> telDictionary = Liste[sehir];
                foreach (var ekle in telDictionary)
                {
                    string isim = ekle.Key;
                    string tel = ekle.Value;
                    Console.WriteLine("\t {0} -      {1}", isim, tel);
                }
            }

            Console.ReadLine();
        }

    }
}