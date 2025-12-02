using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;

namespace LumelAssesment.Helper
{
    public class CSVHelper: ICSVHelper
    {
        public IEnumerable<T> ReadCSV<T>(Stream file)
        {
            var reader = new StreamReader(file);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<T>();
            return records;
        }
    }
}
