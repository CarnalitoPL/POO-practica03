using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_practica03.Clases
{
    internal class clempleados
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public int ReportsTo { get; set; }
        public string PhotoPath { get; set; }


        public clempleados()
        {
        }

        public clempleados(int employeeID)
        {
            EmployeeID = employeeID;
        }

        public clempleados(string lastName, string firstName, string title, string titleOfCourtesy, DateTime birthDate, DateTime hireDate, string address, string city, string region, string postalCode, string country, string homePhone, string extension, byte[] photo, string notes, int reportsTo, string photoPath)
        {
            LastName = lastName;
            FirstName = firstName;
            Title = title;
            TitleOfCourtesy = titleOfCourtesy;
            BirthDate = birthDate;
            HireDate = hireDate;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            HomePhone = homePhone;
            Extension = extension;
            Photo = photo;
            Notes = notes;
            ReportsTo = reportsTo;
            PhotoPath = photoPath;
        }
        public clempleados(int employeeID, string lastName, string firstName, string title, string titleOfCourtesy, DateTime birthDate, DateTime hireDate, string address, string city, string region, string postalCode, string country, string homePhone, string extension, byte[] photo, string notes, int reportsTo, string photoPath)
        {
            EmployeeID = employeeID;
            LastName = lastName;
            FirstName = firstName;
            Title = title;
            TitleOfCourtesy = titleOfCourtesy;
            BirthDate = birthDate;
            HireDate = hireDate;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            HomePhone = homePhone;
            Extension = extension;
            Photo = photo;
            Notes = notes;
            ReportsTo = reportsTo;
            PhotoPath = photoPath;
        }
        public string buscarTodos()
        {
            return ("select *, FirstName +' ' + LastName as nombre from Employees");
        }
        public string buscarTodos2()
        {
            return ("select * from Employees");
        }

        public string grabar()
        {
            return ("sp_graba_empleados");
        }
        public string modificar()
        {
            return ("sp_modifica_empleados");
        }
        public string borrar()
        {
            return ("sp_borra_empleado");
        }
        public string consultari()
        {
            return ("select * from Employees where EmployeeID = '" + this.EmployeeID + "'");
        }

    }
}
