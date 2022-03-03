# TelstraPurple
TelstraPurple-ToyRobot

Developer:

ToyRobot - This is the Executable Console Application. This also has the Visual Studio solution file. For ease of testing/reading I have included all of the projects within this solution. Normally it would just include the Executable and the Logic, but I have included the Unit Tests project as well for simplicity.

To run the ToyRobot solution open the solution file from the ToyRobot folder. You can leave no command line arguments to have the program run with the default tabletop size (6x6) or you can specify the TABLE_SIZE_ENTRY command line argument to allow specification of the table size.

ToyRobot.Logic - This is the class library for the solutions logic.

ToyRobot.Tests - This is the unit tests project - includes 4 basic tests for the place command.

User:

Instructions for use:

NB: Please be aware that commands entered that are invalid will result in the command being discarded - there will be no error given. This includes movements and placements which would result in the robot falling off of the table top.

1. Run the ToyRobot.exe
2. Enter the table top size if requested
3. Place the robot on the table using the following command format: PLACE {X Coordinate},{Y Coordinate},{Direction To Face}
  e.g. PLACE 0,0,NORTH 
  This will place the robot in the south west corner of the tabletop facing north
4. At this point you can use any of the below commands with their results:
  PLACE - The place command can now be specified with or without the direction. i.e. PLACE 5,5 OR PLACE 5,5,NORTH. Both commands are valid. 
    The first will just move the robot to that position
    The second will move the robot and change its direction
    The format still needs to be PLACE {X Coordinate},{Y Coordinate},{Direction To Face}
  MOVE - The move command will move the robot forward one position in the direction it is facing. 
    Be aware that a move command that would attempt to move the robot off of the table will result in the move command being discarded
  REPORT - The report command will display the current position and the Direction that the robot is facing
    If the robot has not been place it will not report anything.
  LEFT - The left command will rotate the robot left in its current position, changing its direction. i.e. NORTH will become WEST
  RIGHT - The right command will rotate the robot right in its current position, changing its direction. i.e. NORTH will become EAST
5. To close the program at any point press Ctrl+C.
