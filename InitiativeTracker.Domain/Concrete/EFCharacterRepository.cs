using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InitiativeTracker.Domain.Entities;
using InitiativeTracker.Domain.Concrete;
using InitiativeTracker.Domain.Abstract;

namespace InitiativeTracker.Domain.Concrete
{
    public class EFCharacterRepository : ICharacterRepository
    {
        private EFdbContext context = new EFdbContext();

        private IEnumerable<CharacterGroup> groups
        {
            get { return context.CharacterGroup; }
        }

        private IEnumerable<EncounterCharacter> encounterCharacters
        {
            get { return context.ECL; }
        }

        private IEnumerable<Encounter> encounters
        {
            get { return context.Encounters; }
        }

        public IEnumerable<Character> items
        {
            get { return context.Characters; }
        }

        public Character Get(int id)
        {
            return context.Characters.Where(c => c.Character_ID == id).FirstOrDefault();
        }

        public Character Save(Character item)
        {
            Character storedItem = Get(item.Character_ID);
            
            if (storedItem != null)
            {
                
                storedItem.Name = item.Name;
                storedItem.Group_ID = item.Group_ID;
                storedItem.Initiative = item.Initiative;
                storedItem.Initiative_Bonus = item.Initiative_Bonus;
            }
            else
            {
                
                context.Characters.Add(item);
            }
            context.SaveChanges();
            return item;
        }

        public string Remove(int id)
        {
            Character item = Get(id);
            if (item != null && encounterCharacters.Where(c => c.Character_ID == id).FirstOrDefault() == null)
            {
                context.Characters.Remove(item);
                context.SaveChanges();
                return "Success";
            } else
            {
                int encounter_ID = encounterCharacters.Where(c => c.Character_ID == id).FirstOrDefault().Encounter_ID;
                string encounterName = encounters.Where(e => e.Encounter_ID == encounter_ID).FirstOrDefault().Name;
                return string.Format("Character could not be deleted because they are part of the encounter named: {0}", encounterName);
            }

        }
    }
}
