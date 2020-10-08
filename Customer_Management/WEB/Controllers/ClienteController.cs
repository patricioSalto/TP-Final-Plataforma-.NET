using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WEB.Controllers
{
    public class ClienteController : Controller
    {
        Class_Library.Cls_Handler_ClientesBD _objBusinessLogic;

        public ActionResult Index()
        {
            List<Entidades.ClienteModel> clienteList = new List<Entidades.ClienteModel>();
            _objBusinessLogic = new Class_Library.Cls_Handler_ClientesBD();

            clienteList = _objBusinessLogic.Obtener_Clientes();

            return View(clienteList);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Entidades.ClienteModel datosCliente)
        {
            _objBusinessLogic = new Class_Library.Cls_Handler_ClientesBD();

            _objBusinessLogic.mtd_Insertar_Cliente(datosCliente);

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            _objBusinessLogic = new Class_Library.Cls_Handler_ClientesBD();

            return View(_objBusinessLogic.Obtener_Clientes().Find(lsmodel => lsmodel.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(Entidades.ClienteModel datosCliente)
        {
            _objBusinessLogic = new Class_Library.Cls_Handler_ClientesBD();

            _objBusinessLogic.mtd_Update_Cliente(datosCliente);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _objBusinessLogic = new Class_Library.Cls_Handler_ClientesBD();

            return View(_objBusinessLogic.Obtener_Clientes().Find(lsmodel => lsmodel.Id == id));
        }

        [HttpPost]
        public ActionResult Delete(Entidades.ClienteModel datosClientes)
        {
            _objBusinessLogic = new Class_Library.Cls_Handler_ClientesBD();

            _objBusinessLogic.mtd_Eliminar_Cliente(datosClientes.Id);

            return RedirectToAction("Index");
        }

        
        public ActionResult clienteBuscar(String filtro)
        {
            //String a = Request.Form["filtro"];

            List<Entidades.ClienteModel> clienteList = new List<Entidades.ClienteModel>();
            _objBusinessLogic = new Class_Library.Cls_Handler_ClientesBD();

            clienteList = _objBusinessLogic.Obtener_Clientes(filtro);

            return View("Index",clienteList);
        }
    }
}
