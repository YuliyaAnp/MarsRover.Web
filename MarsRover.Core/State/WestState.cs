using MarsRover.Core.Models;
using MarsRover.Core.Services;

namespace MarsRover.Core.State
{
    internal class WestState : BaseState
    {
        internal override void MoveL(MarsRoverInstance roverInstance)
        {
            roverInstance.State = new SouthState();
            roverInstance.Coordinates.Direction = Direction.South;
        }

        internal override void MoveR(MarsRoverInstance roverInstance)
        {
            roverInstance.State = new NorthState();
            roverInstance.Coordinates.Direction = Direction.North;
        }

        internal override void MoveM(MarsRoverInstance roverInstance)
        {
            if (roverInstance.Coordinates.X - 1 < Constants.XMin)
            {
                throw new Exception(Constants.OutOfGridErrorMessage);
            }

            if (roverInstance.OccupiedCoordinates.ContainsKey($"{roverInstance.Coordinates.X - 1} {roverInstance.Coordinates.Y}"))
            {
                throw new Exception(Constants.CellIsOccupiedErrorMessage);
            }

            roverInstance.Coordinates.X = roverInstance.Coordinates.X - 1;
        }
    }
}