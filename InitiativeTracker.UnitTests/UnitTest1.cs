using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using InitiativeTracker.Domain.Concrete;
using InitiativeTracker.Domain.Entities;

namespace InitiativeTracker.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllCharacters()
        {
            //Arrange
            EFCharacterRepository characters = new EFCharacterRepository();


            //Act
            List<Character> Characters = characters.items.ToList();
            int length = Characters.Count;
            

            //Assert
            //Assert.IsNotNull(item);
            Assert.AreEqual(2,length);
        }
    }
}
