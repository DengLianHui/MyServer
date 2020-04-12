using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (Console.ReadLine())
            {
                case "A":
                    AddFile();
                    break;

                case "B":

                    break;

                default:
                    break;
            }
        }


        private static void AddFile()
        {
            string[] vs = new string[10000];

            for (int i = 0; i < vs.Length; i++)
            {
                vs[i] = i.ToString() + i + i + i + i + i;
            }


            for (int i = 0; i < 1000000; i++)
            {
                string path = "D:/test/test" + i + DateTime.Now.ToString("HHmmss") + ".txt";

                System.IO.File.AppendAllLines(path, vs);
            }
        }
    }
}
