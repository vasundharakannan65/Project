using CasaDelight.DataAccess.Repository;
using CasaDelight.Models.Models;
using CasaDelight.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDelight.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public OrderController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }


        public IActionResult Index()
        {
            var model = new OrderViewModel
            {
                Dish = _unitofWork.Dishes.GetAll()
            };

            return View(model);
        }

        public IActionResult Cart(int id)
        {
            var dish = _unitofWork.Dishes.Get(id);

            if (dish == null)
            {
                return NotFound();
            }

            var DishList = new List<Dish>().ToList();

            DishList.Add(dish);

            return View(DishList);
        }
    }
}
