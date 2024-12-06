using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_practica03.Clases
{
    internal class ClRegiones
    {
        private int regionId;
        private string regionName;

        public ClRegiones(int regionId)
        {

            this.regionId = regionId;
        }

        public ClRegiones(string regionName)
        {
            this.regionName = regionName;
        }

        public ClRegiones(int regionId, string regionName)
        {
            this.regionId = regionId;
            this.regionName = regionName;
        }
        public ClRegiones()
        {
            //buscar tds los elementos
        }
        public string buscartodos()
        {
            return ("select * from region");
        }
    }
}
