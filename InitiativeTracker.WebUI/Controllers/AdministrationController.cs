using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using InitiativeTracker.Domain.Abstract;
using InitiativeTracker.Domain.Concrete;
using InitiativeTracker.Domain.Entities;

namespace InitiativeTracker.WebUI.Controllers
{
    public class AdministrationController : Controller
    {
        private ICharacterGroupRepository repository;

        public AdministrationController(ICharacterGroupRepository repo)
        {
            this.repository = repo;
        }

        public ActionResult Index()
        {

            return View();
        }

        public ViewResult Groups()
        {
            return View(repository.Groups);
        }

        public ViewResult CreateGroup()
        {
            return View();
        }

        public ViewResult EditGroup(int id)
        {
            CharacterGroup group = repository.Get(id);
            return View(group);
        }

    }
}