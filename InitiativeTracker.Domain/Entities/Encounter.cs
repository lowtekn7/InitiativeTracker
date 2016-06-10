using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;


namespace InitiativeTracker.Domain.Entities
{
    public class Encounter
    {
        [Key]
        public int Encounter_ID { get; set; }
        public string Name { get; set; }
    }
}
