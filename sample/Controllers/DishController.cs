using HotelManagement.Data;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    public class DishController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DishController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Index table
        public IActionResult Index(Dish dish)
        {
            IEnumerable<Dish> dishList = _db.Dishes;

            return View(dishList);
        }

        //Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Dish dish)
        {
            if (ModelState.IsValid)
            {
                _db.Dishes.Add(dish);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(dish);
        }

        //display detail
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = _db.Dishes.FirstOrDefault(x => x.DishId == id);

            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }


        //update
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = _db.Dishes.FirstOrDefault(x => x.DishId == id);

            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        [HttpPost]
        public IActionResult Update(Dish dish)
        {

            if (ModelState.IsValid && dish != null)
            {
                _db.Dishes.Update(dish);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dish);
        }


        //delete
        public IActionResult Delete(int? id)
        {
            var dish = _db.Dishes.FirstOrDefault(x => x.DishId == id);

            if (dish == null)
            {
                return NotFound();
            }

            _db.Dishes.Remove(dish);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
