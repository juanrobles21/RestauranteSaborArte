using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ustaRestaurant.Data.Services;
using ustaRestaurant.Data.Static;
using ustaRestaurant.Models;

namespace ustaRestaurant.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CommentController : Controller
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
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
        public async Task<IActionResult> Create([Bind("FullName,qualification,Opinion")] Comment Comment)
        {
            if (!ModelState.IsValid)
            {
                return View(Comment);
            }
            await _service.AddAsync(Comment);
            return RedirectToAction(nameof(Index));
        }
        //Get: Comments/Details/1

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var CommentDetails = await _service.GetByIdAsync(id);

            if (CommentDetails == null) return View("NotFound");
            return View(CommentDetails);
        }
        //Get: Comment/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var CommentDetails = await _service.GetByIdAsync(id);

            if (CommentDetails == null) return View("NotFound");
            return View(CommentDetails);
        }

        //Get: Comment/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,qualification,Opinion")] Comment Comment)
        {
            if (!ModelState.IsValid) return View(Comment);
            {
                if (id == Comment.Id)
                {
                    await _service.UpdateAsync(id, Comment);
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(Comment);
        }
        //Get: Comment/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var CommentDetails = await _service.GetByIdAsync(id);

            if (CommentDetails == null) return View("NotFound");
            return View(CommentDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CommentDetails = await _service.GetByIdAsync(id);
            if (CommentDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

