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

        public IEnumerable<Character> Characters
        {
            get { return context.Characters; }
        }

        public Character Get(int id)
        {
            return context.Characters.Where(c => c.CharacterID == id).FirstOrDefault();
        }

        public Character Save(Character item)
        {
            Character storedItem = Get(item.CharacterID);
            
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

        public void Remove(int id)
        {
            Character item = Get(id);
            if (item != null)
            {
                context.Characters.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
