using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InitiativeTracker.Domain.Entities;

namespace InitiativeTracker.Domain.Abstract
{
    public interface ICharacterGroupRepository
    {
        IEnumerable<CharacterGroup> Groups { get; }
        CharacterGroup Save(CharacterGroup item);
        CharacterGroup Get(int id);
        CharacterGroup Update(CharacterGroup item, int id);
        void Remove(int id);
    }
}
