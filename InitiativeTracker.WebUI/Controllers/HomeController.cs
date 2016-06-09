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
    public class HomeController : Controller
    {
        private ICharacterRepository repository;
        
        
        public HomeController(ICharacterRepository characterRepository)
        {
            
            this.repository = characterRepository;
        }

        public ActionResult Index(List<Character> list)
        {
            return View(repository.Characters);
        }



    }
}