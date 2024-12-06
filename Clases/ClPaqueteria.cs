using POO_practica03.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace POO_practica03.Clases
{
    internal class ClPaqueteria
    {
        //campos ** el como es o como sera
        private int shipperID;
        private string companyName;
        private string phone;

        public int ShipperID { get => shipperID; set => shipperID = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string Phone { get => phone; set => phone = value; }

        public ClPaqueteria()
        {

        }

        public ClPaqueteria(int shipperID)
        {
            this.shipperID = shipperID;
        }

        public ClPaqueteria(string companyName, string phone)
        {
            CompanyName = companyName;
            Phone = phone;
        }

        public ClPaqueteria(int shipperID, string companyName, string phone)
        {
            ShipperID = shipperID;
            CompanyName = companyName;
            Phone = phone;
        }

        public string buscartodos()
        {
            return ("select * from Shippers");
        }
        public string grabar()
        {
            return ("sp_graba_paqueteria");
       }
        public string consultar()
        {
            return("select * from shippers where shipperid = '" + this.ShipperID + "'");
        }
        public string modificar()
        {
            return ("sp_modificar_paqueteria");
        }
        public string borrar()
        {
            return ("sp_borrar_shippers");
        }
    }
}

