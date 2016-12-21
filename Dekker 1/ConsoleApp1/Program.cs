using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ConsoleApp1
{
    class Program
    {
        public class algoritmoDekker
        {

            int turno;
            bool cancelar;

            public volatile static int a = 0;
            public volatile static int b = 0;
            public void dekker1()
            {
                Console.Write("\n \t \t \t Dekker I \n\n\n");
                Console.WriteLine(" Alternancia Estricta : ");
                Console.WriteLine(" es llamado de esta manera ya que obliga a que cada proceso tenga un turno, osea que hay un cambio de turno cada vez que un proceso sale de la sección crítica, por lo tanto si un proceso es lento atrasara a otros procesos que son rápidos.");

                Console.WriteLine("\n Características : \n");
                Console.WriteLine("Garantiza la exclusión mutua \n");
                Console.WriteLine("Su sincronización es forzada \n");
                Console.WriteLine("Acopla fuertemente a los procesos (procesos lentos atrasan a procesos rápidos \n");
                
                //Recorrido de procesos 
                for (int i = 0; i < 1000; i++)
                {
                    a = 0;
                    b = 0;

                    Parallel.Invoke(delegate { a = 1; if (b == 0) Console.Write("  Proceso  [ A ] ... "); },
                                    delegate { b = 1; if (a == 0) Console.Write("  Proceso  [ B ] ... "); });

                    Console.WriteLine(System.Environment.NewLine);

                    Thread.Sleep(800);
                }

                Console.ReadKey();
            }


            void ejecutar_seccion_critica_1()
            {
                /* lineas eliminadas para facilitar lectura */
            }

            public void proceso1()
            {
                while (!cancelar)
                {
                    while (turno == 2 && !cancelar)
                    {
                        /* esperar */
                    }
                    if (cancelar) break;
                    ejecutar_seccion_critica_1();
                    turno = 2;
                }
            }

            public void ejecutar_seccion_critica_2()
            {
                /* lineas eliminadas para facilitar lectura */
            }

            public void proceso2()
            {
                while (!cancelar)
                {
                    while (turno == 1 && !cancelar)
                    {
                        /* esperar */
                    }
                    if (cancelar) break;
                    ejecutar_seccion_critica_2();
                    turno = 1;
                }
            }

            public void  main()
            {

                // Genera un número aleatorio para definir cual es el turno inicial.
                cancelar = false;
                Random rnd = new Random();
                int turno = rnd.Next(50);     //  crea un numero aleatoria de 0 a 50

                // Se inician los dos hilos para ejecutar proceso1 y proceso2 en paralelo.
                // Thread p1(proceso1);
                //  Thread p2(proceso2);

                // Se espera hasta que el usuario decida finalizar el programa.
                // esperar_enter_del_usuario();

                cancelar = true;

                // Se espera a que finalicen los procesos.
                // p1.join();
               // p2.join();

                 
            }

            /* lineas eliminadas para facilitar lectura */


            static void Main(string[] args)
            {
                algoritmoDekker dekker = new algoritmoDekker();
                dekker.dekker1(); ;

            }
        }
    }
}