using Prueba.DBContext.DB1;
using Prueba.Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Negocio
{
    public class ClienteBL
    {
        public List<ClienteModel> GetClientes()
        {
            List<ClienteModel> ListaCliente = new List<ClienteModel>();

            try
            {
                GenericDB1Impl<Cliente> impl = new GenericDB1Impl<Cliente>();
                var lst = impl.GetAll();

                foreach (var item in lst)
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

                return ListaCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveDataCliente(ClienteModel model)
        {
            int result = 0;

            try
            {
                GenericDB1Impl<Cliente> impl = new GenericDB1Impl<Cliente>();
                Cliente objCliente = new Cliente
                {
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
                throw ex;
            }

            return result;
        }
    }
}
