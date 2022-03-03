using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Logic
{
    public class EntityFactory
    {
        public static IEntity GetEntity()
        {
            return new ToyRobot();
        }
    }
}
