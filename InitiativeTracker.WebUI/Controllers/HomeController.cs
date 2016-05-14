using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

using InitiativeTracker.Domain.Abstract;
using InitiativeTracker.Domain.Concrete;
using InitiativeTracker.Domain.Entities;

namespace InitiativeTracker.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICharacterRepository repository;
        
        
        public HomeController(ICharacterRepository characterRepository)
        {
            this.repository = characterRepository;
            
        }

        public ActionResult Index(List<Character> list)
        {
            return View();
        }

        public ViewResult Characters()
        {
            
            return View();
        }

        public ViewResult Administration()
        {
            return View();
        }

        public ActionResult Remove(int id)
        {
            repository.Remove(id);
            return RedirectToAction("Characters");
        }


    }
}