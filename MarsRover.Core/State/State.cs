using MarsRover.Core.Models;
using MarsRover.Core.Services;

namespace MarsRover.Core.State
{
    abstract internal class BaseState
    {
        abstract internal void MoveM(MarsRoverInstance roverInstance);

        abstract internal void MoveL(MarsRoverInstance roverInstance);

        abstract internal void MoveR(MarsRoverInstance roverInstance);
    }
}