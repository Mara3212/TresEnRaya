using System;
using System.Windows;
using System.Windows.Input;
using TresEnRaya.Ventanas;

namespace TresEnRaya
{
    public partial class MainWindow : Window
    {
        private String jugadorO;
        private String jugadorX;
        public MainWindow()
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

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            jugadorO = cajaTxtUsuarioO.Text;
            jugadorX = cajaTxtUsuarioX.Text;
            if (jugadorO != "" && jugadorX != "")
            {
                CuadroDeJuego jugar = new CuadroDeJuego(1, jugadorX, jugadorO);
                jugar.Show();
                this.Hide();
            }
        }
    }
}
