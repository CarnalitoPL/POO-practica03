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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POO_practica03
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MI_Sumar_Click(object sender, RoutedEventArgs e)
        {
            Practicas.wpf_suma x = new Practicas.wpf_suma();
            x.Show();
        }

        private void miCategorias_Click(object sender, RoutedEventArgs e)
        {
           Datos.frmcategorias x = new Datos.frmcategorias();
            x.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Datos.frmregiones x = new Datos.frmregiones();
            x.Show();
        }

        private void mipaqueteria_Click(object sender, RoutedEventArgs e)
        {
            Datos.frmpaqueteria x = new Datos.frmpaqueteria();
            x.Owner = this;
            x.Show();
        }

        private void miProvedores_Click(object sender, RoutedEventArgs e)
        {
            Datos.frmSuppliers x = new Datos.frmSuppliers();
            x.Owner = this;
            x.Show();
        }

        private void miTerritorios_Click(object sender, RoutedEventArgs e)
        {
            Datos.frmterritorios x = new Datos.frmterritorios();
            x.Owner = this;
            x.Show();
        }

        private void miEmpleados_Click(object sender, RoutedEventArgs e)
        {
            Datos.frmEmpleados x = new Datos.frmEmpleados();
            x.Owner = this;
            x.Show();
        }

        private void miEmpleadosTerritorios_Click(object sender, RoutedEventArgs e)
        {
            Movimientos.frmEmpleados_territorios x = new Movimientos.frmEmpleados_territorios();
            x.Owner = this;
            x.Show();
        }

        private void miClientes_Click(object sender, RoutedEventArgs e)
        {
            Datos.frmCustomers x = new Datos.frmCustomers();
            x.Owner = this;
            x.Show();
        }

        private void miClientesDemografia_Click(object sender, RoutedEventArgs e)
        {
            Movimientos.frmClientes_demografias x = new Movimientos.frmClientes_demografias();
            x.Owner = this;
            x.Show();
        }
    }
}
