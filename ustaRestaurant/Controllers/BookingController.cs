using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ustaRestaurant.Data.Services;
using ustaRestaurant.Data.Static;
using ustaRestaurant.Models;

namespace ustaRestaurant.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        [Authorize(Roles = UserRoles.User)]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,PhoneNumber,Email,HowMany,Date")] Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return View(booking);
            }
            await _service.AddAsync(booking);
            return RedirectToAction("Index", "Home", null);
        }
        //Get: Booking/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var bookingsDetails = await _service.GetByIdAsync(id);

            if (bookingsDetails == null) return View("NotFound");
            return View(bookingsDetails);
        }
        //Get: Booking/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var bookingsDetails = await _service.GetByIdAsync(id);

            if (bookingsDetails == null) return View("NotFound");
            return View(bookingsDetails);
        }

        //Get: Booking/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,PhoneNumber,Email,HowMany,Date")] Booking booking)
        {
            if (!ModelState.IsValid) return View(booking);
            {
                if (id == booking.Id)
                {
                    await _service.UpdateAsync(id, booking);
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(booking);
        }
        //Get: Booking/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var bookingsDetails = await _service.GetByIdAsync(id);

            if (bookingsDetails == null) return View("NotFound");
            return View(bookingsDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingsDetails = await _service.GetByIdAsync(id);
            if (bookingsDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}