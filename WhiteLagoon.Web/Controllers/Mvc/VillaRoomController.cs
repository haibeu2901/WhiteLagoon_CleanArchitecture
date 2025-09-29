using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;
using WhiteLagoon.Web.ViewModels;

namespace WhiteLagoon.Web.Controllers.Mvc
{
    public class VillaRoomController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VillaRoomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var villaRooms = _unitOfWork.villaRoomRepo.GetAll(includeProperties: "Villa");
            return View(villaRooms);
        }

        public IActionResult Create()
        {
            VillaRoomVM villaRoomVM = new()
            {
                VillaList = _unitOfWork.villaRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.VillaId.ToString()
                }).ToList()
            };
            return View(villaRoomVM);
        }

        [HttpPost]
        public IActionResult Create(VillaRoomVM obj)
        {
            bool isNumberUnique = _unitOfWork.villaRoomRepo.Any(r => r.VillaNo == obj.VillaRoom!.VillaNo);
            if (isNumberUnique)
            {
                TempData["error"] = "The Villa room number already exists";
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.villaRoomRepo.Add(obj.VillaRoom!);
                _unitOfWork.Save();
                TempData["success"] = "The Villa room has been created successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error while creating the Villa room";
            obj.VillaList = _unitOfWork.villaRepo.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.VillaId.ToString()
            }).ToList();
            return View(obj);
        }

        public IActionResult Update(int villaNo)
        {
            VillaRoomVM villaRoomVM = new()
            {
                VillaList = _unitOfWork.villaRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.VillaId.ToString()
                }).ToList(),
                VillaRoom = _unitOfWork.villaRoomRepo.Get(r => r.VillaNo == villaNo)
            };
            if (villaRoomVM.VillaRoom is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaRoomVM);
        }

        [HttpPost]
        public IActionResult Update(VillaRoomVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.villaRoomRepo.Update(obj.VillaRoom!);
                _unitOfWork.Save();
                TempData["success"] = "The Villa room has been updated successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error while updating the Villa room";
            obj.VillaList = _unitOfWork.villaRepo.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.VillaId.ToString()
            }).ToList();
            return View(obj);
        }

        public IActionResult Delete(int villaNo)
        {
            VillaRoomVM villaRoomVM = new()
            {
                VillaList = _unitOfWork.villaRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.VillaId.ToString()
                }).ToList(),
                VillaRoom = _unitOfWork.villaRoomRepo.Get(r => r.VillaNo == villaNo)
            };
            if (villaRoomVM.VillaRoom is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaRoomVM);
        }

        [HttpPost]
        public IActionResult Delete(VillaRoomVM obj)
        {
            VillaRoom? room = _unitOfWork.villaRoomRepo.Get(r => r.VillaNo == obj.VillaRoom!.VillaNo);

            if (room is not null)
            {
                _unitOfWork.villaRoomRepo.Delete(obj.VillaRoom!);
                _unitOfWork.Save();
                TempData["success"] = "The Villa room has been deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error while deleting the Villa room";
            return View();
        }
    }
}
