using ustaRestaurant.Models;
using ustaRestaurant.Data.Base;
using ustaRestaurant.Data.ViewModels;

namespace ustaRestaurant.Data.Services
{
    public interface IProductService : IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<NewProductDropdownsVM> GetNewProductDropdownsValues();
        Task AddNewProductAsync(NewProductVM data);
        Task UpdateProductAsync(NewProductVM data);
        Task DeleteProductAsync(NewProductVM data);
    }
}
