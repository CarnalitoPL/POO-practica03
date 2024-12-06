using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_practica03.Clases
{
    internal class ClCustomers
    {
        private string CustomerID;
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
        public string CustomerID1 { get => CustomerID; set => CustomerID = value; }
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

        public ClCustomers()
        {

        }

        public ClCustomers(string customerID1)
        {
            CustomerID1 = customerID1;
        }

        public ClCustomers(string customerID1, string companyName1, string contactName1, string contactTitle1, string address1, string city1, string region1, string postalCode1, string country1, string phone1, string fax1)
        {
            CustomerID1 = customerID1;
            CompanyName1 = companyName1;
            ContactName1 = contactName1;
            ContactTitle1 = contactTitle1;
            Address1 = address1;
            City1 = city1;
            Region1 = region1;
            PostalCode1 = postalCode1;
            Country1 = country1;
            Phone1 = phone1;
            Fax1 = fax1;
        }

        public string buscartodos()
        {
            return ("select * from Customers");
        }
        public string grabar()
        {
            return ("sp_graba_customers");
        }
        public string consultar()
        {
            return ("select * from Customers where CustomerID = '" + this.CustomerID1 + "'");
        }
        public string modificar()
        {
            return ("sp_modificar_customers");
        }
        public string borrar()
        {
            return ("sp_borrar_customers");
        }

    }
}
