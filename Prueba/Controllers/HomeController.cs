using Prueba.DBContext.DB1;
using Prueba.DBContext.DB2;
using Prueba.Negocio;
using Prueba.Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba.Controllers
{
    public class HomeController : Controller
    {
        private ClienteBL clienteBL;
        private EmpleadoBL empleadoBL;

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
            List<ClienteModel> lstClientes;
            ClienteCollection collection = new ClienteCollection();

            try
            {
                clienteBL = new ClienteBL();
                lstClientes = new List<ClienteModel>();
                lstClientes = clienteBL.GetClientes();
                collection.lstCliente = lstClientes;
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
                clienteBL = new ClienteBL();
                result = clienteBL.SaveDataCliente(model);
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
            List<EmpleadoModel> lstEmpleados;
            EmpleadoCollection collection = new EmpleadoCollection();

            try
            {
                empleadoBL = new EmpleadoBL();
                lstEmpleados = new List<EmpleadoModel>();
                lstEmpleados = empleadoBL.GetEmpleados();
                collection.lstEmpleado = lstEmpleados;
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
                empleadoBL = new EmpleadoBL();
                result = empleadoBL.SaveDataEmpleado(model);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}