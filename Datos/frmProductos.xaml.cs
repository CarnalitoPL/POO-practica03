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
    /// Lógica de interacción para frmProductos.xaml
    /// </summary>
    public partial class frmProductos : Window
    {
        public frmProductos()
        {
            InitializeComponent();
            cargarsupplier();
            cargarcategories();
            cargarfolio();
        }
        Clases.conexion c;
        Clases.ClProductos G;
        public void cargarfolio()
        {
            string query = "SELECT MAX(ProductID)+1 AS FOLIO FROM Products;";
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
        private void cargarsupplier()
        {
            DataSet ds = new DataSet();
            Clases.clSuppliers s = new Clases.clSuppliers();
            c = new Clases.conexion(s.buscartodos());
            ds = c.consultar();
            //
            CBSupllier.ItemsSource = ds.Tables[0].DefaultView;
            //
            CBSupllier.DisplayMemberPath = ds.Tables[0].Columns["CompanyName"].ToString();
            //
            CBSupllier.SelectedValuePath = ds.Tables[0].Columns["SupplierID"].ToString();

        }
        private void cargarcategories()
        {
            DataSet ds = new DataSet();
            Clases.clCategorias s = new Clases.clCategorias();
            c = new Clases.conexion(s.buscartodos());
            ds = c.consultar();
            //
            CBSupllier.ItemsSource = ds.Tables[0].DefaultView;
            //
            CBSupllier.DisplayMemberPath = ds.Tables[0].Columns["CategoryName"].ToString();
            //
            CBSupllier.SelectedValuePath = ds.Tables[0].Columns["CategoryID"].ToString();

        }
        private void buscar()
        {
            string query = "SELECT * FROM vta_productos_suppliers_categorias WHERE ProductID = @ProductID";
            using (SqlConnection conn = new SqlConnection(clGlobales.Globales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand(query, conn); //pa hacer crud
                cmd.Parameters.AddWithValue("@ProductID", txtID.Text);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.Read())
                    {
                        // Asignar valores a las propiedades de la clase
                        txtID.Text = reader["TerritoryID"].ToString();
                        txtName.Text = reader["TerritoryDescription"].ToString();
                        CBSupllier.Text = reader["RegionDescription"].ToString();
                        CBCategory.Text = reader["RegionDescription"].ToString();
                        txtQuantity.Text = reader["TerritoryID"].ToString();
                        txtUnit.Text = reader["TerritoryDescription"].ToString();
                        txtUnitsinStock.Text = reader["TerritoryID"].ToString();
                        txtUnitsOnOrder.Text = reader["TerritoryDescription"].ToString();
                        txtReorder.Text = reader["TerritoryID"].ToString();
                        CHBDiscontinued.IsChecked = Convert.ToBoolean(reader["Discontinued"]);
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
                int supplierid = int.Parse(CBSupllier.SelectedValue.ToString());
                int categoryid = int.Parse(CBCategory.SelectedValue.ToString());
                bool discontinued = CHBDiscontinued.IsChecked ?? false;
                Clases.ClProductos B = new Clases.ClProductos(byte.Parse(txtID.Text));
                DataSet ds = new DataSet();
                Clases.conexion c = new Clases.conexion(B.consultar());
                ds = c.consultar();
                G = new Clases.ClProductos();
                G = new Clases.ClProductos(int.Parse(txtID.Text), txtName.Text, supplierid, categoryid, txtQuantity.Text, txtUnit.Text, int.Parse(txtUnitsinStock.Text), int.Parse(txtUnitsOnOrder.Text), int.Parse(txtReorder.Text), discontinued);
                c = new Clases.conexion();
                if (ds.Tables["Tabla"].Rows.Count > 0)
                {
                    MessageBox.Show(c.EJECUTAR(G.modificar(), G.ProductID1, G.ProductName1, G.SupplierID1, G.CategoryID1, G.QuantityPerUnit1, G.UnitPrice1, G.UnitsInStock1, G.UnitsOnOrder1, G.ReorderLevel1, G.Discontinued1));
                }
                else
                {

                    MessageBox.Show(c.EJECUTAR(G.grabar(), G.ProductName1, G.SupplierID1, G.CategoryID1, G.QuantityPerUnit1, G.UnitPrice1, G.UnitsInStock1, G.UnitsOnOrder1, G.ReorderLevel1, G.Discontinued1));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
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
                    Clases.ClProductos B = new Clases.ClProductos(byte.Parse(txtID.Text));
                    DataSet ds = new DataSet();
                    Clases.conexion c = new Clases.conexion(B.consultar());
                    ds = c.consultar();
                    G = new Clases.ClProductos(byte.Parse(txtID.Text));
                    c = new Clases.conexion();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        MessageBox.Show(c.EJECUTAR(G.borrar(), B.ProductID1), "BORRAR");
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

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Clases.ClProductos categ = new Clases.ClProductos();
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

        private void btngrabar_Click(object sender, RoutedEventArgs e)
        {
            {
                graba();
            }
        }
    }
}
