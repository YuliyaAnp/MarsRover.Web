using CsvHelper.Configuration.Attributes;

namespace MarsRover.Core.Models
{
    public class CsvOutputRecord
    {
        [Index(0)]
        public string Coordinates { get; set; }
    }
}
