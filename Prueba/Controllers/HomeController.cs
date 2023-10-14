using Prueba.DBContext.DB1;
using Prueba.DBContext.DB2;
using Prueba.Models;
using Prueba.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Cliente_DB1()
        {
            return View();
        }

        public ActionResult Empleado_DB2()
        {
            return View();
        }

        /// <summary>
        /// Obtener todos los clientes
        /// </summary>
        /// <returns></returns>
        public PartialViewResult GetClientes()
        {
            List<ClienteModel> ListaCliente = new List<ClienteModel>();
            ClienteCollection collection = new ClienteCollection();

            try
            {
                GenericDB1Impl<Cliente> impl = new GenericDB1Impl<Cliente>();
                var lst = impl.GetAll();
                
                foreach(var item in lst)
                {
                    ClienteModel cliente = new ClienteModel();
                    cliente.IdCliente = item.IdCliente;
                    cliente.Nombre = item.Nombre;
                    cliente.ApellidoPaterno = item.Apellido_Paterno;
                    cliente.ApellidoMaterno = item.Apellido_Materno;
                    cliente.Telefono = item.Telefono;
                    cliente.Email = item.email;
                    ListaCliente.Add(cliente);
                }

                collection.lstCliente = ListaCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return PartialView("_GridData", collection);
        }

        /// <summary>
        /// Guardar Información de Clientes
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveDataCliente(ClienteModel model)
        {
            int result = 0;

            try
            {
                GenericDB1Impl<Cliente> impl = new GenericDB1Impl<Cliente>();
                Cliente objCliente = new Cliente {
                    Nombre = model.Nombre,
                    Apellido_Paterno = model.ApellidoPaterno,
                    Apellido_Materno = model.ApellidoMaterno,
                    Telefono = model.Telefono,
                    email = model.Email
                };

                result = impl.Create(objCliente);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        public PartialViewResult GetEmpleados()
        {
            List<EmpleadoModel> ListaEmpleado = new List<EmpleadoModel>();
            EmpleadoCollection collection = new EmpleadoCollection();

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

                collection.lstEmpleado = ListaEmpleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return PartialView("_GridDataEmpleado", collection);
        }

        /// <summary>
        /// Guardar Información del empleado
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveDataEmpleado(EmpleadoModel model)
        {
            int result = 0;

            try
            {
                GenericDB2Impl<Empleado> impl = new GenericDB2Impl<Empleado>();
                Empleado objCliente = new Empleado
                {
                    Nombre_Empelado = model.NombreEmpleado,
                    Apellido_Paterno_Emp = model.ApellidoPaternoEmpleado,
                    Apellido_Materno_Emp = model.ApellidoMaternoEmpleado,
                    NoEmpleado = model.NoEmpleado
                };

                result = impl.Create(objCliente);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}