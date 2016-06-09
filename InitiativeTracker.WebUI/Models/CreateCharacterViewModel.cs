using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using InitiativeTracker.Domain.Entities;
using System.Web.Mvc;

namespace InitiativeTracker.WebUI.Models
{
    public class CreateCharacterViewModel : Character
    {
        public IEnumerable<CharacterGroup> groups { get; set; }
        public IEnumerable<SelectListItem> GetGroups { get; set; }
    }
}