using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 500) };
        
        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
                new Message("", commands);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Message name required.", ex.Message);
            }
        }

        [TestMethod]
        public void ConstructorSetsName()
        {
            Message test = new Message("Name", commands);
            Assert.AreEqual(test.Name, "Name");
        }

        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            Message test = new Message("Name", commands);
            Assert.AreEqual(test.Commands, commands);
        }

    }
}
