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
    /// Lógica de interacción para frmterritorios.xaml
    /// </summary>
    public partial class frmterritorios : Window
    {
        public frmterritorios()
        {
            InitializeComponent();
            cargarregion();
            cargarfolio();
        }
        Clases.conexion c;
        Clases.ClTerritorios G;
        public void cargarfolio()
        {
            string query = "SELECT MAX(TerritoryID)+1 AS FOLIO FROM Territories;";
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
        private void cargarregion()
        {
            DataSet ds = new DataSet();
            Clases.ClRegiones s = new Clases.ClRegiones();
            c = new Clases.conexion(s.buscartodos());
            ds = c.consultar();
            //
            CBregion.ItemsSource = ds.Tables[0].DefaultView;
            //
            CBregion.DisplayMemberPath = ds.Tables[0].Columns["regionDescription"].ToString();
            //
            CBregion.SelectedValuePath = ds.Tables[0].Columns["regionID"].ToString();

        }

        private void buscar()
        {
            string query = "SELECT * FROM bta_territories_region WHERE TerritoryID = @TerritoryID";
            using (SqlConnection conn = new SqlConnection(clGlobales.Globales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand(query, conn); //pa hacer crud
                cmd.Parameters.AddWithValue("@TerritoryID", txtID.Text);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.Read())
                    {
                        // Asignar valores a las propiedades de la clase
                        txtID.Text = reader["TerritoryID"].ToString();
                        txtDescripcion.Text = reader["TerritoryDescription"].ToString();
                        CBregion.Text = reader["RegionDescription"].ToString();
                    }
                    else MessageBox.Show("No existe el proveedor");
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }
        private void graba()
        {
            try 
            {
                int regionid= int.Parse(CBregion.SelectedValue.ToString());
                Clases.ClTerritorios B = new Clases.ClTerritorios(txtID.Text);
                DataSet ds = new DataSet();
                Clases.conexion c = new Clases.conexion(B.consultar());
                ds = c.consultar();
                G = new Clases.ClTerritorios();
                G = new Clases.ClTerritorios(txtID.Text,txtDescripcion.Text, regionid );
                c = new Clases.conexion();
                if (ds.Tables["Tabla"].Rows.Count > 0)
                {
                    MessageBox.Show(c.EJECUTAR(G.modificar(), G.TerritoryID1, G.TerritoryDescription1, G.RegionID1));
                }
                else
                {

                    MessageBox.Show(c.EJECUTAR(G.grabar(), G.TerritoryID1, G.TerritoryDescription1, G.RegionID1));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
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
            Clases.ClTerritorios categ = new Clases.ClTerritorios();
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
                    Clases.ClTerritorios B = new Clases.ClTerritorios(txtID.Text);
                    DataSet ds = new DataSet();
                    Clases.conexion c = new Clases.conexion(B.consultar());
                    ds = c.consultar();
                    G = new Clases.ClTerritorios(txtID.Text);
                    c = new Clases.conexion();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        MessageBox.Show(c.EJECUTAR(G.borrar(), B.TerritoryID1), "BORRAR");
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
