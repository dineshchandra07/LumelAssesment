using LumelAssesment.Models;

namespace LumelAssesment.Services
{
    public interface ICustomerDataAccess
    {
        Task<int> AddCustomer(List<Customers> customers);
        Task<int> AddData(List<CSVData> csvData);
        Task<double> RevenueCalculation(RevenueCalculation data, string Type);
    }
}
