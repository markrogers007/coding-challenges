using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RobotWars.Tests
{
    [TestClass()]
    public class RobotTests
    {
        // Arena  2, 3 -> 2,3
        [TestMethod()]
        public void RobotTestArena()
        {
            //Arrange
            Arena arena = new Arena(2, 3);
            int expectedX = 2;
            int expectedY = 3;
            //Act

            //Assert
            Assert.AreEqual(expectedX,arena.RightHandCornerX);
            Assert.AreEqual(expectedY, arena.RightHandCornerY);
        }

        // Robot  2, 3, True -> 2,3, True
        [TestMethod()]
        public void RobotTestValid()
        {
            //Arrange
            Robot robot = new Robot(1, 2, "M");
            int expectedX = 1;
            int expectedY = 2;
            string expectedMove = "M";
            //Act

            //Assert
            Assert.AreEqual(expectedX, robot.X);
            Assert.AreEqual(expectedY, robot.Y);
            Assert.AreEqual(expectedMove, robot.compassPoint);
        }

        // filenotfoundexecption
        [TestMethod()] 
        [ExpectedException(typeof(FileNotFoundException))]
        public void RobotTestFileNotFound()
        {
            //Arrange
            ReadWarFile.ReadFromFile("nosuchfile");
            //Act
            //Assert
        }
        // fileGeneralExecption
        [TestMethod()]
        public void RobotTestFileGeneralException()
        {
            //Arrange
            Exception exception = null;
            //Act
            try
            {
                ReadWarFile.ReadFromFile("../../nosuchdirectory/nosuchfile");
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            //Assert
            Assert.IsNotNull(exception);
        }

        [TestMethod()][Ignore]
        [ExpectedException(typeof(ArgumentException))]
        public void RobotTestInvalidArenaArguments()
        {
            //Arrange
            RobotWars robotWars = new RobotWars();
            //Act
            robotWars.StartWar();
            //Assert
        }

        [TestMethod()][Ignore]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RobotTestInvalidArenaGrid()
        {
            //Arrange
            RobotWars robotWars = new RobotWars();
            //Act
            robotWars.StartWar();
            //Assert
        }

        [TestMethod()]
        public void RobotTestRotateLeft()
        {
            //Arrange
            Robot robot = new Robot(1, 2, "N");
            int expectedX = 1;
            int expectedY = 2;
            string expectedMove = "W";
            //Act

            robot.MoveRobot("L");

            //Assert
            Assert.AreEqual(expectedX, robot.X);
            Assert.AreEqual(expectedY, robot.Y);
            Assert.AreEqual(expectedMove, robot.compassPoint);
        }

        [TestMethod()]
        public void RobotTestRotateRight()
        {
            //Arrange
            Robot robot = new Robot(1, 2, "N");
            int expectedX = 1;
            int expectedY = 2;
            string expectedMove = "E";
            //Act

            robot.MoveRobot("R");

            //Assert
            Assert.AreEqual(expectedX, robot.X);
            Assert.AreEqual(expectedY, robot.Y);
            Assert.AreEqual(expectedMove, robot.compassPoint);
        }

        [TestMethod()]
        public void RobotTestMoveUp()
        {
            //Arrange
            Robot robot = new Robot(1, 2, "N");
            int expectedX = 1;
            int expectedY = 3;
            string expectedMove = "N";
            //Act

            robot.MoveRobot("M");

            //Assert
            Assert.AreEqual(expectedX, robot.X);
            Assert.AreEqual(expectedY, robot.Y);
            Assert.AreEqual(expectedMove, robot.compassPoint);
        }

        [TestMethod()]
        public void RobotTestMoveDown()
        {
            //Arrange
            Robot robot = new Robot(1, 2, "S");
            int expectedX = 1;
            int expectedY = 1;
            string expectedMove = "S";
            //Act

            robot.MoveRobot("M");

            //Assert
            Assert.AreEqual(expectedX, robot.X);
            Assert.AreEqual(expectedY, robot.Y);
            Assert.AreEqual(expectedMove, robot.compassPoint);
        }

        [TestMethod()]
        public void RobotTestMoveLeft()
        {
            //Arrange
            Robot robot = new Robot(1, 2, "W");
            int expectedX = 0;
            int expectedY = 2;
            string expectedMove = "W";
            //Act

            robot.MoveRobot("M");

            //Assert
            Assert.AreEqual(expectedX, robot.X);
            Assert.AreEqual(expectedY, robot.Y);
            Assert.AreEqual(expectedMove, robot.compassPoint);
        }


        [TestMethod()]
        public void RobotTestMoveRight()
        {
            //Arrange
            Robot robot = new Robot(1, 2, "E");
            int expectedX = 2;
            int expectedY = 2;
            string expectedMove = "E";
            //Act

            robot.MoveRobot("M");

            //Assert
            Assert.AreEqual(expectedX, robot.X);
            Assert.AreEqual(expectedY, robot.Y);
            Assert.AreEqual(expectedMove, robot.compassPoint);
        }
    }
}