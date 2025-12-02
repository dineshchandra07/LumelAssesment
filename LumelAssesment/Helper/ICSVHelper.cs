namespace LumelAssesment.Helper
{
    public interface ICSVHelper
    {
        IEnumerable<T> ReadCSV<T>(Stream file);
    }
}
