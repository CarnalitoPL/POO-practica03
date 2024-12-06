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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace POO_practica03.Datos
{
    /// <summary>
    /// Lógica de interacción para frmpaqueteria.xaml
    /// </summary>
    public partial class frmpaqueteria : Window
    {
        public frmpaqueteria()
        {
            InitializeComponent();
            cargarmetodo();
        }
        Clases.ClPaqueteria G;
        public void cargarmetodo()
        {
            string query = "SELECT MAX(ShipperID)+1 AS Folio FROM Shippers";
            using (SqlConnection conn = new SqlConnection(Clases.clGlobales.Globales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand(query, conn);


                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Asignar valores a las propiedades de la clase
                    this.txtID.Text = reader["folio"].ToString();
                }
                reader.Close();
            }

        }
        private void graba()
        {
            try
            {
                Clases.ClPaqueteria B = new Clases.ClPaqueteria(byte.Parse(txtID.Text));
                DataSet ds = new DataSet();
                Clases.conexion c = new Clases.conexion(B.consultar());
                ds = c.consultar();
                G = new Clases.ClPaqueteria(byte.Parse(txtID.Text), txtCompañia.Text, txtTelefono.Text );
                c = new Clases.conexion();
                if (ds.Tables["Tabla"].Rows.Count > 0)
                {
                    MessageBox.Show(c.EJECUTAR(G.modificar(), G.ShipperID, G.CompanyName, G.Phone));
                }

                else
                {

                    MessageBox.Show(c.EJECUTAR(G.grabar(), G.CompanyName, G.Phone));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void buscar()
        {
            string query = "SELECT * FROM shippers WHERE ShipperID = @ShipperID";
            using (SqlConnection conn = new SqlConnection(clGlobales.Globales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ShipperID", this.txtID.Text);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Asignar valores a las propiedades de la clase
                    this.txtCompañia.Text = reader["CompanyName"].ToString();
                    this.txtTelefono.Text = reader["Phone"].ToString();
                    // this.Picture = (byte[])reader["Picture"];
                }
                else MessageBox.Show("No existe la categoria");
                reader.Close();

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
            Clases.ClPaqueteria categ = new Clases.ClPaqueteria();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Seguro de borrar el registro?", "Borrar", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Verificar la respuesta del usuario
            if (result == MessageBoxResult.Yes)
            {
                try
            {
                Clases.ClPaqueteria B = new Clases.ClPaqueteria(byte.Parse(txtID.Text));
                DataSet ds = new DataSet();
                Clases.conexion c = new Clases.conexion(B.consultar());
                ds = c.consultar();
                Clases.ClPaqueteria G = new Clases.ClPaqueteria(int.Parse(txtID.Text));
                c = new Clases.conexion();
                if (ds.Tables["Tabla"].Rows.Count > 0)
                {
                        MessageBox.Show(c.EJECUTAR(G.borrar(),G.ShipperID),"Borrar");
                        //MessageBox.Show(c.EJECUTAR(G.modificar(), G.CompanyName, G.Phone));
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
                MessageBox.Show("Borrad de registro cancelado");
            }
        }

    }
}
