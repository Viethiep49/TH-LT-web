using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebsiteBanHang.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required]
        public string ApplicationUserId { get; set; }
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; } = "Pending";

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string ShippingAddress { get; set; }
        public string? Notes { get; set; }
        
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
