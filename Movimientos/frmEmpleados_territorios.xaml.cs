using POO_practica03.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace POO_practica03.Movimientos
{
    /// <summary>
    /// Lógica de interacción para frmEmpleados_territorios.xaml
    /// </summary>
    public partial class frmEmpleados_territorios : Window
    {
        public frmEmpleados_territorios()
        {
            InitializeComponent();
            cargarTerritorio();
        }
        Clases.conexion c;
        public ObservableCollection<EmployeeTerritory> EmployeeTerritories { get; set; }
        private void CargarDatos()
        {
            EmployeeTerritories = new ObservableCollection<EmployeeTerritory>();
            DataContext = this;

            //string connectionString = "tu_cadena_de_conexion"; // Reemplaza con tu cadena de conexión
            string query = @"
     SELECT dbo.EmployeeTerritories.TerritoryID, 
            dbo.EmployeeTerritories.EmployeeID, 
            dbo.Territories.TerritoryDescription, 
            dbo.Territories.RegionID, 
            dbo.Region.RegionDescription
     FROM dbo.EmployeeTerritories
     INNER JOIN dbo.Territories ON dbo.EmployeeTerritories.TerritoryID = dbo.Territories.TerritoryID
     INNER JOIN dbo.Region ON dbo.Territories.RegionID = dbo.Region.RegionID where dbo.EmployeeTerritories.EmployeeID = @EmployeeID ";

            using (SqlConnection connection = new SqlConnection(clGlobales.Globales.globales.miconexion))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@EmployeeID", txtID.Text);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EmployeeTerritories.Add(new EmployeeTerritory
                    {
                        TerritoryID = Convert.ToInt32(reader["TerritoryID"]),
                        EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                        TerritoryDescription = reader["TerritoryDescription"].ToString(),
                        RegionID = Convert.ToInt32(reader["RegionID"]),
                        RegionDescription = reader["RegionDescription"].ToString()
                    });
                }

                reader.Close();
            }
        }
        private void buscarEmpleado()
        {
            string query = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";
            using (SqlConnection conn = new SqlConnection(clGlobales.Globales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", txtID.Text);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    // Asignar valores a las propiedades de la clase
                    txtID.Text = reader["EmployeeID"].ToString();
                    txtNombre.Text = reader["FirstName"].ToString();
                    txtTitulo.Text = reader["Title"].ToString();

                }
                else MessageBox.Show("No existe el empleado");
                reader.Close();
            }
        }
        private void cargarTerritorio()
        {
            DataSet ds = new DataSet();
            Clases.ClTerritorios s = new Clases.ClTerritorios();
            c = new Clases.conexion(s.buscartodos());
            ds = c.consultar();
            //
            CBTerritorio.ItemsSource = ds.Tables[0].DefaultView;
            //
            CBTerritorio.DisplayMemberPath = ds.Tables[0].Columns["TerritoryDescription"].ToString();
            //
            CBTerritorio.SelectedValuePath = ds.Tables[0].Columns["TerritoryID"].ToString();

        }
        private void btngrabar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBasura_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBuscarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Clases.clempleados emp = new Clases.clempleados();
            Clases.conexion con = new Clases.conexion();
            if (con.Execute(emp.buscarTodos2(), 0) == true)
            {
                if (con.FieldValue != "")
                {
                    txtID.Text = con.FieldValue;
                    buscarEmpleado();
                    CargarDatos();
                }
            }
        }
    }
}
