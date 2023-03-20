using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ustaRestaurant.Data.Services;
using ustaRestaurant.Data.Static;
using ustaRestaurant.Models;

namespace ustaRestaurant.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _service;

        public DeliveryController(IDeliveryService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("NameDelivery,Phone,StateDelivery")] Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                return View(delivery);
            }
            await _service.AddAsync(delivery);
            return RedirectToAction(nameof(Index));
        }
        //Get: Delivery/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var deliveryDetails= await _service.GetByIdAsync(id);

            if (deliveryDetails == null) return View("NotFound");
            return View(deliveryDetails);
        }
        //Get: Delivery/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var deliveryDetails = await _service.GetByIdAsync(id);

            if (deliveryDetails == null) return View("NotFound");
            return View(deliveryDetails);
        }

        //Get: Delivery/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameDelivery,Phone,StateDelivery")] Delivery delivery)
        {
            if (!ModelState.IsValid) return View(delivery);
            {
                if (id == delivery.Id)
                {
                    await _service.UpdateAsync(id, delivery);
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(delivery);
        }
        //Get: Delivery/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var deliveryDetails = await _service.GetByIdAsync(id);

            if (deliveryDetails == null) return View("NotFound");
            return View(deliveryDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryDetails = await _service.GetByIdAsync(id);
            if (deliveryDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

