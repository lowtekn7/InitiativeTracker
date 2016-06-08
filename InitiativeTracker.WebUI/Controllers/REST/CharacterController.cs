using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http;

using InitiativeTracker.Domain.Abstract;
using InitiativeTracker.Domain.Entities;
using InitiativeTracker.Domain.Concrete;

namespace InitiativeTracker.WebUI.Controllers.REST
{
    public class CharacterController : ApiController
    {
        private EFCharacterGroupRepository groups = new EFCharacterGroupRepository();
        private EFCharacterRepository characters = new EFCharacterRepository();

        [HttpGet]
        [ActionName("Characters")]
        public IEnumerable<Character> GetAllCharacters()
        {
            return characters.Characters;
        }

        [HttpGet]
        [ActionName("Groups")]
        public IEnumerable<CharacterGroup> GetAllGroups()
        {
            return groups.Groups;
        }

        [HttpGet]
        [ActionName("Group")]
        public CharacterGroup GetGroup(int id)
        {
            return groups.Get(id);
        }

        [HttpGet]
        [ActionName("Character")]
        public Character GetCharacter(int id)
        {
            return characters.Get(id);
        }

        [HttpPost]
        [ActionName("Create")]
        public Character CreateCharacter(Character item)
        {
            return characters.Save(item);
        }

        [HttpPut]
        [ActionName("Update")]
        public Character UpdateCharacter(Character item)
        {
            return characters.Save(item);
        }

        [HttpDelete]
        [ActionName("Delete")]
        public void DeleteCharacter(int id)
        {
            characters.Remove(id);
        }
    }
}