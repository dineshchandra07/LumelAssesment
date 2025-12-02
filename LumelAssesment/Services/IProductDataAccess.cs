using LumelAssesment.Models;

namespace LumelAssesment.Services
{
    public interface IProductDataAccess
    {
        Task<int> AddProducts(List<Products> products);
    }
}
