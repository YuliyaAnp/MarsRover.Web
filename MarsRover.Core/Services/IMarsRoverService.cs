using MarsRover.Core.Models;

namespace MarsRover.Core.Services
{
    public interface IMarsRoverService
    {
        public Dictionary<int, Coordinates> FinalRoverCoordinates { get; set; }

        void Run(IList<CsvInputRecord> records);
    }
}