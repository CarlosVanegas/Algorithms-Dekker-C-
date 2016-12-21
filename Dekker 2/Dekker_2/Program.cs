using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dekker_2
{
    class Program
    {
            private static volatile bool _esBloqueo1 = false;
            private static volatile bool _esBloqueo2 = false;
            private static volatile int _contador = 0;

            static void Main(string[] args)
            {
            Console.WriteLine(" \n \t \t \t Dekker II \n \n ");
            Console.WriteLine("   Problema de Interbloqueo \n \n");

            Thread hilo1 = new Thread(TrabajoDeHilo2);
                hilo1.Start();

                TrabajoDeHilo1();
            }

            public static void TrabajoDeHilo1()
            {
                while (true)
                {
                    _esBloqueo1 = true;

                    while (_esBloqueo2)
                    {
                        _esBloqueo1 = false;
                        while (_esBloqueo2) ;
                        _esBloqueo1 = true;
                    }

                    RegioCritica();
                    _esBloqueo1 = false;
                }
            }

            public static void TrabajoDeHilo2()
            {
                while (true)
                {
                    _esBloqueo2 = true;

                    while (_esBloqueo1)
                    {
                        _esBloqueo2 = false;
                        while (_esBloqueo1) ;
                        _esBloqueo2 = true;
                    }

                    RegioCritica();
                    _esBloqueo2 = false;
                }
            }


            private static void RegioCritica()
            {

            
                if (_contador != 0)
                {
                    Console.WriteLine("Proceso [ 1 ] Seguro ...");
                    _contador = 0;
                }

                _contador++;

                if (_contador != 1)
                {
                    Console.WriteLine("Proceso [ 2 ] Seguro ...");
                }

                _contador--;

                if (_contador != 0)
                {
                    Console.WriteLine("Proceso [ 3 ] Seguro ...");
                }
            }
        }
    }
