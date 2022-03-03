using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Logic
{
    public class ToyRobot : IEntity
    {
        public Direction FacingDirection { get; set; }
        public Position Position { get; set; }

        public Position CurrentPosition()
        {
            return Position;
        }

        public Direction CurrentDirection()
        {
            return FacingDirection;
        }

        public void Left()
        {
            if (FacingDirection == Direction.North)
            {
                FacingDirection = Direction.West;
            }
            else if (FacingDirection == Direction.South)
            {
                FacingDirection = Direction.East;
            }
            else if (FacingDirection == Direction.East)
            {
                FacingDirection = Direction.North;
            }
            else if (FacingDirection == Direction.West)
            {
                FacingDirection = Direction.South;
            }
        }
        public void Right()
        {
            if (FacingDirection == Direction.North)
            {
                FacingDirection = Direction.East;
            }
            else if (FacingDirection == Direction.South)
            {
                FacingDirection = Direction.West;
            }
            else if (FacingDirection == Direction.East)
            {
                FacingDirection = Direction.South;
            }
            else if (FacingDirection == Direction.West)
            {
                FacingDirection = Direction.North;
            }
        }

        public void Move()
        {
            Position = Movement.GetNewPositionAfterMovement(this);
        }

        public void Place(Position position, Direction direction)
        {
            Position = position;
            FacingDirection = direction;
        }

        public void Report()
        {
            if (FacingDirection != null && Position != null)
            {
                Console.WriteLine($"{Position.XPosition},{Position.YPosition},{FacingDirection.ToString().Trim().ToUpper()}");
            }
        }
       
    }
}
