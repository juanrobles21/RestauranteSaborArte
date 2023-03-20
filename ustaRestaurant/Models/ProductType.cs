using System.ComponentModel.DataAnnotations;
using ustaRestaurant.Data.Base;

namespace ustaRestaurant.Models
{
    public class ProductType:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name Product Type is required")]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
