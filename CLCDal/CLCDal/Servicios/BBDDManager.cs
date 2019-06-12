using BecaAvanade.Modelo;
using CLCDal.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CLCDal.Servicios
{
    public class BBDDManager
    {
        BBDD_AvanadeContext context = new BBDD_AvanadeContext();

        public List<Empleados> GetEmployees()
        {
            List<Empleados> res = new List<Empleados>(); 
            List<Empleados> per = context.Empleados.ToList();
            for (int i = 0; i < per.Count; i++)
            {
                res.Add(per[i]);
            }

            return res;
        }
        /// <summary>
        /// Asumimos que el id del empleado es unico...
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Empleados> GetEmployee(int id)
        {
            List<Empleados> res = new List<Empleados>();
            List<Empleados> empleados = context.Empleados.ToList();
            bool encontrado = false;
            for (int i = 0; i < empleados.Count && !encontrado; i++)
            {
                if (empleados[i].Id == id)
                {
                    res.Add(empleados[i]);
                    encontrado = true;
                }
            }

            return res;
        }
    
        public int GetEmpleadoId (string nombre)
        {
            int res = 0;
            bool encontrado = false;
            List<Empleados> empleados = context.Empleados.ToList();
            for(int i = 0; i<empleados.Count && !encontrado; i++)
            {
                if(nombre == empleados[i].Persona.Nombre)
                {
                    res = empleados[i].Id;
                    encontrado = true;

                }
            }

            return res;
        }
}

