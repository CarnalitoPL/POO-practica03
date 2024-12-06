using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_practica03.Clases
{
    internal class clOperaciones
    {
        //como es (caracteristicas, campos)
        private decimal valor1;
        private decimal valor2;

        public clOperaciones(decimal valor1, decimal valor2)
        {
            this.valor1 = valor1;
            this.valor2 = valor2;
        }

        //propiedades get, set

        //Constructores

        // Lo que hace (accion)
        public decimal suma()
        {
            return (valor1 + valor2);
        }
        public decimal resta()
        {
            return (valor1 - valor2);
        }
        public decimal multiplicacion()
        {
            return (valor2 * valor1);
        }
        public decimal division()
        {
            return (valor1 / valor2);
        }

    }
}
