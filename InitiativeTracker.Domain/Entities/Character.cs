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
        public int Group_ID { get; set; }
        public string Name { get; set; }
        public int? Initiative { get; set; }
        public int? Initiative_Bonus { get; set; }
    }

}
