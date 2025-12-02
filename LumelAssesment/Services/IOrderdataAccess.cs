using LumelAssesment.Models;

namespace LumelAssesment.Services
{
    public interface IOrderdataAccess
    {
        Task<int> AddOrder(List<Orders> orders);
    }
}
