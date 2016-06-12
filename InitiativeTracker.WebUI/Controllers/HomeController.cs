using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using InitiativeTracker.Domain.Abstract;
using InitiativeTracker.Domain.Concrete;
using InitiativeTracker.Domain.Entities;

using InitiativeTracker.WebUI.Infrastructure;

using InitiativeTracker.WebUI.Models;

namespace InitiativeTracker.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICharacterRepository characters;
        private IEncounterRepository encounters;
        private IECLRepository ecl;
        private ICharacterGroupRepository groups;
        
        public HomeController(ICharacterRepository repo1, IEncounterRepository repo2, IECLRepository repo3, ICharacterGroupRepository repo4)
        {
            this.characters = repo1;
            this.encounters = repo2;
            this.ecl = repo3;
            this.groups = repo4;
        }

        public ActionResult Index(List<Encounter> list)
        {
            return View(encounters.items);
        }

        public ActionResult Start(int id, EncounterCharacters encounterCharacters)
        {
            EncounterViewModel Encounter = new EncounterViewModel();
            Encounter.Name = encounters.Get(id).Name;
            if ((encounterCharacters.list.Count == 0) || !(encounterCharacters.list[0].Encounter_ID == id))
            {
                encounterCharacters.Empty();
                encounterCharacters.Round = 0;
                IEnumerable<EncounterCharacter> Items = ecl.CharactersFor(id);
                foreach (EncounterCharacter item in Items)
                {
                    encounterCharacters.Add(new EncounterCharacterViewModel()
                    {
                        Character_ID = item.Character_ID,
                        EncounterCharacter_ID = item.EncounterCharacter_ID,
                        Encounter_ID = id,
                        Name = characters.Get(item.Character_ID).Name,
                        Group = groups.Get(characters.Get(item.Character_ID).Group_ID).Name,
                        Initiative_bonus = characters.Get(item.Character_ID).Initiative_Bonus
                    });
                }
            }
            Encounter.EncounterCharacters = encounterCharacters.items;
            Encounter.Round = encounterCharacters.Round;
            return View(Encounter);
        }

        public ActionResult _encounterList(EncounterCharacters encounterCharacters)
        {
            return PartialView(encounterCharacters.items);
        }
        
        public ActionResult NextRound(EncounterCharacters encounterCharacters)
        {
            RollInitiative(encounterCharacters);
            encounterCharacters.Round++;
            return RedirectToAction("_encounterList");
        }

        private void RollInitiative(EncounterCharacters encounterCharacters)
        {
            Random random = new Random();
            foreach (EncounterCharacterViewModel character in encounterCharacters.items)
            {
                character.Initiative = (random.Next(1, 21) + (int)character.Initiative_bonus);
            }
            encounterCharacters.list.Sort((y, x) => x.Initiative.CompareTo(y.Initiative));
        }

        public ActionResult End(EncounterCharacters encounterCharacters)
        {
            encounterCharacters.Empty();
            return RedirectToAction("Index");
        }

        public int GetRound(EncounterCharacters encounterCharacters)
        {
            return encounterCharacters.Round;
        }
    }
}