using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_practica03.Clases
{
    internal class ClProductos
    {
        private int ProductID;
        private string ProductName;
        private int SupplierID;
        private int CategoryID;
        private string QuantityPerUnit;
        private string UnitPrice;
        private int UnitsInStock;
        private int UnitsOnOrder;
        private int ReorderLevel;
        private Boolean Discontinued;
        public int ProductID1 { get => ProductID; set => ProductID = value; }
        public string ProductName1 { get => ProductName; set => ProductName = value; }
        public int SupplierID1 { get => SupplierID; set => SupplierID = value; }
        public int CategoryID1 { get => CategoryID; set => CategoryID = value; }
        public string QuantityPerUnit1 { get => QuantityPerUnit; set => QuantityPerUnit = value; }
        public string UnitPrice1 { get => UnitPrice; set => UnitPrice = value; }
        public int UnitsInStock1 { get => UnitsInStock; set => UnitsInStock = value; }
        public int UnitsOnOrder1 { get => UnitsOnOrder; set => UnitsOnOrder = value; }
        public int ReorderLevel1 { get => ReorderLevel; set => ReorderLevel = value; }
        public bool Discontinued1 { get => Discontinued; set => Discontinued = value; }

        public ClProductos()
        {

        }
        public ClProductos(int productID1)
        {
            ProductID1 = productID1;
        }

        public ClProductos(string productName1, int supplierID1, int categoryID1, string quantityPerUnit1, string unitPrice1, int unitsInStock1, int unitsOnOrder1, int reorderLevel1, bool discontinued1)
        {
            ProductName1 = productName1;
            SupplierID1 = supplierID1;
            CategoryID1 = categoryID1;
            QuantityPerUnit1 = quantityPerUnit1;
            UnitPrice1 = unitPrice1;
            UnitsInStock1 = unitsInStock1;
            UnitsOnOrder1 = unitsOnOrder1;
            ReorderLevel1 = reorderLevel1;
            Discontinued1 = discontinued1;
        }

        public ClProductos(int productID1, string productName1, int supplierID1, int categoryID1, string quantityPerUnit1, string unitPrice1, int unitsInStock1, int unitsOnOrder1, int reorderLevel1, bool discontinued1)
        {
            ProductID1 = productID1;
            ProductName1 = productName1;
            SupplierID1 = supplierID1;
            CategoryID1 = categoryID1;
            QuantityPerUnit1 = quantityPerUnit1;
            UnitPrice1 = unitPrice1;
            UnitsInStock1 = unitsInStock1;
            UnitsOnOrder1 = unitsOnOrder1;
            ReorderLevel1 = reorderLevel1;
            Discontinued1 = discontinued1;
        }
        public string buscartodos()
        {
            return ("select * from vta_productos_suppliers_categorias");
        }
        public string grabar()
        {
            return ("sp_Products_grabar");
        }
        public string consultar()
        {
            return ("select * from Products where ProductID = '" + this.ProductID1 + "'");
        }
        public string modificar()
        {
            return ("sp_modificar_products");
        }
        public string borrar()
        {
            return ("sp_Products_borrar");
        }
    }
}
