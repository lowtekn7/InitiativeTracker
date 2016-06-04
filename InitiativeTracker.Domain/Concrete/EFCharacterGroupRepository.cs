using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InitiativeTracker.Domain.Entities;
using InitiativeTracker.Domain.Abstract;

namespace InitiativeTracker.Domain.Concrete
{
    public class EFCharacterGroupRepository : ICharacterGroupRepository
    {
        private EFdbContext context = new EFdbContext();

        public IEnumerable<CharacterGroup> Groups
        {
                get { return context.CharacterGroup; }
        }

        public CharacterGroup Get(int id)
        {
            return context.CharacterGroup.Where(c => c.Group_ID == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            CharacterGroup item = Get(id);
            if (item != null)
            {
                context.CharacterGroup.Remove(item);
                context.SaveChanges();
            }
        }

        public CharacterGroup Save(CharacterGroup item)
        {
            CharacterGroup storedItem = Get(item.Group_ID);

            if (storedItem != null)
            {

                storedItem.Name = item.Name;
            }
            else
            {

                context.CharacterGroup.Add(item);
            }
            context.SaveChanges();
            return item;
        }

        public CharacterGroup Update(CharacterGroup item, int id)
        {
            CharacterGroup storedItem = Get(item.Group_ID);
            if (storedItem != null)
            {
                storedItem.Name = item.Name;
            }

            return item;
        }
    }
}
