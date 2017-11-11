using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class ClientsController : Controller
    {
        // GET: Clients
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateClient(ClientsVM client)
        {
            ClientsDAL.CreateClient(Mapper.Map<ClientsDM>(client));
            return View();
        }

        public ActionResult ReadClients()
        {
            return View(Mapper.Map<List<ClientsVM>>(ClientsDAL.ReadClients()));
        }

        public ActionResult ReadClientByID(ClientsDM client)
        {
            return View(Mapper.Map<ClientsVM>(ClientsDAL.ReadClientById(client.ClientId.ToString())));
        }

        public ActionResult UpdateClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateClient(ClientsVM client)
        {
            ClientsDAL.UpdateClient(Mapper.Map<ClientsDM>(client));
            return View();
        }

        public ActionResult DeleteClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteClient(ClientsVM client)
        {
            ClientsDAL.DeleteClient(Mapper.Map<ClientsDM>(client));
            return View();
        }
    }
}