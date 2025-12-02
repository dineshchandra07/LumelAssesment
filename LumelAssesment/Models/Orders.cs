using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LumelAssesment.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }
       
        public string PaymentMethod { get; set; }
       
        public DateTime DateOfSale { get; set; }
       
        public decimal ShippingCost { get; set; }

        [ForeignKey("CustomerId")]
        public string CustomerId { get; set; }
        [ForeignKey("ProductId")]
        public string ProductId { get; set; }
    }
}
