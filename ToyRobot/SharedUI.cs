using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Logic;

namespace ToyRobot
{
    public class SharedUI
    {
        public static bool AskForRetryOfEntry(ValidationResult result)
        {
            Console.WriteLine($"Entered value for {result.EntryType} was invalid with the following error: {result.ErrorText}. ");
            Console.WriteLine("Would you like to retry? (Y / N)");
            return UserEntryValidation.RequestEntryRetry(Console.ReadLine()).Retry;
        }
    }
}
