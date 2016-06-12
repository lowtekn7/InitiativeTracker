using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InitiativeTracker.Domain.Entities;

namespace InitiativeTracker.Domain.Abstract
{
    public interface IEncounterRepository : IDefaultRepository<Encounter>
    {
        
    }

    public interface IECLRepository : IDefaultRepository<EncounterCharacter>
    {
        IEnumerable<EncounterCharacter> CharactersFor(int id);
        void RemoveAll(int id);
    }
}
