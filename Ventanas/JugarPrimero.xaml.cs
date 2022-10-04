using System;
using System.Collections.Generic;
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

namespace TresEnRaya.Ventanas
{
    /// <summary>
    /// Lógica de interacción para JugarPrimero.xaml
    /// </summary>
    public partial class JugarPrimero : Window
    {
        private String jugadorX, jugadorO;
        private int turno1;
        public JugarPrimero(String jugadorX, String jugadorO)
        {           
            InitializeComponent();
            btnJugadorX.Content = jugadorX;
            btnJugadorO.Content = jugadorO;
            this.jugadorO = jugadorO;
            this.jugadorX = jugadorX;
        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnJugadorUno_Click(object sender, RoutedEventArgs e)
        {
            turno1 = 1;
            CuadroDeJuego op = new CuadroDeJuego(turno1,jugadorX,jugadorO);           
            this.Hide();
        }

        private void btnJugadorDos_Click(object sender, RoutedEventArgs e)
        {
            turno1 = 2;
            CuadroDeJuego op = new CuadroDeJuego(turno1, jugadorX, jugadorO);           
            this.Hide();
        }
        public int getTurno()
        {
            return turno1;
        }
    }
}
