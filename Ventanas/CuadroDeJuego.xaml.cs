using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Brushes = System.Windows.Media.Brushes;
using Image = System.Windows.Controls.Image;

namespace TresEnRaya.Ventanas
{
    /// <summary>
    /// Lógica de interacción para CuadroDeJuego.xaml
    /// </summary>
    public partial class CuadroDeJuego : Window
    {
        private bool[,] casilla = new bool[3, 3];
        private int[,] matriz = new int[3, 3];
        private int turno;
        private int empates = 0;
        private int contGanadorX = 0;
        private int contGanadorO = 0;
        private String jugadorX, jugadorO;

        public CuadroDeJuego(int numeroTurno, String jugadorX,String jugadorO)
        {
            InitializeComponent();
            llenarCasillas();
            turno = numeroTurno;   
            this.jugadorX = jugadorX;
            this.jugadorO = jugadorO;
        }
        public CuadroDeJuego() {
            
        }
        public void setTurno(int num) {
            turno = num;
        }
        private void llenarMatriz()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matriz[i, j] = 0;
                }
            }
        }
        private void llenarCasillas()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    casilla[i, j] = true;
                }
            }
        }
        private void ponerImagenX(Button boton)
        {
            Image imagen = new Image();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new System.Uri("pack://application:,,,/Imagenes/este es rojo.png");
            bi.EndInit();

            imagen.Source = bi;
            ImageBrush b2 = new ImageBrush();
            b2.ImageSource = bi;

            boton.Background = b2;
        }
        private void ponerImagenO(Button boton)
        {
            Image imagen = new Image();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new System.Uri("pack://application:,,,/Imagenes/mejorado.png");
            bi.EndInit();
            imagen.Source = bi;

            ImageBrush b2 = new ImageBrush();
            b2.ImageSource = bi;
            boton.Background = b2;

        }
        private void mouse_MouseHover(Button boton, object sender, MouseEventArgs e)
        {
            boton.Background = Brushes.Black;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void BtnTabla_Click(object sender, RoutedEventArgs e)
        {
            TablaPuntuaciones op = new TablaPuntuaciones(jugadorX,jugadorO,contGanadorX,contGanadorO,empates);
            op.Owner = this;
            op.ShowDialog();
        }
        private void BtnReiniciar_Click(object sender, RoutedEventArgs e)
        {
            contGanadorO = 0; contGanadorX = 0; empates = 0;
            reiniciarJuego();
        }

        private void btnIzquierdaArriba_Click(object sender, RoutedEventArgs e)
        {
            if (casilla[0, 0] == true)
            {
                if (turno == 1)
                {
                    ponerImagenX(btnIzquierdaArriba);
                    matriz[0, 0] = 1;
                    turno = 2;
                }
                else if (turno == 2)
                {
                    ponerImagenO(btnIzquierdaArriba);
                    matriz[0, 0] = 2;
                    turno = 1;
                }
            }
            casilla[0, 0] = false;
            verificar();
        }

        private void btnCentroArriba_Click(object sender, RoutedEventArgs e)
        {
            if (casilla[0, 1] == true)
            {
                if (turno == 1)
                {
                    ponerImagenX(btnCentroArriba);
                    matriz[0, 1] = 1;
                    turno = 2;
                }
                else if (turno == 2)
                {
                    ponerImagenO(btnCentroArriba);
                    matriz[0, 1] = 2;
                    turno = 1;
                }
            }
            casilla[0, 1] = false;
            verificar();
        }

        private void btnDerechaArriba_Click(object sender, RoutedEventArgs e)
        {
            if (casilla[0, 2] == true)
            {
                if (turno == 1)
                {
                    ponerImagenX(btnDerechaArriba);
                    matriz[0, 2] = 1;
                    turno = 2;
                }
                else if (turno == 2)
                {
                    ponerImagenO(btnDerechaArriba);
                    matriz[0, 2] = 2;
                    turno = 1;
                }
            }
            casilla[0, 2] = false;
            verificar();
        }

        private void btnIzquierdaCentro_Click(object sender, RoutedEventArgs e)
        {
            if (casilla[1, 0] == true)
            {
                if (turno == 1)
                {
                    ponerImagenX(btnIzquierdaCentro);
                    matriz[1, 0] = 1;
                    turno = 2;
                }
                else if (turno == 2)
                {
                    ponerImagenO(btnIzquierdaCentro);
                    matriz[1, 0] = 2;
                    turno = 1;
                }
            }
            casilla[1, 0] = false;
            verificar();
        }

        private void btnCentro_Click(object sender, RoutedEventArgs e)
        {
            if (casilla[1, 1] == true)
            {
                if (turno == 1)
                {
                    ponerImagenX(btnCentro);
                    matriz[1, 1] = 1;
                    turno = 2;
                }
                else if (turno == 2)
                {
                    ponerImagenO(btnCentro);
                    matriz[1, 1] = 2;
                    turno = 1;
                }
            }
            casilla[1, 1] = false;
            verificar();
        }

        private void btnDerechaCentro_Click(object sender, RoutedEventArgs e)
        {
            if (casilla[1, 2] == true)
            {
                if (turno == 1)
                {
                    ponerImagenX(btnDerechaCentro);
                    matriz[1, 2] = 1;
                    turno = 2;
                }
                else if (turno == 2)
                {
                    ponerImagenO(btnDerechaCentro);
                    matriz[1, 2] = 2;
                    turno = 1;
                }
            }
            casilla[1, 2] = false;
            verificar();
        }

        private void btnIzquierdaAbajo_Click(object sender, RoutedEventArgs e)
        {
            if (casilla[2, 0] == true)
            {
                if (turno == 1)
                {
                    ponerImagenX(btnIzquierdaAbajo);
                    matriz[2, 0] = 1;
                    turno = 2;
                }
                else if (turno == 2)
                {
                    ponerImagenO(btnIzquierdaAbajo);
                    matriz[2, 0] = 2;
                    turno = 1;
                }
            }
            casilla[2, 0] = false;
            verificar();
        }

        private void btnCentroAbajo_Click(object sender, RoutedEventArgs e)
        {
            if (casilla[2, 1] == true)
            {
                if (turno == 1)
                {
                    ponerImagenX(btnCentroAbajo);
                    matriz[2, 1] = 1;
                    turno = 2;
                }
                else if (turno == 2)
                {
                    ponerImagenO(btnCentroAbajo);
                    matriz[2, 1] = 2;
                    turno = 1;
                }
            }
            casilla[2, 1] = false;
            verificar();
        }

        private void btnDerechaAbajo_Click(object sender, RoutedEventArgs e)
        {
            if (casilla[2, 2] == true)
            {
                if (turno == 1)
                {
                    ponerImagenX(btnDerechaAbajo);
                    matriz[2, 2] = 1;
                    turno = 2;
                }
                else if (turno == 2)
                {
                    ponerImagenO(btnDerechaAbajo);
                    matriz[2, 2] = 2;
                    turno = 1;
                }
            }
            casilla[2, 2] = false;
            verificar();
        }

        private void verificar()
        {
            bool ganadorX = false;
            bool ganadorO = false;
            int contadorEmpate = 0;

            ganadorX = ganador(1);
            ganadorO = ganador(2);

            if (ganadorX == true)
            {
                Ganador op = new Ganador(jugadorX);
                op.Owner = this;
                op.ShowDialog();
                contGanadorX++;
                reiniciarJuego();
                
            }
            else if (ganadorO == true)
            {
                Ganador op = new Ganador(jugadorO);
                op.Owner = this;
                op.ShowDialog();
                contGanadorO++;
                reiniciarJuego();
                
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (matriz[i, j] != 0)
                        {
                            contadorEmpate++;
                        }
                    }
                }
                if (contadorEmpate == 9)
                {
                    empates++;
                    Empate op = new Empate();
                    op.Owner = this;
                    op.ShowDialog();
                    reiniciarJuego();
                }
                else
                {
                    contadorEmpate = 0;
                }
            }
        }
        private bool ganador(int num)
        {
            bool ganador = false;
            if (matriz[0, 0] == num && matriz[0, 1] == num && matriz[0, 2] == num)
            {
                ganador = true;
            }
            else if (matriz[1, 0] == num && matriz[1, 1] == num && matriz[1, 2] == num)
            {
                ganador = true;
            }
            else if (matriz[2, 0] == num && matriz[2, 1] == num && matriz[2, 2] == num)
            {
                ganador = true;
            }
            else if (matriz[0, 0] == num && matriz[1, 1] == num && matriz[2, 2] == num)
            {
                ganador = true;
            }
            else if (matriz[0, 2] == num && matriz[1, 1] == num && matriz[2, 0] == num)
            {
                ganador = true;
            }
            else if (matriz[0, 1] == num && matriz[1, 1] == num && matriz[2, 1] == num)
            {
                ganador = true;
            }
            else if (matriz[0, 0] == num && matriz[1, 0] == num && matriz[2, 0] == num)
            {
                ganador = true;
            }
            else if (matriz[0, 2] == num && matriz[1, 2] == num && matriz[2, 2] == num)
            {
                ganador = true;
            }

            return ganador;
        }
        private void reiniciarJuego() {
            llenarCasillas();
            llenarMatriz();

            btnCentro.Background = Brushes.White;
            btnIzquierdaArriba.Background = Brushes.White;
            btnIzquierdaAbajo.Background = Brushes.White;
            btnIzquierdaCentro.Background = Brushes.White;
            btnCentroArriba.Background = Brushes.White;
            btnCentroAbajo.Background = Brushes.White;
            btnDerechaArriba.Background = Brushes.White;
            btnDerechaCentro.Background = Brushes.White;
            btnDerechaAbajo.Background = Brushes.White;

            jugarPrimero();
        }
        private void jugarPrimero()
        {
            JugarPrimero jugar = new JugarPrimero(jugadorX,jugadorO);
            jugar.Owner = this;
            jugar.ShowDialog();  
            turno = jugar.getTurno();
        }
    }
}
