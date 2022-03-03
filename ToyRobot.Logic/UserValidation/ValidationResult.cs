using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Logic
{
    public class ValidationResult
    {
        public string ErrorText { get; set; }
        public string EntryType { get; set; }

        public bool Success { get; set; }
        public ValidationResult()
        {
        }
    }
}
