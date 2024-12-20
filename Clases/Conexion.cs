﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POO_practica03.Clases.clGlobales;
using System.Windows;

namespace POO_practica03.Clases
{
    internal class conexion
    {
        public string miconexion;
        private string sentencia1;

        // estas se derivan de la clase System.Data.SqlClient
        private SqlConnection conn;
        private SqlCommand cmd;
        public conexion()
        {


            miconexion = @"Data Source=PRADOROBOT\SQLEXPRESS;Initial Catalog=northwind;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        }

        public conexion(string sentencia)
        {

            sentencia1 = sentencia;
            miconexion = @"Data Source=PRADOROBOT\SQLEXPRESS;Initial Catalog=northwind;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        }
        public string EJECUTAR()
        {

            conn = new SqlConnection(Globales.globales.miconexion);
            conn.Open();
            cmd = new SqlCommand(sentencia1, conn);
            // cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.CommandText = sentencia1;
            cmd.ExecuteNonQuery();
            conn.Close();
            return "Operación exitosa";

        }
        public string EJECUTAR(string sentenciaSQL, params object[] parametros)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Globales.globales.miconexion))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sentenciaSQL, conn))

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        for (int i = 0; i < parametros.Length; i++)
                        {
                            cmd.Parameters.AddWithValue("@param" + (i + 1), parametros[i]);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
                return "Operación exitosa";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        private string mFieldValue;
        internal string FieldValue
        {
            get { return mFieldValue; }
        }
        internal bool Execute(string SQL, int ColumnNumberToRetrive)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(SQL, Globales.globales.miconexion);
            da.Fill(ds, "Table");

            Datos.SearchForm frmSearchForm = new Datos.SearchForm();
            frmSearchForm.mColNumber = ColumnNumberToRetrive;
            frmSearchForm.mDS = ds;
            ds = null;
            bool? resultado = frmSearchForm.ShowDialog();
            if (resultado.HasValue && resultado.Value)
            {
                mFieldValue = frmSearchForm.ReturnValue;
                return true;
            }
            else
            {
                return false;
            }

        }


        public DataSet consultar()
        {
            DataSet datos = new DataSet();
            try
            {

                conn = new SqlConnection(miconexion);
                conn.Open();
                SqlDataAdapter resp = new SqlDataAdapter(sentencia1, conn);
                resp.Fill(datos, "Tabla");
                conn.Close();
                return datos;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error ", ex.Message);
            }
            finally
            {


            }
            return datos;
        }
    }
}
