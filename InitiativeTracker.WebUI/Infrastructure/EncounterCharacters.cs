using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using InitiativeTracker.WebUI.Models;

namespace InitiativeTracker.WebUI.Infrastructure
{
    public class EncounterCharacters
    {
        public List<EncounterCharacterViewModel> list = new List<EncounterCharacterViewModel>();
        public void Add(EncounterCharacterViewModel item)
        {
            list.Add(item);
        }

        public int Round { get; set; }

        public void Remove(int id)
        {
            list.RemoveAt(id);
        }

        public void Empty()
        {
            list.Clear();
        }

        public EncounterCharacterViewModel Get(int id)
        {
            return list.FirstOrDefault(x => x.Character_ID == id);
        }

        public IEnumerable<EncounterCharacterViewModel> items
        {
            get
            {
                return list;
            }
        }
    }
}