using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using POO_practica03.Clases;

namespace POO_practica03.Movimientos
{
    /// <summary>
    /// Lógica de interacción para frmClientes_demografias.xaml
    /// </summary>
    public partial class frmClientes_demografias : Window
    {
        public frmClientes_demografias()
        {
            InitializeComponent();
            cargardemografias();
        }
        Clases.conexion c;
        private void cargardemografias()
        {
            DataSet ds = new DataSet();
            Clases.ClDemografias s = new Clases.ClDemografias();
            c = new Clases.conexion(s.buscartodos());
            ds = c.consultar();
            cbdemografias.ItemsSource = ds.Tables[0].DefaultView;
            cbdemografias.DisplayMemberPath = ds.Tables[0].Columns["CustomerDesc"].ToString();
            cbdemografias.SelectedValuePath = ds.Tables[0].Columns["CustomerTypeID"].ToString();
        }
        private void buscarCliente()
        {
            string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
            using (SqlConnection conn = new SqlConnection(clGlobales.Globales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", txtID.Text);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    // Asignar valores a las propiedades de la clase
                    txtID.Text = reader["CustomerID"].ToString();
                    txtempresa.Text = reader["CompanyName"].ToString();
                    txtnombre.Text = reader["ContactName"].ToString();

                }
                else MessageBox.Show("No existe el cliente");
                reader.Close();
            }
        }
        private void btngrabar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnbasura_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnagregar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btneliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnbuscarclientes_Click(object sender, RoutedEventArgs e)
        {
            Clases.ClCustomers emp = new Clases.ClCustomers();
            Clases.conexion con = new Clases.conexion();
            if (con.Execute(emp.buscartodos(), 0) == true)
            {
                if (con.FieldValue != "")
                {
                    txtID.Text = con.FieldValue;
                    buscarCliente();
                }
            }
        }

    }
}
