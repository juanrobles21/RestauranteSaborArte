using Microsoft.EntityFrameworkCore;
using ustaRestaurant.Models;
using ustaRestaurant.Data.Base;
using ustaRestaurant.Data.ViewModels;

namespace ustaRestaurant.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                Image = data.Image,
                Price = data.Price,
                ProductTypeId = data.ProductTypeId,
                
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            await _context.SaveChangesAsync();
        }
        public Task DeleteProductAsync(NewProductVM data)
        {
            throw new NotImplementedException();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var ProductDetails = await _context.Products
                .Include(pt => pt.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);

            return ProductDetails;
        }
        public async Task<NewProductDropdownsVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownsVM()
            {
                ProductTypes = await _context.ProductTypes.OrderBy(pt => pt.Name).ToListAsync(),
                
            };

            return response;
        }
        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == data.Id);
            if (dbProduct != null)
            {

                dbProduct.Name = data.Name;
                dbProduct.Description = data.Description;
                dbProduct.Image = data.Image;
                dbProduct.Price = data.Price;
                dbProduct.ProductTypeId = data.ProductTypeId;
                await _context.SaveChangesAsync();
            }
        }
    }
}