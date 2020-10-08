using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiWebClientes.Controllers
{
    public class ApiClientesController : ApiController
    {
        Class_Library.Cls_Handler_ClientesBD objBusinessLogic;

        [Route("api/ApiClientes/GetAllClientes")]
        [HttpPost]
        public IEnumerable<Entidades.ClienteModel> GetAllClientes()
        {
            objBusinessLogic = new Class_Library.Cls_Handler_ClientesBD();
            List<Entidades.ClienteModel> lstResultado = new List<Entidades.ClienteModel>();
            lstResultado = objBusinessLogic.Obtener_Clientes();

            return lstResultado;
        }

        [Route("api/ApiClientes/GetClienteById")]
        [HttpPost]
        public Entidades.ClienteModel GetClienteById(Entidades.ClienteModel _cliente)
        {
            objBusinessLogic = new Class_Library.Cls_Handler_ClientesBD();

            return objBusinessLogic.Obtener_Clientes().Find(lsmodel => lsmodel.Id == _cliente.Id);
        }

        [Route("api/ApiClientes/InsertCliente")]
        [HttpPost]
        public void InsertCliente(Entidades.ClienteModel _cliente)
        {
            objBusinessLogic = new Class_Library.Cls_Handler_ClientesBD();

            objBusinessLogic.mtd_Insertar_Cliente(_cliente);
        }

        [Route("api/ApiClientes/DeleteCliente")]
        [HttpPost]
        public bool DeleteCliente(Entidades.ClienteModel _cliente)
        {
            objBusinessLogic = new Class_Library.Cls_Handler_ClientesBD();

            objBusinessLogic.mtd_Eliminar_Cliente(_cliente.Id);

            return true;
        }

        [Route("api/ApiClientes/BuscarClientes")]
        [HttpPost]
        public IEnumerable<Entidades.ClienteModel> BuscarClientes(string filtro)
        {
            objBusinessLogic = new Class_Library.Cls_Handler_ClientesBD();

            List<Entidades.ClienteModel> clienteResultado = new List<Entidades.ClienteModel>();

            clienteResultado = objBusinessLogic.Obtener_Clientes(filtro);

            return clienteResultado;
        }

        [Route("api/ApiClientes/ActualizarCliente")]
        [HttpPost]
        public bool ActualizarCliente(Entidades.ClienteModel _cliente)
        {
            objBusinessLogic = new Class_Library.Cls_Handler_ClientesBD();

            objBusinessLogic.mtd_Update_Cliente(_cliente);

            return true;
        }

    }
}
