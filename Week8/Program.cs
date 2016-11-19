using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8
{
    class Program
    {
        static IEnumerable<string[]> ReadCsv1(string filename)
        {
            using (var stream = new StreamReader(filename))
                while (true)
                {
                    if (stream.EndOfStream)
                    {
                        stream.Close();
                        yield break;
                    }
                    var str = stream.ReadLine().Split(',');
                    for (var i = 0; i < str.Length; i++)
                        if (str[i] == "NA")
                            str[i] = null;
                        else str[i] = str[i].Replace("\"", null);
                    yield return str;
                }
        }

        static void Main(string[] args)
        {
            foreach (var strAr in ReadCsv1("C:\\Users\\Евгений\\Desktop\\airquality.csv"))
            {
                foreach (var str in strAr)
                {
                    Console.Write("{0} ", str);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

    }
}