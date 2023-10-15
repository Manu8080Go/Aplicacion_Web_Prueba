using Prueba.DBContext.DB2;
using Prueba.Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Negocio
{
    public class EmpleadoBL
    {
        public List<EmpleadoModel> GetEmpleados()
        {
            List<EmpleadoModel> ListaEmpleado = new List<EmpleadoModel>();

            try
            {
                GenericDB2Impl<Empleado> impl = new GenericDB2Impl<Empleado>();
                var lst = impl.GetAll();

                foreach (var item in lst)
                {
                    EmpleadoModel empleado = new EmpleadoModel();
                    empleado.IdEmpleado = item.IdEmpleado;
                    empleado.NombreEmpleado = item.Nombre_Empelado;
                    empleado.ApellidoPaternoEmpleado = item.Apellido_Paterno_Emp;
                    empleado.ApellidoMaternoEmpleado = item.Apellido_Materno_Emp;
                    empleado.NoEmpleado = item.NoEmpleado;
                    ListaEmpleado.Add(empleado);
                }

                return ListaEmpleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveDataEmpleado(EmpleadoModel model)
        {
            int result = 0;

            try
            {
                GenericDB2Impl<Empleado> impl = new GenericDB2Impl<Empleado>();
                Empleado objEmpleado = new Empleado
                {
                    Nombre_Empelado = model.NombreEmpleado,
                    Apellido_Paterno_Emp = model.ApellidoPaternoEmpleado,
                    Apellido_Materno_Emp = model.ApellidoMaternoEmpleado,
                    NoEmpleado = model.NoEmpleado
                };

                result = impl.Create(objEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
