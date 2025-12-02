using LumelAssesment.DataAccess;
using LumelAssesment.Models;

namespace LumelAssesment.Services
{
    public class ProductsDataAccess:IProductDataAccess
    {
        private readonly LumelDbContext _db;
        public ProductsDataAccess(LumelDbContext db)
        {
            _db = db;
        }
        public async Task<int> AddProducts(List<Products> products)
        {
            await _db.Products.AddRangeAsync(products);
            var result = await _db.SaveChangesAsync();
            return result;
        }
    }
}
