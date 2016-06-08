using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InitiativeTracker.Domain.Entities;

namespace InitiativeTracker.Domain.Abstract
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> Characters { get; }
        Character Save(Character item);
        Character Get(int id);
        void Remove(int id);
    }
}
