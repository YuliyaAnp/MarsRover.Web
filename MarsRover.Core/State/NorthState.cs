using MarsRover.Core.Models;

namespace MarsRover.Core.State
{
    internal class NorthState : BaseState
    {
        internal override void MoveL(MarsRoverInstance roverInstance)
        {
            roverInstance.State = new WestState();
            roverInstance.Coordinates.Direction = Direction.West;
        }

        internal override void MoveR(MarsRoverInstance roverInstance)
        {
            roverInstance.State = new EastState();
            roverInstance.Coordinates.Direction = Direction.East;
        }

        internal override void MoveM(MarsRoverInstance roverInstance)
        {
            if (roverInstance.Coordinates.Y + 1 > Constants.YMax)
            {
                throw new Exception("Steps are incorrect: rover is sent out of grid!");
            }

            if (roverInstance.OccupiedCoordinates.ContainsKey($"{roverInstance.Coordinates.X} {roverInstance.Coordinates.Y + 1}"))
            {
                throw new Exception("The cell is occupied by another rover! Select another route.");
            }

            roverInstance.Coordinates.Y = roverInstance.Coordinates.Y + 1;
        }        
    }
}