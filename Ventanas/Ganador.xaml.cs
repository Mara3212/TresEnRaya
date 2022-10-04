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
    /// Lógica de interacción para Ganador.xaml
    /// </summary>
    public partial class Ganador : Window
    {
        String ganador;
        
        public Ganador(String ganador)
        {
            InitializeComponent();
            this.ganador = ganador;
            txtNombreGanador.Text = ganador;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
       
    }
}
