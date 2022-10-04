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
    /// Lógica de interacción para TablaPuntuaciones.xaml
    /// </summary>
    public partial class TablaPuntuaciones : Window
    {
        private String jugadorX, jugadorO;
        private int _jugX, _jugO, _empate;
        public TablaPuntuaciones(String jugadorX, String jugadorO, int jugX, int jugO, int empate)
        {
            InitializeComponent();
            this.jugadorX = jugadorX;
            this.jugadorO = jugadorO;
            this._jugX = jugX;
            this._jugO = jugO;
            this._empate = empate;
            asignarNombres();
            Employee employee = new Employee();
            employee.jugadorX = _jugX;
            employee.jugadorO = _jugO;
            employee.empate = _empate;

            dataXaml.Items.Add(employee);
        }
        private void asignarNombres()
        {
            jugadorXTabla.Header = " "+jugadorX.ToString();
            jugadorOTabla.Header = " "+jugadorO.ToString();
        }
        public class Employee
        {
            public int jugadorX { get; set; }
            public int jugadorO { get; set; }
            public int empate { get; set; }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnJugarDeNuevo_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
