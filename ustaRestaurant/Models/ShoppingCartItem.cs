using System.ComponentModel.DataAnnotations;

namespace ustaRestaurant.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Product")]
        [Required(ErrorMessage = "Product is required")]
        public Product Product { get; set; }
        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Amount is required")]
        public int Amount { get; set; }

        [Display(Name = "Shopping Id")]
        [Required(ErrorMessage = "Shopping Id is required")]
        public string ShoppingCartId  { get; set; }
    }
}
