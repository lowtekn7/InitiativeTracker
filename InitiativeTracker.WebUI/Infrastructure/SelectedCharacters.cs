using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InitiativeTracker.WebUI.Models;

namespace InitiativeTracker.WebUI.Infrastructure
{
    public class SelectedCharacters
    {
        private List<CharacterViewModel> list = new List<CharacterViewModel>();
        public void Add(CharacterViewModel item)
        {
            list.Add(item);
        }

        public void Remove(int id)
        {
            list.RemoveAt(id);
        }

        public void Empty()
        {
            list.Clear();
        }

        public CharacterViewModel Get(int id)
        {
            return list.FirstOrDefault(x => x.Character_ID == id);
        }

        public IEnumerable<CharacterViewModel> items
        {
            get
            {
                return list;
            }
        }
    }
}
