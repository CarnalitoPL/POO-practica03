using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_practica03.Clases
{
    public class EmployeeTerritory
    {


        public int TerritoryID { get; set; }
        public int EmployeeID { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionID { get; set; }
        public string RegionDescription { get; set; }
        // Indica si este registro es nuevo y debe ser grabado
        public bool EsNuevo { get; set; } = false;

        public EmployeeTerritory(int territoryID)
        {
            TerritoryID = territoryID;
        }
        public EmployeeTerritory()
        {

        }

        public EmployeeTerritory(int territoryID, int employeeID)
        {
            TerritoryID = territoryID;
            EmployeeID = employeeID;
        }

        public string grabar()
        {
            return ("sp_graba_territorios");
        }
        public string consultari()
        {
            return ("select * from EmployeeTerritories where employeeID = '" + this.EmployeeID + "'  AND TerritoryID = '" + this.TerritoryID + "'");
        }
    }
}
