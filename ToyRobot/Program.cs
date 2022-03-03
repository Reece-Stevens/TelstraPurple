using System;
using ToyRobot.Logic;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            bool userEntryOfTableSize = false;
            foreach (string arg in args)
            {
                if (arg.Trim().ToUpper() == "TABLE_SIZE_ENTRY")
                {
                    userEntryOfTableSize = true;
                }
            }
            StartToyRobotSimulation(userEntryOfTableSize);
        }

        private static void StartToyRobotSimulation(bool userEntryOfTableSize)
        {
            Console.WriteLine("Welcome to Toy Robot Simulator. ");
            if (userEntryOfTableSize)
            {
                Console.WriteLine("You are running in Create Table Mode");
                Console.WriteLine("Please Create a Table Top size by providing the X and Y lengths");
            }

            TableTop tableTop = new TableTop() { PositionXLength = 6, PositionYLength = 6 };
            if (userEntryOfTableSize)
            {
                tableTop = TableTopCreationUI.DoTableTopCreation();
            }

            Console.WriteLine("Please place your Robot on the table to begin.");

            //Just in case we extend this to not only support robots, but any other entity.
            IEntity robot = EntityFactory.GetEntity();

            ToyRobotUI.DoMovementLogic(tableTop, robot);
        }
    }
}
