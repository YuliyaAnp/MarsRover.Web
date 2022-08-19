using MarsRover.Core.Models;
using MarsRover.Core.Services;

namespace MarsRover.Core
{
    public class MarsRoverService : IMarsRoverService
    {
        public MarsRoverService()
        {
            OccupiedCoordinates = new();
            FinalRoverCoordinates = new();
        }

        public Dictionary<int, Coordinates> FinalRoverCoordinates { get; set; }
        public Dictionary<string, int> OccupiedCoordinates { get; set; }

        public void Run(IList<CsvInputRecord> records)
        {
            SetInitialOccupiedCoordinates(records);

            var roverNumber = 0;
            foreach (var record in records)
            {
                RemoveCurrentRoverCoordinatesFromOccupiedCoordinates(record);

                var marsRover = new MarsRoverInstance(record.GetCoordinates(), OccupiedCoordinates);

                foreach (var movement in record.Steps.ToCharArray())
                {
                    try
                    {
                        switch (movement)
                        {
                            case 'M':
                                marsRover.MoveM();
                                break;
                            case 'L':
                                marsRover.MoveL();
                                break;
                            case 'R':
                                marsRover.MoveR();
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        //logging
                        break;
                    }
                }

                FinalRoverCoordinates.Add(roverNumber, marsRover.Coordinates);
                OccupiedCoordinates[$"{marsRover.Coordinates.X} {marsRover.Coordinates.Y}"] = roverNumber;
                roverNumber++;
            }
        }

        private void RemoveCurrentRoverCoordinatesFromOccupiedCoordinates(CsvInputRecord record)
        {
            OccupiedCoordinates.Remove($"{record.GetCoordinates().X} {record.GetCoordinates().Y}");
        }

        private void SetInitialOccupiedCoordinates(IList<CsvInputRecord> records)
        {
            for (var i = 0; i < records.Count; i++)
            {
                var coords = records[i].GetCoordinates();
                if (OccupiedCoordinates.ContainsKey($"{coords.X} {coords.Y}"))
                {
                    throw new Exception("Invalid input");
                }

                OccupiedCoordinates.Add($"{coords.X} {coords.Y}", i);
            }
        }
    }
}