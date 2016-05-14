using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using InitiativeTracker.Domain.Concrete;
using InitiativeTracker.Domain.Entities;

namespace InitiativeTracker.WebUI.Controllers
{
    public class EncounterController : ApiController
    {
        private EncounterDAL repo = new EncounterDAL();

        public IEnumerable<Character> GetAllCharacters()
        {
            return repo.Characters;
        }

        public Character GetCharacter(int id)
        {
            return repo.Get(id);
        }

        [HttpPost]
        public Character CreateCharacter(Character item)
        {
            return repo.Save(item);
        }

        [HttpPut]
        public Character UpdateCharacter(Character item, int id)
        {
            return repo.Update(item, id);
        }

        [HttpDelete]
        public void DeleteCharacter(int id)
        {
            repo.Remove(id);
        }
    }
}