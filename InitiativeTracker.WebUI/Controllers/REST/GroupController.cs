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
    public class GroupController : ApiController
    {
        private EFCharacterGroupRepository groups = new EFCharacterGroupRepository();

        [HttpGet]
        public IEnumerable<CharacterGroup> GetAllGroups()
        {
            return groups.Groups;
        }
    }
}