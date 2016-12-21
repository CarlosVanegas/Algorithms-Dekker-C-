using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Security.Cryptography;

namespace Dekker_4._1
{
    //Otra version de Dekker 4, retardo con un tiempo aleatorio (tiempo en segundos)
    public static class Dekker4
    {
        #region Miembros

        private readonly static TimerCallback tiempo = new TimerCallback(Dekker4.EjecutarAccionRetardada);

        #endregion

        #region Metodos

          public static void Do(Action action, TimeSpan delay, int interval = Timeout.Infinite)
        {
            //  Crear un nuevo temporizador de hilo para ejecutar el método después del retardo
            new Timer(tiempo, action, Convert.ToInt32(delay.TotalMilliseconds), interval);

            return;
        }

         public static void Hacer(Action iniciaAccion, int retrasar, int intervalo = Timeout.Infinite)
        {
            Do(iniciaAccion, TimeSpan.FromMilliseconds(retrasar), intervalo);

            return;
        }

        public static void Hacer(Action iniciarAccion, DateTime aTiempo, int intervalo = Timeout.Infinite)
        {
            if (aTiempo < DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("aTiempo", " Ya ha transcurrido el tiempo debido especificado.");
            }

            Do(iniciarAccion, aTiempo - DateTime.Now, intervalo);

            return;
        }

     
        private static void EjecutarAccionRetardada(object o)
        {
            // invoke the anonymous method
            (o as Action).Invoke();

            return;
        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n \t\t\t\t Dekker 4");
            Console.WriteLine("Finaliza despues de 15 segundos transcurridos en los porcesos aleatorios");

            Console.WriteLine("\n \t  Tiempo: {0} - empezado..", DateTime.Now);
           
            //  Demostrar que el orden es irrelevante
            Dekker4.Hacer(() => Console.WriteLine(" Tiempo: {0} - Hola Mundo! (despues de 5s)", DateTime.Now), DateTime.Now.AddSeconds(5));
            Dekker4.Hacer(() => Console.WriteLine(" Tiempo: {0} - Hola Mundo! (despues de 3s)", DateTime.Now), DateTime.Now.AddSeconds(3));
            Dekker4.Hacer(() => Console.WriteLine(" Tiempo: {0} - Hola Mundo! (despues de 1s)", DateTime.Now), DateTime.Now.AddSeconds(1));

            Dekker4.Do
            (
               () =>
               {
                   //  Demostrar la flexibilidad de los métodos anónimos
                   for (int i = 0; i < 10; i++)
                   {
                       Console.WriteLine("   Tiempo: {0} - Hola Mundo! - i == {1} (despues de  4s)", DateTime.Now, i);
                   }
               },
               TimeSpan.FromSeconds(4)
            );

            //  Bloquea el hilo principal para mostrar la ejecución de los hilos de fondo
            Thread.Sleep(15000);

            return;
        }
    }
}
