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

        public Order order = new();


        public OrderController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
            order.CartList = new List<Dish>();
            
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

            order.CartList.Add(dish);

            return View(order.CartList);
        }
    }
}
