using MarsRover.Core.Models;

namespace MarsRover.Core
{
    public class MarsRoverService
    {
        public Dictionary<int, Coordinates> RoversCoordinates = new();
        public Dictionary<string, int> OccupiedCoordinates = new();

        public void Run(IList<CsvInputRecord> records)
        {
            var roverNumber = 0;
            foreach (var record in records)
            {
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

                RoversCoordinates.Add(roverNumber, marsRover.Coordinates);
                OccupiedCoordinates.Add($"{marsRover.Coordinates.X} {marsRover.Coordinates.Y}", roverNumber);
                roverNumber++;
            }

            //return roversCoordinates;
        }
    }
}