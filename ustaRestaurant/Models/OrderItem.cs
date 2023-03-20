using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ustaRestaurant.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Amount is required")]

        public int Amount { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
