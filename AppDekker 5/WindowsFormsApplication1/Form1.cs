using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int tiempos = 0;
        bool rojo, verde, tmps;
        Carrito Vehiculo;
        List<Carrito> Autos = new List<Carrito>();
        Thread Carga, Movimiento, Semafo;
        bool arrajo = true, izqder = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Thread Semaforo1;

            CheckForIllegalCrossThreadCalls = false;
            Carga = new Thread(new ThreadStart(GenerarAuto));
            Movimiento = new Thread(new ThreadStart(Mover));
            Semafo = new Thread(new ThreadStart(Semaforo));
            Carga.Start();
            Movimiento.Start();
            Semafo.Start();
        }
        public void GenerarAuto()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Random aleatorio = new Random();
                Carrito VehiculoMotorizadoSuperUltraMegaVelozPapu;
                string sentido = "", marca = "";
                Color color = new Color();
                Point pos = new Point(0, 0), tamaño = new Point(10, 10);
                int Ve = 2;
                var ale = aleatorio.Next(0, 5);
                int x = 80;
                if (Autos.Count > x)
                { Ve += 2; x += 80; }

                switch (ale)
                {
                    case 1:
                        sentido = "izquierda";
                        marca = "PICK UP";
                        color = Color.Black;
                        pos = new Point(420, 201);
                        tamaño = new Point(75, 23);
                        Vehiculo = VehiculoMotorizadoSuperUltraMegaVelozPapu = new Carrito(new Button(), sentido, Ve, pos, marca, color, tamaño);
                        Autos.Add(VehiculoMotorizadoSuperUltraMegaVelozPapu);
                        break;
                    case 2:
                        //if (!izqder)
                        //{
                        sentido = "abajo";
                        marca = "COMBI";
                        color = Color.Blue;
                        tamaño = new Point(23, 75);
                        pos = new Point(208, 0);
                        Vehiculo = VehiculoMotorizadoSuperUltraMegaVelozPapu = new Carrito(new Button(), sentido, Ve, pos, marca, color, tamaño);
                        Autos.Add(VehiculoMotorizadoSuperUltraMegaVelozPapu);
                        //}
                        break;
                    case 3:
                        //if (!izqder)
                        //{
                        sentido = "arriba";
                        marca = "SEDAN";
                        color = Color.Gray;
                        tamaño = new Point(23, 75);
                        pos = new Point(280, 406);
                        Vehiculo = VehiculoMotorizadoSuperUltraMegaVelozPapu = new Carrito(new Button(), sentido, Ve, pos, marca, color, tamaño);
                        Autos.Add(VehiculoMotorizadoSuperUltraMegaVelozPapu);
                        //}
                        break;
                    case 4:
                        sentido = "derecha";
                        marca = "BMW";
                        color = Color.White;
                        tamaño = new Point(75, 23);
                        pos = new Point(120, 274);
                        Vehiculo = VehiculoMotorizadoSuperUltraMegaVelozPapu = new Carrito(new Button(), sentido, Ve, pos, marca, color, tamaño);
                        Autos.Add(VehiculoMotorizadoSuperUltraMegaVelozPapu);
                        break;
                }


            }
        }
        public void Mover()
        {
            while (true)
            {
                try
                {
                    foreach (Carrito c in Autos)
                    {
                        if (izqder)
                        {
                            if (c.sentido == "izquierda" || c.sentido == "derecha")
                            {
                                c.Carro.Visible = true;
                                if (!rojo)
                                    c.Movimiento();
                                else if ((c.Carro.Left >= 127) & c.sentido == "derecha")
                                    c.Movimiento();
                                else if ((c.Carro.Left <= 290) & c.sentido == "izquierda")
                                    c.Movimiento();
                            }
                        }
                        else
                        {
                            if (c.sentido == "arriba" || c.sentido == "abajo")
                            {
                                c.Carro.Visible = true;
                                if (!verde)
                                    c.Movimiento();
                                else if ((c.Carro.Top >= 120) & c.sentido == "abajo")
                                    c.Movimiento();
                                else if ((c.Carro.Top <= 278) & c.sentido == "arriba")
                                    c.Movimiento();
                            }
                        }
                    }
                }
                catch { }
            }
        }
        public void Semaforo()
        {

            while (true)
            {
                Thread.Sleep(2000);

                if (arrajo)
                {
                    arrajo = false;
                    izqder = true;
                }
                else
                {
                    arrajo = true;
                    izqder = false;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tmps)
            {//cuando el semaforo se pone en automatico cada 6 segundos
                tiempos++;
                if (tiempos == 500)//.......... espera 3 segundos para que el rojo pase a verde
                { button6.BackColor = Color.Orange; button2.BackColor = Color.WhiteSmoke; }
                else if (tiempos == 600)//12 segundos
                {
                    /////////////////////
                    //cuando sea el segundo 12 el verde pasa a rojo y.........
                    button6.BackColor = Color.WhiteSmoke;
                    button1.BackColor = Color.Red;
                    button2.BackColor = Color.WhiteSmoke;
                    rojo = true;
                    //////////////                    
                    button4.BackColor = Color.Green;
                    button3.BackColor = Color.WhiteSmoke;

                    /////////////////////
                }
                else if (tiempos == 649)//12 segundos
                    verde = false;
                else if (tiempos == 1100)
                { button7.BackColor = Color.Orange; button4.BackColor = Color.WhiteSmoke; }
                else if (tiempos == 1200)
                {
                    //cuando sea el segundo 12 el verde pasa a rojo y.........
                    button7.BackColor = Color.WhiteSmoke;
                    button4.BackColor = Color.WhiteSmoke;
                    button3.BackColor = Color.Red;
                    verde = true;

                    //.......... tarda 3 segundos para que el rojo pase a verde
                    button1.BackColor = Color.WhiteSmoke;
                    button2.BackColor = Color.Green;

                    rojo = false;
                    tiempos = 0;
                    /////////////////////
                }
                else if (tiempos == 1249)//12 segundos
                {
                    rojo = false;
                    tiempos = 0;
                }
            }
            try
            {
                foreach (Carrito c in Autos)
                {
                    if (c.Carro.Left + c.Carro.Width < 0)
                        Controls.Remove(c.Carro);
                    else if (c.Carro.Top + c.Carro.Height < 0)
                        Controls.Remove(c.Carro);
                    else if (c.Carro.Top > this.Height)
                        Controls.Remove(c.Carro);
                    else if (c.Carro.Left > this.Width)
                        Controls.Remove(c.Carro);
                    else if (Controls.Contains(c.Carro) != true)
                        Controls.Add(c.Carro);
                }
            }
            catch { }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Carga.Abort();
            Movimiento.Abort();
            Semafo.Abort();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            button2.BackColor = Color.WhiteSmoke;
            rojo = true;//si es true es por que el semaforo esta en rojo///////////////////////////////////////////////////////////////////////////////////////
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Green;
            button1.BackColor = Color.WhiteSmoke;
            rojo = false;//si es false es por que el semaforo esta en verde///////////////////////////////////////////////////////////////////////////////////
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.Red;
            button4.BackColor = Color.WhiteSmoke;
            verde = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.Green;
            button3.BackColor = Color.WhiteSmoke;
            verde = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tmps = true;
        }

    }
    public class Carrito
    {
        public Button Carro;
        public string sentido;
        public double velocidad;
        Point posicion;
        public Carrito(Button C, string S, double Ve, Point Po, string Ma, Color Co, Point Ta)
        {
            Carro = C;
            sentido = S;
            velocidad = Ve;
            posicion = Po;
            Carro.Height = Ta.Y;
            Carro.Width = Ta.X;
            Carro.BackColor = Co;
            Carro.Text = Ma;
            Carro.Top = Po.Y;
            Carro.Left = Po.X;
        }
        public void Movimiento()
        {
            //Thread.Sleep(1000);
            if (sentido == "abajo")
                Carro.Top += (int)velocidad;
            else if (sentido == "derecha")
                Carro.Left += (int)velocidad;
            else if (sentido == "izquierda")
                Carro.Left -= (int)velocidad;
            else if (sentido == "arriba")
                Carro.Top -= (int)velocidad;
        }
    }
}