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
        private EFCharacterRepository characters = new EFCharacterRepository();

        [HttpGet]
        public IEnumerable<Character> GetAllCharacters()
        {
            return characters.Characters;
        }


        public Character GetCharacter(int id)
        {
            return characters.Get(id);
        }

        [HttpPost]
        public Character CreateCharacter(Character item)
        {
            return characters.Save(item);
        }

        [HttpPut]
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