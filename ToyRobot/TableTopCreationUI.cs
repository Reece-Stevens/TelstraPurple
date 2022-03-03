using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Logic;

namespace ToyRobot
{
    public class TableTopCreationUI
    {

        /// <summary>
        /// Requests user entry of the table top details - Get the X and Y lengths for the tabletop
        /// </summary>
        /// <returns></returns>
        public static TableTop DoTableTopCreation()
        {
            TableTop tableTop = new TableTop();
            tableTop.PositionXLength = RequestTableTopXValue();
            tableTop.PositionYLength = RequestTableTopYValue();

            Console.WriteLine($"Table Top has been created with X: {tableTop.PositionXLength} and Y: {tableTop.PositionYLength}");

            return tableTop;
        }

        /// <summary>
        /// Request the X Value of the table top from the user
        /// </summary>
        /// <returns>X value entered by user</returns>
        private static int RequestTableTopXValue()
        {
            Console.WriteLine("Please enter the Length of the Table (X)");
            string? xValueEntered = Console.ReadLine();
            ValidationResult result = UserEntryValidation.ValidateTableTopXValue(xValueEntered);
            if (!result.Success)
            {
                if (SharedUI.AskForRetryOfEntry(result))
                {
                    return RequestTableTopXValue();
                }
                else
                {
                    Environment.Exit(0);
                }
            }

            return int.Parse(xValueEntered);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static int RequestTableTopYValue()
        {
            Console.WriteLine("Please enter the Depth of the Table (Y)");
            string? yValueEntered = Console.ReadLine();
            ValidationResult result = UserEntryValidation.ValidateTableTopYValue(yValueEntered);
            if (!result.Success)
            {
                if (SharedUI.AskForRetryOfEntry(result))
                {
                    return RequestTableTopYValue();
                }
                else
                {
                    Environment.Exit(0);
                }
            }

            return int.Parse(yValueEntered);
        }
    }
}
