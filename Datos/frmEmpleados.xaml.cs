using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using POO_practica03.Clases;

namespace POO_practica03.Datos
{
    /// <summary>
    /// Lógica de interacción para frmEmpleados.xaml
    /// </summary>
    public partial class frmEmpleados : Window
    {
        public frmEmpleados()
        {
            InitializeComponent();
            Cargarfolio();
            CargarReporte();
        }
        Clases.conexion c;
        Clases.clempleados G;

        private void btnBasura_Click(object sender, RoutedEventArgs e)
        {
            //Mostrar el cuadro de diálogo de confirmación en WPF
            MessageBoxResult result = MessageBox.Show("¿Seguro de borrar el registro?", "Borrar", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            // Verificar la respuesta del usuario

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Clases.clempleados B = new Clases.clempleados(int.Parse(txtID.Text));
                    DataSet ds = new DataSet();
                    Clases.conexion c = new Clases.conexion(B.consultari());
                    ds = c.consultar();
                    G = new Clases.clempleados(int.Parse(txtID.Text));
                    c = new Clases.conexion();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        MessageBox.Show(c.EJECUTAR(G.borrar(), G.EmployeeID), "BORRAR");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el registro");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
            else
            {
                // El usuario seleccionó "No".
                MessageBox.Show("Borrado de registro cancelado");
            }
        }

        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {
            Clases.clempleados emp = new Clases.clempleados();
            Clases.conexion con = new Clases.conexion();
            if (con.Execute(emp.buscarTodos(), 0) == true)
            {
                if (con.FieldValue != "")
                {
                    txtID.Text = con.FieldValue;
                    buscar();
                }
            }
        }

        private void buscar()
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
                    txtApellido.Text = reader["LastName"].ToString();
                    txtNombre.Text = reader["FirstName"].ToString();
                    txtTiutlo.Text = reader["Title"].ToString();
                    txtTituloCortesia.Text = reader["TitleOfCourtesy"].ToString();
                    dpFechaNacimiento.SelectedDate = DateTime.Parse(reader["BirthDate"].ToString());
                    dpFechaContratacion.SelectedDate = DateTime.Parse(reader["HireDate"].ToString());
                    txtDirección.Text = reader["Address"].ToString();
                    txtCiudad.Text = reader["City"].ToString();
                    txtRegion.Text = reader["Region"].ToString();
                    txtCP.Text = reader["PostalCode"].ToString();
                    txtPais.Text = reader["Country"].ToString();
                    txtNumCasa.Text = reader["HomePhone"].ToString();
                    txtExtension.Text = reader["Extension"].ToString();
                    txtNotas.Text = reader["Notes"].ToString();
                    cbReporte.Text = reader["ReportsTo"].ToString();
                    txtDireccionFoto.Text = reader["PhotoPath"].ToString();
                    if (reader["Photo"] != DBNull.Value)
                    {
                        byte[] imageData = (byte[])reader["Photo"];
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.StreamSource = ms;
                            bitmap.CacheOption = BitmapCacheOption.OnLoad;
                            bitmap.EndInit();
                            imFoto.Source = bitmap;
                        }
                    }
                }
                else MessageBox.Show("No existe el empleado");
                reader.Close();
            }
        }

        private void btngrabar_Click(object sender, RoutedEventArgs e)
        {
            int cvreporte = 0;
            if (cbReporte.SelectedValue != null)
            {
                cvreporte = int.Parse(cbReporte.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Seleccione a alguien para hacer el reporte");
                return;
            }
            try
            {
                Clases.clempleados B = new Clases.clempleados(int.Parse(txtID.Text));
                DataSet ds = new DataSet();
                Clases.conexion c = new Clases.conexion(B.consultari());
                ds = c.consultar();
                G = new Clases.clempleados();
                G.EmployeeID = int.Parse(txtID.Text);
                G.LastName = txtApellido.Text;
                G.FirstName = txtNombre.Text;
                G.Title = txtTiutlo.Text;
                G.TitleOfCourtesy = txtTituloCortesia.Text;
                G.BirthDate = dpFechaNacimiento.SelectedDate.Value;
                G.HireDate = dpFechaContratacion.SelectedDate.Value;
                G.Address = txtDirección.Text;
                G.City = txtCiudad.Text;
                G.Region = txtRegion.Text;
                G.PostalCode = txtCP.Text;
                G.Country = txtPais.Text;
                G.HomePhone = txtNumCasa.Text;
                G.Extension = txtExtension.Text;
                G.Photo = photoBytes;
                G.Notes = txtNotas.Text;
                G.ReportsTo = cvreporte;
                G.PhotoPath = txtDireccionFoto.Text;

                c = new Clases.conexion();
                if (ds.Tables["Tabla"].Rows.Count > 0)
                {
                    MessageBox.Show(c.EJECUTAR(G.modificar(), G.EmployeeID, G.LastName, G.FirstName, G.Title, G.TitleOfCourtesy, G.BirthDate, G.HireDate, G.Address, G.City, G.Region, G.PostalCode, G.Country, G.HomePhone, G.Extension, G.Photo, G.Notes, G.ReportsTo, G.PhotoPath));
                }
                else
                {
                    MessageBox.Show(c.EJECUTAR(G.grabar(), G.LastName, G.FirstName, G.Title, G.TitleOfCourtesy, G.BirthDate, G.HireDate, G.Address, G.City, G.Region, G.PostalCode, G.Country, G.HomePhone, G.Extension, G.Photo, G.Notes, G.ReportsTo, G.PhotoPath));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void Cargarfolio()
        {
            string query = "SELECT MAX(EmployeeID)+1 AS FOLIO FROM Employees";
            using (SqlConnection conn = new SqlConnection(clGlobales.Globales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    // Asignar valores a las propiedades de la clase
                    txtID.Text = reader["FOLIO"].ToString();
                }
                reader.Close();
            }
        }
        private void CargarReporte()
        {
            DataSet ds = new DataSet();
            Clases.clempleados s = new Clases.clempleados();
            c = new Clases.conexion(s.buscarTodos());
            ds = c.consultar();
            cbReporte.ItemsSource = ds.Tables[0].DefaultView;
            cbReporte.DisplayMemberPath = ds.Tables[0].Columns["nombre"].ToString();
            cbReporte.SelectedValuePath = ds.Tables[0].Columns["EmployeeID"].ToString();

        }
        private byte[] photoBytes;
        private void btnSeleccionarFoto_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Image Files|.jpg;.jpeg;.png;.bmp";
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string selectedFileName = dlg.FileName;
                txtDireccionFoto.Text = selectedFileName;
                photoBytes = File.ReadAllBytes(selectedFileName); // Convertir imagen a arreglo de bytes
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                imFoto.Source = bitmap;
            }
        }
    }
}
    

