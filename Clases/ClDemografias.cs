using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_practica03.Clases
{
    internal class ClDemografias
    {
        private string CustomerTypeID;
        private string CustomerDesc;


        public string CustomerTypeID1 { get => CustomerTypeID; set => CustomerTypeID = value; }
        public string CustomerDesc1 { get => CustomerDesc; set => CustomerDesc = value; }
        public ClDemografias(string customerTypeID1)
        {
            CustomerTypeID1 = customerTypeID1;
        }

        public ClDemografias(string customerTypeID1, string customerDesc1)
        {
            CustomerTypeID1 = customerTypeID1;
            CustomerDesc1 = customerDesc1;
        }

        public ClDemografias()
        {

        }
        public string buscartodos()
        {
            return ("select * from CustomerDemographics");
        }
        public string grabar()
        {
            return ("sp_graba_demografia");
        }
        public string consultar()
        {
            return ("select * from CustomerDemographics where CustomerTypeID = '" + this.CustomerTypeID1 + "'");
        }
        public string modificar()
        {
            return ("sp_modificar_demografia");
        }
        public string borrar()
        {
            return ("sp_borrar_demografia");
        }
    }
}
