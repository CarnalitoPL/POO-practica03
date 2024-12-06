using POO_practica03.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Lógica de interacción para frmcategorias.xaml
    /// </summary>
    public partial class frmcategorias : Window
    {

        public frmcategorias()
        {
            InitializeComponent();
        }
        public void buscar()
        {
            string query = "SELECT * FROM categoriEs WHERE CategoryId = @CategoryId";
            using (SqlConnection conn = new SqlConnection(clGlobales.Globales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryId", this.txtID.Text);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Asignar valores a las propiedades de la clase
                    this.txtNombre.Text = reader["CategoryName"].ToString();
                    this.txtDescipcion.Text = reader["Description"].ToString();
                    // this.Picture = (byte[])reader["Picture"];
                }
                else MessageBox.Show("No existe la categoria");
                reader.Close();

            }
        }
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
                Clases.clCategorias categ = new Clases.clCategorias();
                Clases.conexion con = new Clases.conexion();
                if (con.Execute(categ.buscartodos(), 0) ==true)
                {
                    if (con.FieldValue != "")
                    {
                        txtID.Text = con.FieldValue;
                        buscar();
                    }
                }
        }

        private void btngrabar_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM categoriEs WHERE CategoryId = @CategoryId";
            string querygrabar = "INSERT INTO CATEGORIES (categoryname, description) values (@categoryname, @description)";
            string querymodificar = "UPDATE CATEGORIES SET categoryname = @categoryname, description = @description WHERE Categoryid=@Categoryid";
            using (SqlConnection conn = new SqlConnection(clGlobales.Globales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryId", this.txtID.Text);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //modificar
                    SqlCommand cmdmodificar = new SqlCommand(querymodificar, conn);
                    cmdmodificar.Parameters.AddWithValue("@categoryid", this.txtID.Text);
                    cmdmodificar.Parameters.AddWithValue("@categoryname", this.txtNombre.Text);
                    cmdmodificar.Parameters.AddWithValue("@description", this.txtDescipcion.Text);

                    reader.Close();
                    cmdmodificar.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmdgrabar = new SqlCommand(querygrabar, conn);
                    cmdgrabar.Parameters.AddWithValue("@categoryname", this.txtNombre.Text);
                    cmdgrabar.Parameters.AddWithValue("@description", this.txtDescipcion.Text);

                    reader.Close();
                    cmdgrabar.ExecuteNonQuery();
                    //grabar

                }
                reader.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Seguro de borrar el registro?", "Borrar", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Verificar la respuesta del usuario
            if (result == MessageBoxResult.Yes)
            {
                string queryborrar = "delete from categories WHERE CategoryId = @CategoryId";
                using (SqlConnection conn = new SqlConnection(clGlobales.Globales.globales.miconexion))
                {

                    SqlCommand cmdborrar = new SqlCommand(queryborrar, conn);
                    cmdborrar.Parameters.AddWithValue("@categoryId", txtID.Text);
                    conn.Open();
                    // reader.Close();
                    cmdborrar.ExecuteNonQuery();
                    MessageBox.Show("Registro Borrado exitosamente!");
                    txtDescipcion.Clear();
                    txtNombre.Clear();
                    txtNombre.Focus();
                }
            }
            else
            {
                // El usuario seleccionó "No".
                MessageBox.Show("Borrad de registro cancelado");
            }
        }
    }
    }

