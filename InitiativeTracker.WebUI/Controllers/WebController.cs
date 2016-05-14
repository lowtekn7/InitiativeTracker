using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using InitiativeTracker.Domain.Abstract;
using InitiativeTracker.Domain.Entities;
using InitiativeTracker.Domain.Concrete;

namespace InitiativeTracker.WebUI.Controllers
{
    public class WebController : ApiController
    {

        private EFCharacterRepository repo = new EFCharacterRepository();

        //private CharacterDAL repo = new CharacterDAL();
        
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
        public bool UpdateCharacter(Character item)
        {
            return repo.Update(item);
        }

        [HttpDelete]
        public void DeleteCharacter(int id)
        {
            repo.Remove(id);
        }

    }
}