using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Logic;

namespace ToyRobot
{
    public class ToyRobotUI
    { 
        /// <summary>
        /// This method is used for a recurring request for user entry. The user is allowed to continue entering for as long as they like, or until they exit the console.
        /// </summary>
        /// <param name="tableTop"></param>
        /// <param name="robot"></param>
        public static void DoMovementLogic(TableTop tableTop, IEntity robot)
        {
            while (1 == 1)
            {
                UserEntryValidation.ValidateEntry(tableTop, robot, Console.ReadLine());
            }
        }
    }
}
