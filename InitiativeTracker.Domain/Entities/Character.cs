using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker.Domain.Entities
{
    public class Character
    {
        public int CharacterID { get; set; }
        public string Name { get; set; }
        public int Initiative { get; set; }
        public string Group { get; set; }
    }

}
