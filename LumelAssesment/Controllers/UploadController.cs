using LumelAssesment.DataAccess;
using LumelAssesment.Helper;
using LumelAssesment.Models;
using LumelAssesment.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LumelAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ICSVHelper _cSVHelper;
        private readonly IOrderdataAccess _IOrderdataAccess;
        private readonly IProductDataAccess _IProductDataAccess;
        private readonly ICustomerDataAccess _ICustomerDataAccess;
        private readonly LumelDbContext _db;
        public UploadController(ICSVHelper cSVHelper, LumelDbContext db, IProductDataAccess iProductDataAccess, ICustomerDataAccess iCustomerDataAccess, IOrderdataAccess IOrderdataAccess)
        {
            _cSVHelper = cSVHelper;
            _db = db;
            _IProductDataAccess = iProductDataAccess;
            _ICustomerDataAccess = iCustomerDataAccess;
            _IOrderdataAccess = IOrderdataAccess;
        }

        [HttpPost("uploadCSV")]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> UploadCSV([FromForm] IFormFileCollection file)
        {
            List<CSVData> csvdata = new List<CSVData>();

            var data = _cSVHelper.ReadCSV<CSVData>(file[0].OpenReadStream());
            csvdata= data.ToList();
            var customerStatus = await _ICustomerDataAccess.AddData(csvdata);

            if (customerStatus == 1)
                return Ok(true);
            else
                return Ok(false);
        }

        [HttpPost("productRevenue")]
        public async Task<IActionResult> productRevenue([FromBody] RevenueCalculation value)
        {
            var result = await _ICustomerDataAccess.RevenueCalculation(value, "product");
            return Ok(result);
        }
        [HttpPost("categroyRevenue")]
        public async Task<IActionResult> CategroyRevenue([FromBody] RevenueCalculation value)
        {
            var result = await _ICustomerDataAccess.RevenueCalculation(value, "categroy");
            return Ok(result);
        }
        [HttpPost("regionRevenue")]
        public async Task<IActionResult> regionRevenue([FromBody] RevenueCalculation value)
        {
            var result = await _ICustomerDataAccess.RevenueCalculation(value, "region");
            return Ok(result);
        }
        [HttpPost("allRevenue")]
        public async Task<IActionResult> AllRevenue([FromBody] RevenueCalculation value)
        {
            var result = await _ICustomerDataAccess.RevenueCalculation(value, "all");
            return Ok(result);
        }
    }
}
