using HotelManagement.Data;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        //display menu
        public IActionResult Index()
        {
            IEnumerable<Dish> dishList = _db.Dishes;

            return View(dishList);
        }


        //adding to cart
        public IActionResult Cart(int? id,string UpdateQty)
        {
            List<Dish> orderedDishes = new List<Dish>();

            if (id == null)
            {
                return NotFound();
            }

            var dish = _db.Dishes.FirstOrDefault(x => x.DishId == id);

            if (dish == null)
            {
                return NotFound();
            }

            dish.DishQty = Convert.ToInt32(UpdateQty);

            orderedDishes.Add(dish);

            ViewBag.DishList = orderedDishes;

            TempData["mydata"] = orderedDishes;

            return View();
        }

        //[HttpPost]
        //public ActionResult UpdateQty(Dish dish, string UpdateQty)
        //{
        //    dish.DishQty = Convert.ToInt32(UpdateQty);

        //    return View();
        //}

        public IActionResult ContinueCart()
        {
            Dish data = TempData["mydata"] as Dish;

            return View(data);
        }

        //delete from cart
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
