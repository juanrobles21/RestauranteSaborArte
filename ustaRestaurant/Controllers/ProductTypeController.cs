using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ustaRestaurant.Data.Services;
using ustaRestaurant.Data.Static;
using ustaRestaurant.Models;

namespace ustaRestaurant.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService _service;

        public ProductTypeController(IProductTypeService service)
        {
            _service = service;
        }
        [AllowAnonymous]
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
        public async Task<IActionResult> Create([Bind("Name")] ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return View(productType);
            }
            await _service.AddAsync(productType);
            return RedirectToAction(nameof(Index));
        }
        //Get: ProductTypes/Details/1

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var productTypeDetails = await _service.GetByIdAsync(id);

            if (productTypeDetails == null) return View("NotFound");
            return View(productTypeDetails);
        }
        //Get: ProductType/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var productTypeDetails = await _service.GetByIdAsync(id);

            if (productTypeDetails == null) return View("NotFound");
            return View(productTypeDetails);
        }

        //Get: ProductType/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProductType productType)
        {
            if (!ModelState.IsValid) return View(productType);
            {
                if (id == productType.Id)
                {
                    await _service.UpdateAsync(id, productType);
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(productType);
        }
        //Get: ProductType/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var productTypeDetails = await _service.GetByIdAsync(id);

            if (productTypeDetails == null) return View("NotFound");
            return View(productTypeDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productTypeDetails = await _service.GetByIdAsync(id);
            if (productTypeDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

