using ustaRestaurant.Data.Base;
using ustaRestaurant.Models;

namespace ustaRestaurant.Data.Services
{
    public class BookingService : EntityBaseRepository<Booking>, IBookingService
    {
        public BookingService(ApplicationDbContext context) : base(context) { }
    }
}