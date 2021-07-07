using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        Rover testRover;
        [TestInitialize]
        public void CreateTestRover()
        {
            testRover = new Rover("NORMAL", 10, 50);
        }
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Assert.AreEqual(testRover.Position, 10);
        }

        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Assert.AreEqual(testRover.Mode, "NORMAL");
        }

        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Assert.AreEqual(testRover.GeneratorWatts, 50);
        }

        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER") };
            Message modeChange = new Message("CHANGE MODE", commands);

            testRover.ReceiveMessage(modeChange);
            Assert.AreEqual(testRover.Mode, commands[0].NewMode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoesNotMoveInLowPower()
        {
            testRover.Mode = "LOW_POWER";
            Command[] commands = { new Command("MOVE", 500) };
            Message move = new Message("MOVE TO 500", commands);
            testRover.ReceiveMessage(move);
        }

        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Command[] commands = { new Command("MOVE", 350) };
            Message move = new Message("MOVE TO 350", commands);
            testRover.ReceiveMessage(move);
            Assert.AreEqual(testRover.Position, 350);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RoverReturnsAMessageForAnUnknownCommand()
        {
            Command[] commands = { new Command("SET ALTIMETER", 320) };
            Message unknown = new Message("THIS COMMAND IS NOT PROGRAMMED", commands);
            testRover.ReceiveMessage(unknown);
        }
    }
}
