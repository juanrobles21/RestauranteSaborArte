using System.ComponentModel.DataAnnotations;
using ustaRestaurant.Models;

namespace ustaRestaurant.Data.ViewModels
{
    public class NewProductVM
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Select Product Type")]
        [Required(ErrorMessage = "Movie director is required")]
        public int ProductTypeId { get; set; }
    }
}
