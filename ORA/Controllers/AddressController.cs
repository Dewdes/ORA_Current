using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        public ActionResult Index()
        {
            return View();
        }

        [Route("Address/Create")]
        public ActionResult CreateAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAddress(AddressVM address)
        {
            //AddressDAL.CreateAddress(Mapper.Map<AddressDM>(address));
            return View();
        }

        public ActionResult ReadAllAddress()
        {
            return View(Mapper.Map<List<AddressVM>>(AddressDAL.ReadAllAddress()));
        }
        
        public ActionResult ReadAddressByID(AddressVM address)
        {
            return View(Mapper.Map<AddressVM>(AddressDAL.ReadAddressByID(address.Address_ID.ToString())));
        }

        public ActionResult UpdateAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateAddress(AddressVM address)
        {
            AddressDAL.UpdateAddress(Mapper.Map<AddressDM>(address));
            return View();
        }

        public ActionResult DeleteAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteAddress(AddressVM address)
        {
            AddressDAL.DeleteAddress(Mapper.Map<AddressDM>(address));
            return View();
        }
    }
}