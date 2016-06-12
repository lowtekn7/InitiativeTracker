using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InitiativeTracker.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace InitiativeTracker.Domain.Concrete
{
    public class EFdbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterGroup> CharacterGroup { get; set; }
        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<EncounterCharacter> ECL { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }


}
