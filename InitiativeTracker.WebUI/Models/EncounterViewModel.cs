using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using InitiativeTracker.Domain.Entities;
using InitiativeTracker.WebUI.Models;

namespace InitiativeTracker.WebUI.Models
{
    public class EncounterViewModel : Encounter
    {
        public IEnumerable<EncounterCharacterViewModel> EncounterCharacters { get; set; }
        public int Round { get; set; }
    }
}