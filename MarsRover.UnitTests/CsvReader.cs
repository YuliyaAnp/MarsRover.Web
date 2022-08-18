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
                //Mode = CsvMode.NoEscape,
                Delimiter = "|",
                HasHeaderRecord = false
            };

            var records = new List<T>();
            using (var reader = new StreamReader(File.OpenRead(inputFileName)))
            using (var csv = new CsvReader(reader, config))
            {
                //csv.Read();
                //csv.Context.RegisterClassMap<FestivalMap>();
                records = csv.GetRecords<T>().ToList();
            }

            return records;
        }

        //public sealed class InputMap : ClassMap<CsvRec>
        //{
        //    public FooMap()
        //    {
        //        Map(f => f.Day).Index(0);
        //        Map(f => f.Start).Index(1);
        //        Map(f => f.Lenght).Index(2);
        //        Map(f => f.FilmName).Index(3);
        //        Map(f => f.Rating).Index(4);
        //    }
        //}
    }
}