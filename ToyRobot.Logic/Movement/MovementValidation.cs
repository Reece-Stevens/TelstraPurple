using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Logic
{
    public class MovementValidation
    {
        public  static MovementResult ValidatePlacementParametersEntered(string? entryValue, IEntity robot)
        {
            if (entryValue != null)
            {
                try
                {
                    //placement format is PLACE X,Y,DIRECTION
                    string[] placementArgs = entryValue.Split(" ");
                    if (placementArgs.Length == 2)
                    {
                        //First index of placement args is the place command
                        //Second index of placement args is the X,Y,DIRECTION

                        //Splitting basedoff of comma here, should result in 3 values when the place command has been sent with direction
                        //and 2 when the place command is sent without direction.

                        //In the case where the direction isn't provided the robot needs to stay the same direction, but the position should change.
                        string[] positionAndDirection = placementArgs[1].Split(",");

                        Direction directionEntered = robot.CurrentDirection();
                        if(positionAndDirection.Length > 2)
                        {
                            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
                            {
                                if (direction.ToString().Trim().ToUpper() == positionAndDirection[2].Trim().ToUpper())
                                {
                                    directionEntered = direction;
                                }
                            }
                        }

                        //So this is to catch the case where the robot hasnt been placed yet, but there has been attempt made to place it without specifying direction
                        //This wasn't a hard constraint specified in the requirements, however deciding the direction without user input would result in unexpected values/outcomes.
                        if (robot.CurrentPosition() == null && positionAndDirection.Length <= 2)
                        {
                            return new MovementResult() { MovementIsSuccessful = false };
                        }

                        //Create the new positon and return that as part of a movement result. This position has not yet been validated as a position available on the tabletop, so it still needs to call ValidateNewPosition
                        Position newProposedPosition = new Position() { XPosition = int.Parse(positionAndDirection[0]), YPosition = int.Parse(positionAndDirection[1]), Successful = true };
                        return new MovementResult() { DirectionFacing = directionEntered, MovementIsSuccessful = true, NewPosition = newProposedPosition };
                    }
                }
                catch
                {

                }
            }
            return new MovementResult() { MovementIsSuccessful = false };
        }

        /// <summary>
        /// Validate that the new positon that is provided is within the table top that has been created.
        /// Return a MovementResult with an unsuccesful flag if the position is not valid.
        /// </summary>
        /// <param name="tableTop"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static MovementResult ValidateNewPosition(TableTop tableTop, Position position)
        {
            //The new position provided must be within the tabletop, otherwise a movement result with an unsucessful flag will be sent back.
            if (position.XPosition <= tableTop.PositionXLength - 1 && position.YPosition <= tableTop.PositionYLength - 1 && position.XPosition >= 0 && position.YPosition >= 0)
            {
                return new MovementResult() { MovementIsSuccessful = true };
            }
            else
            {
                return new MovementResult() { MovementIsSuccessful = false };
            }
        }
    }
}
