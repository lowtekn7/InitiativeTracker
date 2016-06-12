using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using InitiativeTracker.Domain.Entities;

namespace InitiativeTracker.WebUI.Models
{
    public class CharacterViewModel
    {
        public int Character_ID { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public int? Initiative { get; set; }
        public int? Initiative_Bonus { get; set; }
        public int? EncounterCharacter_ID { get; set; }
    }
}