using CLCDal.Models.DB;
using CLCDal.Servicios;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        BBDDManager manager = new BBDDManager();
        [Test]
        public void GetEmployeesOK()
        {

            List<Empleados> empleados = manager.GetEmployees();
         }
        [Test]          
        public void getEmployeeOK()
        {
            List<Empleados> empleado = manager.GetEmployee(2);
        }
    }
}