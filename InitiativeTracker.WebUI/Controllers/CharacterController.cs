using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using InitiativeTracker.Domain.Abstract;
using InitiativeTracker.Domain.Entities;
using InitiativeTracker.Domain.Concrete;
using InitiativeTracker.WebUI.Infrastructure;

using InitiativeTracker.WebUI.Models;

namespace InitiativeTracker.WebUI.Controllers.REST
{
    public class CharacterController : Controller
    {
        private ICharacterRepository characters;
        private ICharacterGroupRepository groups;
        
        public CharacterController(ICharacterGroupRepository groupRepo, ICharacterRepository characterRepo)
        {
            this.characters = characterRepo;
            this.groups = groupRepo;
        }

        public ViewResult Summary()
        {
            IEnumerable<CharacterViewModel> list = SharedMethods.ConvertIEToCharacterVM(
                characters.items, groups.items);
            return View(list);
        }

        public ViewResult Create()
        {
            CreateCharacterViewModel vm = new CreateCharacterViewModel();
            vm.GetGroups = SharedMethods.SelectListOf(groups);
            return View(vm);
        }

        public ActionResult Cancel()
        {
            return RedirectToAction("Summary");
        }

        public ViewResult Edit(int id)
        {
            Character item = characters.Get(id);

            CreateCharacterViewModel vm = new CreateCharacterViewModel()
            {
                Character_ID = item.Character_ID,
                Name = item.Name,
                Initiative_Bonus = item.Initiative_Bonus,
                Group_ID = item.Group_ID
            };

            vm.GetGroups = SharedMethods.SelectListOf(groups);
            return View(vm);
        }

        public ActionResult Save(CreateCharacterViewModel item)
        {
            Character character = new Character()
            {
                Name = item.Name,
                Character_ID = item.Character_ID,
                Group_ID = item.Group_ID,
                Initiative = item.Initiative,
                Initiative_Bonus = item.Initiative_Bonus
            };
            characters.Save(character);
            return RedirectToAction("Summary");
        }

        public ActionResult Delete(int id)
        {
            characters.Remove(id);
            return RedirectToAction("Summary");
        }
    }
}