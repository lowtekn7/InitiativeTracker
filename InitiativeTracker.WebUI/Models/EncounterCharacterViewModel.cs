using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using InitiativeTracker.Domain.Entities;

namespace InitiativeTracker.WebUI.Models
{
    public class EncounterCharacterViewModel : EncounterCharacter
    {
        public string Name { get; set; }
        public int Initiative { get; set; }
        public string Group { get; set; }
        public int? Initiative_bonus { get; set; }
    }
}