using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_practica03.Clases
{
    internal class ClTerritorios
    {
        private string TerritoryID;
        private string TerritoryDescription;
        private int RegionID;


        public string TerritoryID1 { get => TerritoryID; set => TerritoryID = value; }
        public string TerritoryDescription1 { get => TerritoryDescription; set => TerritoryDescription = value; }
        public int RegionID1 { get => RegionID; set => RegionID = value; }

        public ClTerritorios()
        {

        }
        public ClTerritorios(string territoryDescription, int regionID)
        {
            TerritoryDescription = territoryDescription;
            RegionID = regionID;
        }

        public ClTerritorios(string territoryID1, string territoryDescription1, int regionID1)
        {
            TerritoryID1 = territoryID1;
            TerritoryDescription1 = territoryDescription1;
            RegionID1 = regionID1;
        }

        public ClTerritorios(string territoryID1)
        {
            TerritoryID1 = territoryID1;
        }

        public string buscartodos()
        {
            return ("select * from bta_territories_region");
        }
        public string grabar()
        {
            return ("sp_graba_territorios");
        }
        public string consultar()
        {
            return ("select * from Territories where TerritoryID = '" + this.TerritoryID1 + "'");
        }
        public string modificar()
        {
            return ("sp_modificar_territorios");
        }
        public string borrar()
        {
            return ("sp_borrar_territorios");
        }
    }
}
