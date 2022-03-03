using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Logic
{
    public class MovementResult
    {
        public bool MovementIsSuccessful { get; set; }
        public Direction DirectionFacing { get; set; }
        public Position NewPosition { get; set; }
    }
}
