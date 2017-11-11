using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class PositionController : Controller
    {
        // GET: Position
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePosition()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePosition(PositionsVM position)
        {
            PositionsDAL.CreatePosition(Mapper.Map<PositionsDM>(position));
            return View();
        }

        public ActionResult ReadPositiions()
        {
            return View(Mapper.Map<List<PositionsVM>>(PositionsDAL.ReadPositions()));
        }

        public ActionResult ReadPositionByID(PositionsDM position)
        {
            return View(Mapper.Map<PositionsVM>(PositionsDAL.ReadPositionById(position.PositionId.ToString())));
        }

        public ActionResult UpdatePosition()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePosition(PositionsVM position)
        {
            PositionsDAL.UpdatePosition(Mapper.Map<PositionsDM>(position));
            return View();
        }

        public ActionResult DeletePosition()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeletePosition(PositionsVM position)
        {
            PositionsDAL.DeletePosition(Mapper.Map<PositionsDM>(position));
            return View();
        }
    }
}