using LumelAssesment.DataAccess;
using LumelAssesment.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace LumelAssesment.Services
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private readonly LumelDbContext _db;
        public CustomerDataAccess(LumelDbContext db)
        {
            _db = db;
        }
        public async Task<int> AddCustomer(List<Customers> customers)
        {
            await _db.Customers.AddRangeAsync(customers);
            var result = await _db.SaveChangesAsync();
            return result;
        }
        public async Task<int> AddData(List<CSVData> csvData)
        {
            await _db.OrderHistory.AddRangeAsync(csvData);
            var result = await _db.SaveChangesAsync();
            return result;
        }
        public async Task<double> RevenueCalculation(RevenueCalculation data, string Type)
        {
            List<CSVData> products = new List<CSVData>();
            var totalrevenue = 0.0;
            if (Type == "product")
                products = await _db.OrderHistory.Where(x => x.ProductId == data.Id && x.DateOfSale >= data.From && x.DateOfSale <= data.To).ToListAsync();
            else if (Type == "categroy")
                products = await _db.OrderHistory.Where(x => x.ProductCategory == data.Id && x.DateOfSale >= data.From && x.DateOfSale <= data.To).ToListAsync();
            else if (Type == "region")
                products = await _db.OrderHistory.Where(x => x.Region == data.Id && x.DateOfSale >= data.From && x.DateOfSale <= data.To).ToListAsync();
            else if (Type == "all")
                products = await _db.OrderHistory.Where(x => x.DateOfSale >= data.From && x.DateOfSale <= data.To).ToListAsync();
            foreach (var item in products)
            {
                if (item.QuantitySold != 0)
                    totalrevenue += Convert.ToInt32(item.UnitPrice) * item.QuantitySold;
            }
            return totalrevenue;
        }
       
    }
}
