using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_practica03.Clases
{
    internal class clSuppliers
    {
        private int SupplierID;
        private string CompanyName;
        private string ContactName;
        private string ContactTitle;
        private string Address;
        private string City;
        private string Region;
        private string PostalCode;
        private string Country;
        private string Phone;
        private string Fax;
        private string HomePage;

        public int SupplierID1 { get => SupplierID; set => SupplierID = value; }
        public string CompanyName1 { get => CompanyName; set => CompanyName = value; }
        public string ContactName1 { get => ContactName; set => ContactName = value; }
        public string ContactTitle1 { get => ContactTitle; set => ContactTitle = value; }
        public string Address1 { get => Address; set => Address = value; }
        public string City1 { get => City; set => City = value; }
        public string Region1 { get => Region; set => Region = value; }
        public string PostalCode1 { get => PostalCode; set => PostalCode = value; }
        public string Country1 { get => Country; set => Country = value; }
        public string Phone1 { get => Phone; set => Phone = value; }
        public string Fax1 { get => Fax; set => Fax = value; }
        public string HomePage1 { get => HomePage; set => HomePage = value; }

        public clSuppliers()
        {

        }

        public clSuppliers(int supplierID)
        {
            SupplierID = supplierID;
        }

        public clSuppliers(string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax, string homePage)
        {
            CompanyName = companyName;
            ContactName = contactName;
            ContactTitle = contactTitle;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            Fax = fax;
            HomePage = homePage;
        }

        public clSuppliers(int supplierID, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax, string homePage)
        {
            SupplierID = supplierID;
            CompanyName = companyName;
            ContactName = contactName;
            ContactTitle = contactTitle;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            Fax = fax;
            HomePage = homePage;
        }
        public string buscartodos()
        {
            return ("select * from Suppliers");
        }
        public string grabar()
        {
            return ("sp_graba_suppliers");
        }
        public string consultar()
        {
            return ("select * from Suppliers where SupplierID = '" + this.SupplierID + "'");
        }
        public string modificar()
        {
            return ("sp_modificar_suppliers");
        }
        public string borrar()
        {
            return ("sp_borrar_suppliers");
        }   
    }
}
