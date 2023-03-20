using Microsoft.EntityFrameworkCore;
using ustaRestaurant.Models;
using ustaRestaurant.Data.Base;

namespace ustaRestaurant.Data.Services
{
    public class ProductTypeService : EntityBaseRepository<ProductType>, IProductTypeService
    {
       public ProductTypeService(ApplicationDbContext context) : base(context) { }
    }
}
