using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace MarsRover.UnitTests
{
    public static class CsvReader<T>
    {
        public static IList<T> ReadCsv(string inputFileName)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "|",
                HasHeaderRecord = false
            };

            var records = new List<T>();
            using (var reader = new StreamReader(File.OpenRead(inputFileName)))
            using (var csv = new CsvReader(reader, config))
            {
                records = csv.GetRecords<T>().ToList();
            }

            return records;
        }
    }
}