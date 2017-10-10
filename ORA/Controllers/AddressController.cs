﻿using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult CreateAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAddress(AddressVM address)
        {
            AddressDAL.CreateAddress(Mapper.Map<AddressDM>(address));
            return View();
        }

        public ActionResult ReadAddress()
        {
            AddressDAL.ReadAllAddress();
            return View();
        }

        public ActionResult UpdateAddress()
        {
            return View();
        }

        public ActionResult DeleteAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteAddress(AddressVM address)
        {
            return View();
        }
    }
}