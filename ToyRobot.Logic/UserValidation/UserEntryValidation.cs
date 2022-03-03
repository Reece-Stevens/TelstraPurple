using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Logic
{
    public class UserEntryValidation
    {
        private const string NULL_ENTRY_ERROR = "No Value entered";
        private const string SUCCESSFUL_ENTRY = "Successful";
        private const string VALUE_ENTERED_NOT_NUMBER = "Entered value is not a number.";
        private const string VALUE_ENTERED_LESS_THAN_ZERO = "The value entered must be greater than zero.";

        /// <summary>
        /// Method to determine if the entered value is attempting to retry a failed entry value
        /// </summary>
        /// <param name="retryValue"></param>
        /// <returns>A Retry Result with Retry boolean</returns>
        public static RetryResult RequestEntryRetry(string? retryValue)
        {
            //If they don't enter anything, retry anyway, thats better than losing the simulation up until this point.
            if (retryValue == null)
            {
                return new RetryResult() { Retry = true };
            }
            else
            {
                if (retryValue.Trim().ToUpper() == "N")
                {
                    return new RetryResult() { Retry = false };
                }
                else
                {
                    //Retry result should be default to retry so you don't lost your work.
                    return new RetryResult() { Retry = true };
                }
            }
        }

        /// <summary>
        /// Public table top validation for the creation of the TableTop object. The entry for X must be an integer.
        /// </summary>
        /// <param name="userEntry"></param>
        /// <returns>Validation Result</returns>
        public static ValidationResult ValidateTableTopXValue(string? userEntry)
        {
            return ValidateTableTopValue("X", userEntry);
        }

        /// <summary>
        /// Public table top validation for the creation of the TableTop object. The entry for Y must be an integer.
        /// </summary>
        /// <param name="userEntry"></param>
        /// <returns></returns>
        public static ValidationResult ValidateTableTopYValue(string? userEntry)
        {
            return ValidateTableTopValue("Y", userEntry);
        }

        /// <summary>
        /// Private logic for how the table top value must be entered for a successful entry. Both table top values must be non-null integers
        /// </summary>
        /// <param name="tableTopDirection"></param>
        /// <param name="userEntry"></param>
        /// <returns></returns>
        private static ValidationResult ValidateTableTopValue(string tableTopDirection, string? userEntry)
        {
            string validationEntry = $"Table Top {tableTopDirection}";
            if (userEntry == null)
            {
                return new ValidationResult() { EntryType = validationEntry, ErrorText = NULL_ENTRY_ERROR, Success = false };
            }
            else
            {
                //The only time that the X Value is valid is if it can be successfully Parsed as an int. 
                //Any other result returns a validation error
                try
                {
                    int tableValue = int.Parse(userEntry.Trim());
                    if (tableValue > 0)
                    {
                        return new ValidationResult() { EntryType = validationEntry, ErrorText = SUCCESSFUL_ENTRY, Success = true };
                    }
                    else
                    {
                        return new ValidationResult() { EntryType = validationEntry, ErrorText = VALUE_ENTERED_LESS_THAN_ZERO, Success = false };
                    }
                }
                catch
                {
                    return new ValidationResult() { EntryType = validationEntry, ErrorText = VALUE_ENTERED_NOT_NUMBER, Success = false };
                }
            }
        }

        public static void ValidateEntry(TableTop tableTop, IEntity robot, string? entryValue)
        {
            if (entryValue != null)
            {

                if (robot.CurrentPosition() == null && !entryValue.StartsWith("PLACE"))
                {
                    //Ignore all attempts to do anything with the robot if it isnt placed.
                    return;
                }
                else
                {
                    entryValue = entryValue.Trim().ToUpper();
                    if (entryValue.StartsWith("PLACE"))
                    {
                        MovementResult result = MovementValidation.ValidatePlacementParametersEntered(entryValue, robot);
                        if (result.MovementIsSuccessful)
                        {
                            if (MovementValidation.ValidateNewPosition(tableTop, result.NewPosition).MovementIsSuccessful)
                            {
                                robot.Place(result.NewPosition, result.DirectionFacing);
                            }
                        }
                    }
                    else if (entryValue == "MOVE")
                    {
                        Movement.DoMovementIfPossible(tableTop, robot);
                    }
                    else if (entryValue == "REPORT")
                    {
                        robot.Report();
                    }
                    else if (entryValue == "LEFT")
                    {
                        robot.Left();
                    }
                    else if (entryValue == "RIGHT")
                    {
                        robot.Right();
                    }
                }
            }
        }
    }
}
