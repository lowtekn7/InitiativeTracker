using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace InitiativeTracker.Domain.Entities
{
    public class EncounterCharacter
    {
        [Key]
        public int EncounterCharacter_ID { get; set; }

        public int Character_ID { get; set; }
        public int Encounter_ID { get; set; }
    }
}
