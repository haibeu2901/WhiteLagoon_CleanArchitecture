using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers.Mvc
{
    public class VillaRoomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VillaRoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var villaRooms = _context.VillaRooms.ToList();
            return View(villaRooms);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if (obj.Name.Equals(obj.Description))
            {
                ModelState.AddModelError("Name", "The description cannot exactly match the name.");
            }

            if (ModelState.IsValid)
            {
                _context.Villas.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "The Villa has been created successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error while creating the Villa";
            return View();
        }

        public IActionResult Update(int villaId)
        {
            Villa? obj = _context.Villas.FirstOrDefault(v => v.VillaId == villaId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Villa obj)
        {
            if (ModelState.IsValid)
            {
                _context.Villas.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "The Villa has been updated successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error while updating the Villa";
            return View();
        }

        public IActionResult Delete(int villaId)
        {
            Villa? obj = _context.Villas.FirstOrDefault(v => v.VillaId == villaId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? villa = _context.Villas.FirstOrDefault(v => v.VillaId == obj.VillaId);

            if (villa is not null)
            {
                _context.Villas.Remove(obj);
                _context.SaveChanges();
                TempData["success"] = "The Villa has been deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error while deleting the Villa";
            return View();
        }
    }
}
