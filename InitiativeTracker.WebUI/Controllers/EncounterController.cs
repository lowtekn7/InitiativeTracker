using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using InitiativeTracker.Domain.Abstract;
using InitiativeTracker.Domain.Concrete;
using InitiativeTracker.Domain.Entities;

using InitiativeTracker.WebUI.Models;
using InitiativeTracker.WebUI.Infrastructure;

namespace InitiativeTracker.WebUI.Controllers
{
    public class EncounterController : Controller
    {
        private IEncounterRepository encounters;
        private ICharacterRepository characters;
        private ICharacterGroupRepository groups;
        private IECLRepository ecl;

        public EncounterController(IEncounterRepository repo1, ICharacterRepository repo2,
            ICharacterGroupRepository repo3, IECLRepository repo4)
        {
            this.encounters = repo1;
            this.characters = repo2;
            this.groups = repo3;
            this.ecl = repo4;
        }

        public ViewResult Summary()
        {
            return View(encounters.items);
        }

        public ViewResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id, SelectedCharacters list)
        {
            // get the encounter name
            // get a list of all characters in the encounter and populate the SelectedCharacters list with them
            list.Empty();
            Encounter item = encounters.Get(id);
            IEnumerable<EncounterCharacter> encounterCharacters = ecl.CharactersFor(id);
            foreach (EncounterCharacter character in encounterCharacters)
            {
                CharacterViewModel cVM = SharedMethods.ConvertToCharacterVM(characters.Get(character.Character_ID), groups.items);
                cVM.EncounterCharacter_ID = character.EncounterCharacter_ID;
                list.Add(cVM);
            }
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            ecl.RemoveAll(id);
            encounters.Remove(id);
            return RedirectToAction("Summary");
        }

        public ActionResult _characterSelectionList()
        {
            IEnumerable<CharacterViewModel> list = SharedMethods.ConvertIEToCharacterVM(
                characters.items, groups.items);
            return PartialView(list);
        }

        public PartialViewResult SelectedCharacters(SelectedCharacters list)
        {
            return PartialView("_selectedCharacters", list.items);
        }

        public ActionResult AddTo(SelectedCharacters list, int id)
        {
            CharacterViewModel item = SharedMethods.
                ConvertToCharacterVM(characters.Get(id), groups.items);
            list.Add(item);
            return PartialView("_selectedCharacters",list.items);
        }

        public ActionResult Remove(SelectedCharacters list, int id)
        {
            list.Remove(id);
            return PartialView("_selectedCharacters", list.items);
        }

        public ActionResult Cancel(SelectedCharacters list)
        {
            list.Empty();
            return RedirectToAction("Summary");
        }

        public ActionResult Save(Encounter item, SelectedCharacters list)
        {
            Encounter Encounter = encounters.Save(item);
            ecl.RemoveAll(Encounter.Encounter_ID);
            foreach (CharacterViewModel character in list.items)
            {
                ecl.Save(new EncounterCharacter()
                {
                    Character_ID = character.Character_ID,
                    Encounter_ID = Encounter.Encounter_ID
                });
            }
            list.Empty();
            return RedirectToAction("Summary");
        }
    }
}