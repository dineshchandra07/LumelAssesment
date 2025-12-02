using LumelAssesment.DataAccess;
using LumelAssesment.Models;

namespace LumelAssesment.Services
{
    public class OrderdataAccess: IOrderdataAccess
    {
        private readonly LumelDbContext _db;
        public OrderdataAccess(LumelDbContext db)
        {
            _db = db;
        }
        public async Task<int> AddOrder(List<Orders> orders)
        {
            await _db.Orders.AddRangeAsync(orders);
            var result = await _db.SaveChangesAsync();
            return result;
        }
    }
}
