using NUnit.Framework;
using ToyRobot.Logic;

namespace ToyRobot.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Position should still be null on a new robot if the direction is missed.
        [Test]
        public void PlaceCommandMissingDirection_NewRobot()
        {
            TableTop tableTop = new TableTop();
            tableTop.PositionXLength = 6;
            tableTop.PositionYLength = 6;
            IEntity robot = EntityFactory.GetEntity();


            UserEntryValidation.ValidateEntry(tableTop, robot, "PLACE 5,5");

            
            Assert.IsNull(robot.CurrentPosition());
        }

        [Test]
        public void PlaceCommandMissingDirection_ExistingRobot()
        {
            TableTop tableTop = new TableTop();
            tableTop.PositionXLength = 6;
            tableTop.PositionYLength = 6;
            IEntity robot = EntityFactory.GetEntity();

            robot.Place(new Position() { XPosition = 1, YPosition = 1 }, Direction.North);

            UserEntryValidation.ValidateEntry(tableTop, robot, "PLACE 5,5");

            bool xPositionIsFive = robot.CurrentPosition().XPosition == 5;
            bool yPositionIsFive = robot.CurrentPosition().YPosition == 5;
            bool directionIsNorth = robot.CurrentDirection() == Direction.North;


            Assert.IsTrue(xPositionIsFive && yPositionIsFive && directionIsNorth);
        }

        [Test]
        public void PlaceCommandIncludingDirection_NewRobot()
        {
            TableTop tableTop = new TableTop();
            tableTop.PositionXLength = 6;
            tableTop.PositionYLength = 6;
            IEntity robot = EntityFactory.GetEntity();

            UserEntryValidation.ValidateEntry(tableTop, robot, "PLACE 5,5,NORTH");

            bool xPositionIsFive = robot.CurrentPosition().XPosition == 5;
            bool yPositionIsFive = robot.CurrentPosition().YPosition == 5;
            bool directionIsNorth = robot.CurrentDirection() == Direction.North;


            Assert.IsTrue(xPositionIsFive && yPositionIsFive && directionIsNorth);
        }

        [Test]
        public void PlaceCommandIncludingDirection_ExistingRobot()
        {
            TableTop tableTop = new TableTop();
            tableTop.PositionXLength = 6;
            tableTop.PositionYLength = 6;
            IEntity robot = EntityFactory.GetEntity();

            robot.Place(new Position() { XPosition = 1, YPosition = 1 }, Direction.South);

            UserEntryValidation.ValidateEntry(tableTop, robot, "PLACE 5,5,NORTH");

            bool xPositionIsFive = robot.CurrentPosition().XPosition == 5;
            bool yPositionIsFive = robot.CurrentPosition().YPosition == 5;
            bool directionIsNorth = robot.CurrentDirection() == Direction.North;


            Assert.IsTrue(xPositionIsFive && yPositionIsFive && directionIsNorth);
        }
    }
}