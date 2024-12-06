using POO_practica03.Clases;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para frmregiones.xaml
    /// </summary>
    public partial class frmregiones : Window
    {
        public frmregiones()
        {
            InitializeComponent();
        }
        private void cargarfolio()
        {
            //consulta sql
            string sql = "select max(regionID)+1 as folio from region";
            using (SqlConnection conn = new SqlConnection(Clases.clGlobales.Globales.globales.miconexion)) 
            { 
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtID.Text = rdr.GetString(0);
                }
                rdr.Close();
                //cmd.ExecuteNonQuery(); solo para grabar, modificar y eliminar

            }

        }
        private void buscar()
        {
            //string query = "SELECT * FROM Region WHERE RegionId = @RegionId";

            using (SqlConnection conn = new SqlConnection(clGlobales.Globales.globales.miconexion))
            {
                SqlCommand cmd = new SqlCommand("SP_buscar_region", conn);
                cmd.Parameters.AddWithValue("@RegionId", this.txtID.Text);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Asignar valores a las propiedades de la clase
                    this.txtID.Text = reader["RegionID"].ToString();
                    this.txtDescription.Text = reader["RegionDescription"].ToString();
                    // this.Picture = (byte[])reader["Picture"];
                }
                else MessageBox.Show("No existe la categoria");
                reader.Close();
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Clases.ClRegiones categ = new Clases.ClRegiones();
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
         //   string query = "INSERT INTO REGION (REGIONID,REGIONDESCRIPTION) values (@regionid, @regiondescription)";
           // string querybuscar = "select * from region where regionID = @regionid";
            //using (SqlConnection conn = new SqlConnection(Clases.clGlobales.Globales.globales.miconexion));
            //{
              //  SqlCommand cmd = new SqlCommand(querybuscar, conn);
              //  cmd.Parameters.AddWithValue("@regionid", txtID.Text);
              //  con.Open();
               // SqlDataReader r = cmd.ExecuteReader();
               // if (r.Read())
               // {
                    //modiifcr
               // }
               // else
               // {
               //     SqlCommand cmdgrabar = new SqlCommand(query, conn);
              //  }
           // }
       }
    }
}
