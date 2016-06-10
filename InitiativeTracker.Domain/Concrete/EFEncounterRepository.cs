using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InitiativeTracker.Domain.Abstract;
using InitiativeTracker.Domain.Entities;

namespace InitiativeTracker.Domain.Concrete
{
    public class EFEncounterRepository : IEncounterRepository
    {
        private EFdbContext context = new EFdbContext();

        public IEnumerable<Encounter> items
        {
            get
            {
                return context.Encounters;
            }
        }

        public Encounter Get(int id)
        {
            return context.Encounters.Where(x => x.Encounter_ID == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            Encounter item = Get(id);
            if (item != null)
            {
                context.Encounters.Remove(item);
                context.SaveChanges();
            }
        }

        public Encounter Save(Encounter item)
        {
            Encounter storedItem = Get(item.Encounter_ID);

            if (storedItem != null)
            {
                storedItem.Name = item.Name;
            }
            else
            {
                context.Encounters.Add(item);
            }
            context.SaveChanges();
            return item;
        }
    }
}
