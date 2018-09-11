using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            double cel, feh;
            Console.WriteLine("enter the value of cel");
            cel = Convert.ToDouble(Console.ReadLine());
            feh = (9.0 / 5.0) * cel + 32;
            Console.WriteLine("feh = " + feh);
            Console.WriteLine("enter the value of a");
            a = Convert.ToInt16(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                } Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
