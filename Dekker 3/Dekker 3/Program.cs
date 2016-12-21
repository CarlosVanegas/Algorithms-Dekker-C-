using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Dekker_3
{
    //Dekker III
    //Colisión región crítica no garantiza la exclusión mutua

    class Cuenta
    {
        private Object esteBloqueo = new Object();
        int balance;

        Random random = new Random();

        public Cuenta(int inicio)
        {
            balance = inicio;
        }

        int Retirar(int cantidad)
        {

            // Esta condición nunca es verdadera a menos que la instrucción de bloqueo
            // comentado.
            if (balance < 0)
            {
                throw new Exception("Valor Negativo, Balance");
            }

            //  Comente la siguiente línea para ver el efecto de dejar de lado 
            // La palabra clave de bloqueo.
            lock (esteBloqueo)
            {
                if (balance >= cantidad)
                {
                    Console.WriteLine(" \n \t Saldo antes de retiro  :  " + balance);
                    Console.WriteLine(" \t Cantidad a retirar       : -" + cantidad);
                    balance = balance - cantidad;
                    Console.WriteLine(" \t Saldo después de la retirada  :  " + balance);
                    return cantidad;
                }
                else
                {
                    //retorno cero 
                    return 0; // Transacción rechazada
                }
            }
        }

        public void HacerTransacciones()
        {
            for (int i = 0; i < 100; i++)
            {
                Retirar(random.Next(1, 100));
            }
        }
    }

    class Prueba
    {
        static void Main()

        {
            Console.WriteLine("\n \t \t Dekker III \n");
            Console.WriteLine("  Colisión región crítica no garantiza la exclusión mutua  \n");
            Thread[] hilo = new Thread[10];
            Cuenta acc = new Cuenta(1000);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.HacerTransacciones));
                hilo[i] = t;
            }
            for (int i = 0; i < 10; i++)
            {
                hilo[i].Start();
            }
            Console.ReadKey();

        }
    }
}