using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Logic
{
    public class Movement
    {
        public static Position GetNewPositionAfterMovement(IEntity robot)
        {
            Position newPosition = new Position() { XPosition = robot.CurrentPosition().XPosition, YPosition = robot.CurrentPosition().YPosition };
            if(robot.CurrentDirection() == Direction.North)
            {
                newPosition.YPosition++;
            }
            else if (robot.CurrentDirection() == Direction.South)
            {
                newPosition.YPosition--;
            }
            else if (robot.CurrentDirection() == Direction.East)
            {
                newPosition.XPosition++;
            }
            else if (robot.CurrentDirection() == Direction.West)
            {
                newPosition.XPosition--;
            }

            return newPosition;
        }

        public static void DoMovementIfPossible(TableTop tableTop, IEntity robot)
        {
            Position position = Movement.GetNewPositionAfterMovement(robot);
            if (MovementValidation.ValidateNewPosition(tableTop, position).MovementIsSuccessful)
            {
                robot.Move();
            }
        }
    }
}
