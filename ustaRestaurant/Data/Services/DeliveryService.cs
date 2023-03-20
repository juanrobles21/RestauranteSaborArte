using Microsoft.EntityFrameworkCore;
using ustaRestaurant.Models;
using ustaRestaurant.Data.Base;

namespace ustaRestaurant.Data.Services
{
    public class DeliveryService : EntityBaseRepository<Delivery>, IDeliveryService
    {
        public DeliveryService(ApplicationDbContext context) : base(context) { }
    }
}
