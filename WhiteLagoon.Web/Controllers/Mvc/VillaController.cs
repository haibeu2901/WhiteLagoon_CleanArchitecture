using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers.Mvc
{
    public class VillaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VillaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var villas = _unitOfWork.villaRepo.GetAll();
            return View(villas);
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
                _unitOfWork.villaRepo.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "The Villa has been created successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error while creating the Villa";
            return View();
        }

        public IActionResult Update(int villaId)
        {
            Villa? obj = _unitOfWork.villaRepo.Get(v => v.VillaId == villaId);
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
                _unitOfWork.villaRepo.Update(obj);
               _unitOfWork.Save();
                TempData["success"] = "The Villa has been updated successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error while updating the Villa";
            return View();
        }

        public IActionResult Delete(int villaId)
        {
            Villa? obj = _unitOfWork.villaRepo.Get(v => v.VillaId == villaId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? villa = _unitOfWork.villaRepo.Get(v => v.VillaId == obj.VillaId);

            if (villa is not null)
            {
                _unitOfWork.villaRepo.Delete(obj);
                _unitOfWork.Save();
                TempData["success"] = "The Villa has been deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error while deleting the Villa";
            return View();
        }
    }
}
