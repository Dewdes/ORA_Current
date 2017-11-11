using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class StoryController : Controller
    {
        // GET: Story
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateStory()
        {
            StoryVM story = new StoryVM();
            story.Created = DateTime.Now;
            story.Modified = DateTime.Now;
            story.Clients = Mapper.Map<List<ClientsVM>>(ClientsDAL.ReadClients());
            return View(story);
        }

        [HttpPost]
        public ActionResult CreateStory(StoryVM story)
        {
            StoryDAL.CreateStory(Mapper.Map<StoryDM>(story));
            return View();
        }

        public ActionResult ReadStorys()
        {
            return View(Mapper.Map<List<StoryVM>>(StoryDAL.ReadStorys()));
        }

        public ActionResult ReadStoryByID(StoryDM story)
        {
            return View(Mapper.Map<StoryVM>(StoryDAL.ReadStoryById(story.StoryId.ToString())));
        }

        public ActionResult UpdateStory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateStory(StoryVM story)
        {
            story.Modified = DateTime.Now;
            StoryDAL.UpdateStory(Mapper.Map<StoryDM>(story));
            return View();
        }

        public ActionResult DeleteStory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteStory(StoryVM story)
        {
            StoryDAL.DeleteStory(Mapper.Map<StoryDM>(story));
            return View();
        }
    }
}