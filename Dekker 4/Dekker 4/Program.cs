using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dekker_4
{
    public class Class1
    {
        public static void Main()
        {

            Console.WriteLine("\n \t \t \t Dekker IV \n");

            byte[] bytes1 = new byte[100];
            byte[] bytes2 = new byte[100];
            Random rnd1 = new Random();
            Random rnd2 = new Random();

            rnd1.NextBytes(bytes1);
            rnd2.NextBytes(bytes2);

            Console.WriteLine("Pimer Serio de Tiempos :");
            for (int ctr = bytes1.GetLowerBound(0);
                 ctr <= bytes1.GetUpperBound(0);
                 ctr++)
            {
                Console.Write("{0, 5}", bytes1[ctr]);
                if ((ctr + 1) % 10 == 0) Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Segunda Serie de Tiempos :");
            for (int ctr = bytes2.GetLowerBound(0);
                 ctr <= bytes2.GetUpperBound(0);
                 ctr++)
            {
                Console.Write("{0, 5}", bytes2[ctr]);
                if ((ctr + 1) % 10 == 0) Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}