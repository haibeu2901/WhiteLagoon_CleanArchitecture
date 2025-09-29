using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;
using WhiteLagoon.Web.ViewModels;

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
            var villaRooms = _context.VillaRooms.Include(r => r.Villa).ToList();
            return View(villaRooms);
        }

        public IActionResult Create()
        {
            VillaRoomVM villaRoomVM = new()
            {
                VillaList = _context.Villas.Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.VillaId.ToString()
                }).ToList()
            };
            return View(villaRoomVM);
        }

        [HttpPost]
        public IActionResult Create(VillaRoom obj)
        {
            if (ModelState.IsValid)
            {
                _context.VillaRooms.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "The Villa room has been created successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error while creating the Villa room";
            return View();
        }

        public IActionResult Update(int VillaNo)
        {
            VillaRoom? obj = _context.VillaRooms.FirstOrDefault(r => r.VillaNo == VillaNo);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(VillaRoom obj)
        {
            if (ModelState.IsValid)
            {
                _context.VillaRooms.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "The Villa room has been updated successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error while updating the Villa room";
            return View();
        }

        public IActionResult Delete(int villaNo)
        {
            VillaRoom? obj = _context.VillaRooms.FirstOrDefault(r => r.VillaNo == villaNo);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(VillaRoom obj)
        {
            VillaRoom? room = _context.VillaRooms.FirstOrDefault(r => r.VillaNo == obj.VillaNo);

            if (room is not null)
            {
                _context.VillaRooms.Remove(obj);
                _context.SaveChanges();
                TempData["success"] = "The Villa room has been deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error while deleting the Villa room";
            return View();
        }
    }
}
