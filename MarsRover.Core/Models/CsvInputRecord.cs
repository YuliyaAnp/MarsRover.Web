using CsvHelper.Configuration.Attributes;

namespace MarsRover.Core.Models
{
    public class CsvInputRecord
    {
        [Index(0)]
        public string Coordinates { private get; set; }

        [Index(1)]
        public string Steps { get; set; }

        public Coordinates GetCoordinates()
        {
            var s = Coordinates.Split(" ");
            return new Coordinates
            {
                X = int.Parse(s[0]),
                Y = int.Parse(s[1]),
                Direction = (Direction)char.Parse(s[2])
            };
        }
    }
}
