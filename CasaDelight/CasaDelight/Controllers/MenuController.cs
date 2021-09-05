using CasaDelight.DataAccess.Repository;
using CasaDelight.Models.Models;
using CasaDelight.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDelight.Controllers
{
    public class MenuController : Controller
    {

        private readonly IWebHostEnvironment _hosting;
        private readonly IUnitofWork _unitofWork;

        public MenuController(IUnitofWork unitofWork, IWebHostEnvironment hosting)
        {
            _unitofWork = unitofWork;
            _hosting = hosting;
        }

        //main page of admin
        //Read
        [Authorize]
        public IActionResult Index()
        {
            var model = new MenuViewModel
            { 
                Dish = _unitofWork.Dishes.GetAll()
            };

            return View(model);
        }


        //Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CreateViewModel createdDish)
        {
            if (ModelState.IsValid)
            {
                string fileName = PhotoProcess(createdDish);

                Dish newDish = new()
                {   
                    DishImage = fileName,
                    DishName = createdDish.DishName,
                    DishDesc = createdDish.DishDesc,
                    DishPrice = createdDish.DishPrice
                };

                _unitofWork.Dishes.Add(newDish);
                _unitofWork.Save();
                return RedirectToAction("Index");
            }

            return View();
        }


        //details
        public IActionResult Details(int id)
        {
            var dish = _unitofWork.Dishes.Get(id);

            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        //update
        public IActionResult Update(int id)
        {
            var dish = _unitofWork.Dishes.Get(id);

            if (dish == null)
            {
                return NotFound();
            }

            UpdateViewModel updateViewModel = new()
            {
                DishName = dish.DishName,
                DishDesc = dish.DishDesc,
                DishPrice = dish.DishPrice,
                ExistingImage = dish.DishImage
            };
            return View(updateViewModel);
        }

        [HttpPost]
        public IActionResult Update(UpdateViewModel editedDish)
        {
            if (ModelState.IsValid)
            {
                Dish dish = _unitofWork.Dishes.Get(editedDish.Id);
                dish.DishName = editedDish.DishName;
                dish.DishDesc = editedDish.DishDesc;
                dish.DishPrice = editedDish.DishPrice;

                if(editedDish.DishImage != null)
                {
                    if(editedDish.ExistingImage != null)
                    {
                        string filePath = Path.Combine(_hosting.WebRootPath,
                            "images", editedDish.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }
                    dish.DishImage = PhotoProcess(editedDish);
                }

                _unitofWork.Dishes.Update(dish);
                _unitofWork.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        //display and saving img
        private string PhotoProcess(CreateViewModel editedDish)
        {
            string fileName = null;
            if (editedDish.DishImage != null)
            {
                string uploadPhoto = Path.Combine(_hosting.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "_" + editedDish.DishImage.FileName;
                string filePath = Path.Combine(uploadPhoto, fileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                editedDish.DishImage.CopyTo(fileStream);
            }

            return fileName;
        }

        //delete
        public IActionResult Delete(int id)
        {
            var dish = _unitofWork.Dishes.Get(id);

            if (dish == null)
            {
                return NotFound();
            }
            _unitofWork.Dishes.Remove(dish);
            _unitofWork.Save();

            return RedirectToAction("Index");
        }
    }
}
