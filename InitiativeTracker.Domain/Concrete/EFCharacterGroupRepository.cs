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
        private IEnumerable<Character> characters {
            get { return context.Characters; }
        }


        public IEnumerable<CharacterGroup> items
        {
                get { return context.CharacterGroup; }
        }

        public CharacterGroup Get(int id)
        {
            return context.CharacterGroup.Where(c => c.Group_ID == id).FirstOrDefault();
        }

        public string Remove(int id)
        {
            CharacterGroup item = Get(id);
            if (item != null && characters.Where(c => c.Group_ID == id).FirstOrDefault() == null)
            {
                context.CharacterGroup.Remove(item);
                context.SaveChanges();
                return "Success";
            } else
            {
                string error = "Could not delete group because the following characters are still assigned to this group:\r\n" + Environment.NewLine;
                foreach (Character character in characters.Where(c => c.Group_ID == id))
                {
                    error += character.Name + Environment.NewLine;
                }
                return error;
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
    }
}
