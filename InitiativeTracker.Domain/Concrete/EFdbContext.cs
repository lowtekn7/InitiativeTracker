using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InitiativeTracker.Domain.Entities;

namespace InitiativeTracker.Domain.Concrete
{
    public class EFdbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
    }
}
