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

        IList<Dish> _cartList = new List<Dish>();


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

            _cartList.Add(dish);

            //ViewBag.Cart.Concat(dish);
            //ViewBag.students = students.Concat(weekend);

            ViewBag.Cart = _cartList;

            return View();
        }

        //placeorder
        public IActionResult PlaceOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            Order newOrder = new Order
            {
                PhoneNumber = order.PhoneNumber
            };

            _unitofWork.Orders.Add(newOrder);
            _unitofWork.Save();

            return View();
        }


    }
}
