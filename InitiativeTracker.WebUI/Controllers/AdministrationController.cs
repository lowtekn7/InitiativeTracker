using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using InitiativeTracker.Domain.Abstract;

namespace InitiativeTracker.WebUI.Controllers
{
    public class AdministrationController : Controller
    {
        private ICharacterGroupRepository repository;

        public AdministrationController(ICharacterGroupRepository repo)
        {
            this.repository = repo;
        }

        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Groups()
        {
            return View(repository.Groups);
        }

    }
}