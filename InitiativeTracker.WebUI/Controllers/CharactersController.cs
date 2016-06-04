using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace InitiativeTracker.WebUI.Controllers
{
    public class CharactersController : Controller
    {
        // GET: Character
        public ActionResult Index()
        {
            return View();
        }
    }
}