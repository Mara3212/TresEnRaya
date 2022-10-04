using System.Windows;
using System.Windows.Input;

namespace TresEnRaya.Ventanas
{
    public partial class Empate : Window
    {
        public Empate()
        {
            InitializeComponent();
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
            this.Hide();
        }
    }
}
