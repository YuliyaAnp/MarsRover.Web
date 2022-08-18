using MarsRover.Core.Models;
using MarsRover.Core.State;

namespace MarsRover.Core
{
    internal class MarsRoverInstance
    {
        internal Coordinates Coordinates { get; set; }
        internal BaseState State { get; set; }

        public Dictionary<string, int> OccupiedCoordinates;

        private readonly Dictionary<char, BaseState> initialStates = new() 
        {
            { (char)Direction.North, new NorthState() },
            { (char)Direction.West, new WestState() },
            { (char)Direction.East, new EastState() },
            { (char)Direction.South, new SouthState() },
        };

        public MarsRoverInstance(Coordinates coordinates, Dictionary<string, int> occupiedCoordinates)
        {
            Coordinates = coordinates;
            OccupiedCoordinates = occupiedCoordinates;
            State = initialStates[(char)coordinates.Direction];
        }

        internal void MoveM()
        {
            State.MoveM(this);
        }

        internal void MoveL()
        {
            State.MoveL(this);
        }

        internal void MoveR()
        {
            State.MoveR(this);
        }
    }
}