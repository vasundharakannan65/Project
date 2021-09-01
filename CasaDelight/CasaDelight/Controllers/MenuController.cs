using CasaDelight.DataAccess.Repository;
using CasaDelight.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDelight.Controllers
{
    public class MenuController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        public MenuController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        [Authorize]
        public IActionResult Index()
        {
            var MenuDishes = _unitofWork.Dishes.GetAll(); 

            return View();
        }
    }
}
