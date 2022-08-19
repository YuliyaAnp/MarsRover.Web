using MarsRover.Core;
using MarsRover.Core.Models;
using Xunit;

namespace MarsRover.UnitTests
{
    public class MarsRoverServiceShould
    {
        [Theory]
        [InlineData("Input\\oneRover.csv", "Output\\oneRover.csv")]
        [InlineData("Input\\multipleRovers.csv", "Output\\multipleRovers.csv")]
        public void ReturnCorrectCoordinates_WhenValidSteps(string inputFileName, string outputFileName)
        {
            var marsRoverService = new MarsRoverService();
            IList<CsvInputRecord> inputRecords = CsvReader<CsvInputRecord>.ReadCsv(inputFileName);
            IList<CsvOutputRecord> outputRecords = CsvReader<CsvOutputRecord>.ReadCsv(outputFileName);

            Assert.Equal(inputRecords.Count, outputRecords.Count);

            marsRoverService.Run(inputRecords);
            var results = marsRoverService.FinalRoverCoordinates;

            for (int i = 0; i < results.Count; i++)
            {
                var csvResult = $"{results[i].X} {results[i].Y} {(char)results[i].Direction}";
                Assert.Equal(outputRecords[i].Coordinates, csvResult);
            }  
        }

        [Theory]
        [InlineData("Input\\roverOutOfGrid.csv", "Output\\roverOutOfGrid.csv")]
        public void StopOnTheEdgeOfTheGrid_WhenStepsLeadRoverOutOfGrid(string inputFileName, string outputFileName)
        {
            var marsRoverService = new MarsRoverService();
            IList<CsvInputRecord> inputRecords = CsvReader<CsvInputRecord>.ReadCsv(inputFileName);
            IList<CsvOutputRecord> outputRecords = CsvReader<CsvOutputRecord>.ReadCsv(outputFileName);

            Assert.Equal(inputRecords.Count, outputRecords.Count);

            marsRoverService.Run(inputRecords);
            var results = marsRoverService.FinalRoverCoordinates;

            for (int i = 0; i < results.Count; i++)
            {
                var csvResult = $"{results[i].X} {results[i].Y} {(char)results[i].Direction}";
                Assert.Equal(outputRecords[i].Coordinates, csvResult);
            }
        }

        [Theory]
        [InlineData("Input\\roversCross-secondCrossesFirst.csv", "Output\\roversCross-secondCrossesFirst.csv")] 
        [InlineData("Input\\roversCross-firstCrossesSecond.csv", "Output\\roversCross-firstCrossesSecond.csv")]
        public void StopOnTheCurrentCellOfTheGrid_WhenCrossWithOtherRover(string inputFileName, string outputFileName)
        {
            var marsRoverService = new MarsRoverService();
            IList<CsvInputRecord> inputRecords = CsvReader<CsvInputRecord>.ReadCsv(inputFileName);
            IList<CsvOutputRecord> outputRecords = CsvReader<CsvOutputRecord>.ReadCsv(outputFileName);

            Assert.Equal(inputRecords.Count, outputRecords.Count);

            marsRoverService.Run(inputRecords);
            var results = marsRoverService.FinalRoverCoordinates;

            for (int i = 0; i < results.Count; i++)
            {
                var csvResult = $"{results[i].X} {results[i].Y} {(char)results[i].Direction}";
                Assert.Equal(outputRecords[i].Coordinates, csvResult);
            }
        }

        [Theory]
        [InlineData("Input\\invalidInput.csv")]
        public void ReturnError_WhenInvalidInput(string inputFileName)
        {
            var marsRoverService = new MarsRoverService();
            IList<CsvInputRecord> inputRecords = CsvReader<CsvInputRecord>.ReadCsv(inputFileName);

            Assert.Throws<Exception>(() => marsRoverService.Run(inputRecords));
        }
    }
}
