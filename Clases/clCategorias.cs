using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_practica03.Clases
{
    internal class clCategorias
    {
        private int CategoryId;
        private String CategoryName;
        private String Description;
        private byte[] Picture;

        public clCategorias()
        {
            //mostrar todos los datos de la tabla
        }
        public clCategorias(int categoryid)
        {
            //consultar un solo registro por categoria ID
            this.CategoryId = categoryid;
        }

        public clCategorias(int categoryId, string categoryName, string description, byte[] picture)
        {
            //grabar un registro nuevo o modificar los datos de registro
            CategoryId = categoryId;
            CategoryName = categoryName;
            Description = description;
            Picture = picture;
        }
        // PROCEDIMIENTOS
        //GRABAR

        //BUSCAR INDIVIDUALMENTE
        public string buscar()
        {
            return ("Select * from Categories where CategoryID = '" + this.CategoryId +"'");
        }
        //BUSCAR TODOS

        //MODIFICAR

        //ELIMINAR
        public string buscartodos()
        {
            return ("Select * from categories");
        }
    }
}
