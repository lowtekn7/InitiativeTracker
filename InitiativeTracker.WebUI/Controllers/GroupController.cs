﻿using System;
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
        private ICharacterGroupRepository repository;
        //private EFCharacterGroupRepository groups = new EFCharacterGroupRepository();

        public GroupController(ICharacterGroupRepository repo)
        {
            this.repository = repo;
        }

        public ActionResult Save(CharacterGroup item)
        {
            repository.Save(item);
            return RedirectToAction("Groups", "Administration");
        }

        public ActionResult Delete(int id)
        {
            repository.Remove(id);
            return RedirectToAction("Groups", "Administration");
        }
    }
}