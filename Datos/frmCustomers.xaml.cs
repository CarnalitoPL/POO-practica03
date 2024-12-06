using POO_practica03.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace POO_practica03.Datos
{
    /// <summary>
    /// Lógica de interacción para frmCustomers.xaml
    /// </summary>
    public partial class frmCustomers : Window
    {
        public frmCustomers()
        {
            InitializeComponent();
        }
        Clases.conexion c;
        Clases.ClCustomers G;
        public void cargarfolio()
        {
            string query = "SELECT MAX(CustomerID)+1 AS FOLIO FROM Customers;";
            using (SqlConnection conn = new SqlConnection(clGlobales.Globales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    // Asignar valores a las propiedades de la clase
                    txtID.Text = reader["Folio"].ToString();
                }
                reader.Close();
            }
        }
        private void LimpiarFormulario()
        {
            foreach (var control in GridCustomers.Children)
            {
                if (control is TextBox textBox)
                    textBox.Text = string.Empty;
            }
        }
        private void graba()
        {
            try
            {
                Clases.ClCustomers B = new Clases.ClCustomers(txtID.Text);
                DataSet ds = new DataSet();
                Clases.conexion c = new Clases.conexion(B.consultar());
                ds = c.consultar();
                G = new Clases.ClCustomers(txtID.Text, txtCompany.Text, txtContactName.Text, txtContactTitle.Text, txtAddress.Text, txtCity.Text, txtRegion.Text, txtPostalCode.Text, txtCountry.Text, txtPhone.Text, txtFax.Text);
                c = new Clases.conexion();
                if (ds.Tables["Tabla"].Rows.Count > 0)
                {
                    MessageBox.Show(c.EJECUTAR(G.modificar(), G.CustomerID1, G.CompanyName1, G.ContactName1, G.ContactTitle1, G.Address1, G.City1, G.Region1, G.PostalCode1, G.Country1, G.Phone1, G.Fax1));
                    LimpiarFormulario();
                }

                else
                {

                    MessageBox.Show(c.EJECUTAR(G.grabar(), G.CustomerID1, G.CompanyName1, G.ContactName1, G.ContactTitle1, G.Address1, G.City1, G.Region1, G.PostalCode1, G.Country1, G.Phone1, G.Fax1));
                    LimpiarFormulario();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
        private void buscar()
        {
            string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
            using (SqlConnection conn = new SqlConnection(clGlobales.Globales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand(query, conn); //pa hacer crud
                cmd.Parameters.AddWithValue("@CustomerID", txtID.Text);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.Read())
                    {
                        // Asignar valores a las propiedades de la clase
                        txtID.Text = reader["CustomerID"].ToString();
                        txtCompany.Text = reader["CompanyName"].ToString();
                        txtContactName.Text = reader["ContactName"].ToString();
                        txtContactTitle.Text = reader["ContactTitle"].ToString();
                        txtAddress.Text = reader["Address"].ToString();
                        txtCity.Text = reader["City"].ToString();
                        txtRegion.Text = reader["Region"].ToString();
                        txtPostalCode.Text = reader["PostalCode"].ToString();
                        txtCountry.Text = reader["Country"].ToString();
                        txtPhone.Text = reader["Phone"].ToString();
                        txtFax.Text = reader["Fax"].ToString();
                    }
                    else MessageBox.Show("No existe");
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }
        private void btngrabar_Click(object sender, RoutedEventArgs e)
        {
            {
                graba();
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Clases.ClCustomers categ = new Clases.ClCustomers();
            Clases.conexion con = new Clases.conexion();
            if (con.Execute(categ.buscartodos(), 0) == true)
            {
                if (con.FieldValue != "")
                {
                    txtID.Text = con.FieldValue;
                    buscar();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Desea borrar el registro?", "Borrar", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Verificar la respuesta del usuario

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Clases.ClCustomers B = new Clases.ClCustomers(txtID.Text);
                    DataSet ds = new DataSet();
                    Clases.conexion c = new Clases.conexion(B.consultar());
                    ds = c.consultar();
                    G = new Clases.ClCustomers(txtID.Text);
                    c = new Clases.conexion();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        MessageBox.Show(c.EJECUTAR(G.borrar(), B.CustomerID1), "BORRAR");
                        LimpiarFormulario();
                    }

                    else
                    {
                        MessageBox.Show("No se encontro el registro");
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
    }
}
