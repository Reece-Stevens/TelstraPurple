using System;

namespace ToyRobot.Logic
{
    public interface IEntity
    {
        void Move();
        void Left();
        void Right();
        void Report();
        void Place(Position position, Direction direction);
        Direction CurrentDirection();
        Position CurrentPosition();
    }
}
