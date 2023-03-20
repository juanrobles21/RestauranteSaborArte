using ustaRestaurant.Models;

namespace ustaRestaurant.Data.ViewModels
{
    public class NewProductDropdownsVM
    {
        public List<ProductType> ProductTypes { get; set; }

        public NewProductDropdownsVM()
        {
            ProductTypes = new List<ProductType>();
        }
    }
}
