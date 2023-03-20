using System.ComponentModel.DataAnnotations;
using ustaRestaurant.Data.Base;

namespace ustaRestaurant.Models
{
    public class Delivery:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name Delivery  is required")]
        public string NameDelivery { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }

        [Display(Name = "State Delivery")]
        [Required(ErrorMessage = "State Delivery is required")]
        public Boolean StateDelivery { get; set; }
    }
}
