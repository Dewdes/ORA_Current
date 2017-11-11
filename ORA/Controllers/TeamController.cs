using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateTeam()
        {
            TeamsVM team = new TeamsVM();
            team.Clients = Mapper.Map<List<ClientsVM>>(ClientsDAL.ReadClients());
            return View(team);
        }

        [HttpPost]
        public ActionResult CreateTeam(TeamsVM team)
        {
            TeamsDAL.CreateTeam(Mapper.Map<TeamsDM>(team));
            return View();
        }

        public ActionResult ReadTeams()
        {
            return View(Mapper.Map<List<TeamsVM>>(TeamsDAL.ReadTeams()));
        }

        public ActionResult ReadTeamByID(TeamsDM team)
        {
            return View(Mapper.Map<TeamsVM>(TeamsDAL.ReadTeamById(team.TeamId.ToString())));
        }

        public ActionResult UpdateTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateTeam(TeamsVM team)
        {
            TeamsDAL.UpdateTeam(Mapper.Map<TeamsDM>(team));
            return View();
        }

        public ActionResult DeleteTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteTeam(TeamsVM team)
        {
            TeamsDAL.DeleteTeam(Mapper.Map<TeamsDM>(team));
            return View();
        }
    }
}