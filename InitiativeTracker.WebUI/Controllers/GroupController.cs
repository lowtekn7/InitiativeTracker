using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using InitiativeTracker.Domain.Abstract;
using InitiativeTracker.Domain.Entities;
using InitiativeTracker.Domain.Concrete;

namespace InitiativeTracker.WebUI.Controllers.REST
{
    public class GroupController : Controller
    {
        private EFCharacterGroupRepository groups = new EFCharacterGroupRepository();

        public ActionResult Save(CharacterGroup item)
        {
            groups.Save(item);
            return RedirectToAction("Groups", "Administration");
        }

        public ActionResult Delete(int id)
        {
            groups.Remove(id);
            return RedirectToAction("Groups", "Administration");
        }
    }
}