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

    public class EFECLRepository : IECLRepository
    {
        private EFdbContext context = new EFdbContext();

        public IEnumerable<EncounterCharacter> items
        {
            get
            {
                return context.ECL;
            }
        }

        public IEnumerable<EncounterCharacter> CharactersFor(int id)
        {
            return context.ECL.Where(x => x.Encounter_ID == id);
        }

        public EncounterCharacter Get(int id)
        {
            return context.ECL.Where(x => x.EncounterCharacter_ID == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            EncounterCharacter item = Get(id);
            if (item != null)
            {
                context.ECL.Remove(item);
                context.SaveChanges();
            }
            
        }

        public void RemoveAll(int id)
        {
            context.ECL.RemoveRange(CharactersFor(id));
            context.SaveChanges();
        }

        public EncounterCharacter Save(EncounterCharacter item)
        {
            EncounterCharacter storedItem = Get(item.EncounterCharacter_ID);

            if (storedItem != null)
            {
                storedItem.Encounter_ID = item.Encounter_ID;
                storedItem.Character_ID = item.Character_ID;
            }
            else
            {
                context.ECL.Add(item);
            }
            context.SaveChanges();
            return item;
        }
    }
}
