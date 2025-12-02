using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LumelAssesment.Models
{
    public class CSVData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Name("Order ID")]
        public int OrderID { get; set; }
        [Name("Customer ID")]
        public string CustomerId { get; set; }
        [Name("Customer Name")]
        public string CustomerName { get; set; }
        [Name("Customer Email")]
        public string CustomerEmail { get; set; }
        [Name("Customer Address")]
        public string CustomerAddress { get; set; }
        [Name("Region")]
        public string Region { get; set; }
        [Name("Payment Method")]
        public string PaymentMethod { get; set; }
        [Name("Date of Sale")]
        public DateTime DateOfSale { get; set; }
        [Name("Shipping Cost")]
        public decimal ShippingCost { get; set; }
        [Name("Product ID")]
        public string ProductId { get; set; }
        [Name("Product Name")]
        public string ProductName { get; set; }
        [Name("Category")]
        public string ProductCategory { get; set; }
        [Name("Unit Price")]
        public decimal UnitPrice { get; set; }
        [Name("Discount")]
        public decimal Discount { get; set; }
        [Name("Quantity Sold")]
        public int QuantitySold { get; set; }
    }
}
